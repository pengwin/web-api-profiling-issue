import http from 'k6/http';
import { Counter } from 'k6/metrics';

const commonOptions = {
  vus: 4,
  duration: '10s',
};

export const options = {
  scenarios: {
    'innerApi': {
      executor: 'constant-vus',
      exec: 'innerApi',
      vus: commonOptions.vus,
      duration: commonOptions.duration,
    },
    'outerApi': {
      executor: 'constant-vus',
      exec: 'outerApi',
      vus: commonOptions.vus,
      duration: commonOptions.duration,
    },
    'outerSelfApi': {
      executor: 'constant-vus',
      exec: 'outerSelfApi',
      vus: commonOptions.vus,
      duration: commonOptions.duration,
    },
  }
};

const innerApiCounter = new Counter('Counter InnerApi');
const outerApiCounter = new Counter('Counter OuterApi');
const outerApiSelfCounter = new Counter('Counter OuterApiSelf');

export function innerApi() {
  http.get('http://localhost:5001/data', { tags: { name: 'inner-api/data'} });
  innerApiCounter.add(1);
}

export function outerApi() {
  http.get('http://localhost:5002/data', { tags: { name: 'outer-api/data'} });
  outerApiCounter.add(1);
}

export function outerSelfApi() {
  http.get('http://localhost:5002/data-self', { tags: { name: 'outer-api/data-self'} });
  outerApiSelfCounter.add(1);
}

export function handleSummary(data) {
  const innerMetrics = data.metrics['Counter InnerApi'].values;
  const outerMetrics = data.metrics['Counter OuterApi'].values;
  const outerSelfMetrics = data.metrics['Counter OuterApiSelf'].values;

  let result = '\n';
  result += '| Metrics | Count | Rate |\n';
  result += '| ------- | ----- | ---- |\n';
  result += `| Counter InnerApi | ${innerMetrics.count} | ${innerMetrics.rate}/s |\n`;
  result += `| Counter OuterApi | ${outerMetrics.count} | ${outerMetrics.rate}/s |\n`;
  result += `| Counter OuterApiSelf | ${outerSelfMetrics.count} | ${outerSelfMetrics.rate}/s |\n`;

  return {
    stdout: result
  };
}
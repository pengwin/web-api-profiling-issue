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
    'outerProxyApi': {
      executor: 'constant-vus',
      exec: 'outerProxyApi',
      vus: commonOptions.vus,
      duration: commonOptions.duration,
    },
  }
};

const innerApiCounter = new Counter('Counter InnerApi');
const outerApiCounter = new Counter('Counter OuterApi');
const outerApiProxyCounter = new Counter('Counter OuterApiProxy');

export function innerApi() {
  http.get('http://localhost:5001/data', { tags: { name: 'inner-api/data'} });
  innerApiCounter.add(1);
}

export function outerApi() {
  http.get('http://localhost:5002/data', { tags: { name: 'outer-api/data'} });
  outerApiCounter.add(1);
}


export function outerProxyApi() {
  http.get('http://localhost:5002/data-proxy', { tags: { name: 'outer-api/data-proxy'} });
  outerApiProxyCounter.add(1);
}

export function handleSummary(data) {
  const innerMetrics = data.metrics['Counter InnerApi'].values;
  const outerMetrics = data.metrics['Counter OuterApi'].values;
  const outerProxyMetrics = data.metrics['Counter OuterApiProxy'].values;

  const innerRatio = (100*innerMetrics.count/innerMetrics.count).toFixed(2);
  const outerRatio = (100*outerMetrics.count/innerMetrics.count).toFixed(2);
  const outerProxyRatio = (100*outerProxyMetrics.count/innerMetrics.count).toFixed(2);

  let result = '\n';
  result += '| Metrics | Count | Rate | Ratio |\n';
  result += '| ------- | ----- | ---- | ----- |\n';
  result += `| Counter InnerApi | ${innerMetrics.count} | ${innerMetrics.rate}/s | ${innerRatio}% |\n`;
  result += `| Counter OuterApi | ${outerMetrics.count} | ${outerMetrics.rate}/s | ${outerRatio}% | \n`;
  result += `| Counter OuterApiProxy | ${outerProxyMetrics.count} | ${outerProxyMetrics.rate}/s | ${outerProxyRatio}% |\n`;

  return {
    stdout: result
  };
}
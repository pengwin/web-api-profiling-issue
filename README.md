## Dependencies

Install k6

```
choco install k6
```

## K6 Tests

### Inner Api Test

```
dotnet run -c Release -p InnerApi
```

```
execution: local
     script: get-data-inner.js
     output: -

  scenarios: (100.00%) 1 scenario, 10 max VUs, 40s max duration (incl. graceful stop):
           * default: 10 looping VUs for 10s (gracefulStop: 30s)


     data_received..................: 9.3 GB 924 MB/s
     data_sent......................: 298 kB 30 kB/s
     http_req_blocked...............: avg=11.53µs min=0s      med=0s      max=2.13ms   p(90)=0s      p(95)=0s
     http_req_connecting............: avg=1.42µs  min=0s      med=0s      max=505.6µs  p(90)=0s      p(95)=0s
     http_req_duration..............: avg=28.1ms  min=22.39ms med=25.69ms max=216.4ms  p(90)=31.45ms p(95)=37.92ms
       { expected_response:true }...: avg=28.1ms  min=22.39ms med=25.69ms max=216.4ms  p(90)=31.45ms p(95)=37.92ms
     http_req_failed................: 0.00%  ✓ 0          ✗ 3543
     http_req_receiving.............: avg=25.02ms min=2ms     med=24.28ms max=110.18ms p(90)=29.24ms p(95)=35.04ms
     http_req_sending...............: avg=86.95µs min=0s      med=0s      max=18.58ms  p(90)=0s      p(95)=0s
     http_req_tls_handshaking.......: avg=0s      min=0s      med=0s      max=0s       p(90)=0s      p(95)=0s
     http_req_waiting...............: avg=2.99ms  min=0s      med=1ms     max=107.21ms p(90)=7.51ms  p(95)=14.01ms
     http_reqs......................: 3543   353.836923/s
     iteration_duration.............: avg=28.22ms min=22.39ms med=25.79ms max=218.53ms p(90)=31.53ms p(95)=38.28ms
     iterations.....................: 3543   353.836923/s
     vus............................: 10     min=10       max=10
     vus_max........................: 10     min=10       max=10
```

### Outer Api Test

```
dotnet run -c Release -p OuterApi
```

```
execution: local
     script: get-data-outer.js
     output: -

  scenarios: (100.00%) 1 scenario, 10 max VUs, 40s max duration (incl. graceful stop):
           * default: 10 looping VUs for 10s (gracefulStop: 30s)


     data_received..................: 1.6 GB 162 MB/s
     data_sent......................: 53 kB  5.2 kB/s
     http_req_blocked...............: avg=29.68µs  min=0s      med=0s       max=1.71ms   p(90)=0s       p(95)=0s
     http_req_connecting............: avg=0s       min=0s      med=0s       max=0s       p(90)=0s       p(95)=0s
     http_req_duration..............: avg=160.06ms min=110.3ms med=149.72ms max=471.18ms p(90)=196.25ms p(95)=210.04ms
       { expected_response:true }...: avg=160.06ms min=110.3ms med=149.72ms max=471.18ms p(90)=196.25ms p(95)=210.04ms
     http_req_failed................: 0.00%  ✓ 0         ✗ 627
     http_req_receiving.............: avg=38.37ms  min=5.16ms  med=32.81ms  max=128.48ms p(90)=58.48ms  p(95)=77.1ms
     http_req_sending...............: avg=196.69µs min=0s      med=0s       max=18.16ms  p(90)=0s       p(95)=452.31µs
     http_req_tls_handshaking.......: avg=0s       min=0s      med=0s       max=0s       p(90)=0s       p(95)=0s
     http_req_waiting...............: avg=121.49ms min=81.28ms med=113.04ms max=342.76ms p(90)=153.47ms p(95)=168.47ms
     http_reqs......................: 627    62.051109/s
     iteration_duration.............: avg=160.31ms min=110.3ms med=149.8ms  max=472.9ms  p(90)=196.88ms p(95)=210.47ms
     iterations.....................: 627    62.051109/s
     vus............................: 10     min=10      max=10
     vus_max........................: 10     min=10      max=10
```
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


     data_received..................: 9.1 GB 912 MB/s
     data_sent......................: 294 kB 29 kB/s
     http_req_blocked...............: avg=12.09µs min=0s      med=0s      max=2.45ms   p(90)=0s      p(95)=0s
     http_req_connecting............: avg=2.88µs  min=0s      med=0s      max=1ms      p(90)=0s      p(95)=0s
     http_req_duration..............: avg=28.51ms min=22.33ms med=26.26ms max=170.77ms p(90)=32.27ms p(95)=36.45ms
       { expected_response:true }...: avg=28.51ms min=22.33ms med=26.26ms max=170.77ms p(90)=32.27ms p(95)=36.45ms
     http_req_failed................: 0.00%  ✓ 0          ✗ 3497
     http_req_receiving.............: avg=25.57ms min=2.68ms  med=24.75ms max=111.27ms p(90)=30.01ms p(95)=34ms
     http_req_sending...............: avg=82.96µs min=0s      med=0s      max=29.51ms  p(90)=0s      p(95)=0s
     http_req_tls_handshaking.......: avg=0s      min=0s      med=0s      max=0s       p(90)=0s      p(95)=0s
     http_req_waiting...............: avg=2.84ms  min=0s      med=1ms     max=60.57ms  p(90)=7.01ms  p(95)=13.52ms
     http_reqs......................: 3497   349.078396/s
     iteration_duration.............: avg=28.62ms min=22.77ms med=26.34ms max=173.22ms p(90)=32.4ms  p(95)=36.99ms
     iterations.....................: 3497   349.078396/s
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


     data_received..................: 1.9 GB 188 MB/s
     data_sent......................: 61 kB  6.1 kB/s
     http_req_blocked...............: avg=42.85µs  min=0s      med=0s       max=2.62ms   p(90)=0s       p(95)=0s
     http_req_connecting............: avg=0s       min=0s      med=0s       max=0s       p(90)=0s       p(95)=0s
     http_req_duration..............: avg=138.04ms min=87.84ms med=126.37ms max=428.52ms p(90)=164.23ms p(95)=180.8ms
       { expected_response:true }...: avg=138.04ms min=87.84ms med=126.37ms max=428.52ms p(90)=164.23ms p(95)=180.8ms
     http_req_failed................: 0.00%  ✓ 0         ✗ 727
     http_req_receiving.............: avg=31.95ms  min=4.4ms   med=28.68ms  max=114.28ms p(90)=43.42ms  p(95)=55.36ms
     http_req_sending...............: avg=229.81µs min=0s      med=0s       max=17.74ms  p(90)=0s       p(95)=507.07µs
     http_req_tls_handshaking.......: avg=0s       min=0s      med=0s       max=0s       p(90)=0s       p(95)=0s
     http_req_waiting...............: avg=105.86ms min=74.37ms med=96.84ms  max=314.93ms p(90)=126.7ms  p(95)=143.09ms
     http_reqs......................: 727    72.041762/s
     iteration_duration.............: avg=138.26ms min=87.84ms med=126.43ms max=431.15ms p(90)=164.75ms p(95)=181.06ms
     iterations.....................: 727    72.041762/s
     vus............................: 10     min=10      max=10
     vus_max........................: 10     min=10      max=10
```
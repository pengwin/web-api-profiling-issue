## Dependencies

Install k6

```
choco install k6
```

## K6 Tests


```
dotnet run -c Release -p InnerApi
```


```
dotnet run -c Release -p OuterApi
```

| Metrics | Count | Rate | Ratio |
| ------- | ----- | ---- | ----- |
| Counter InnerApi | 919 | 90.96765701871351/s | 100.00% |
| Counter OuterApi | 257 | 25.43926861132685/s | 27.97% |
| Counter OuterApiProxy | 756 | 74.83302361931166/s | 82.26% |
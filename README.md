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
| Counter InnerApi | 763 | 75.76454694444314/s | 100.00% |
| Counter OuterApi | 306 | 30.385257359108255/s | 40.10% |
| Counter OuterApiProxy | 725 | 71.99121433122055/s | 95.02% |
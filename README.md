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
| Counter InnerApi | 918 | 91.46195569712387/s | 100.00% |
| Counter OuterApi | 311 | 30.985477365801223/s | 33.88% |
| Counter OuterApiProxy | 813 | 81.00062089516526/s | 88.56% |
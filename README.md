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

| Metrics | Count | Rate |
| ------- | ----- | ---- |
| Counter InnerApi | 913 | 90.26631350556475/s |
| Counter OuterApi | 264 | 26.10110270040427/s |
| Counter OuterApiSelf | 890 | 87.9923538006053/s |
### Build and test (in labs/XX-...)
```
dotnet restore
dotnet build 
dotnet run --project ./src/DSA.LabXX.App
dotnet test
```

## Run specific test
`dotnet test --filter Name~TestMethod1`
## Initialization

```bash
dotnet tool install dotnet-ef --global
dotnet ef migrations add InitialCreate
dotnet ef database update
```
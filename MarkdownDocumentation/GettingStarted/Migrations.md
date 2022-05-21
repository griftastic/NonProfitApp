# Migrations

Now that your connection string is set up. You are ready to start migrating the entities into your SQL server.

1. Open a new terminal.
2. To initialize the migration, type in:

```
dotnet ef migrations add AddAllTables -p NonProfitApp.Data -s NonProfitApp.WebAPI
```

3. After this, you need to update your migration. Type in: 

```
dotnet ef database update -p NonProfit.Data -s NonProfitApp.WebAPI
```

Your SQL Database should now have all of the entities present.

---
[Back](./ConnectionString.md) | [Next](./PostmanIntegration.md)

[Back to home](../../README.md)

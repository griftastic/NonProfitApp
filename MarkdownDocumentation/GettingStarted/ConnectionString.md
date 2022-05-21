# Connection String

This app requires the use of a local SQL Server. You should have a localhost server set up all ready.

For your convenience, we have provided a filled out connection string within ./NonProfitApp.WebAPI/Program.cs

1. Navigate to ./NonProfitApp.WebAPI.Program.cs
2. Locate the connection string on line 19.

It should look like this:
```
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=localhost;Database=NonProfitApp;User=sa;Password=PASSWORD"));

```
3. Replace 'PASSWORD' with your personal SQL password.

At this point, the connection string is all ready to go for your app.

---
[Back](./Cloning.md) | [Next](./Migrations.md)

[Back to home](../../README.md)

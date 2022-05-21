# Migrations

Now that your connection string is set up. You are ready to start migrating the entities into your SQL server.

1. Open a new terminal.
2. Type in:

```

```

2. Locate the connection string on line 19.

It should look like this:
```
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=localhost;Database=NonProfitApp;User=sa;Password=PASSWORD"));

```
3. Replace 'PASSWORD' with your personal SQL password.

At this point, the connection string is all ready to go for your app.

---
[Next](./PostmanIntegration.md)

[Back to home](../../README.md)

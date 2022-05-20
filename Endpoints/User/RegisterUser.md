# RegisterUser

This endpoint creates a user entity and provides it with a unique userId integer.

We've implemented the use of a password hasher so that the user's password can remain hidden.


## Use the following link with a POST endpoint to create a user:
### https://localhost:5001/api/User/Register

Here are the body parameters required to create a user (in json format):

```
{
  "email": "user@example.com",
  "password": "string",
  "confirmPassword": "string",
  "nonProfitUser": true
}
```

[Back to home](../../README.md)

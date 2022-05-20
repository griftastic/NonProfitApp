# GetToken

This endpoint creates a secret token that will provide authorization for your app to allow you to access all of the other endpoints.

Each token lasts 14 days, so it will need to be redone on a biweekly basis.

The email and password should match one of the users that you have created for it to work.


## Use the following link with a POST endpoint to create a token:
### https://localhost:5001/api/Token

Here are the body parameters required to create a token (in json format):

```
{
  "email": "string",
  "password": "string"
}
```

[Back to home](../../README.md)

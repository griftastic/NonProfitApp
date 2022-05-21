# CreateNPEntity

This endpoint creates a NonProfit and attaches it to the userId that is logged in currently.

It will create the NonProfit and provide the NonProfit itself with its own unique nPEntityId integer.


## Use the following link with a POST endpoint to create a NonProfit:
### https://localhost:5001/api/NPEntity

Here are the body parameters required to post an nPEntity (in json format):

```
{
  "title": "string",
  "content": "string"
}
```

---
[Back to home](../../../README.md)

# CreateVolunteer

This endpoint creates a Volunteer and attaches it to the userId that is logged in currently.

It will create the Volunteer and provide the Volunteer itself with its own unique volunteerId integer.


## Use the following link with a POST endpoint to create a Volunteer:
### https://localhost:5001/api/Volunteer

Here are the body parameters required to post a Volunteer (in json format):

```
{
  "firstName": "string",
  "lastName": "string",
  "email": "string"
}
```

---
[Back to home](../../../README.md)

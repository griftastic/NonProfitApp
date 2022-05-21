# CreateEvent

This endpoint creates an event and attaches it to the userId that is logged in currently.

It will create the event and provide the event itself with its own unique eventId integer.


## Use the following link with a POST endpoint to create an event:
### https://localhost:5001/api/Event

Here are the body parameters required to post an event (in json format):

```
{
  "nonProfitName": "string",
  "eventName": "string",
  "eventDescription": "stringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstringstri",
  "eventDate": "2022-05-19T23:33:13.368Z",
  "eventAddress": "string"
}
```

---
[Back to home](../../../README.md)

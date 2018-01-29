# CHURRAS APP

## SERVER

Project structure

Churras.Server  
├── Churras.Api  
├── Churras.Domain  
├── Churras.Repository  
└── Churras.Test   

ASP.NET Core 2.0 API made with:

- EntityFramework 6
- SQLite / InMemory databases
- FluentValidation
- Swashbuckle
- XUnit

### Error messages

```json
{
  "message": "string",
  "developerMessage": "string",
  "errors": [
    {
      "type": 0,
      "field": "string",
      "message": "string"
    }
  ]
}
```

### X-Pagination Header

```json
{
  "totalCount": 20,
  "pageSize": 10,
  "currentPage": 2,
  "totalPages": 2,
  "previousPageLink": "http://localhost:5000/api/barbecues?page=1",
  "nextPageLink": null
}
```

### Swagger doc example

![Imgur](https://i.imgur.com/iO2Zm1V.png)

### DEMO

https://churrasapi.azurewebsites.net/swagger

## CLIENT

> TODO
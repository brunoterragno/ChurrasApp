# CHURRAS APP

## SERVER

Project structure

Churras.Server  
|-- Churras.Api  
|-- Churras.Domain  
|-- Churras.Repository  
`-- Churras.Test 

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
> Churras Web Project

## Build Setup

``` bash
# install dependencies
npm install

# serve with hot reload at localhost:8080
npm run dev

# build for production with minification
npm run build

# build for production and view the bundle analyzer report
npm run build --report

# run unit tests
npm run unit

# run e2e tests
npm run e2e

# run all tests
npm test
```

For a detailed explanation on how things work, check out the [guide](http://vuejs-templates.github.io/webpack/) and [docs for vue-loader](http://vuejs.github.io/vue-loader).

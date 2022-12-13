# API SPECIFICATION

## Customer API

### Create New Customer

- Method : `POST`
- Endpoint : `/api/customers`
- Header :
    - Content-Type : `application/json`
    - Accept : `application/json`
- Body :

```json
{
  "name": "string",
  "mobilePhone": "string"
}
```

- Response :

```json
{
  "id": "88444e23-8f2a-43cc-97f7-00b74148da4d",
  "name": "Rifqi Ramadhan",
  "mobilePhone": "08123"
}
```

### Get Customer By Id

- Method : `GET`
- Endpoint : `/api/customers/{id}`
- Header :
    - Accept : `application/json`
- Response :

```json
{
  "id": "88444e23-8f2a-43cc-97f7-00b74148da4d",
  "name": "Rifqi Ramadhan",
  "mobilePhone": "08123"
}
```

### Get All Customer

- Method : `GET`
- Endpoint : `/api/customers`
- Header :
    - Accept : `application/json`
- Response :

```json
[
  {
    "id": "88444e23-8f2a-43cc-97f7-00b74148da4d",
    "name": "Rifqi Ramadhan",
    "mobilePhone": "08123"
  }
]
```

### Update Customer

- Method : `PUT`
- Endpoint : `/api/customers`
- Header :
    - Content-Type : `application/json`
    - Accept : `application/json`
- Body :

```json
{
  "id": "88444e23-8f2a-43cc-97f7-00b74148da4d",
  "name": "string",
  "mobilePhone": "string"
}
```

- Response :

```json
{
  "id": "88444e23-8f2a-43cc-97f7-00b74148da4d",
  "name": "Rifqi Ramadhan",
  "mobilePhone": "08123"
}
```

### Delete Customer

- Method : `DELETE`
- Endpoint : `/api/customers/{id}`
- Header :
    - Content-Type : `application/json`
    - Accept : `application/json`

## Product API

### Create New Product

- Method : `POST`
- Endpoint : `/api/products`
- Header :
    - Content-Type : `application/json`
    - Accept : `application/json`
- Body :

```json
{
  "name": "string",
  "duration": 0,
  "price": 0
}
```

- Response :

```json
{
  "id": "257391d7-6c92-48d8-9c81-0752dc5edf88",
  "name": "Cuci + Setrika - Express",
  "duration": 1,
  "productPrice": {
    "id": "dde91e48-39ce-4cb0-986e-358c5e0d7a2a",
    "price": 12000,
    "isActive": true,
    "productId": "257391d7-6c92-48d8-9c81-0752dc5edf88"
  }
}
```

### Get Product By Id

- Method : `GET`
- Endpoint : `/api/products/{id}`
- Header :
    - Accept : `application/json`
- Response :

```json
{
  "id": "257391d7-6c92-48d8-9c81-0752dc5edf88",
  "name": "Cuci + Setrika - Express",
  "duration": 1,
  "productPrice": {
    "id": "dde91e48-39ce-4cb0-986e-358c5e0d7a2a",
    "price": 12000,
    "isActive": true,
    "productId": "257391d7-6c92-48d8-9c81-0752dc5edf88"
  }
}
```

### Get All Product

```json
[
  {
    "id": "257391d7-6c92-48d8-9c81-0752dc5edf88",
    "name": "Cuci + Setrika - Express",
    "duration": 1,
    "productPrice": [
      {
        "id": "dde91e48-39ce-4cb0-986e-358c5e0d7a2a",
        "price": 12000,
        "isActive": true,
        "productId": "257391d7-6c92-48d8-9c81-0752dc5edf88"
      }
    ]
  },
  {
    "id": "34a21f43-1932-437a-be79-d91d7f31224a",
    "name": "Cuci + Setrika",
    "duration": 3,
    "productPrice": [
      {
        "id": "cdd3dd0b-fd73-4469-ad62-614dfd51172d",
        "price": 8000,
        "isActive": true,
        "productId": "34a21f43-1932-437a-be79-d91d7f31224a"
      }
    ]
  }
]
```

### Update Product

- Method : `PUT`
- Endpoint : `/api/products`
- Header :
    - Content-Type : `application/json`
    - Accept : `application/json`
- Body :

`Update Create New Price`

```json
{
  "id": "257391d7-6c92-48d8-9c81-0752dc5edf88",
  "name": "Cuci + Setrika - Express",
  "duration": 1,
  "productPrice": {
    "price": 14000
  }
}
```

`OR`

```json
{
  "id": "257391d7-6c92-48d8-9c81-0752dc5edf88",
  "name": "Cuci + Setrika - Kilat",
  "duration": 1
}
```

- Response :

```json
{
  "id": "257391d7-6c92-48d8-9c81-0752dc5edf88",
  "name": "Cuci + Setrika - Express",
  "duration": 1,
  "productPrice": {
    "id": "6bc8ef25-d909-4517-9425-1c11a244109d",
    "price": 14000,
    "isActive": true,
    "productId": "257391d7-6c92-48d8-9c81-0752dc5edf88"
  }
}
```

### Delete Product

- Method : `DELETE`
- Endpoint : `/api/products/{id}`
- Header :
    - Content-Type : `application/json`
    - Accept : `application/json`
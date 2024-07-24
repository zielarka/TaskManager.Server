
**ERP.GranFol.Server
---

#### AUTH MODULE ####

### POST /api/Auth/register

Request body:
```
{
  "firstname": "Jan",
  "surname": "Kowalski",
  "password": "secret123!",
  "role": "user"
}
```

### POST /api/Auth/login
Example: Login – POST /api/Auth/login

Request body:
```
{
  "firstname": "Jan",
  "surname": "Kowalski",
  "password": "secret123!"
}
```

#### USER MODULE ####

### GET /api/User/ 
[Authorize]
Example: Get All Users – GET /api/User/

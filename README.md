
**Task.Manager
---

## Getting Started

To get a local copy up and running, follow these steps.

### Prerequisites

Make sure you have [Node.js](https://nodejs.org/en/) and [npm](https://www.npmjs.com/) installed.

### Installation **Task.Manager.Server

1. Please open the file ```TaskManager.Server.sln``` 

2. Build solution 

3. Start project ```TaskManager.Api``` 

4. It will redirect us to swagger :)

### Installation **Task.Manager.Web

1. Clone the repository:

   ```bash
   git clone https://github.com/zielarka/TaskManager.Server.git
   cd src/TaskManager.WebApp

2. Clone the repository:
    ```bash
   npm install

3. Create a .env.local file in the root directory and add environment variables:
    ```bash
    NEXT_PUBLIC_API=https://localhost:44387/api
 
4. To display the data, create a new profile in the ```.vscode/launch file``` and add:
```bash
{
    "version": "0.2.0",
    "configurations": [
        {
            "type": "pwa-chrome",
            "request": "launch",
            "name": "Chrome",
            "url": "http://localhost:3000",
            "webRoot": "${workspaceFolder}",
            "runtimeArgs": ["--disable-web-security"]
        }
    ]
}
4. Running the Application To start the development server, run:
    ```bash
    npm run dev


## Task MODULE 

### POST /api/ToDoTask/GetTask

Request body:
```
{
  "taskId": "C5F01E88-8DE0-4309-AC3E-41CFAF7F628A"
}
```

### POST /api/ToDoTask/GetTasks

Request body:
```
{}
```
### POST /api/ToDoTask
Create a Task

Request body:
```
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "title": "string",
  "description": "string",
  "startDate": "2024-07-24T03:05:30.209Z",
  "dueDate": "2024-07-24T03:05:30.209Z",
  "status": 0
}
```
Update Task

### PUT /api/ToDoTask
Update a Task

Request body:
```
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "title": "string",
  "description": "string",
  "status": 0,
  "dueDate": "2024-07-24T03:05:39.574Z"
}
```

DELETE Task

### DELETE /api/ToDoTask
DELETE a Task

Request body:
```
{
  "taskId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

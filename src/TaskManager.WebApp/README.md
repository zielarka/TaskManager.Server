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
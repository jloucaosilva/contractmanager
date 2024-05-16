# Welcome to Legal contract manager

This is a sample application with a simple concept of legal contracts, it uses a .net Core server side and Vue3 TS SPA as a Front-End application.

As a sample application, it uses an in-memory database, and even though its limitations are quite known for this simple purpose it is more than enough.

It also has swagger capabilities accessible on the following endpoint "[Swagger UI](http://localhost:5020/swagger/index.html)".

# Required tools
 - .net core 8
 - node v20.13.1
 - npm 10.7.0

# Usage
 - If you don't have the tools mentioned above installed please install them first 
 - Clone the code present in this repository
 - Open a command prompt
 - Navigate to where you cloned the repo and then into the "contractmanager\ContractManager.Server\" folder
 - run the command "dotnet run .\ContractManager.Server.csproj" this will start both the back-end and front-end applications
 - Open your browser and access the URI mentioned on the command prompts
	 - this link will take you to swagger [Swagger UI](http://localhost:5020/swagger/index.html)
	 - this one will take you to the  application [Front-end Vue3 TS](https://localhost:5173/)
 - As there is no data present on the in-memory database you'll have to create some to start
	 - you can use the swagger interface
	 - you can use the SPA application

## Build status

[![.NET Automatic build](https://github.com/jloucaosilva/contractmanager/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jloucaosilva/ditate/actions/workflows/dotnet.yml)

[![Manual build](https://github.com/jloucaosilva/contractmanager/actions/workflows/manual.yml/badge.svg)](https://github.com/jloucaosilva/ditate/actions/workflows/manual.yml)

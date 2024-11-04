# Video Game Catalog

A full-stack web application for managing a video game catalog, built with ASP.NET Core Web API and Angular.

## Description

This project is a two-page catalog application that allows users to browse and manage video game entries. Users can view all games in the catalog, add new games, and edit existing ones.

## Tech Stack

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Code First approach for database management

### Frontend
- Angular 17
- TypeScript
- Bootstrap 5
- Angular Reactive Forms
- Angular Router

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (v18 or higher)
- [Angular CLI](https://angular.io/cli)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express edition is sufficient)

## Installation & Setup

1. Clone the repository
```bash
  git clone https://github.com/Berkayayaz/VideoGameCatalog.git
```
2. Backend Setup
   
  #### Important Database Configuration
  The application currently works with a localhost database server. To configure your database connection:

  - Navigate to VideoGameCatalog.Server/appsettings.json
  - Locate the ConnectionStrings section
  - Modify the VideoGameCatalogContext value according to your database setup:
  ```bash
  {
    "ConnectionStrings": {
      "VideoGameCatalogContext": "Server=(localdb)\\mssqllocaldb;Database=VideoGameCatalog;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
  }
```
 ```bash
# Navigate to the backend project directory
cd VideoGamesCatalog/VideoGameCatalog.Server

#Restore dependencies
dotnet restore

# Run the API
dotnet run
``` 
3. Frontend Setup
```bash
  #Navigate to the frontend project directory
  cd VideoGamesCatalog/Client

  # Install dependencies
  npm install

  # Start the Angular development server
  ng serve
```
4. The application should now be running at:
- Frontend: http://localhost:4200
- Backend API: http://localhost:5129

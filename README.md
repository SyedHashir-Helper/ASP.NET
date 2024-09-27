# README: Configuring an ASP.NET Core with Entity Framework Project

## Overview
This document provides step-by-step instructions for setting up an existing ASP.NET Core project that utilizes Entity Framework Core for data access.

## Prerequisites

Before you begin, ensure you have the following installed on your development machine:

- [.NET SDK](https://dotnet.microsoft.com/download) (version compatible with the project)
- [Visual Studio](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload) or [Visual Studio Code](https://code.visualstudio.com/) (with C# extension)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other supported database server (e.g., SQLite, PostgreSQL)

## Step-by-Step Instructions

### 1. Clone the Repository

First, clone the repository containing the ASP.NET Core project:

```bash
git clone <repository-url>
cd <repository-folder>
```
### 2. Restore NuGet Packages

Using Visual Studio:
- Open the solution in Visual Studio.
- Right-click on the solution in Solution Explorer and select Restore NuGet Packages.


### 3. Configure Connection String
Locate the appsettings.json file in the project root and configure your database connection string.

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
  }
}
```

- Replace your_server, your_database, your_user, and your_password with your actual database server details.

### 5. Apply Migrations
If the project includes existing migrations, apply them to set up the database schema:

Using Visual Studio:
- Open the Package Manager Console.
- Run the following command:
```bash
Update-Database
```

### 6. Run the Application
Now you can run the application to ensure everything is working correctly.

Using Visual Studio:
- Press F5 or click the Start button to run the application.

### 7. Access the Application
Once the application is running, open a web browser and navigate to http://localhost:7210 (or the specified port in the console output) to access your application.

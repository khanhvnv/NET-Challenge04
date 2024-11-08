# Starter app for Create a web UI with ASP.NET Core

Welcome! This is the homework for the Challenge 04:
- Integrate with HttpClientFactory for .Net MVC Project
- Use HttpClient to call category endpoint of .Net Core Minimal API to get all categories data
- Replace the hardcoded category data with data retrieved from API
- Run 2 projects and verify the results

## Completed version


## Contributing

This project welcomes contributions and suggestions.  

## Step-by-step guide to run the web app

Prerequisites
Ensure you have:
- Visual Studio Code installed
- NET SDK 8 (compatible with .NET MVC)

Step 1: Set Up Your Development Environment
1. Install .NET SDK: Ensure you have the latest .NET SDK installed. You can download it from the .NET download page.
2. Install an IDE: Use Visual Studio, Visual Studio Code, or any other preferred IDE.

Step 2: Set Up the Project for Entity Framework Core
1. Install Required NuGet Packages
You need to install the following NuGet packages for Entity Framework Core:
-	Microsoft.EntityFrameworkCore.SqlServer (for SQL Server database provider)
-	Microsoft.EntityFrameworkCore.Tools (for EF Core tools)
-	Microsoft.EntityFrameworkCore.Design (for design-time support)

Open your terminal and run the following commands in your project folder:
-	dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2
-	dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.2
-	dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.2
These packages will allow us to interact with SQL Server and run migrations for creating the database schema.

Run the following command to install the Swagger package to use Swagger:
	dotnet add package Swashbuckle.AspNetCore
	This will add the Swashbuckle.AspNetCore package to your project, which includes the AddSwaggerGen method.

Step 3: Configure the Database Connection
You need to update your connection string for your SQL Server instance (replace the Server name and Database name) in the appsettings.json file.
Make sure that your SQL Server instance is running and you have a database named 'master' (or you can change the name in the connection string).

Step 4: Create and Apply Migrations
Entity Framework uses migrations to generate and update the database schema based on the models.
1. Add Initial Migration
Run the following commands in your terminal to create the first migration, which will generate the necessary SQL to create the Categories table in the database.
	dotnet ef migrations add InitialCreate
This command will generate migration files in the Migrations folder. It will also include the SQL code needed to create the Categories table.
2. Apply the Migration to the Database
Next, apply the migration to create the Categories table in the SQL Server database.	
	dotnet ef database update
This will create the CategoryDb database (if it doesn’t already exist) and the Categories table.

Step 5: Trust the Development Certificate
In a terminal, run the following command to trust the .NET development certificate:
	dotnet dev-certs https --trust
Restart both projects after running this command.
	
Step 6: Run Both Projects and Verify the Results
	
 	1. Run the Minimal API (CategoryApi) in one terminal:
		○ Open the terminal in CategoryApi project folder and run: dotnet run
		○ Ensure that it’s running on https://localhost:5001 (replace 5000 by the port CategoryApi is listening on)
		
	2.Update the BaseAddress in CategoryProject>Services>CategoryService.cs 
		○ Find the BaseAddress
		○ replace the current port by the port CategoryApi is listening on

  	3. Run the MVC Project (CategoryProject) in another terminal:
		○ Open the terminal in CategoryProject project folder and run:	dotnet run
		○ Open a browser and navigate to http://localhost:5000/Category (or the appropriate port for your MVC project).


Verification
- The "Category" page in the MVC project should display a table with the categories retrieved from the Minimal API instead of the hardcoded data.

Notice:
Clear SSL Cache and Restart
Sometimes, SSL issues can be due to cached certificates. You can try restarting your machine to clear any cached SSL settings and ensure a fresh connection.

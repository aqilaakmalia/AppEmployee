# AppEmploye API Service
API service for employee apps

## Tech Stack
- Framework : .NET (Version 8.0.401) https://dotnet.microsoft.com/en-us/download/dotnet/8.0
- Database : MYSQL Server (Version 8.0.23) (can be adjusted)

## Running Program
dotnet run

## Link UI
http://localhost:5211/

## Link Swagger 
http://localhost:5211/swagger/

## Notes
- use employee_db.sql for database
- adjust the connection string in the Program.cs file
`builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql("Server=localhost;Database=employee_db;User=root;Password=;", 
        new MySqlServerVersion(new Version(8, 0, 23))));`

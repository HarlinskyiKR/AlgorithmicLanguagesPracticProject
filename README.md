**Project Setup Instructions**

1. `cd AlgorithmicLanguagesPracticProject`
2. `dotnet ef migrations add UpdateMediaGenreNullable`
3. `dotnet ef database update`
4. `dotnet run`
5. Open `http://localhost:5086/` in your browser to access the Swagger UI and test the API endpoints.

Default credentials for authentication:

- Username: `admin@local`
- Password: `admin`

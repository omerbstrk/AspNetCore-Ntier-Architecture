## 🚀 AspNetCore-Ntier-Architecture
This project is a Web API template built using ASP.NET Core with a layered (N-Tier) architecture. It is structured following the principles of clean code and sustainable software development.

## 📋 Contents
```
🔍 About the Project

🛠️ Technologies

📁 Project Structure

🚀 Getting Started

⚙️ Usage

🤝 Contributing

📄 License
```
## 🔍 About the Template
This project is developed using ASP.NET Core Web API and consists of the following layers:

API (Presentation Layer): Handles HTTP requests and directs them to appropriate services.

Service: Contains business logic and communicates with the data access layer.

Repository: Performs database operations.

DTO (Data Transfer Object): Defines objects used for data transfer.

Data: Contains the database context and model classes.

## 🛠️ Technologies
```
── ASP.NET Core 6.0
── Entity Framework Core
── SQL Server
── JWT Authentication
── Swagger
── Serilog (Logging)
── AutoMapper
── FluentValidation
── XUnit (Unit Testing)
── Moq (Mocking)
── FluentAssertions
```
## 📁 Template Structure
```
/AspNetCore-Ntier-Architecture
│
├── Api/                # Web API layer  
├── Repository/         # Data access layer  
├── Service/            # Business logic layer  
├── Sablon.DTO/         # Data transfer objects  
├── Sablon.Data/        # Database context and models  
├── ServiceHelper/      # Helper services  
└── webapisablon.sln    # Solution file
```  
## 🚀 Getting Started
To run the project locally, follow these steps:

Clone the repository:
```
git clone https://github.com/omerbstrk/AspNetCore-Ntier-Architecture.git
cd AspNetCore-Ntier-Architecture
```
Update the database connection string in appsettings.json.

Apply Entity Framework Core migrations:
```
cd Repository
dotnet ef database update
```
Start the project:
```
cd ..
dotnet run --project Api
```
By default, the API will run at:
https://localhost:5001

## ⚙️ Usage
Swagger UI: You can test the API using the Swagger interface at https://localhost:5001/swagger while the application is running.

## 🤝 Contributing
Contributions are welcome! To contribute:

Fork this repository.

Create a new branch (git checkout -b feature/YourFeature).

Make your changes and commit (git commit -am 'Add new feature').

Push your branch (git push origin feature/YourFeature).

Open a Pull Request.

## 📄 License
This project is licensed under the MIT License.

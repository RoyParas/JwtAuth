# 🔐 JwtAuth API (.NET 7 + SQL Server)

A simple ASP.NET Core Web API with JWT authentication, SQL Server integration, and Entity Framework Core.

---

## 🚀 Getting Started

### 📋 Prerequisites

- [.NET 7 SDK or later](https://dotnet.microsoft.com/en-us/download)
- SQL Server (LocalDB or full version)
- (Optional) EF Core CLI tools:  
  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

### 📦 Clone the Repository

```bash
git clone https://github.com/your-username/JwtAuth.git
cd JwtAuth
```

---

### 🛠️ Project Setup

#### 1. Restore NuGet Packages

```bash
dotnet restore
```

#### 2. Add `appsettings.json`

Since `appsettings.json` is ignored in Git (for security), create it manually based on the following template:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=JwtAuthDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "your_super_secret_key",
    "Issuer": "your_app_name",
    "Audience": "your_app_name"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> 🔐 Make sure to replace placeholders with your actual configuration.

---

#### 3. Apply EF Core Migrations

```bash
dotnet ef database update
```

This will create your database using existing migrations.

---

### ▶️ Run the Application

```bash
dotnet run
```

The API will be available at:

```
https://localhost:5001
```

---

## 🧪 Testing the API

You can test the endpoints using:
- **Swagger UI** at `https://localhost:5001/swagger` (if enabled)
- **Postman**, **curl**, or any other API testing tool

---

## 📁 Project Structure

```
JwtAuth/
├── Controllers/            # API endpoints
├── Models/                 # Data models
├── DataContext/            # DB context and config
├── Migrations/             # EF Core migrations
├── Properties/
├── JwtAuth.csproj          # Project file (required)
├── JwtAuth.sln             # Solution file (recommended)
├── Program.cs              # App entry point
└── appsettings.json        # Ignored in Git
```

---

## 📄 License

This project is licensed under the MIT License.

---

## ✨ Author

- [Your Name](https://github.com/your-username)
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

You can use appsettings.json.example as a base.
So the step is:

```bash
cp appsettings.json.example appsettings.json
```
Or just manually create the file using the example.

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
http://localhost:5130
```

---

## 🧪 Testing the API

You can test the endpoints using:
- **Swagger UI** at `https://localhost:5130/swagger` (if enabled)
- **Postman**, **curl**, or any other API testing tool

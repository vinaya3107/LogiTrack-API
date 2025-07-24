
# LogiTrack API

**LogiTrack** is a secure, optimized inventory and order management system built with **ASP.NET Core Web API**. It includes full authentication, role-based access, caching, and persistent data storage using **Entity Framework Core**.

---

## 🔧 Tech Stack

- ASP.NET Core 8 Web API
- Entity Framework Core (Code First)
- SQL Server (LocalDB or SQL Express)
- JWT Authentication
- ASP.NET Identity
- IMemoryCache
- Swagger UI

---

## 📦 Features

- ✅ **User Registration & Login** (JWT-based)
- ✅ **Role-Based Access** (`Admin`, `User`)
- ✅ **Inventory CRUD** with caching
- ✅ **Order viewing** with navigation properties
- ✅ **In-memory caching** for performance
- ✅ **Persistent state management**
- ✅ **Secure endpoints with [Authorize]**
- ✅ **Full Swagger documentation**

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server Express / LocalDB
- Visual Studio / VS Code

### Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/LogiTrack.git
   cd LogiTrack
   ```

2. **Apply Database Migrations**
   ```bash
   dotnet ef database update
   ```

3. **Run the Project**
   ```bash
   dotnet run
   ```

4. **Open Swagger UI**
   Visit: `http://localhost:5265/swagger`

---

## 🔐 Authentication

### Register a User  
`POST /api/auth/register`
```json
{
  "email": "user@example.com",
  "password": "Password@123",
  "role": "User"
}
```

### Login  
`POST /api/auth/login`
```json
{
  "email": "user@example.com",
  "password": "Password@123"
}
```

Copy the returned token and authorize in Swagger using the format:
```
Bearer <your-token>
```

---

## 📦 Inventory API

### GET /api/inventory  
Returns the inventory list (uses in-memory caching)

### POST /api/inventory  
Add a new inventory item
```json
{
  "name": "Printer",
  "quantity": 10
}
```

### DELETE /api/inventory/{id}  
Deletes an inventory item by ID

---

## 📦 Order API

### GET /api/order  
Returns a list of orders including items (with navigation properties)

---

## 🧠 State Management

- Uses EF Core Code First with SQL Server for persistent state  
- In-memory caching boosts GET request performance  
- Data persists across server restarts  

---

## 🧪 Testing Checklist

- ✅ Register/Login flow tested  
- ✅ Role-based access validated  
- ✅ Inventory endpoints tested (CRUD)  
- ✅ Orders returned with included items  
- ✅ JWT tokens secured all protected routes  
- ✅ GET routes use caching  
- ✅ Server restart doesn't lose data  

---

## 🤖 Copilot Enhancements

GitHub Copilot assisted with:

- Refactoring duplicate logic  
- Caching integration  
- Readability improvements  
- Secure exception handling  

---

## 📜 Project Summary (for Peer Review)

> LogiTrack is a secure API-based inventory/order system built using ASP.NET Core, implementing authentication, role management, EF Core data persistence, and in-memory caching for performance. Swagger supports interactive API testing, and best practices are followed throughout the solution.

---

## 👨‍💻 Author

**Vinaya Mandalapu**  

---

## 📄 License

This project is private and intended solely for academic or educational use by the original author.
Do not redistribute, publish, or use commercially without explicit permission.

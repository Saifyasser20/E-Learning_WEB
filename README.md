# 📚 E-Learning Backend API (.NET)

## 🚀 Project Overview

This project is a **backend API for an E-Learning platform** built using ASP.NET Core.
It allows users to register, authenticate, create courses, enroll in courses, and retrieve course data.

The system supports **role-based access control** with three roles:

* **Admin**
* **Instructor**
* **Student**

---

# ⚙️ How to Run the Project

## 🧩 Prerequisites

Make sure you have:

* .NET SDK (v8 or later recommended)
* Docker (for SQL Server)
* Postman (for testing APIs)

---

## 🐳 1. Run SQL Server using Docker

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong!Pass123" \
-p 1433:1433 --name sqlserver \
-d mcr.microsoft.com/mssql/server:2022-latest
```

---

## 🔧 2. Configure Connection String

In `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=ELearningDB;User Id=sa;Password=YourStrong!Pass123;TrustServerCertificate=True"
}
```

---

## 🧱 3. Apply Migrations

```bash
dotnet ef database update
```

---

## ▶️ 4. Run the Project

```bash
dotnet run
```

---

## 🌐 API Base URL

```text
http://localhost:5284/api
```

---

# 🧪 Technologies Used

## 1. ASP.NET Core Web API

Used to build RESTful APIs.
Provides routing, controllers, middleware, and dependency injection.

---

## 2. Entity Framework Core (EF Core)

ORM (Object Relational Mapper) used to:

* Interact with the database
* Handle relationships
* Perform CRUD operations

---

## 3. SQL Server

Relational database used to store:

* Users
* Courses
* Enrollments

---

## 4. Docker

Used to run SQL Server in a container for easy setup and portability.

---

## 5. JWT (JSON Web Token)

Used for authentication and authorization.
Allows secure communication between client and server.

---

## 6. LINQ (Language Integrated Query)

Used to query data and transform it into DTOs using `.Select()`.

---

## 7. Dependency Injection (DI)

Used to inject services (like `CourseService`) into controllers.

---

## 8. DTOs (Data Transfer Objects)

Used to:

* Control API responses
* Hide internal database structure
* Improve security and performance

---

## 9. Async/Await

Used for non-blocking database operations to improve performance.

---

# 🔐 Why HTTP-Only Cookies Are Used (Industry Standard)

HTTP-only cookies are commonly used for authentication because they enhance security:

### ✅ Protection Against XSS (Cross-Site Scripting)

* JavaScript cannot access HTTP-only cookies
* Prevents attackers from stealing authentication tokens

### ✅ Automatic Sending with Requests

* Cookies are automatically included in HTTP requests
* No need to manually attach tokens

### ✅ Reduced Token Exposure

* Tokens are not stored in localStorage/sessionStorage
* Less risk of leakage

---

## ⚠️ In This Project

We used **JWT in Authorization headers** for simplicity, but in production systems:
👉 HTTP-only cookies are preferred for higher security.



# ✅ Features Implemented

* User Authentication (JWT)
* Role-Based Authorization
* Course Management
* Enrollment System (Many-to-Many)
* LINQ Queries with DTO Projection
* Async Database Operations
* Service Layer Architecture

---

# 🏁 Conclusion

This project demonstrates a complete backend system using modern .NET practices:

* Clean architecture
* Secure authentication
* Efficient database handling
* Scalable design

---

🔥 Ready for extension with:

* Lesson/Video system
* File uploads
* Frontend integration

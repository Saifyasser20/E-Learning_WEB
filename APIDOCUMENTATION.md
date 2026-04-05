# 📡 API Documentation (Full)

## 🔐 Authentication

---

### 🔹 Login

```http
POST /api/users/login
```

#### Request Body

```json
{
  "email": "admin@test.com",
  "password": "123456"
}
```

#### Response

```json
{
  "token": "JWT_TOKEN"
}
```

#### Notes

* Token must be used in all protected endpoints
* Format:

```
Authorization: Bearer TOKEN
```

---

# 👤 Users

---

### 🔹 Register User

```http
POST /api/users
```

#### Request Body

```json
{
  "name": "User1",
  "email": "user@test.com",
  "password": "123456",
  "role": "Student"
}
```

#### Response

```json
{
  "id": 1,
  "name": "User1",
  "email": "user@test.com",
  "role": "Student"
}
```

---

# 📚 Courses

---

### 🔹 Create Course

```http
POST /api/courses
```

#### Headers

```
Authorization: Bearer TOKEN
```

#### Roles Allowed

* Admin
* Instructor

#### Request Body

```json
{
  "title": "Math",
  "description": "Basic math course"
}
```

#### Response

```json
{
  "id": 1,
  "title": "Math",
  "description": "Basic math course",
  "instructorId": 1
}
```

---

### 🔹 Get All Courses

```http
GET /api/courses
```

#### Response

```json
[
  {
    "id": 1,
    "title": "Math",
    "description": "Basic math course",
    "instructorName": "Admin"
  }
]
```

---

### 🔹 Get Course By ID

```http
GET /api/courses/{id}
```

#### Example

```http
GET /api/courses/1
```

#### Response

```json
{
  "id": 1,
  "title": "Math",
  "students": [
    "Student1"
  ]
}
```

---

# 📥 Enrollments

---

### 🔹 Enroll in Course

```http
POST /api/enrollments
```

#### Headers

```
Authorization: Bearer TOKEN
```

#### Role Required

* Student

#### Request Body

```json
{
  "courseId": 1
}
```

#### Response

```text
Enrolled successfully
```

---

### 🔹 Duplicate Enrollment

#### Response

```text
Already enrolled
```

---

# 🔒 Authorization Summary

| Endpoint          | Method | Role Required     |
| ----------------- | ------ | ----------------- |
| /api/users        | POST   | Public            |
| /api/users/login  | POST   | Public            |
| /api/courses      | POST   | Admin, Instructor |
| /api/courses      | GET    | Public            |
| /api/courses/{id} | GET    | Public            |
| /api/enrollments  | POST   | Student           |

---

# ⚠️ HTTP Status Codes

| Code | Meaning      |
| ---- | ------------ |
| 200  | Success      |
| 400  | Bad Request  |
| 401  | Unauthorized |
| 403  | Forbidden    |
| 404  | Not Found    |

---

# 🧠 Notes

* Authentication is handled using JWT tokens
* Role-based access control is enforced using `[Authorize(Roles = "...")]`
* Data is returned using DTOs for security and clarity
* Async methods are used for better performance

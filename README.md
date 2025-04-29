# CRUD Operations Using C#

This project demonstrates CRUD (Create, Read, Update, Delete) operations in a C# application using **ASP.NET Core Web API** and **SQLite**.

## Technologies Used
- **C#**
- **ASP.NET Core**
- **SQLite**
- **Postman** (Optional)

API Endpoints
1. GET /api/DummyData
Fetch all items.

2. GET /api/DummyData/{id}
Fetch item by ID.

3. POST /api/DummyData
Create a new item.

Request body: {"name": "Sample Item", "description": "Sample", "date": "2025-04-29T10:00:00"}

4. PUT /api/DummyData/{id}
Update item by ID.

Request body: {"id": 1, "name": "Updated Item", "description": "Updated", "date": "2025-04-30T10:00:00"}

5. DELETE /api/DummyData/{id}
Delete item by ID.

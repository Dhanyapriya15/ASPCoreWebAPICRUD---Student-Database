# ASPCoreWebAPICRUD---Student-Database
# ASP.NET Core Web API - Student CRUD with MySQL

This is a RESTful Web API built using **ASP.NET Core** and **MySQL**, supporting **CRUD operations** on a `Students` table. The API is testable via **Swagger UI** and uses `MySql.Data.MySqlClient` for database access.


##  Features

- Get all students
- Get student by ID
- Create (Insert) student
- Update student
- Delete student
- Swagger UI support for testing


## Technologies Used

- ASP.NET Core Web API (.NET 6+)
- MySQL Database
- MySql.Data (ADO.NET driver)
- Swagger 

## API Endpoints

| Method | Endpoint               | Description             |
| ------ | ---------------------- | ----------------------- |
| GET    | `/api/StudentAPI`      | Get all students        |
| GET    | `/api/StudentAPI/{id}` | Get student by ID       |
| POST   | `/api/StudentAPI`      | Create new student      |
| PUT    | `/api/StudentAPI/{id}` | Update existing student |
| DELETE | `/api/StudentAPI/{id}` | Delete student by ID    |

## Project Structure
![image](https://github.com/user-attachments/assets/daaec806-9f8d-4fcc-8fb6-da41bd5d9577)



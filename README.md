# MathTestSystem

MathTestSystem is a full-stack web application for uploading, and reviewing math exams. It is built using **ASP.NET Core** for the backend, **Blazor** for the frontend, and **SQLite** as the database.

## Features

* **User Authentication & Authorization**

  * Implemented using ASP.NET Core Identity
  * Supports `Student` and `Teacher` roles

* **Student Functionality**

  * Login and view personal exam results
  * Review detailed exam results including task correctness, formulas, and scores
  * Responsive Blazor components for student dashboard

* **Teacher Functionality**

  * Login and upload math exams
  * Show exam results for every student

* **Exam Processing**

  * Automatically evaluates tasks by computing formulas
  * Records correct and incorrect answers in the database
  * Stores detailed task results including formula, student answer, correct answer, and result

* **Database**

  * SQLite database with Entity Framework Core
  * Identity tables for users and roles
  * Custom tables for Students, Teachers, Exams, ExamResults, and ExamTaskResults
  * Seed data for initial users, roles, teachers, and students

* **API Endpoints**

  * AuthController for login
  * Student endpoints for retrieving exam results
  * Teacher endpoints for uploading exams

* **Frontend**

  * Blazor Server components
  * Navigation menu dynamically shows options based on user role
  * Generic Login/Logout link component

* **CORS & Swagger**

  * Configured to allow frontend calls from Blazor UI
  * Swagger UI enabled for API testing

## Technologies Used

* ASP.NET Core 7
* Blazor Server
* Entity Framework Core
* SQLite
* ASP.NET Core Identity
* JWT Authentication
* C#

## Getting Started

1. **Clone the repository:**

   ```bash
   git clone https://github.com/hristinacvetanoska/MathTestSystem.git
   cd MathTestSystem
   ```

2. **Apply Migrations:**

   ```bash
   dotnet ef database update
   ```

3. **Run the application:**

   ```bash
   dotnet run
   ```

4. **Access the frontend:**
   Open a browser and navigate to `https://localhost:7299`

5. **Login:**

   * Teacher: `williamTeacher` / `Teacher123!`
   * Student: `anaStudent` / `AnaStudent123!`
   * Student: `johnStudent` / `JohnStudent123!`

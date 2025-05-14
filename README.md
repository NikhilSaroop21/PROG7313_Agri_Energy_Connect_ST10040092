 Agri-Energy Connect — Web Application Prototype
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
**Student Name:** Nikhil Saroop  
**Student Number:** ST10040092  
**Module:** PROG7311 — Programming 3A  
**Part:** 2 — Functional Web Application Development  

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


 1.  Project Overview
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Agri-Energy Connect is a secure, role-driven web application built with ASP.NET Core MVC. The system serves as a digital platform to bring together South African farmers and renewable energy solution providers. Its main objective is to facilitate knowledge sharing, enable collaborative farming practices, and simplify access to green technologies. The application is designed with two user roles — Farmers and Employees — each with dedicated dashboard views and functionality tailored to their needs. This promotes efficient data management and supports the transition toward environmentally sustainable agriculture.


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

 2.  Technologies Implemented
    
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Category              | Technology                                | Purpose & Rationale                                                                             |
|-----------------------|--------------------------------------------|-------------------------------------------------------------------------------------------------|
| Framework             | ASP.NET Core MVC                           | Follows MVC architecture for clean code separation and easier maintainability.                  |
| Object Relational Mapper | Entity Framework Core (Code-First)     | Simplifies database creation and access using strongly-typed classes and supports migrations.   |
| Authentication        | ASP.NET Identity with Roles                | Provides out-of-the-box user management and secure role-based access control.                   |
| Frontend & Layout     | Razor Views, Bootstrap 5, Bootswatch       | Delivers a responsive, mobile-first UI with customizable themes for consistency and usability.  |
| Development IDE       | Visual Studio 2022                         | Offers powerful development, debugging, and scaffolding features for ASP.NET Core projects.     |
| Database              | SQL Server (via SSMS 20)                   | A scalable and enterprise-grade database engine ideal for transactional applications.           |


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## 3. 📦 Installed Dependencies
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

### Backend (via NuGet):
- `Microsoft.EntityFrameworkCore.SqlServer`  
- `Microsoft.EntityFrameworkCore.Tools`  
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore`  
- `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`  
- `Microsoft.AspNetCore.Identity.UI`  
- `Microsoft.AspNetCore.Authentication.Cookies`  
- `Microsoft.Extensions.Logging.Console`  
- `Microsoft.VisualStudio.Web.CodeGeneration.Design`  

### Frontend:
- Bootstrap 5 (CDN)
- Bootswatch Theme (CDN)

These libraries collectively enable secure authentication, database interaction, dynamic UI, and debugging/logging features.



--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

 4. Main Functionalities
    
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
# Role-Based Access Control
- Secure login with ASP.NET Identity.
- Differentiated user roles: **Farmer** and **Employee**.
- Farmers must request access; employees can approve or deny requests.


# 🌾 Farmer Dashboard
- Submit new product entries (Name, Type, Production Date).
- View, edit, and remove your own products.
- Filter products by date and category.
- Responsive interface optimized for mobile and desktop.


# Employee Dashboard
- Register and manage farmer profiles.
- View all submitted products across the platform.
- Apply filters by farmer, product type, or production date.
- Approve or reject farmer registration requests.


# Validation & Data Quality
- Uses data annotations for backend validation.
- Client-side and server-side form checks.
- Controllers and views secured with role-based authorization.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


 5.  Database Setup (SQL Server via SSMS)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Key Tables:

---------------

`AspNetUsers`, `AspNetRoles`, `AspNetUserRoles` — for Identity management  
- `Farmers` — stores farmer information  
- `Products` — stores product listings  
- `FarmerAccountRequests` — tracks pending farmer registration requests  

Initial Setup:

------------------

Open Visual Studio
Tools → NuGet Package Manager → Package Manager Console
Run: Update-Database

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Sample Users (Pre-Seeded):
Role	Email	Password
Employee	employee1@example.com	Employee123!
Farmer	farmer1@example.com	Farmer123!

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Test records are preloaded for demonstration purposes.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
6. 👥 User Instructions
👨‍💼 For Employees:
Navigate to: /Identity/Account/Login

Log in using your Employee credentials.

You will be able to:

Create new farmer profiles

View and filter all product submissions

Review and manage pending farmer access requests

👨‍🌾 For Farmers:
Log in with approved farmer credentials.

Once logged in:

Add products to your profile

Edit or delete your own submissions

Filter your list by type or date

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

7. 🎥 Demo Video
Watch a full demonstration of:

Role-specific login flow

Farmer and Employee dashboards

Product submission and filtering

Account approval process

🔗 Demo Video on YouTube
Note: Replace the link with your actual video.


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

8. 🚀 Running the Application Locally
---------------------------------------------
   
System Requirements:

---------------------------------------------

.NET 8.0 SDK

Visual Studio 2022 (with ASP.NET workload)

SQL Server and SSMS (v20+)

----------------------------------------------

Setup Instructions:

-----------------------------------------------

1. Clone or Download the Repository

Open the .sln file in Visual Studio.

2. Install Dependencies

-Navigate to:Tools > NuGet Package Manager > Package Manager Console

-Run:Update-Package -reinstall

3. Update Connection String

Edit appsettings.json:


"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=AgriEnergyDB;Trusted_Connection=True;"
}

4. Apply EF Core Migrations

Run in Package Manager Console:

Update-Database

5. Run the Application

-Press Ctrl + F5 or click the green ▶️ button in Visual Studio.

-The application will launch in your browser.


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

9.  Project Structure Overview
Path	Purpose
Models/	Contains entity classes (e.g., Farmer, Product)
Controllers/	Manages request-response logic and page routing
Views/	Razor view files for rendering the frontend
Data/	Includes DbContext, migrations, and data seeding
Areas/Identity/	Contains Identity UI components (login, register, roles, etc.)

10. 🖌️ UI/UX Principles
Responsive Design: Mobile-first layout compatible across devices.

Performance Optimized: Leverages CDNs for reduced load times.

Accessibility Focus: Forms use labels, placeholders, and ARIA tags.

Visual Clarity: Clean, consistent theme using Bootswatch templates.

Secure by Design: Built-in CSRF protection and role validation layers.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
11. 🙋 Support & Contributions

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Developer: Nikhil Saroop
Student Number: ST10040092
Module: PROG7311 — Programming 3A


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

12. 📚 References

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Microsoft Learn (2025). ASP.NET Identity Overview

Microsoft Learn (2024). Entity Framework Core in ASP.NET MVC

Bootswatch (2025). Free Bootstrap Themes



--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
13. 🔧 Developer Setup Guide (Extended)
This section offers a more detailed explanation for local development setup.

Required Tools:
Visual Studio 2022 or newer with ASP.NET & Web Development workloads

.NET SDK 8.0 or later

SQL Server and SQL Server Management Studio (SSMS 20+)

Full Setup Workflow:
1. Extract or Clone the Project
Extract the ZIP or clone via Git.

Launch the solution (.sln) in Visual Studio.

2. Install Dependencies
Use NuGet Package Manager Console:


Update-Package -reinstall
3. Configure Database Connection
In appsettings.json, adjust the connection string:


"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=AgriEnergyDB;Trusted_Connection=True;"

4. Initialize the Database
Run EF Core command:
Update-Database



5. Launch the Web Application
Press Ctrl + F5 or start the app via the toolbar.

Your default browser will open the home page.

6. Test Functionality
Use test credentials to explore Farmer and Employee flows.

Ensure all seeded data appears as expected.

Tip: Restart SQL Server or verify the connection string if you encounter DB connection errors.





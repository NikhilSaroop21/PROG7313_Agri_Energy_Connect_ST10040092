-------------------------------------------------------------
  README — Agri-Energy Connect Web Application Prototype
   
 Student Name: Nikhil Saroop
               
 Student Number: ST10040092  
 
 Module: PROG7311 — Programming 3A                        

 Part: 2 — Functional Web Application Development         
-------------------------------------------------------------

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 1. Project Purpose


A secure, role-based ASP.NET Core MVC web application Agri-Energy Connect unites South African farmers and suppliers of renewable energy solutions.  By offering users the the ability for them to collaborate together, acquire knowledge, and manage agricultural products, in addition to by making understanding on green technologies simple to find, the platform promotes environmentally friendly farming.  The software guarantees role-specific access and an easier user interface with distinct dashboards for Farmers and Employees.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
2. Technologies Used
   

| Category             | Technology                                | Justification                                                                                  |
|----------------------|--------------------------------------------|-----------------------------------------------------------------------------------------------|
| Framework            | ASP.NET Core MVC                           | Ensures clean separation of logic, UI, and data using the Model-View-Controller pattern.      |
| Backend ORM          | Entity Framework Core (Code-First)         | Enables efficient database interaction using C# models and supports migrations and seeding.   |
| Authentication       | ASP.NET Identity (Role-based)              | Provides secure authentication and granular role-based authorization for different users.     |
| UI Design            | Razor Views + Bootstrap 5 + Bootswatch     | Delivers modern, responsive, and consistent UI with customizable themes and grid systems.     |
| Development IDE      | Visual Studio 2022                         | Full-featured IDE ideal for .NET development, debugging, scaffolding, and productivity.        |
| Database Management  | SQL Server (via SSMS 20)                   | Enterprise-grade relational database; supports scalability and works well with EF Core.       |


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


3. Installed Dependencies

// Backend (NuGet) //
- Microsoft.EntityFrameworkCore.SqlServer  
- Microsoft.EntityFrameworkCore.Tools  
- Microsoft.AspNetCore.Identity.EntityFrameworkCore  
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore  
- Microsoft.AspNetCore.Identity.UI  
- Microsoft.VisualStudio.Web.CodeGeneration.Design  
- Microsoft.AspNetCore.Authentication.Cookies  
- Microsoft.Extensions.Logging.Console  

// Frontend //
- Bootstrap 5 (via CDN)  
- Bootswatch (for UI theme, via CDN)  



-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


 4. Core Features (Part 2)

 Authentication & Authorization
- Secure login using ASP.NET Identity
- Role-based access control: Employee and Farmer roles
- Public farmer registration via "Request Account" form (approved by Employees)

 Farmer Dashboard
- Add, edit, delete, and view your products
- Filter products by category and production date
- Clean, mobile-optimized dashboard interface

 Employee Dashboard
- Register new Farmers with a secure form
- View all products from any farmer
- Filter products by:
  • Farmer name
  • Product category
  • Production date
- Approve or deny pending farmer registration requests

 Data Integrity & Validation
- Entity-level validation (data annotations)
- Server-side and client-side input checks
- Role verification at both controller and view levels


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

 5. Database Setup (SQL Server via SSMS 20)

Key Tables:
- AspNetUsers
- AspNetRoles
- AspNetUserRoles
- FarmerAccountRequests
- Farmers
- Products

To initialize:
> Open Visual Studio  
> Tools → NuGet Package Manager → Package Manager Console

![Uploading tools.png…]()

> Run: Update-Database

 Seeded Test Accounts:

| Role      | Email                   | Password       |
|-----------|-------------------------|----------------|
| Employee  | employee1@example.com   | Employee123!   |
| Farmer    | farmer1@example.com     | Farmer123!     |

- Additional test records are seeded for demo and testing purposes.



--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



 6. User Instructions

// Employee Instructions //
1. Navigate to the login page: `/Identity/Account/Login`
2. Use your Employee credentials.
3. On the Employee Dashboard, you can:
   - View all farmers and products
   - Register new farmer accounts
   - Filter product lists by farmer, category, or date
   - Approve/Reject pending farmer sign-up requests

// Farmer Instructions //
1. Visit the login page.
2. Enter approved Farmer credentials.
3. On the Farmer Dashboard, you can:
   - Add products (name, category, date)
   - View and manage your existing products
   - Use filters to sort or search your product list
   - Edit or delete only your products







--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


 7. Video Demonstration

A full feature walk-through video will show:
- Login for both roles
- Dashboard navigation
- Product management
- Account request and approval flow

 YouTube Link: https://youtu.be/YOUR_UNLISTED_LINK  
(*Replace this placeholder with your final video URL*)


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


 8. How to Launch the App

// Prerequisites //
- .NET 8.0 SDK
- Visual Studio 2022+
- SQL Server (SSMS 20 configured)

// Launch Steps //
1. Download or clone the repository.
2. Open the solution in Visual Studio 2022.
3. Open `appsettings.json` and edit:
   "DefaultConnection": "Server=YOUR_SERVER;Database=AgriEnergyDB;Trusted_Connection=True;"
4. Open the Package Manager Console and run:
   > Update-Database
5. Press `Ctrl + F5` to build and launch the web app in your browser.


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


 
 9. Project Structure

| Folder / File        | Description                                      |
|----------------------|--------------------------------------------------|
| Models/              | Defines EF Core entities: Farmer, Product, etc.  |
| Controllers/         | Logic for handling requests and routing          |
| Views/               | Razor Pages for rendering user interface         |
| Data/                | ApplicationDbContext, configuration, seeding     |
| Areas/Identity/      | Identity area for user authentication and login  |


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


 10. UI/UX Considerations

- Mobile-First Design: Works on all devices
- Low Bandwidth Optimization: Minimal assets and CDN usage
- Accessibility: Forms include placeholders, labels, and ARIA support
- Visual Themes: Bootswatch theme for clean appearance
- Security: Role-locked pages, anti-forgery tokens, input sanitization



--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




 11. Contributors and Support

Developer: Nikhil Saroop  
Student Number: ST10040092  
Module: PROG7311 — Programming 3A  





--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

 12. References

- Microsoft Learn. (2025). Introduction to ASP.NET Identity  
  https://learn.microsoft.com/en-us/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity  
  [Accessed 6 May 2025]

- Microsoft Learn. (2024). EF Core in ASP.NET MVC  
  https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-9.0  
  [Accessed 6 May 2025]

- Bootswatch. (2025). Free Bootstrap Themes  
  https://bootswatch.com  
  [Accessed 6 May 2025]






Agri-Energy Connect
Student ID: ST10040092
Module: Programming 3A — PROG7311
Part: 2 — Web Application Prototype

**Overview
Agri-Energy Connect is a web application developed as part of the PROG7311 POE assignment. The platform aims to support sustainable farming in South Africa by enabling two types of users — Farmers and Employees — to collaborate and manage agricultural product information via a secure, role-based web platform.

 **Features
**Authentication & Authorization
1.Role-based login for Farmers and Employees using ASP.NET Identity.
2.Public registration for Farmers via a Request Account form.
3.Employees can approve or deny farmer registration requests.

**Employee Capabilities
Access to an Employee Dashboard with:

1.List of all Farmer Profiles
2.Ability to register new Farmers (secure form with no autofill).
3.Product management system to view and filter products across farmers by:
4.Farmer name
5.Product category
6.Date range
7.Ability to approve or deny pending Farmer registration requests.

**Farmer Capabilities
1.Access to a personalized Farmer Dashboard with:
2.View of their own products.
3.Filters (by category or production date) to sort products.
4.CRUD operations on their products:
5.Add new products.
6.Edit existing products.
7.Delete products.
8.View only their own data; no access to other farmers' data.

 **Data Accuracy & Validation
1.Input validation ensures correct product data entry.
2.Role-based access ensures only rightful owners (Farmers) can edit or delete their products.
3.Filters allow for flexible searching by one or multiple criteria.

** Technologies Used
1.ASP.NET Core MVC for the web framework.
2.Entity Framework Core with SQL Server 2022 for data storage.
3.ASP.NET Identity for authentication and authorization.
3.Razor Pages and Razor Views for dynamic content rendering.
4.Bootstrap for responsive UI styling.
5.Visual Studio 2022 for development.

**Database Setup
1.Before running the application, ensure your SQL Server environment is ready. This project includes SQL scripts that must be executed manually if automatic migrations are not being used.
2.Required Tables
3.Execute the following scripts in this order to create and seed the database correctly:
4.AspNetRoles – Defines application roles such as Farmer and Employee.
5.AspNetUsers – Stores user credentials and login information.
6.AspNetUserRoles – Maps users to their respective roles.
8.Products – Stores product entries added by each farmer.

These scripts ensure all necessary tables are available and populated before the application runs.

***How to Run the Application
1.Open the solution in Visual Studio 2022.
2.Ensure that SQL Server 2022 is installed and configured.
3.Update the appsettings.json file with your valid SQL connection string.
4.Run the application — it will automatically:
5.Apply database migrations.
6.Seed roles (Farmer, Employee).
7.Create demo users and products.

**Seeded Test Accounts
Role	Email	Password
Employee	employee1@example.com	Employee123!
Farmer	farmer1@example.com	Farmer123!


**User Flow and Navigation Guide
--For Employees:
1.Login through the /Identity/Account/Login page.

2.Access the Employee Dashboard to:

3.Manage Farmers: View and edit farmer profiles.

4.Register New Farmer: Add a new farmer to the platform.

5.Filter Products: Search and filter agricultural products.


--For Farmers:
1.Login with your farmer account credentials.
2.Access the Farmer Dashboard to:
3.Add, view, edit, or delete products.
View only your own data within the dashboard.

** User Interface & Experience
-The UI is responsive and accessible on both desktop and mobile devices.
-Autofill has been disabled on sensitive forms, such as employee-created farmer registrations.
-The platform follows enterprise software design principles and ensures a good user experience (UX).

** Project Structure
Models/ — Contains Entity and ViewModel classes.

Controllers/ — Role-based logic for managing dashboards, admin functions, and products.

Views/ — Razor views, organized by feature (e.g., product management, dashboards).

Data/ — Contains ApplicationDbContext and seeding logic.

Areas/Identity/ — Scaffolded ASP.NET Identity pages for login functionality.

** References
Microsoft Learn, 2020. Using SSMS 20 in Visual Studio Projects. [Online]
Available at:https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms
[Accessed 4 May 2025].

Microsoft Learn, 2024. Tutorial: Get started with EF Core in an ASP.NET MVC web app. [Online]
Available at: https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-9.0
[Accessed 5 May 2025].

Microsoft Learn, 2025. Introduction to ASP.NET Identity. [Online]
Available at: https://learn.microsoft.com/en-us/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity
[Accessed 3 May 2025].

Author
Student: ST10040092
Module: Programming 3A — PROG7311
Part: 2 — Web Application Prototype

 Agri-Energy Connect
Student ID: ST10040092
Module: Programming 3A (PROG7311)
Assignment Part: 2 – Web App Prototype

📘 Summary
Agri-Energy Connect is a web-based system developed to aid sustainable farming initiatives in South Africa. The platform connects two main user roles—Farmers and Employees—through a secure, role-sensitive environment where farming products can be managed collaboratively.

This solution streamlines agricultural record-keeping and empowers users to interact efficiently through features like login control, product management, and data filtering, all within a responsive, modern interface.

🔐 User Access & Security
ASP.NET Identity is used for secure authentication and role management.

Farmers can submit account requests via an online form.

Employees log in to review and decide on these requests (approve or reject).

🧑‍🌾 Farmer Dashboard
When a Farmer logs in, they are taken to a dashboard tailored to their activities. Features include:

Viewing only their own product entries.

Adding, modifying, or deleting their products.

Using filters to search products by:

Category

Production date

⚠ Farmers cannot see or interact with data belonging to other users.

🧑‍💼 Employee Dashboard
Employees access an administrative panel with expanded privileges:

Access to all registered farmer profiles.

Ability to securely register new farmers (form autofill is turned off).

Viewing and filtering all products across the platform using:

Farmer names

Product categories

Specific date ranges

Approving or denying farmer registration requests.

🛠 Tech Stack Overview
Backend: ASP.NET Core MVC

Database Layer: Entity Framework Core + SQL Server 2022

Authentication: ASP.NET Identity

Frontend: Razor Pages and Views

UI Styling: Bootstrap + Bootswatch (for themed responsiveness)

IDE Used: Visual Studio 2022

🗄 Database Essentials
Before launching the application:

Set up your SQL Server 2022 environment.

Either allow EF Core to auto-migrate or manually run the following scripts:

AspNetRoles

AspNetUsers

AspNetUserRoles

Products

These create the necessary schema and seed initial records for testing.

🚀 How to Launch the App
Load the solution in Visual Studio 2022.

Confirm SQL Server 2022 is installed and operational.

Update the appsettings.json with a valid SQL connection string.

Run the project. The app will:

Migrate and seed the database

Insert demo users and product entries

Set up default roles: Farmer and Employee

🧪 Sample Accounts
Role	Email	Password
Employee	employee@email.com	employee123!
Farmer	farmer@email.com	Farmer123!

🔄 Navigation Workflow
Employee Steps
Login through /Identity/Account/Login.

Navigate to the dashboard:

Manage farmer accounts

Register new farmers

Access the product filtering interface

Farmer Steps
Log in with farmer credentials.

Use your dashboard to:

Add or manage your product listings

Filter your data by category or date

📱 UI and Usability
Designed to work across devices (desktop and mobile).

Clean, intuitive layout powered by Bootstrap and styled using Bootswatch themes.

Autofill disabled on critical forms to enhance data privacy.

User experience emphasizes clarity, speed, and accessibility.

📁 Folder Layout (Simplified)
/Models: Business entities and ViewModels

/Controllers: Backend logic by role and feature

/Views: Razor UI views, grouped by modules

/Data: DbContext and initial data configuration

/Areas/Identity: Authentication and login flows

🔗 Sources and Learning Material
Microsoft Docs. “Using SSMS with Visual Studio.” https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms. Accessed 4 May 2025.

Microsoft Docs. “Get started with EF Core in MVC.” https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro. Accessed 5 May 2025.

Microsoft Docs. “Intro to ASP.NET Identity.” https://learn.microsoft.com/en-us/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity. Accessed 3 May 2025.

Bootswatch. “Themes for Bootstrap.” https://bootswatch.com/. Accessed 5 May 2025.

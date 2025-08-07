# MVC Bird Management System

An ASP.NET Core MVC web application for managing bird records.  
Ideal for bird sanctuaries, wildlife research centers, or hobbyists, this system allows users to easily create, view, update, and delete bird information through a clean and responsive interface.

---

## Features

- **Bird Record Management (CRUD)**  
  Create, read, update, and delete bird entries.

- **Image Upload & Display**  
  Upload images to visually identify each bird.

- **Search & Filtering**  
  Quickly find birds by name, species, or other attributes.

- **Responsive Design**  
  Built with Bootstrap for mobile and desktop compatibility.

- **Validation & Error Handling**  
  Ensures accurate, consistent data input.

- **Database Integration**  
  Uses Entity Framework Core with SQL Server for persistent storage.

---

## Technologies Used

- **ASP.NET Core MVC**  
- **Entity Framework Core** (Code-First approach)  
- **SQL Server** (LocalDB or Azure SQL)  
- **Bootstrap 5** for UI styling  
- **Azure Blob Storage** (optional, for image hosting)  

---

## Getting Started

### Prerequisites

- Visual Studio 2022 or later  
- .NET 6.0 SDK or later  
- SQL Server LocalDB (installed with Visual Studio)  

### Installation Steps

1. Clone the repository  
   ```bash
   git clone https://github.com/LukePageDev/MVCBirdManagementSystem.git
Open the solution in Visual Studio (MVCBirdManagementSystem.sln).

Configure the database connection string in appsettings.json to point to your SQL Server instance.

Open the Package Manager Console and run migrations:

powershell
Copy
Edit
Update-Database
Build and run the application by pressing F5 or clicking Run.

Usage
Home Page: Overview and navigation.

Bird List: View all birds with search and filter options.

Create Bird: Add new bird details including an image upload.

Edit Bird: Modify existing bird information.

Delete Bird: Remove birds from the system with confirmation.

Details View: Display comprehensive information about a selected bird.

### Project Structure
vbnet
Copy
Edit
MVCBirdManagementSystem/
├── Controllers/
│   ├── BirdsController.cs
│   └── HomeController.cs
├── Models/
│   ├── Bird.cs
│   └── ...
├── Views/
│   ├── Birds/
│   └── Shared/
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── images/
├── appsettings.json
└── MVCBirdManagementSystem.sln
---
## Future Improvements
Implement user authentication and role-based authorization.

Add pagination for bird listings.

Enhance filtering with habitat, conservation status, or region.

Integrate bulk import/export of bird data via CSV or Excel files.

Improve UI with animations and accessibility features.

Enable REST API for external integrations.

---

Thank you for using MVC Bird Management System!

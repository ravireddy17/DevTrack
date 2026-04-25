# 📋 DevTrack — Developer Task Tracker

A full-stack **ASP.NET Core MVC** web application built with **C# and .NET 8**, demonstrating core enterprise development skills relevant to the **the company Developer II** role.

## 🛠️ Tech Stack

| Technology | Purpose |
|---|---|
| **C# / .NET 8** | Backend language & runtime |
| **ASP.NET Core MVC** | Web framework (MVC pattern) |
| **Entity Framework Core** | ORM / Data access layer |
| **SQLite** | Local database |
| **Razor Views** | Server-side HTML templating |
| **HTML/CSS/JavaScript** | Frontend |

## ✨ Features

- ✅ Full **CRUD** operations (Create, Read, Update, Delete)
- ✅ Task **priority levels** (High / Medium / Low)
- ✅ **Status tracking** (Pending / In Progress / Completed)
- ✅ **Filter** tasks by status or priority
- ✅ **Dashboard stats** with live counts
- ✅ **Due date** tracking with overdue alerts
- ✅ **Form validation** (server-side + client-side)
- ✅ Responsive design

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Run Locally

```bash
# Clone the repo
git clone https://github.com/YOUR_USERNAME/DevTrack.git
cd DevTrack/src

# Run the app
dotnet run
```

Then open your browser at: `https://localhost:5001`

The SQLite database is created automatically on first run with sample data.

## 📁 Project Structure

```
DevTrack/
├── src/
│   ├── Controllers/
│   │   └── HomeController.cs      # CRUD actions
│   ├── Models/
│   │   └── TaskItem.cs            # Data model
│   ├── Data/
│   │   └── AppDbContext.cs        # EF Core DbContext + seed data
│   ├── Views/
│   │   ├── Home/
│   │   │   ├── Index.cshtml       # Dashboard
│   │   │   ├── Create.cshtml      # Create form
│   │   │   └── Edit.cshtml        # Edit form
│   │   └── Shared/
│   │       └── _Layout.cshtml     # Master layout
│   ├── wwwroot/
│   │   ├── css/site.css
│   │   └── js/site.js
│   └── Program.cs                 # App entry point
└── .gitignore
```

## 🧠 Key C# / .NET Concepts Demonstrated

- **MVC Architecture** — Controllers, Views, Models separation
- **Dependency Injection** — DbContext injected via constructor
- **Entity Framework Core** — Code-first migrations, LINQ queries
- **Razor Syntax** — `@model`, `@foreach`, Tag Helpers (`asp-action`, `asp-for`)
- **Async/Await** — All DB calls are asynchronous
- **Data Annotations** — `[Required]`, `[StringLength]` for validation
- **Anti-forgery tokens** — CSRF protection on all POST forms

---

Built by **Ravi Reddy** | ASP.NET Core MVC Portfolio Project

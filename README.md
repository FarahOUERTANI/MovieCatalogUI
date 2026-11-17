# 🍿 MovieCatalogUI

The **web front-end** of the Movie Catalog project. It is an **ASP.NET Core MVC** application that fetches movies from the [MovieCatalogApi](https://github.com/FarahOUERTANI/MovieCatalogApi) REST API and displays them in a clean table.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-5C2D91)
![HttpClient](https://img.shields.io/badge/HttpClient-REST%20consumer-0078D4)
![Bootstrap](https://img.shields.io/badge/Bootstrap-UI-7952B3?logo=bootstrap&logoColor=white)

---

## 📖 Overview

This project shows how to **consume a REST API from an ASP.NET Core MVC app**. It doesn't access a database itself; all data comes from MovieCatalogApi over HTTP.

```
 Browser ──▶ MoviesController ──▶ MovieService (HttpClient) ──▶ MovieCatalogApi ──▶ SQL Server
         ◀── Razor view (table) ◀── List<Movie> (JSON → C#) ◀──
```

## ✨ Features

- Displays every movie: title, genre, director, release date and description
- A typed **`HttpClient` service** (`MovieService`) registered through dependency injection
- Case-insensitive JSON deserialization with `System.Text.Json`
- Friendly *"No movies found."* message when the API returns nothing or isn't reachable
- Responsive Bootstrap table layout

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 8 (MVC) |
| HTTP | `IHttpClientFactory` + typed client |
| Serialization | `System.Text.Json` |
| UI | Razor views, Bootstrap |

## 🗂️ Project Structure

```
MovieCatalogUI/
├── Controllers/
│   ├── HomeController.cs      # Home / privacy / error
│   └── MoviesController.cs    # Gets movies from the service → view
├── Models/
│   └── Movie.cs               # Same shape as the API's Movie
├── Services/
│   └── MovieService.cs        # Calls GET api/movies on the API
├── Views/
│   ├── Movies/Index.cshtml    # Movie table
│   └── Shared/                # Layout
└── Program.cs                 # Registers AddHttpClient<MovieService>()
```

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MovieCatalogApi](https://github.com/FarahOUERTANI/MovieCatalogApi) running locally

### 1. Start the API first
Follow the MovieCatalogApi README. The API must be listening on **https://localhost:7240**, which is the address hard-coded in `Services/MovieService.cs`:
```csharp
_httpClient.BaseAddress = new Uri("https://localhost:7240/");
```

### 2. Run the UI
```bash
git clone https://github.com/FarahOUERTANI/MovieCatalogUI.git
cd MovieCatalogUI/MovieCatalogUI
dotnet run --launch-profile https
```

### 3. Open the movie list
Go to **https://localhost:7244/Movies**.

> Tip: in Visual Studio you can start both projects together: right-click the solution → *Configure Startup Projects* → *Multiple startup projects*.

## 🔮 Possible Improvements
- Move the API base URL into `appsettings.json` instead of hard-coding it
- Add create, edit and delete pages that call the API's `POST`, `PUT` and `DELETE` endpoints
- Add a *Movies* link to the navigation bar
- Show an explicit error message when the API is unreachable

## 👩‍💻 Author

**Farah Ouertani** – [github.com/FarahOUERTANI](https://github.com/FarahOUERTANI)

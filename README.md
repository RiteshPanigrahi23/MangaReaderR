# MangaReaderR
# 📚 MangaReaderR

**MangaReaderR** is a full-stack ASP.NET Core MVC web application that lets users browse, read, and manage manga in a sleek, immersive interface. Built with a focus on rapid iteration, visual polish, and user-centric design, it’s designed to feel like a real-world manga platform.

---

## 🚀 Features

- 🔍 **Browse & Search Manga**  
  Explore a curated library of manga with cover images and titles.

- 📖 **Vertical Chapter Reader**  
  Read manga chapters with full-page images in a smooth scroll experience.

- 👤 **User Registration & Login**  
  Anyone can create an account and log in — no admin-only access.

- 🌗 **Theme Toggle & Dropdown Menu**  
  Switch between light/dark modes and access profile/logout options.

- 🕘 **Reading History**  
  Track what you've read and when — personalized for each user.

- 🏠 **Home Dashboard**  
  See popular manga, your reading history, and quick links to explore.

- 📂 **Static Folder-Based Manga Loading**  
  Images are loaded from `wwwroot/manga/{FolderName}/`, making it easy to manage content.

---

## 🛠️ Tech Stack

- **ASP.NET Core MVC** (.NET 9.0)
- **Razor Views** for dynamic UI
- **HTML/CSS/JavaScript** for layout and interactivity
- **Session & Cookie Auth** for user management
- **Local JSON Storage** for users and history
- **Static image folders** for manga content

---

## 📁 Folder Structure
MangaReaderR/
├── Controllers/
├── Models/
├── Views/
│   ├── Home/
│   ├── Manga/
│   └── Shared/
├── wwwroot/
│   ├── images/          # Cover images
│   └── manga/           # Manga folders (e.g. /asura/1.jpg)
├── Data/
│   └── LocalStorage.cs  # In-memory + JSON-backed storage




---

## ⚙️ Getting Started

1. **Clone the repo**  
   ```bash
   git clone https://github.com/yourusername/MangaReaderR.git
   cd MangaReaderR

   - Run the app
dotnet build
dotnet run

- Access in browser
Navigate to http://localhost:5000

🧪 Sample UsersYou can register any username/password. All data is stored in App_Data/users.json.

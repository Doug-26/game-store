# GameStore - Full Stack Application

A full-stack game store application built with Angular and .NET, featuring a modern frontend and a RESTful API backend.

## 🚀 Tech Stack

### Frontend

- **Angular 21.1.0** - Modern Component-based framework
- **TypeScript 5.9** - Type-safe JavaScript
- **RxJS** - Reactive programming
- **Vitest** - Unit testing framework

### Backend

- **.NET 10.0** - Latest .NET framework
- **Entity Framework Core 10.0** - ORM for database operations
- **SQLite** - Lightweight database
- **Minimal APIs** - Modern API endpoints

## 📋 Prerequisites

Before running this project, ensure you have the following installed:

- **Node.js** (v18 or later) - [Download here](https://nodejs.org/)
- **npm** (v11.6.2 or later) - Comes with Node.js
- **.NET 10.0 SDK** - [Download here](https://dotnet.microsoft.com/download)
- **Git** - [Download here](https://git-scm.com/)

### Verify Installation

```bash
# Check Node.js version
node --version

# Check npm version
npm --version

# Check .NET version
dotnet --version
```

## 🏃‍♂️ How to Run the Project Locally

### Step 1: Clone the Repository

```bash
git clone <repository-url>
cd "Angular and DotNet"
```

### Step 2: Run the Backend API

1. **Navigate to the API directory:**

   ```bash
   cd GameStore.Api
   ```

2. **Restore NuGet packages:**

   ```bash
   dotnet restore
   ```

3. **Build the project:**

   ```bash
   dotnet build
   ```

4. **Run the API:**

   ```bash
   dotnet run
   ```

   The API will start and listen on `http://localhost:5000` (or the port specified in launchSettings.json)

   **Note:** The database will be automatically created and migrated on first run.

### Step 3: Run the Angular Frontend

1. **Open a new terminal** and navigate to the Angular directory:

   ```bash
   cd GameStore.Angular
   ```

2. **Install npm packages:**

   ```bash
   npm install
   ```

3. **Start the development server:**

   ```bash
   npm start
   ```

   The application will open automatically in your browser at `http://localhost:4200`

### 🎉 You're All Set!

- **Frontend:** http://localhost:4200
- **Backend API:** http://localhost:5000

## 📁 Project Structure

```
GameStore/
├── GameStore.Api/              # .NET Backend API
│   ├── Data/                   # Database context and extensions
│   │   ├── GameStoreContext.cs
│   │   └── Migrations/
│   ├── DTOs/                   # Data Transfer Objects
│   ├── Endpoints/              # API endpoint definitions
│   │   ├── GamesEndpoints.cs
│   │   └── GenresEndpoints.cs
│   ├── Models/                 # Domain models
│   │   ├── Game.cs
│   │   └── Genre.cs
│   └── Program.cs              # Application entry point
│
├── GameStore.Angular/          # Angular Frontend
│   ├── src/
│   │   ├── app/
│   │   │   ├── core/           # Core services and interceptors
│   │   │   │   ├── interceptors/
│   │   │   │   └── services/
│   │   │   ├── features/       # Feature modules
│   │   │   │   ├── games/
│   │   │   │   └── home/
│   │   │   ├── models/         # TypeScript models
│   │   │   └── shared/         # Shared components
│   │   └── environments/       # Environment configurations
│   └── package.json
│
└── README.md                   # This file
```

## 🔧 Available Scripts

### Backend (GameStore.Api)

```bash
# Run the application
dotnet run

# Run with hot reload
dotnet watch run

# Build the application
dotnet build

# Run tests
dotnet test

# Create a new migration
dotnet ef migrations add <MigrationName>

# Update database
dotnet ef database update
```

### Frontend (GameStore.Angular)

```bash
# Start development server
npm start

# Build for production
npm run build

# Run tests
npm test

# Run tests in watch mode
npm run watch

# Format code
npm run format

# Check code formatting
npm run format:check
```

## 🗄️ Database

The application uses **SQLite** as the database, which is automatically created in the API project directory on first run. The database file is named `GameStore.db`.

### Migrations

Entity Framework Core migrations are used to manage database schema changes. Existing migrations:

- `InitialCreate` - Creates initial Game and Genre tables

## 🌐 API Endpoints

### Games

- `GET /games` - Get all games
- `GET /games/{id}` - Get game by ID
- `POST /games` - Create a new game
- `PUT /games/{id}` - Update a game
- `DELETE /games/{id}` - Delete a game

### Genres

- `GET /genres` - Get all genres

## 🔒 CORS Configuration

The API is configured to allow requests from the Angular frontend running on `http://localhost:4200`. This is set up in [Program.cs](GameStore.Api/Program.cs).

## 🛠️ Development Tools

- **Prettier** - Code formatting (Frontend)
- **TypeScript** - Type checking (Frontend)
- **Entity Framework Core** - Database migrations and queries (Backend)

## 📝 Additional Notes

- The Angular app uses an HTTP interceptor to automatically prepend the API base URL to all HTTP requests
- Hot reload is enabled for both frontend and backend development
- The project uses modern C# features with nullable reference types enabled
- Angular uses standalone components (no modules)

## 🐛 Troubleshooting

### Port Already in Use

If port 4200 or 5000 is already in use:

**Frontend:**

```bash
ng serve --port 4201
```

**Backend:**
Update the port in [Properties/launchSettings.json](GameStore.Api/Properties/launchSettings.json)

### Database Issues

If you encounter database issues, delete the `GameStore.db` file and restart the API. The database will be recreated automatically.

### CORS Errors

Ensure the backend is running before starting the frontend. If you change the frontend port, update the CORS policy in [Program.cs](GameStore.Api/Program.cs).

## 📄 License

This project is for educational purposes.

## 🤝 Contributing

Feel free to submit issues and enhancement requests!

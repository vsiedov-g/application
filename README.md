# 🧾 Desk Booking App

A fullstack desk and room reservation system built with Angular, ASP.NET Core, PostgreSQL, and Docker.

---

## 🚀 Tech Stack

- **Frontend**: Angular + Tailwind CSS
- **Backend**: ASP.NET Core 8 Web API
- **Database**: PostgreSQL
- **Containerization**: Docker + Docker Compose

---

## 📦 Features

- View workspace types (e.g., Open Space, Private Room)
- Select room size
- Book for a specific date range and time slot
- Avoid overlapping reservations
- View and manage your own bookings

---

## ⚙️ Getting Started (With Docker)

### 1. Clone the repo

```bash
git clone https://github.com/vsiedov-g/application.git
cd application
```

###  2. Create .env file
```bash
  POSTGRES_DB=yourdb
  POSTGRES_USER=postgres
  POSTGRES_PASSWORD=postgres
  ASPNETCORE_ENVIRONMENT=Development
```
Place it in the root of the project.

###  3. Build and start containers

```bash
docker compose up --build
```
Your entire app will be available at:

👉 http://localhost:5258

###  🛠️ Manual Steps

Apply migrations manually before first run:

```bash
dotnet ef database update --project application
```

Make sure your connection string in appsettings.json matches the one in docker-compose.yml.



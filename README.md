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

- View coworking spaces
- View workspace types (e.g., Open Space, Private Room)
- Select room size
- Book for a specific date range and time slot
- View and manage your own bookings
- AI Assistant

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
  GROQ_API_KEY=your_groq_api_key
```
Place it in the root of the project.

###  3. Build and start containers

```bash
docker compose up --build
```
Your entire app will be available at:

👉 http://localhost:5258

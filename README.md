# 🚌 ApiAppTransporte (.NET Core)

Este proyecto contiene una API REST para gestionar rutas de transporte, desarrollada con **ASP.NET Core** y desplegada mediante **Docker**.

---

## 🚀 Tecnologías

- .NET Core 8
- ASP.NET Core Web API
- Docker
- C#

---

## 📁 Estructura del Proyecto

- `Controllers/` → Controladores de las rutas
- `Models/` → Clases de dominio (`Usuario`, `Ruta`, etc.)
- `Program.cs` → Configuración principal de la API
- `Dockerfile` → Define cómo construir la imagen Docker
- `launchSettings.json` → Configuración de puertos local
- `appsettings.json` → Configuración general de la app

---

## 🐳 Cómo ejecutar la API en Docker

### 1. Construir la imagen Docker

Desde la raíz del proyecto, ejecuta:

```bash
docker build -t apiapptransporte .
```
```bash
docker run -d -p 5005:5005 --name middleware-api apiapptransporte
```
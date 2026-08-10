# TrainingApp API
API REST desarrollada en ASP.NET Core para la gestión de rutinas y ejercicios de entrenamiento.

## Tecnologías
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (Supabase)
- JWT Authentication

## Funcionalidades

### Rutinas
- Crear, listar, modificar y eliminar rutinas

### Ejercicios
- Crear, listar, modificar y eliminar ejercicios
- Relación Ejercicio - Rutina

### Usuarios
- Registro
- Login con JWT

## Características técnicas
- Uso de DTOs
- Validaciones con Data Annotations
- Autenticación con JWT
- Deploy en Render con base de datos en Supabase

## Cómo probar
1. Accedé a la API online: https://trainingapp-fduy.onrender.com/swagger/index.html
2. Registrate en `/api/auth/register`
3. Hacé login en `/api/auth/login` y copiá el token
4. Usá el token en el botón Authorize de Swagger
5. Probá los endpoints de rutinas y ejercicios

# API Proyecto Clínico

API REST desarrollada en ASP.NET Core 8 para la administración de un sistema clínico/hospitalario.

El proyecto implementa arquitectura por capas utilizando:

* ASP.NET Core 8
* Entity Framework Core
* Repository Pattern
* AutoMapper
* SQL Server / MySQL
* Swagger/OpenAPI
* DTOs
* Arquitectura RESTful

---

# Características

* Gestión de pacientes
* Gestión de doctores
* Gestión de empleados
* Gestión de hospitales
* Gestión de permisos y roles
* Gestión de diagnósticos
* Gestión de medicamentos
* Gestión de facturación
* Gestión de citas médicas
* Documentación Swagger
* Arquitectura escalable

---

# Arquitectura del Proyecto

El proyecto utiliza una arquitectura organizada por capas:

```text
ApiProyecto/
│
├── Controllers/
├── Models/
├── Models/Dtos/
├── Repository/
├── Repository/IRepository/
├── Data/
├── Mappings/
├── Services/
├── Migrations/
├── Properties/
├── appsettings.json
├── Program.cs
└── ApiProyecto.csproj
```

---

# Tecnologías Utilizadas

| Tecnología            | Versión    |
| --------------------- | ---------- |
| .NET                  | 8          |
| ASP.NET Core          | 8          |
| Entity Framework Core | 8          |
| AutoMapper            | 13         |
| Swagger               | OpenAPI    |
| SQL Server            | Compatible |
| MySQL                 | Compatible |

---

# Configuración del Proyecto

## 1. Clonar el repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
```

---

## 2. Entrar al proyecto

```bash
cd ApiProyecto
```

---

## 3. Restaurar dependencias

```bash
dotnet restore
```

---

# Ejecutar el Proyecto

```bash
dotnet run
```

La API estará disponible en:

```text
https://localhost:5001
```

---

# Swagger

La documentación Swagger estará disponible en:

```text
https://localhost:5001/swagger
```

---

# Buenas Prácticas Implementadas

* Uso de DTOs
* Separación de responsabilidades
* Repository Pattern
* Arquitectura RESTful
* Inyección de dependencias
* Manejo de respuestas HTTP
* AutoMapper para mapeo de entidades
* Entity Framework Core para persistencia

---

# Levantar con Docker (desde cero)

Este proyecto incluye una imagen de SQL Server personalizada que crea automáticamente la base de datos `ApiMedico` y todas sus tablas al iniciar.

## Requisitos previos

* [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado y en ejecución

## Pasos

### 1. Clonar el repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
```

### 2. Entrar a la carpeta del proyecto

```bash
cd ApiProyecto
```

### 3. Levantar los contenedores

```bash
docker compose up --build
```

Docker construirá dos imágenes:

| Contenedor  | Descripción                                         |
| ----------- | --------------------------------------------------- |
| `sql`       | SQL Server 2022 con la BD `ApiMedico` inicializada  |
| `api-medico`| API REST en .NET 8 conectada al contenedor `sql`    |

La API estará disponible en:

```
http://localhost:5001
```

Swagger:

```
http://localhost:5001/swagger
```

---

## Reiniciar desde cero (borrar datos)

Si necesitas destruir los contenedores **y el volumen** de la base de datos para volver al estado inicial:

```bash
docker compose down -v
docker compose up --build
```

> **Advertencia:** `down -v` elimina todos los datos almacenados en el volumen `sql_data`. Úsalo solo cuando quieras un entorno completamente limpio.

---

## Comandos útiles

| Comando                        | Descripción                                      |
| ------------------------------ | ------------------------------------------------ |
| `docker compose up --build`    | Construir y levantar todos los contenedores      |
| `docker compose up -d --build` | Levantar en segundo plano (modo detached)        |
| `docker compose down`          | Detener y eliminar contenedores (conserva datos) |
| `docker compose down -v`       | Detener, eliminar contenedores **y volúmenes**   |
| `docker compose logs -f`       | Ver logs en tiempo real                          |
| `docker compose logs -f sql`   | Ver logs solo del contenedor SQL Server          |

---

# Estado del Proyecto

Proyecto en desarrollo.

Próximas mejoras:

* JWT Authentication
* Roles y permisos avanzados
* Validaciones con FluentValidation
* Logging
* Unit Testing
* CI/CD
* Versionado de API

---

# Autor

Victor Corea

Desarrollador Backend especializado en:

* C#
* ASP.NET Core
* Java
* Spring Boot
* SQL Server
* MySQL
* PostgreSQL
* React
* Angular

---

# Licencia

Proyecto de uso académico y educativo.

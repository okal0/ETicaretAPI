# 🛒 ETicaretAPI

The API part of the e-commerce site provides **CRUD operations**.  

---

## Features
- Follows the **Onion Architecture** approach  
- Database management using **Entity Framework Core**  
- Implements **Repository + Unit of Work** pattern  
- Supports **Dependency Injection**  
- **Swagger/OpenAPI** (to be added)  

---

## Layers
- **ETicaretAPI.API** → API entry point (Controllers, Middleware)  
- **ETicaretAPI.Application** → Business logic (Services, Use Cases)  
- **ETicaretAPI.Domain** → Core entities and interfaces  
- **ETicaretAPI.Infrastructure** → External services (e.g., Email, third-party integrations)  
- **ETicaretAPI.Persistence** → Database access (DbContext, Repositories)  

# 🛒 ETicaretAPI

ETicaret sitesinin API kısmında CRUD işlemlerini sağlamaktadır.

## Özellikler
- Onion Architecture yaklaşımı  
- Entity Framework Core ile veritabanı yönetimi  
- Repository + Unit of Work pattern kullanılmıştır
- Dependency Injection desteği  
- Swagger/OpenAPI (eklenecek)  

---

##  Katmanlar
- **ETicaretAPI.API** → API giriş noktası (Controllers, Middleware)  
- **ETicaretAPI.Application** → İş mantığı (Services, Use Cases)  
- **ETicaretAPI.Domain** → Temel varlıklar (Entities, Interfaces)  
- **ETicaretAPI.Infrastructure** → Harici servisler (ör: Mail, dış entegrasyonlar)  
- **ETicaretAPI.Persistence** → Veritabanı erişimi (DbContext, Repositories) 

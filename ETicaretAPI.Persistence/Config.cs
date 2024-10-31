using Microsoft.Extensions.Configuration;


namespace ETicaretAPI.Persistence
{
    static class Config
    {

     public static string GetConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();

                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("DefaultConnection");
                
            }
        }

    }
}

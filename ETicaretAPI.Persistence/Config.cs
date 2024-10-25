using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class Config
    {
        static ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SQL"];

     public static string GetConnectionString
        {
            get
            {
                return settings.ConnectionString;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Data_Objects
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}

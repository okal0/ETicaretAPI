using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exception
{
    public class UserCreateFailedException : System.Exception
    {
        public UserCreateFailedException() : base("Kullanıcı oluşturulurken bir hata ile karşılaşıldı!")
        {
        }

        public UserCreateFailedException(string message) : base(message)
        {

        }

        public UserCreateFailedException(string message, System.Exception innerException) : base(message, innerException)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exception
{
    public class UserLoginFailedException : System.Exception
    {
        public UserLoginFailedException()
        {
        }

        public UserLoginFailedException(string? message) : base(message)
        {
        }

        public UserLoginFailedException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

    }
}

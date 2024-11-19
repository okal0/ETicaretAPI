using ETicaretAPI.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions
{
    public interface IUserService
    {
        public Task<CreateUserResponse> CreateAsync(CreateUser model);
    }
}

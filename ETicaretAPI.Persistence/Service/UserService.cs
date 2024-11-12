using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Data_Objects.User;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ETicaretAPI.Persistence.Service.UserService;

namespace ETicaretAPI.Persistence.Service
{

        public class UserService : IUserService
        {
            readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

            public UserService(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
   
            }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
            {
                IdentityResult result = await _userManager.CreateAsync(new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    Email = model.Email,
                    NameSurname = model.NameSurname,
                }, model.Password);

                CreateUserResponse response = new() { IsSuccees = result.Succeeded };

                if (result.Succeeded)
                    response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
                else
                    foreach (var error in result.Errors)
                        response.Message += $"{error.Code} - {error.Description}\n";

                return response;
            }
        }
}

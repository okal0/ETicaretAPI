using ETicaretAPI.Application.Exception;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity = ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager <Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new Identity.AppUser
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                Email = request.Email,
                UserName = request.UserName
            }, request.Password);

            CreateUserCommandResponse response = new() { IsSuccess = result.Succeeded };                
                
            if(result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else 
                foreach(var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";


            return response;
            //throw new UserCreateFailedException();

        }   
    }
}

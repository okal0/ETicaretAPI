using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exception;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X = ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<X.AppUser> _userManager;
        readonly SignInManager<X.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> manager, SignInManager<Domain.Entities.Identity.AppUser> signInManager, 
            ITokenHandler tokenHandler)
        {
            _userManager = manager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            X.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if(user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            if (user == null)
                throw new UserLoginFailedException();
     
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if(result.Succeeded)
                {
                    TokenDTO token = _tokenHandler.CreateAccessToken(5);
                    return new LoginUserSuccessCommandResponse() { AccessToken = token };
                }

            return new LoginUserErrorCommandResponse() 
            {
                Message = "Kullanıcı adı veya şifre hatalı."
            };

            //throw new AuthenticationErrorException();
    
            
        }
    }
}

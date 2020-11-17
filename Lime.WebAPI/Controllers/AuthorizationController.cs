using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lime.Business.Services.Interfaces;
using Lime.ViewModels.ViewModels;
using Lime.ViewModels.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lime.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        [HttpPost("singin")]
        public async Task<SignInAccountView> SignIn([FromBody] SignInAuthorizationViewModel model)
        {
            //test values for viewModel in postman
            //var result= await _authorizationService.SignIn(new SignInAuthorizationViewModel { Email = $"kjjbjk@gmail.com", Password = "!3422k34P56" });
            return await _authorizationService.SignIn(model);
        }
        [HttpPost("singup")]
        public async Task<string> SingUp([FromBody]SignUpAuthorizationViewModel viewModel)
        {
            //test values for viewModel in postman
            //var viewModel = new SignUpAuthorizationViewModel { UserName = $"qer@gmail.com", Email = $"spofkpsoe@gmail.com", Password = "!3422k34P56" };
            var result=await _authorizationService.SingUp(viewModel);
            return result;
        }

    }
}

using System.Threading.Tasks;
using Lime.Business.Services.Interfaces;
using Lime.ViewModels.ViewModels;
using Lime.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lime.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<AuthorizationController> _logger;
        public AuthorizationController(IAuthorizationService authorizationService, ILogger<AuthorizationController> logger)
        {
            _authorizationService = authorizationService;
            _logger = logger;
            _logger.LogInformation("AuthorizationController is created");
        }
        [HttpPost("singin")]
        public async Task<SignInAccountView> SignIn([FromBody] SignInAuthorizationViewModel model)
        {
            _logger.LogInformation("SignIn by "+model.Email );

            //test values for viewModel in postman
            //var result= await _authorizationService.SignIn(new SignInAuthorizationViewModel { Email = $"kjjbjk@gmail.com", Password = "!3422k34P56" });
            return await _authorizationService.SignIn(model);
        }
        [HttpPost("singup")]
        public async Task<string> SingUp([FromBody]SignUpAuthorizationViewModel viewModel)
        {
            _logger.LogInformation("SingUp by " + viewModel.Email);
            //test values for viewModel in postman
            //var viewModel = new SignUpAuthorizationViewModel { UserName = $"qer@gmail.com", Email = $"spofkpsoe@gmail.com", Password = "!3422k34P56" };
            var result=await _authorizationService.SingUp(viewModel);
            return result;
        }

    }
}


using Lime.ViewModels.ViewModels;
using Lime.ViewModels.Views;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Lime.Business.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<SignInAccountView> SignIn(SignInAuthorizationViewModel viewModel);
        Task<string> SingUp(SignUpAuthorizationViewModel viewModel);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Lime.Business.Services.Interfaces;
using Lime.ViewModels.ViewModels;
using Lime.ViewModels.Views;
using Microsoft.AspNetCore.Mvc;

namespace Lime.WebAPI.Controllers
{
    [Route("api/apartment")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentsService _apartmentsService;
        public ApartmentsController(IApartmentsService apartmentsService)
        {
            _apartmentsService = apartmentsService;
        }
        [HttpGet("get")]
        public async Task<List<GetApartmentView>> GetApartments()
        {
            return await _apartmentsService.GetApartments();
        }
    }
}

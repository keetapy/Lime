using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Lime.Business.Services.Interfaces;
using Lime.ViewModels.ViewModels;
using Lime.ViewModels.Views;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lime.WebAPI.Controllers
{
    [Route("api/apartment")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentsService _apartmentsService;
        private readonly ILogger<ApartmentsController> _logger;

        public ApartmentsController(IApartmentsService apartmentsService, ILogger<ApartmentsController> logger)
        {
            _apartmentsService = apartmentsService;
            _logger = logger;
            _logger.LogInformation("ApartmentsController is created");

        }
        [HttpGet("get")]
        public async Task<List<GetApartmentDapperView>> GetApartments()
        {
            _logger.LogInformation("GetApartments started");

            return await _apartmentsService.GetApartments();
        }
        [HttpGet("getbyid/{id:int}")]
        public async Task<GetApartmentView> GetApartmentsById(int id)
        {
            _logger.LogInformation("GetApartment with id: "+id);

            return await _apartmentsService.GetApartmentById(id);
        }
        [HttpPost("set")]
        public async Task<List<GetApartmentDapperView>> SetApartments(List<SetApartmentsViewModel> viewModels)
        {
            _logger.LogInformation("SetApartments started");

            return await _apartmentsService.SetApartments(viewModels);
        }
    }
}

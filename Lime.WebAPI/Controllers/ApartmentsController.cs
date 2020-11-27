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

namespace Lime.WebAPI.Controllers
{
    [Route("api/apartment")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentsService _apartmentsService;
        public ApartmentsController(IApartmentsService apartmentsService)
        {
            _apartmentsService = apartmentsService;
        }
        [HttpGet("get")]
        public async Task<List<GetApartmentDapperView>> GetApartments()
        {
            return await _apartmentsService.GetApartments();
        }
        [HttpGet("getbyid/{id:int}")]
        public async Task<GetApartmentView> GetApartmentsById(int id)
        {
           
            return await _apartmentsService.GetApartmentById(id);
        }
    }
}

using CatHome.Domain.DTOs.WriteDTOs;
using CatHome.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionApplicationsController : ControllerBase
    {
        private readonly IAdoptionApplicationService _adoptApplicationService;

        public AdoptionApplicationsController(IAdoptionApplicationService adoptApplicationService)
        {
            _adoptApplicationService = adoptApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var applications = await _adoptApplicationService.GetAdoptionApplicationsAsync();
                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAdoptionApplication(AdoptionApplicationWriteDTO application)
        {
            try
            {
                var adoptionApplication = await _adoptApplicationService.PostAdoptionApplication(application);
                return Ok(adoptionApplication);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }
    }
}

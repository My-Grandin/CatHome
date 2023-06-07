using CatHome.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatService _catService;

        public CatsController(ICatService catService)
        {
            _catService = catService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cats = await _catService.GetCatsAsync();
                return Ok(cats);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBamboo.Service;

namespace TaskBamboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoriesService _pService;

        public StoriesController(IStoriesService pService)
        {
            _pService = pService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> bestStories()
        {
            var response = await _pService.bestStories();
            if (response != null) return Ok(response);
            return StatusCode(400);
        }
    }
}

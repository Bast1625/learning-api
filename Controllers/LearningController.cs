using Microsoft.AspNetCore.Mvc;

namespace Learning_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LearningController : ControllerBase
    {
        private readonly ILogger<LearningController> _logger;

        public LearningController(ILogger<LearningController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(id * 2);
        }
    }
}
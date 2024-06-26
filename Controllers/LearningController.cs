using Learning_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learning_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LearningController : ControllerBase
    {
        private readonly ILogger<LearningController> _logger;
        private readonly LearningContext _context;
        public LearningController(ILogger<LearningController> logger, LearningContext context)
        {
            _logger = logger;
            _context = context;
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

        [HttpGet("data")]
        public IActionResult GetData()
        {
            try
            {
                IEnumerable<NewTable> newTables = from newTable in _context.NewTables
                                                  select newTable;

                if (newTables.Any())
                    return Ok(newTables);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
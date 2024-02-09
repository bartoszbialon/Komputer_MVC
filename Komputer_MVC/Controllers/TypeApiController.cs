using Data;
using Microsoft.AspNetCore.Mvc;

namespace Komputer_MVC.Controllers
{
    [Route("api/types")]
    [ApiController]
    public class TypeApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TypeApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllTypes() 
        {
            var types = _context.Types.Select(t => new { id = t.TypeId, typeName = t.TypeName}).ToList();
            return Ok(types);
        }
    }
}

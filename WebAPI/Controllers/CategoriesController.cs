using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedDto;
using SharedLibrary;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CommerceDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(CommerceDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // Get All Categories async
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {

            return _mapper.Map<List<CategoryDto>>( await _context.Categories.Include(c=>c.Products).ToListAsync());
        }

        
    }
}

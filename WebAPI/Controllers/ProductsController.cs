using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedDto;
using SharedLibrary;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CommerceDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(CommerceDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Retrieves all products with their categories.
        /// </summary>
        /// <returns>A list of all products including their category information.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            return _mapper.Map<List<ProductDto>>(await _context.Products.Include(c => c.Category).ToListAsync());
        }

        /// <summary>
        /// Retrieves a single product by its ID along with category information.
        /// Not used in the frontend.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product matching the specified ID, including its category information.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            return _mapper.Map<ProductDto>(await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id));
        }

        /// <summary>
        /// Retrieves products filtered by category ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to filter products by.</param>
        /// <returns>A list of products belonging to the specified category.</returns>
        [HttpGet("GetProductsByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(int categoryId)
        {
            var products = await _context.Products
                            .Where(p => p.CategoryId == categoryId)
                            .Include(p => p.Category)
                            .ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

    }
}

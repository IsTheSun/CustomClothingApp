using CustomClothingApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CustomClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingModelsController : ControllerBase
    {
        private readonly CustomClothingDbContext _context;
        public ClothingModelsController(CustomClothingDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clothingmodel>>> GetClothingModels()
        {
            return await _context.Clothingmodels.ToListAsync();
        }
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Clothingmodel>>> GetClothingModelsByCategory([FromQuery] string? category)
        {
            var query = _context.Clothingmodels.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(m => m.Category == category);
            }
            var filteredModels = await query.ToListAsync();
            return Ok(filteredModels);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Clothingmodel>> GetClothingModel(int id)
        {
            var model = await _context.Clothingmodels.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }
        [HttpPost]
        public async Task<ActionResult<Clothingmodel>> PostClothingModel(Clothingmodel model)
        {
            _context.Clothingmodels.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClothingModel), new { id = model.Modelid }, model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingModel(int id, Clothingmodel model)
        {
            if (id != model.Modelid)
            {
                return BadRequest();
            }
            _context.Entry(model).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingModel(int id)
        {
            var model = await _context.Clothingmodels.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            _context.Clothingmodels.Remove(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool ClothingModelExists(int id)
        {
            return _context.Clothingmodels.Any(e => e.Modelid == id);
        }
    }
}

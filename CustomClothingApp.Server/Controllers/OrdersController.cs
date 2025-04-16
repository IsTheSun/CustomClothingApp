using CustomClothingApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CustomClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CustomClothingDbContext _context;
        public OrdersController(CustomClothingDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Measurements)
                .Include(o => o.Model)
                .FirstOrDefaultAsync(o => o.Orderid == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }
        [HttpPost]
        public async Task<IActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (order.Userid == null || order.Measurementsid == null)
            {
                return BadRequest("Идентификаторы пользователя и измерений должны быть указаны.");
            }
            if (order.Createddate == null)
            {
                order.Createddate = DateTime.UtcNow;
            }
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetOrder), new { id = order.Orderid }, order);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении заказа: {ex.Message}");
                return StatusCode(500, "Ошибка сервера при сохранении заказа.");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Orderid)
            {
                return BadRequest();
            }
            _context.Entry(order).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Orderid == id);
        }
    }
}

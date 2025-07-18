// Controllers/CartController.cs
using Microsoft.AspNetCore.Mvc;
using CartService.Models;


using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly CartDbContext _context;
    public CartController(CartDbContext context) => _context = context;

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCart(string userId)
    {
        var items = await _context.CartItems.Where(c => c.UserId == userId).ToListAsync();
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem(CartItem item)
    {
        _context.CartItems.Add(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, CartItem updatedItem)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item == null) return NotFound();

        item.Quantity = updatedItem.Quantity;
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveItem(int id)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item == null) return NotFound();

        _context.CartItems.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

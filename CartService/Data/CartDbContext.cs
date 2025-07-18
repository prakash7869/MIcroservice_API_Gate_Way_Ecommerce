// Data/CartDbContext.cs
using CartService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class CartDbContext : DbContext
{
    public CartDbContext(DbContextOptions<CartDbContext> options) : base(options) { }

    public DbSet<CartItem> CartItems { get; set; }
}

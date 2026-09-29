using CafeteriaWeb.Models;
using Microsoft.EntityFrameworkCore;

public class CafeteriaContext : DbContext
{
    public CafeteriaContext(DbContextOptions<CafeteriaContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
}

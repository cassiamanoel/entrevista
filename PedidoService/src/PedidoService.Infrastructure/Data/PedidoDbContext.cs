using Microsoft.EntityFrameworkCore;
using PedidoService.Domain.Entities;

namespace PedidoService.Infrastructure.Data;

public class PedidoDbContext : DbContext
{
    public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options) { }

    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>()
            .HasMany(p => p.Itens)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

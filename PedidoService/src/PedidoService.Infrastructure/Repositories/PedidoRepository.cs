using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PedidoService.Domain.Entities;
using PedidoService.Domain.Interfaces;
using PedidoService.Infrastructure.Data;

namespace PedidoService.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly PedidoDbContext _context;

    public PedidoRepository(PedidoDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
    }
    public async Task<Pedido?> ObterPorIdAsync(int id)
    {
        return await _context.Pedidos
            .Include(p => p.Itens)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Pedido>> ListarPorStatusAsync(string status)
    {
        return await _context.Pedidos
            .Include(p => p.Itens)
            .Where(p => p.Status == status)
            .ToListAsync();
    }

    public async Task<bool> ExisteDuplicadoAsync(int pedidoId)
    {
        return await _context.Pedidos.AnyAsync(p => p.PedidoId == pedidoId);
    }
}
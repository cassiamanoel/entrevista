using System.Collections.Generic;
using PedidoService.Domain.Entities;

namespace PedidoService.Application.DTOs;

public class PedidoRequest
{
    public int PedidoId { get; set; }
    public int ClienteId { get; set; }
    public List<ItemPedidoRequest> Itens { get; set; } = new();
}

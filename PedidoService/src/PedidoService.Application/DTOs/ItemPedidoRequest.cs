using System.Collections.Generic;
using PedidoService.Domain.Entities;

namespace PedidoService.Application.DTOs;

public class ItemPedidoRequest
{
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }
}
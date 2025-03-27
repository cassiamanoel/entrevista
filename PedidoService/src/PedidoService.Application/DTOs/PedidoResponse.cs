using System.Collections.Generic;
using PedidoService.Domain.Entities;
using System.Linq;

namespace PedidoService.Application.DTOs;

public class PedidoResponse
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int ClienteId { get; set; }
    public decimal Imposto { get; set; }
    public string Status { get; set; }
    public List<ItemPedidoResponse> Itens { get; set; }

    public PedidoResponse(Pedido pedido)
    {
        Id = pedido.Id;
        PedidoId = pedido.PedidoId;
        ClienteId = pedido.ClienteId;
        Imposto = pedido.Imposto;
        Status = pedido.Status;
        Itens = pedido.Itens.Select(i => new ItemPedidoResponse
        {
            ProdutoId = i.ProdutoId,
            Quantidade = i.Quantidade,
            Valor = i.Valor
        }).ToList();
    }
}
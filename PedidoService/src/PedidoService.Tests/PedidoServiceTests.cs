using PedidoService.Application.DTOs;
using PedidoService.Domain.Entities;
using PedidoService.Domain.Interfaces;
using PedidoService.Infrastructure.Services;
using FluentAssertions;
using NSubstitute;

public class PedidoServiceTests
{
    private readonly IPedidoRepository _repository = Substitute.For<IPedidoRepository>();
    private readonly IFeatureFlagService _featureFlag = Substitute.For<IFeatureFlagService>();
    private readonly PedidoService _service;

    public PedidoServiceTests()
    {
        _service = new PedidoService(_repository, _featureFlag);
    }

    [Fact]
    public async Task CriarPedidoAsync_DeveCalcularImpostoCorreto_ComNovaRegra()
    {
        _repository.ExisteDuplicadoAsync(Arg.Any<int>()).Returns(false);
        _featureFlag.UsarNovaRegra().Returns(true);

        var request = new PedidoRequest
        {
            PedidoId = 1,
            ClienteId = 10,
            Itens = new List<ItemPedidoRequest>
            {
                new() { ProdutoId = 100, Quantidade = 2, Valor = 50 }
            }
        };

        var result = await _service.CriarPedidoAsync(request);

        result.Imposto.Should().Be(20); // 100 * 0.2
    }

    [Fact]
    public async Task CriarPedidoAsync_DeveLancarExcecao_SePedidoDuplicado()
    {
        _repository.ExisteDuplicadoAsync(Arg.Any<int>()).Returns(true);

        var request = new PedidoRequest { PedidoId = 1, ClienteId = 1 };

        var act = async () => await _service.CriarPedidoAsync(request);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Pedido duplicado.");
    }
}

using PedidoService.Domain.Interfaces;

namespace PedidoService.Infrastructure.Services
{
    public class FeatureFlagService : IFeatureFlagService
    {
        public bool IsNovaRegraTributariaAtiva()
        {
            return true;
        }
    }
}

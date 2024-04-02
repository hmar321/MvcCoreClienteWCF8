using ServiceReferenceMetodosVarios;

namespace MvcCoreClienteWCF8.Services
{
    public class ServiceMetodosVarios
    {
        private MetodosVariosContractClient client;

        public ServiceMetodosVarios(MetodosVariosContractClient client)
        {
            this.client = client;
        }

        public async Task<int[]> GetTablaMultiplicarAsync(int numero)
        {
            int[] tabla = await this.client.GetTablaMultiplicarAsync(numero);
            return tabla;
        }
    }
}

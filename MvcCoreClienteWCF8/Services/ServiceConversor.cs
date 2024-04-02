using ServiceNumberConversor;
namespace MvcCoreClienteWCF8.Services
{
    public class ServiceConversor
    {
        private NumberConversionSoapTypeClient client;

        public ServiceConversor()
        {
            this.client = new NumberConversionSoapTypeClient(NumberConversionSoapTypeClient.EndpointConfiguration.NumberConversionSoap);
        }

        public async Task<string> ConverNumberToWordsAsync(string numbers)
        {
            ulong numeros = ulong.Parse(numbers);
            NumberToWordsResponse response=await this.client.NumberToWordsAsync(numeros);
            string data = response.Body.NumberToWordsResult;
            return data;
        }
    }
}

using MvcCoreClienteWCF8.Models;
using ServiceReferenceCatastro;
using System.Xml;
using System.Xml.Linq;

namespace MvcCoreClienteWCF8.Services
{
    public class ServiceCatastro
    {
        private CallejerodelasedeelectrónicadelcatastroSoapClient client;

        public ServiceCatastro(CallejerodelasedeelectrónicadelcatastroSoapClient client)
        {
            this.client = client;
        }

        public async Task<List<Provincia>> GetProvinciasAsync()
        {
            ConsultaProvincia1 response = await this.client.ObtenerProvinciasAsync();
            XmlNode nodoProvincias = response.Provincias;
            string dataXml = nodoProvincias.OuterXml;
            XDocument document = XDocument.Parse(dataXml);
            XNamespace ns = "http://www.catastro.meh.es/";
            var consulta = from datos in document.Descendants(ns + "prov")
                           select new Provincia
                           {
                               IdProvincia = int.Parse(datos.Element(ns + "cpine").Value),
                               Nombre = datos.Element(ns + "np").Value
                           };
            return consulta.ToList();
        }

        public async Task<List<string>> GetMunicipioAsync(string provincia)
        {
            ConsultaMunicipio1 response=await this.client.ObtenerMunicipiosAsync(provincia,null);
            XmlNode nodo=response.Municipios;
            string dataXml = nodo.OuterXml;
            XDocument document = XDocument.Parse(dataXml);
            XNamespace ns = "http://www.catastro.meh.es/";
            var consulta = from datos in document.Descendants(ns + "muni")
                           select datos.Element(ns + "nm").Value;
            return consulta.ToList();
        }
    }
}

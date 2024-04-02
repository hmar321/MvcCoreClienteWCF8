using MvcCoreClienteWCF8.Helpers;
using MvcCoreClienteWCF8.Models;
using System.Xml.Linq;

namespace MvcCoreClienteWCF8.Repositories
{
    public class RepositoryCliente
    {
        private HelperPathProvider helper;

        public RepositoryCliente(HelperPathProvider helper)
        {
            this.helper = helper;
        }

        public List<Cliente> GetClientes()
        {
            string path = this.helper.MapPath("ClientesID.xml", Folders.Documents);
            XDocument document = XDocument.Load(path);
            //from datos in document.Descentants("TAG")
            //where ..
            //select datos;
            var consulta = from datos in document.Descendants("CLIENTE")
                           select datos;
            //EXTRAEMOS LOS ELEMENTOS XElement DE LA CONSULTA
            List<Cliente> clientesList = new List<Cliente>();
            foreach (XElement tag in consulta)
            {
                Cliente cliente = new Cliente
                {
                    IdCliente = int.Parse(tag.Element("IDCLIENTE").Value),
                    Nombre = tag.Element("NOMBRE").Value,
                    Direccion = tag.Element("DIRECCION").Value,
                    Email = tag.Element("EMAIL").Value,
                    ImagenCliente = tag.Element("IMAGENCLIENTE").Value
                };
                clientesList.Add(cliente);
            }
            return clientesList;
        }

        public Cliente FindCLiente(int idcliente)
        {
            string path = this.helper.MapPath("ClientesID.xml", Folders.Documents);
            XDocument document = XDocument.Load(path);
            var consulta = from datos in document.Descendants("CLIENTE")
                           where datos.Element("IDCLIENTE").Value == idcliente.ToString()
                           select new Cliente
                           {
                               IdCliente = int.Parse(datos.Element("IDCLIENTE").Value),
                               Nombre = datos.Element("NOMBRE").Value,
                               Direccion = datos.Element("DIRECCION").Value,
                               Email = datos.Element("EMAIL").Value,
                               ImagenCliente = datos.Element("IMAGENCLIENTE").Value
                           };
            return consulta.FirstOrDefault();
        }
    }
}

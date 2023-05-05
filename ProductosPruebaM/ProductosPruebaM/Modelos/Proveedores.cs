using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProductosPruebaM.Modelos
{
    public class Proveedores
    {
        public int Id { get; set; }
        public string Ruc { get; set; } = string.Empty;
        public string NombreProveedor { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        //public string Estado { get; set; }
        public bool Estado { get; set; }

    }
}
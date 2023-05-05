using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProductosPruebaM.Modelos
{
    public class Compras
    {
        public int Id { get; set; }

        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }

        [DisplayName("Producto")]
        public int IdProducto { get; set; }

        [DisplayName("Trabajador")]
        public int IdTrabajador { get; set; }

        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }

        [DisplayName("Boleta")]
        public string? Boleta { get; set; }
        public string? Observaciones { get; set; }

        public bool Estado { get; set; }

        [NotMapped]
        public IFormFile? BoletaIFormFile { get; set; }
        public string BoletaURL => Boleta == null ? "" : Boleta;

        public string BoletaURL2
        {
            get
            {
                if (string.IsNullOrEmpty(Boleta))
                {
                    return "";
                }
                else
                {
                    return $"https://localhost:7271/{Boleta}";
                }
            }
        }

        [NotMapped]
        public string TrabajadorDescripcion { get; set; } = string.Empty;
        [NotMapped]
        public int IdZona { get; set; }
        [NotMapped]
        public int IdCategoria { get; set; }
        [NotMapped]
        public string? NombreProducto { get; set; }
        [NotMapped]
        public string? Marca { get; set; }
        [NotMapped]
        public string? UnidadMedida { get; set; }
        [NotMapped]
        public int Precio { get; set; }
        [NotMapped]
        public int Stock { get; set; }
        [NotMapped]
        public DateTime FechaVencimiento { get; set; }
        [NotMapped]
        public int IdProveedor { get; set; }
    }
}

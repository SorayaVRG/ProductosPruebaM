using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductosPruebaM.Modelos
{
    public class Productos
    {
        public int Id { get; set; }

        [DisplayName("Categoria")]
        public int IdCategoria { get; set; }

        [DisplayName("Nombre Producto")]
        public string? NombreProducto { get; set; }

        [DisplayName("Marca")]
        public string? Marca { get; set; }

        [DisplayName("Unidad Medida")]
        public string? UnidadMedida { get; set; }

        [DisplayName("Precio")]
        public decimal Precio { get; set; }

        [DisplayName("Stock")]
        public decimal Stock { get; set; }

        [DisplayName("Fecha Vencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [DisplayName("Proveedores")]
        public int IdProveedor { get; set; }

        [DisplayName("Documento Tecnico")]
        public string? DocumentoTecnico { get; set; }
        [NotMapped]
        public IFormFile? DocumentoTecnicoIFormFile { get; set; }
        public string DocumentoTecnicoURL => DocumentoTecnico == null ? "" : DocumentoTecnico;

        public string DocumentoTecnicoURL2
        {
            get
            {
                if (string.IsNullOrEmpty(DocumentoTecnico))
                {
                    return "";
                }
                else
                {
                    return $"https://localhost:7271/{DocumentoTecnico}";
                }
            }
        }

        [DisplayName("Imagen")]
        public string? Imagen { get; set; }
        [NotMapped]
        public IFormFile? ImagenIFormFile { get; set; }
        public string ImagenURL => Imagen == null ? "" : Imagen;

        public string ImagenURL2
        {
            get
            {
                if (string.IsNullOrEmpty(Imagen))
                {
                    return "";
                }
                else
                {
                    return $"https://localhost:7271/{Imagen}";
                }
            }
        }

        public bool Estado { get; set; }
        [NotMapped]
        public string? ProveedorDescripcion { get; set; }
        [NotMapped]
        public int IdZona { get; set; }
    }
}
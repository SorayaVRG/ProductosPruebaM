using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProductosPruebaM.Modelos
{
    public class PR_PRODUCTOS_Q01
    {
        public int Id { get; set; }

        [DisplayName("Categoria")]
        public string NombreCategoria { get; set; } = string.Empty;

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
        public string NombreProveedor { get; set; } = string.Empty;

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
        public string Imagen { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile ImagenIFormFile { get; set; }
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

        [DisplayName("Zona")]
        [NotMapped]
        public int IdZona { get; set; }
        public string NombreZona { get; set; } = string.Empty;

    }
}
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProductosPruebaM.Modelos
{
    public class PR_COMPRAS_S01
    {
        [DisplayName("IdCompras")]
        public int Id { get; set; }

        [DisplayName("NombreZona")]
        public string? Zona { get; set; }

        [DisplayName("NombreCategoria")]
        public string? Categoria { get; set; }

        [DisplayName("NombreProducto")]
        public string? Producto { get; set; }

        [DisplayName("NombreTrabajador")]
        public string? Trabajador { get; set; }

        [DisplayName("TipoDocumento")]
        public string? TipoDocumento { get; set; }

        [DisplayName("NumeroDocumento")]
        public string? NumeroDocumento { get; set; }

        [DisplayName("Sexo")]
        public string? Sexo { get; set; }

        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }

        [DisplayName("PrecioUnitario")]
        public decimal PrecioUnitario { get; set; }

        [DisplayName("PrecioFinal")]
        public decimal PrecioFinal { get; set; }

        [DisplayName("Boleta")]
        public string? Boleta { get; set; }
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

        [DisplayName("Estado")]
        public bool Estado { get; set; }

        [DisplayName("Observaciones")]
        public string Observaciones { get; set; }

    }
}

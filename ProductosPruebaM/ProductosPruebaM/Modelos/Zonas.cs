using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProductosPruebaM.Modelos
{
    public class Zonas
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Zonas")]
        public string NombreZona { get; set; } = string.Empty;
    }
}
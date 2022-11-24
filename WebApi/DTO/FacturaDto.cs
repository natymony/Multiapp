using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO
{
    public class FacturaDto
    {
        [Key]
        public int numero { get; set; }
        public DateTime fecha { get; set; }
        public decimal valor { get; set; }
        public string descripcion { get; set; }
    }
}

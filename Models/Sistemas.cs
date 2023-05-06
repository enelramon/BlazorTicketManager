using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models
{
    public class Sistemas
    {
        [Key]
        public int SistemaId { get; set; }

        [Required (ErrorMessage ="El nombre del sistema es obligatorio")]
        public String? Nombre { get; set; }
    }
}

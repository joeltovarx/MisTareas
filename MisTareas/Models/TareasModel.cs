using System.ComponentModel.DataAnnotations;

namespace MisTareas.Models
{
    public class TareasModel
    {
        public int idTarea { get; set; }
        public string? fecha { get; set; }
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string? descripcion { get; set; }
        public string? estado { get; set; }
    }
}

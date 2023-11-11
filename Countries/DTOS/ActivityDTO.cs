using System.ComponentModel.DataAnnotations;

namespace Countries.DTOS
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        [Required]
        public int Dificultad { get; set; }
        [Required]
        public int Duracion { get; set; }
        public string Temporada { get; set; }
    }
}

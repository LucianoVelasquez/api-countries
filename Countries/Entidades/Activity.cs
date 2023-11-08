using System.ComponentModel.DataAnnotations;

namespace Countries.Entidades
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        public int Dificultad { get; set; }
        [Required]
        public int Duracion { get; set; }
        public string Temporada { get; set; }
    }
}

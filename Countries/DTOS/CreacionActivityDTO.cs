using System.ComponentModel.DataAnnotations;

namespace Countries.DTOS
{
    public class CreacionActivityDTO
    {

        public int Dificultad { get; set; }
        [Required]
        public int Duracion { get; set; }
        public string Temporada { get; set; }
        public List<int> CountryIds { get; set; }
    }
}

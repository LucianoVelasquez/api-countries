using System.ComponentModel.DataAnnotations;

namespace Countries.DTOS
{
    public class CountryDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Bandera { get; set; }
        [Required]
        public string Continente { get; set; }
        [Required]
        public string Capital { get; set; }
        public string SubRegion { get; set; }
        public string Area { get; set; }
        [Required]
        public int Poblacion { get; set; }
    }
}

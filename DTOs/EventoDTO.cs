using System.ComponentModel.DataAnnotations;

namespace InfoCad.DTOs
{
    public class EventoDTO
    {
        public int EventoId { get; set; }
        [Required]
        [StringLength(80)]
        public string Titulo { get; set; }
        public string UrlImagem { get; set; }
        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }
        public string UrlEdital { get; set; }
        public DateTime DataEvento { get; set; }
    }
}

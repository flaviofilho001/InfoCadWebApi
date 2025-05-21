using System.ComponentModel.DataAnnotations;

namespace InfoCad.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }
        public string Titulo { get; set; }
        public string UrlImagem { get; set; }
        public string Descricao { get; set; }
        public string UrlEdital { get; set; }
        public DateTime DataEvento { get; set; }

    }
}

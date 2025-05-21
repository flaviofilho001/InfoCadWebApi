using System.ComponentModel.DataAnnotations;

namespace InfoCad.Models
{
    public class Noticia
    {
        [Key]
        public int NoticiaId { get; set; }

        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string UrlImagem { get; set; }
        public string Descricao { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace InfoCad.Models
{
    public class Notificacao
    {
        [Key]
        public int NotificacaoId { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }


    }
}

using InfoCad.Models;

namespace InfoCad.DTOs.Mappings
{
    public static class EventoDTOMappingExtensions
    {
        public static EventoDTO? ToEventoDTO(this Evento evento)
        {
            if (evento is null)
                return null;

            return new EventoDTO
            {
                EventoId = evento.EventoId,
                Titulo = evento.Titulo,
                UrlImagem = evento.UrlImagem,
                Descricao = evento.Descricao,
                UrlEdital = evento.UrlEdital,
                DataEvento = evento.DataEvento 
            };
        }

        public static Evento? ToEvento(this EventoDTO eventoDTO)
        {
            if (eventoDTO is null) return null;

            return new Evento
            {
                EventoId = eventoDTO.EventoId,
                Titulo = eventoDTO.Titulo,
                UrlImagem = eventoDTO.UrlImagem,
                Descricao = eventoDTO.Descricao,
                UrlEdital = eventoDTO.UrlEdital,
                DataEvento = eventoDTO.DataEvento
            };
        }

        public static IEnumerable<EventoDTO> ToEventoDTOList(this IEnumerable<Evento> eventos)
        {
            if (eventos is null || !eventos.Any())
            {
                return new List<EventoDTO>();
            }

            return eventos.Select(evento => new EventoDTO
            {
                EventoId = evento.EventoId,
                Titulo = evento.Titulo,
                UrlImagem = evento.UrlImagem,
                Descricao = evento.Descricao,
                UrlEdital = evento.UrlEdital,
                DataEvento = evento.DataEvento

            }).ToList();
        }
    }
}

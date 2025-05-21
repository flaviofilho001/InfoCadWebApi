using InfoCad.Context;
using InfoCad.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoCad.Repositories
{
    public class EventoRespository : Repository<Evento> , IEventoRepository
    {

        public EventoRespository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Evento> GetEventoPorNome(string nome)
        {
            return GetAll().Where(e => e.Titulo == nome);
        }

    }
}

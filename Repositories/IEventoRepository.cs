using InfoCad.Models;

namespace InfoCad.Repositories
{
    public interface IEventoRepository : IRepository<Evento>
    {
        IEnumerable<Evento> GetEventoPorNome(string nome);
    }
}

using InfoCad.Models;
namespace InfoCad.Repositories
{
    public interface INotificacaoRepository
    {
       IQueryable<Notificacao> GetNotificacoes();
       Notificacao GetNotificacao(int id);
       Notificacao Create(Notificacao notificacao);    
       bool Update(Notificacao notificacao);
       bool Delete(int id);

    }
}

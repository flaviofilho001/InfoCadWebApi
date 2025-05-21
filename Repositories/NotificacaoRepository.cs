using InfoCad.Context;
using InfoCad.Models;

namespace InfoCad.Repositories
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly AppDbContext _context;

        public NotificacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Notificacao> GetNotificacoes()
        {
            return _context.Notificacaos;
        }
        public Notificacao GetNotificacao(int id)
        {
            var notificacao = _context.Notificacaos.FirstOrDefault(n => n.NotificacaoId == id);
            if (notificacao == null) { throw new InvalidOperationException("Produto é null"); }
            return notificacao;

        }

        public Notificacao Create(Notificacao notificacao)
        {
            if (notificacao == null) { throw new InvalidOperationException("Produto é null"); }

            _context.Notificacaos.Add(notificacao);
            _context.SaveChanges();
            return notificacao;

        }

        public bool Update(Notificacao notificacao)
        {
            if (notificacao == null) { throw new InvalidOperationException("Produto é null"); }
            if (_context.Notificacaos.Any(n => n.NotificacaoId == notificacao.NotificacaoId)) 
            {

                _context.Notificacaos.Update(notificacao);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var notificacao = _context.Notificacaos.Find(id);
            
            if(notificacao is not null)
            {
                _context.Notificacaos.Remove(notificacao);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}

using InfoCad.Context;
using InfoCad.Models;

namespace InfoCad.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IEventoRepository? _eventoRepo;
    private INotificacaoRepository? _notificacaoRepo;

    public AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IEventoRepository EventoRepository
    {
        get
        {
            return _eventoRepo = _eventoRepo ?? new EventoRespository(_context);
            //if (_produtoRepo == null)
            //{
            //    _produtoRepo = new ProdutoRepository(_context);
            //}
            //return _produtoRepo;
        }
    }

    public INotificacaoRepository NotificacaoRepository
    {
        get
        {
            return _notificacaoRepo = _notificacaoRepo ?? new NotificacaoRepository(_context);
        }
    }

    public void Commit()
    {
        _context.SaveChanges();
    } 

    public void Dispose()
    {
        _context.Dispose();
    }
}

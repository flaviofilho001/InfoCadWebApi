using InfoCad.Repositories;

namespace InfoCad.Repositories;

public interface IUnitOfWork
{ //aqui vou adicionar os repositórios que eu tenho, esse é um repositório de repositorio
    IEventoRepository EventoRepository { get; }
    INotificacaoRepository NotificacaoRepository { get; }
    void Commit();
}

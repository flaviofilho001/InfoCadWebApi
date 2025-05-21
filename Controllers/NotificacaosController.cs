using InfoCad.Context;
using InfoCad.Models;
using InfoCad.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoCad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificacaosController : ControllerBase
    {
        private readonly INotificacaoRepository _repository;
        private readonly ILogger<NotificacaosController> _logger;

        public NotificacaosController(INotificacaoRepository repository, ILogger<NotificacaosController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Notificacao>> Get()
        {
            var notificacoes = _repository.GetNotificacoes().ToList();

            if (notificacoes is null || !notificacoes.Any())
            {

                return NotFound("Não foram encontradas notificações.");
            }

            return notificacoes;
        }

        [HttpGet("{id:int}", Name = "ObterNotificacao")]
        public ActionResult<Notificacao> Get(int id)
        {
            var notificacao = _repository.GetNotificacao(id);
            if (notificacao is null)
            {
                _logger.LogWarning($"Evento com {id} não encontrado");

                return NotFound("Notificação não encontrada.");
            }
            return Ok(notificacao);
        }

        [HttpPost]
        public ActionResult Post(Notificacao notificacao)
        {
            if (notificacao is null)
            {
                _logger.LogWarning($"Dados inválidos");
                return BadRequest("Notificação inválida ou com informações em falta.");


            }
            var novaNotificacao = _repository.Create(notificacao);
            return new CreatedAtRouteResult("ObterNotificacao", new { id = novaNotificacao.NotificacaoId }, novaNotificacao);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Notificacao notificacao)
        {
            if (id != notificacao.NotificacaoId)
            {
                    _logger.LogWarning($"Dados inválidos");
                    return BadRequest("Notificação inválida ou com informações em falta.");
            }
            bool atualizado = _repository.Update(notificacao);
            if (atualizado)
            {
                return Ok(notificacao);
            }
            else
            {
                return StatusCode(500, $"Notificacao de Id = {id} ,não foi atualizada.");
            }

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            bool deletado = _repository.Delete(id);
            if (deletado)
            {
                return Ok($"Produto de id = {id} foi apagado");
            }
            else
            {
                return StatusCode(500, $"Notificacao de Id = {id} ,não foi apagado.");

            }
        }
    }
}

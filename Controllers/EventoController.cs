using InfoCad.Context;
using InfoCad.Models;
using InfoCad.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoCad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IEventoRepository _eventoRepository;
        private readonly ILogger<EventoController> _logger;

        public EventoController(ILogger<EventoController> logger, IEventoRepository eventoRepository,IUnitOfWork uof)
        {
            _uof = uof;
            _logger = logger; 
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
           var eventos = _uof.EventoRepository.GetAll();
            return Ok(eventos);

        }

        [HttpGet("{id:int}", Name = "ObterEvento")]
        public ActionResult<Evento> Get(int id)
        {
            var evento = _uof.EventoRepository.Get(c => c.EventoId == id);
            if (evento is null)
            {
                _logger.LogWarning($"Evento com {id} não encontrado");
                return NotFound("Evento não encontrado");
            }
            return Ok(evento);
        }

        [HttpGet("nome/{nome:length(3,40)}")]
        public ActionResult<Evento> GetNome(string nome)
        {
            var evento = _eventoRepository.GetEventoPorNome(nome);
            if (evento is null)
            {
                _logger.LogWarning($"Evento com {nome} não encontrado");
                return NotFound("Evento não encontrado");
            }
            return Ok(evento);
        }

        [HttpPost]
        public ActionResult Post(Evento evento)
        {
            if (evento is null) {
                _logger.LogWarning($"Dados inválidos");
                return BadRequest("Evento inválido ou com informações em falta");
            }
            
            var eventoCriado = _uof.EventoRepository.Create(evento);
            _uof.Commit();
            return new CreatedAtRouteResult("ObterEvento", new { id = eventoCriado.EventoId }, eventoCriado);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Evento evento)
        {
            if (id != evento.EventoId) {
                _logger.LogWarning($"Dados inválidos");
                return BadRequest("Evento inválido ou com informações em falta");
            }
            _uof.EventoRepository.Update(evento);
            _uof.Commit();


            return Ok(evento);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            
            var evento = _uof.EventoRepository.Get(c => c.EventoId == id);
            if (evento is null) return NotFound("Evento não localizado");

            var categoriaExcluida = _uof.EventoRepository.Delete(evento);
            _uof.Commit();

            return Ok(categoriaExcluida);

        }

    }
}

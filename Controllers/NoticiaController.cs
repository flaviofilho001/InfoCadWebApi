using InfoCad.Context;
using InfoCad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoCad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NoticiaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Noticia>> Get()
        {
            var noticias = _context.Noticias.ToList();

            if (noticias is null || !noticias.Any())
            {
                return NotFound("Não foram encontradas notícias.");
            }

            return noticias;
        }

        [HttpGet("{id:int}", Name = "ObterNoticia")]
        public ActionResult<Noticia> Get(int id)
        {
            var noticia = _context.Noticias.FirstOrDefault(p => p.NoticiaId == id);
            if (noticia is null)
            {
                return NotFound("Notícia não encontrada.");
            }
            return noticia;
        }

        [HttpPost]
        public ActionResult Post(Noticia noticia)
        {
            if (noticia is null)
                return BadRequest("Notícia inválida ou com informações em falta.");

            _context.Noticias.Add(noticia);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterNoticia", new { id = noticia.NoticiaId }, noticia);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Noticia noticia)
        {
            if (id != noticia.NoticiaId)
                return BadRequest("IDs não coincidem.");

            _context.Entry(noticia).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(noticia);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var noticia = _context.Noticias.FirstOrDefault(p => p.NoticiaId == id);
            if (noticia is null)
                return NotFound("Notícia não localizada.");

            _context.Noticias.Remove(noticia);
            _context.SaveChanges();

            return Ok(noticia);
        }
    }
}

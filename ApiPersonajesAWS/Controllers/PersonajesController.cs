using ApiPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private PersonajesRepository _repository;

        public PersonajesController(PersonajesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonajes()
        {
            var personajes = await _repository.GetPersonajesAsync();
            return Ok(personajes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindPersonaje(int id)
        {
            var personaje = await _repository.FindPersonajeAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }
            return Ok(personaje);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonaje([FromBody] Models.Personaje personaje)
        {
            if (personaje == null)
            {
                return BadRequest("El personaje no puede ser nulo.");
            }
            await _repository.CreatePersonajeAsync(personaje);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonaje([FromBody] Models.Personaje personaje)
        {
            if (personaje == null)
            {
                return BadRequest("El personaje no puede ser nulo.");
            }
            await _repository.UpdatePersonajeAsync(personaje);
            return Ok();
        }


    }
}

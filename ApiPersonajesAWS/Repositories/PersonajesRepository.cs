using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Repositories
{
    public class PersonajesRepository
    {

        private PersonajesContext _context;

        public PersonajesRepository(PersonajesContext context)
        {
            _context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await _context.Personajes.ToListAsync();
        }

        public async Task<int> GetMaxIdPersonajeAsync()
        {
            return await _context.Personajes.MaxAsync(p => p.IdPersonaje);
        }

        public async Task CreatePersonajeAsync(Personaje personaje)
        {
            var maxId = await GetMaxIdPersonajeAsync();
            personaje.IdPersonaje = maxId + 1;
            await _context.Personajes.AddAsync(personaje);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(Personaje personaje)
        {
            _context.Personajes.Update(personaje);
            await _context.SaveChangesAsync();
        }
    }
}

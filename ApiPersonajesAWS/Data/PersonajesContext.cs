using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Data
{
    public class PersonajesContext: DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options) : base(options)
        {
        }

        public DbSet<Models.Personaje> Personajes { get; set; }
    }
}

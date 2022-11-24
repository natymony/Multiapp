using WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Model.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        protected readonly AdapterDbContext _context;
        public PersonaRepository(AdapterDbContext context) => _context = context;

        public async Task<persona> CreatePersonaAsync(persona Persona)
        {
            await _context.Set<persona>().AddAsync(Persona);
            await _context.SaveChangesAsync();
            return Persona;
      
        }

        public async Task<bool> DeletePersonaAsync(persona Persona)
        {
            if (Persona is null)
            {
                return false;
            }
            _context.Set<persona>().Remove(Persona);
            await _context.SaveChangesAsync();

            return true;

 
        }

        public IEnumerable<persona> GetPersona()
        {
            return _context.Persona.ToList();
       
        }

        public persona GetPersonaById(int codigo)
        {
            return _context.Persona.Find(codigo);
        }

        public async Task<bool> UpdatePersonaAsync(persona Persona)
        {
            _context.Entry(Persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

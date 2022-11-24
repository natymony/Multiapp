namespace WebApi.Model.Repository
{
    public interface IPersonaRepository
    {
            Task<persona> CreatePersonaAsync(persona Persona);
            Task<bool> DeletePersonaAsync(persona Persona);
            persona GetPersonaById(int codigo);
            IEnumerable<persona> GetPersona();
            Task<bool> UpdatePersonaAsync(persona Persona);
        
    }
}

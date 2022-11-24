
using WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Model.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class personaController : Controller
    {

        private IPersonaRepository _personaRepository;

        public personaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetPersonaAsync))]
        public IEnumerable<persona> GetPersonaAsync()
        {
            return _personaRepository.GetPersona();
          
        }

        [HttpGet("{codigo}")]
        [ActionName(nameof(GetPersonaById))]
        public ActionResult<persona> GetPersonaById(int codigo)
        {
            var productByID =  _personaRepository.GetPersonaById(codigo);
            if (productByID == null)
            {
                return NotFound();
            }
            return productByID;
        }

        [HttpPost]
        [ActionName(nameof(CreatePersonaAsync))]
        public async Task<ActionResult<persona>> CreatePersonaAsync(persona Persona)
        {
  
            return await _personaRepository.CreatePersonaAsync(Persona);
        }

        [HttpPut("{codigo}")]
        [ActionName(nameof(UpdatePersona))]
        public async Task<ActionResult> UpdatePersona(string codigo, persona Persona)
        {
            if (codigo != Persona.cedula)
            {
                return BadRequest();
            }

            await _personaRepository.UpdatePersonaAsync(Persona);

            return NoContent();

        }

        [HttpDelete("{codigo}")]
        [ActionName(nameof(DeletePersona))]
        public async Task<IActionResult> DeletePersona(int codigo)
        {
            var Persona = _personaRepository.GetPersonaById(codigo);
            if (Persona == null)
            {
                return NotFound();
            }

            await _personaRepository.DeletePersonaAsync(Persona);

            return NoContent();
        }

    }
}

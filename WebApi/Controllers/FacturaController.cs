using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Model.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        private IFacturaRepository _facturaRepository;

        public FacturaController(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetFacturaAsync))]
        public IEnumerable<factura> GetFacturaAsync()
        {
            return _facturaRepository.GetFactura();

        }

        [HttpPost]
        [ActionName(nameof(CreateFacturaAsync))]
        public async Task<ActionResult<factura>> CreateFacturaAsync(factura Factura)
        {

            return await _facturaRepository.CreateFacturaAsync(Factura);
        }

        [HttpDelete("{numero}")]
        [ActionName(nameof(DeleteFactura))]
        public async Task<IActionResult> DeleteFactura(int numero)
        {
            var Factura = _facturaRepository.GetFacturaById(numero);
            if (Factura == null)
            {
                return NotFound();
            }

            await _facturaRepository.DeleteFacturaAsync(Factura);

            return NoContent();
        }

    }
}

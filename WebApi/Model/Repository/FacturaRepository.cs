using WebApi.Data;

namespace WebApi.Model.Repository
{
    public class FacturaRepository: IFacturaRepository
    {
        protected readonly AdapterDbContext _context;
        public FacturaRepository(AdapterDbContext context) => _context = context;


        public IEnumerable<factura> GetFactura()
        {
            return _context.Factura.ToList();
        }

        public async Task<factura> CreateFacturaAsync(factura Factura)
        {
            await _context.Set<factura>().AddAsync(Factura);
            await _context.SaveChangesAsync();
            return Factura;

        }

        public factura GetFacturaById(int numero)
        {
            return _context.Factura.Find(numero);
        }

        public async Task<bool> DeleteFacturaAsync(factura Factura)
        {
            if (Factura is null)
            {
                return false;
            }
            _context.Set<factura>().Remove(Factura);
            await _context.SaveChangesAsync();

            return true;


        }
    }
}

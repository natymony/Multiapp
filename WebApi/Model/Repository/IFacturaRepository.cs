namespace WebApi.Model.Repository
{
    public interface IFacturaRepository
    {
        IEnumerable<factura> GetFactura();
        Task<factura> CreateFacturaAsync(factura Factura);
        Task<bool> DeleteFacturaAsync(factura Factura);
        factura GetFacturaById(int numero);
    }
}

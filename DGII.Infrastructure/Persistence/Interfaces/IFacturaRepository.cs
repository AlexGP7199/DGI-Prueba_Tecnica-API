using DGII.Domain.Entities;

using DGII.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Interfaces
{
    public interface IFacturaRepository : IGenericRepository<Factura>
    {
        Task<CantidadFacturasResponse> GetCantidadFacturasByContribuyenteId(int contribuyenteId);
        Task<FacturaMontoTotalResponseDto> GetMontoTotalByContribuyenteId(int contribuyenteId);
        //Task<Factura> valitedFacturaByRncCedula(string rncCedula);
        Task<List<Factura>> getAllFacturasByRncCedulaId(int rncCedulaId, int pageNumber, int pageSize);


    }
}

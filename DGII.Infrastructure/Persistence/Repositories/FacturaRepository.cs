using DGII.Domain.Entities;

using DGII.Infrastructure.Persistence.Context;
using DGII.Infrastructure.Persistence.Interfaces;
using DGII.Utilities.Static;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Repositories
{
    public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
    {
      
        public FacturaRepository(DgiiPruebaTContext _dbContext) : base(_dbContext) 
        { }

        public async Task<Factura> valitedFacturaByRncCedula(string rncCedula)
        {
            var factura = await _appDbContext.Facturas.Where(x=> x.Equals(rncCedula)).FirstOrDefaultAsync();
            return factura;
        }

        public async Task<FacturaMontoTotalResponseDto> GetMontoTotalByContribuyenteId(int contribuyenteId)
        {
            var factura = new FacturaMontoTotalResponseDto();
            factura.Itbis_Total = await _appDbContext.Facturas.Where(x => x.RncCedulaId.Equals(contribuyenteId)).SumAsync(x => x.Itbis18);
            return factura;
            
        }

        public async Task<List<Factura>> getAllFacturasByRncCedulaId(int rncCedulaId, int pageNumber, int pageSize)
        {
            var facturas = await _appDbContext.Facturas.Where(x=> x.RncCedulaId.Equals(rncCedulaId))
                .Skip((pageNumber - 1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
            return facturas;
        }

        public async Task<CantidadFacturasResponse> GetCantidadFacturasByContribuyenteId(int contribuyenteId)
        {
           var data = await _appDbContext.Facturas.Where(x=> x.RncCedulaId.Equals(contribuyenteId)).CountAsync();
           var response = new CantidadFacturasResponse();
           response.cantidad = data;
           return response;
        }
    }
}

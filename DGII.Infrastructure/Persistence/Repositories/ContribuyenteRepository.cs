using DGII.Domain.Entities;
using DGII.Infrastructure.Persistence.Context;
using DGII.Infrastructure.Persistence.Interfaces;
using DGII.Utilities.Static;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Repositories
{
    public class ContribuyenteRepository : GenericRepository<Contribuyente>, IContribuyenteRepository
    {
        
        public ContribuyenteRepository(DgiiPruebaTContext _dbContext) : base(_dbContext){}

        public async Task<List<Contribuyente>> GetAllInfoWithInclude(int pageNumber, int pageSize)
        {
            return await _appDbContext.Contribuyentes
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(c => c.EstatusContribuyente)
                .Include(c => c.TipoContribuyente)
                .ToListAsync();
        }

        public async Task<CantidadContribuyentesResponse> GetCantidadDeContribuyentes()
        {
            var cantidadContribuyentes= await _appDbContext.Contribuyentes.CountAsync();
            var response = new CantidadContribuyentesResponse();
            response.cantidadContribuyentes = cantidadContribuyentes;
            return response;
        }

        public async Task<Contribuyente> GetContribuyenteByIdWithInclude(int id)
        {
            return await _appDbContext.Contribuyentes
                .Include(c => c.EstatusContribuyente)
                .Include(c => c.TipoContribuyente)
                .Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Contribuyente> GetContribuyenteByType(int tipoContribuyenteId)
        {
            return await _appDbContext.Contribuyentes.FirstOrDefaultAsync(x => x.TipoContribuyenteId == tipoContribuyenteId);
        }

        public async Task<Contribuyente> GetContribuyenteByEstatus(int estatusContribuyenteId)
        {
            return await _appDbContext.Contribuyentes.FirstOrDefaultAsync(x => x.EstatusContribuyenteId == estatusContribuyenteId);
        }

        public async Task<Contribuyente> GetContribuyenteByRncCedula(string rncCedula)
        {
            return await _appDbContext.Contribuyentes.FirstOrDefaultAsync(x => x.RncCedula == rncCedula);
        }

       




        /*
        public async Task<Contribuyente> GetContribuyenteWithFacturas(int id)
        {
            return await _appDbContext.Contribuyentes.Include(x=> x.Facturas).Where(x => x.Id == id).FirstOrDefaultAsync();
        }*/
    }
}

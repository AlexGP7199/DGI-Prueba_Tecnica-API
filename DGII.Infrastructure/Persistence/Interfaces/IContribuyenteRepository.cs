using DGII.Domain.Entities;
using DGII.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Interfaces
{
    public interface IContribuyenteRepository : IGenericRepository<Contribuyente>
    {
        Task<CantidadContribuyentesResponse> GetCantidadDeContribuyentes();
        Task<List<Contribuyente>> GetAllInfoWithInclude(int pageNumber, int pageSize);
        Task<Contribuyente> GetContribuyenteByIdWithInclude(int id);
        Task<Contribuyente> GetContribuyenteByType(int tipoContribuyenteId);
        Task<Contribuyente> GetContribuyenteByEstatus(int estatusContribuyenteId);
        Task<Contribuyente> GetContribuyenteByRncCedula(string rncCedula);
        //Task<Contribuyente> GetContribuyenteWithFacturas(int id);
    }
}

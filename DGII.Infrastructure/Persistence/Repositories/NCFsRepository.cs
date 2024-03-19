using DGII.Domain.Entities;
using DGII.Infrastructure.Persistence.Context;
using DGII.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Repositories
{
    public class NCFsRepository : GenericRepository<Ncf>, INCFsInterfaceRepository
    {
        public NCFsRepository(DgiiPruebaTContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Ncf> getContrubuyenteNFCinfoById(int contribuyenteId)
        {
            var data = await _appDbContext.Ncfs.Where(x => contribuyenteId.Equals(contribuyenteId)).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            return data;
        }

        
    }
}

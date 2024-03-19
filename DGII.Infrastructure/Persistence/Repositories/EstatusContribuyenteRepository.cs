using DGII.Domain.Entities;
using DGII.Infrastructure.Persistence.Context;
using DGII.Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Repositories
{
    public class EstatusContribuyenteRepository : GenericRepository<EstatusContribuyente>, IEstatusContribuyenteRepository
    {
        public EstatusContribuyenteRepository(DgiiPruebaTContext appDbContext) : base(appDbContext)
        {
        }
    }
}

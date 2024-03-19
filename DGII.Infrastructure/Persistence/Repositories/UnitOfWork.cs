using DGII.Infrastructure.Persistence.Context;
using DGII.Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DgiiPruebaTContext _dbContext;


        public IContribuyenteRepository contribuyente { get; private set; }

        public IFacturaRepository factura { get; private set; }

        public ITipoContribuyenteRepository tipoContribuyente { get; private set; }

        public IEstatusContribuyenteRepository estatusContribuyente { get; private set; }

        public INCFsInterfaceRepository ncfs { get; private set; }
        public UnitOfWork(DgiiPruebaTContext dbContext)
        {
            _dbContext = dbContext;
            contribuyente = new ContribuyenteRepository(_dbContext);
            factura = new FacturaRepository(_dbContext);
            tipoContribuyente = new TipoContribuyenteRepository(_dbContext);
            estatusContribuyente = new EstatusContribuyenteRepository(_dbContext);
            ncfs = new NCFsRepository(_dbContext);
        }

        public void Dispose()
        {
           _dbContext.Dispose();
        }

        public void saveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

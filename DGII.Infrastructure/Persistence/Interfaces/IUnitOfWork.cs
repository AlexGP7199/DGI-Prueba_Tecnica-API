using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContribuyenteRepository contribuyente { get; }
        IFacturaRepository factura { get; }
        ITipoContribuyenteRepository tipoContribuyente { get; }
        IEstatusContribuyenteRepository estatusContribuyente { get; }
        INCFsInterfaceRepository ncfs { get; }
        void saveChanges();
        Task SaveChangesAsync();
    }
}

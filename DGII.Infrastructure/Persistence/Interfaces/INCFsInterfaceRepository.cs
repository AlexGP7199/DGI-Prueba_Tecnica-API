﻿using DGII.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Interfaces
{
    public interface INCFsInterfaceRepository : IGenericRepository<Ncf> 
    {
        Task<Ncf> getContrubuyenteNFCinfoById(int contribuyenteId);
        
    }
}

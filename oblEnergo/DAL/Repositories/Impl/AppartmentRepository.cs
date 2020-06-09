using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;

namespace DAL.Repositories.Impl
{
    public class AppartmentRepository
        :BaseRepository<Appartment>, IAppartmentRepository
    {
        internal AppartmentRepository(oblEnergoContext context)
            :base(context)
        {

        }
    }
}

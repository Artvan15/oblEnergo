using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;

namespace DAL.Repositories.Impl
{
    public class StreetRepository
        :BaseRepository<Street>, IStreetRepository
    {

        internal StreetRepository(oblEnergoContext context)
            :base(context)
        {

        }
    }
}

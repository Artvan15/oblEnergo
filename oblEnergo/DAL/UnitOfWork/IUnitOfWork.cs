using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRegionRepository Regions { get; }
        ICityRepository Cities { get; }
        IStreetRepository Streets { get; }
        IBuildingRepository Buildings { get; }
        IAppartmentRepository Appartments { get; }
        void Save();
    }
}

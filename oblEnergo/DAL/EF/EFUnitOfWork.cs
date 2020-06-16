using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.UnitOfWork;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class EFUnitOfWork
        :IUnitOfWork
    {
        private readonly oblEnergoContext db;
        private RegionRepository regionRepository;
        private CityRepository cityRepository;
        private StreetRepository streetRepository;
        private BuildingRepository buildingRepository;
        private AppartmentRepository appartmentRepository;

        public EFUnitOfWork(DbContextOptions<oblEnergoContext> options)
        {
            db = new oblEnergoContext(options);
        }
        public IRegionRepository Regions
        {
            get
            {
                if (regionRepository == null)
                    regionRepository = new RegionRepository(db);
                return regionRepository;
            }
        }
        public ICityRepository Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(db);
                return cityRepository;
            }
        }
        public IStreetRepository Streets
        {
            get
            {
                if (cityRepository == null)
                    streetRepository = new StreetRepository(db);
                return streetRepository;
            }
        }
        public IBuildingRepository Buildings
        {
            get
            {
                if (buildingRepository == null)
                    buildingRepository = new BuildingRepository(db);
                return buildingRepository;
            }
        }
        public IAppartmentRepository Appartments
        {
            get
            {
                if (appartmentRepository == null)
                    appartmentRepository = new AppartmentRepository(db);
                return appartmentRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
        ~EFUnitOfWork()
        {
            Dispose(false);
        }
    }
}

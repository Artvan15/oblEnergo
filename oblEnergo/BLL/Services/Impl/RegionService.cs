using System;
using System.Collections.Generic;
using System.Text;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using BLL.DTO;
using CCL.Security;
using CCL.Security.Identity;
using AutoMapper;
using DAL.Entities;

namespace BLL.Services.Impl
{
    public class RegionService
        : IRegionService
    {
        private readonly IUnitOfWork database;
        private int pageSize = 10;

        public RegionService(IUnitOfWork unitOfWork)
        {
            database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<RegionDTO> GetRegions(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            

            if(userType != typeof(Administrator) 
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }

            var RegionsEntities = database.Regions.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Region, RegionDTO>()).CreateMapper();
            var regionsDto = mapper.Map<IEnumerable<Region>, List<RegionDTO>>(RegionsEntities);
            return regionsDto;
        }

        public void AddRegion(RegionDTO region)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if(userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }
            if(region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }

            validate(region);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RegionDTO, Region>()).CreateMapper();
            var regionEntity = mapper.Map<RegionDTO, Region>(region);
            database.Regions.Create(regionEntity);
        }

        private void validate(RegionDTO region)
        {
            if (string.IsNullOrEmpty(region.Name))
            {
                throw new ArgumentException("Name must have a value!");
            }
        }
    }
}

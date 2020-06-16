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
    public class BuildingService
        : IBuildingService
    {
        private readonly IUnitOfWork database;
        private int pageSize = 10;

        public BuildingService(IUnitOfWork unitOfWork)
        {
            database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<BuildingDTO> GetBuildings(StreetDTO street, int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();


            if (userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }

            var BuildingsEntities = database.Buildings.Find(z => z.StreetId == street.Id, pageNumber, pageSize);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Building, BuildingDTO>()).CreateMapper();
            var buildingsDto = mapper.Map<IEnumerable<Building>, List<BuildingDTO>>(BuildingsEntities);
            return buildingsDto;
        }

        public IEnumerable<BuildingDTO> GetAllBuildings()
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();


            if (userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }

            var BuildingsEntities = database.Buildings.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Building, BuildingDTO>()).CreateMapper();
            var buildingsDto = mapper.Map<IEnumerable<Building>, List<BuildingDTO>>(BuildingsEntities);
            return buildingsDto;
        }

        public void AddBuilding(BuildingDTO building)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            validate(building);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BuildingDTO, Building>()).CreateMapper();
            var buildingEntity = mapper.Map<BuildingDTO, Building>(building);
            database.Buildings.Create(buildingEntity);
        }

        private void validate(BuildingDTO building)
        {
            if (building.BuildingNum <= 0)
            {
                throw new ArgumentException("BuildingNum must be > 0!");
            }
        }
    }
}

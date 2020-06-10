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
    public class CityService
        : ICityService
    {
        private readonly IUnitOfWork database;
        private int pageSize = 10;

        public CityService(IUnitOfWork unitOfWork)
        {
            database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<CityDTO> GetCities(RegionDTO region, int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();


            if (userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }

            var CitiesEntities = database.Cities.Find(z => z.RegionId == region.Id, pageNumber, pageSize);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<City, CityDTO>()).CreateMapper();
            var citiesDto = mapper.Map<IEnumerable<City>, List<CityDTO>>(CitiesEntities);
            return citiesDto;
        }

        public void AddCity(CityDTO city)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            validate(city);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CityDTO, City>()).CreateMapper();
            var cityEntity = mapper.Map<CityDTO, City>(city);
            database.Cities.Create(cityEntity);
        }

        private void validate(CityDTO city)
        {
            if (string.IsNullOrEmpty(city.Name))
            {
                throw new ArgumentException("Name must have a value!");
            }
        }
    }
}

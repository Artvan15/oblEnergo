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
    public class StreetService
        : IStreetService
    {
        private readonly IUnitOfWork database;
        private int pageSize = 10;

        public StreetService(IUnitOfWork unitOfWork)
        {
            database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<StreetDTO> GetStreets(CityDTO city, int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();


            if (userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }

            var StreetsEntities = database.Streets.Find(z => z.CityId == city.Id, pageNumber, pageSize);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Street, StreetDTO>()).CreateMapper();
            var streetsDto = mapper.Map<IEnumerable<Street>, List<StreetDTO>>(StreetsEntities);
            return streetsDto;
        }

        public void AddStreet(StreetDTO street)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }
            if (street == null)
            {
                throw new ArgumentNullException(nameof(street));
            }

            validate(street);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StreetDTO, Street>()).CreateMapper();
            var streetEntity = mapper.Map<StreetDTO, Street>(street);
            database.Streets.Create(streetEntity);
        }

        private void validate(StreetDTO street)
        {
            if (string.IsNullOrEmpty(street.Name))
            {
                throw new ArgumentException("Name must have a value!");
            }
        }
    }
}

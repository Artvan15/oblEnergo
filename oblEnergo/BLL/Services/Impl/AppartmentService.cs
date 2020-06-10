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
    public class AppartmentService
        : IAppartmentService
    {
        private readonly IUnitOfWork database;
        private int pageSize = 10;

        public AppartmentService(IUnitOfWork unitOfWork)
        {
            database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<AppartmentDTO> GetAppartments(BuildingDTO building, int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();


            if (userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }

            var AppartmentsEntities = database.Appartments.Find(z => z.BuildingId == building.Id, pageNumber, pageSize);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Appartment, AppartmentDTO>()).CreateMapper();
            var appartmentsDto = mapper.Map<IEnumerable<Appartment>, List<AppartmentDTO>>(AppartmentsEntities);
            return appartmentsDto;
        }

        public void AddAppartment(AppartmentDTO appartment)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Administrator)
                && userType != typeof(OblEnergoSpecialist))
            {
                throw new MethodAccessException();
            }
            if (appartment == null)
            {
                throw new ArgumentNullException(nameof(appartment));
            }

            validate(appartment);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AppartmentDTO, Appartment>()).CreateMapper();
            var appartmentEntity = mapper.Map<AppartmentDTO, Appartment>(appartment);
            database.Appartments.Create(appartmentEntity);
        }

        private void validate(AppartmentDTO appartment)
        {
            if (appartment.Number <= 0)
            {
                throw new ArgumentException("Appartment's number must be > 0!");
            }
        }
    }
}

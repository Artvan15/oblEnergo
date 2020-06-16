using System;
using Microsoft.EntityFrameworkCore;
using DAL.EF;
using CCL.Security;
using CCL.Security.Identity;
using CCL.Tariff;
using BLL.DTO;
using BLL.Services.Impl;
using System.Collections.Generic;
using System.Linq;


namespace oblEnergo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Director director = new Director();
            BuildingBuilder builder = new BuildingType1Builder();

            Building type1 = director.Create(builder);
            Console.WriteLine(type1.Lifts[0].Power);

            BuildingBuilder builder2 = new BuildingType2Builder();
            Building type2 = director.Create(builder2);
            Console.WriteLine(type2.BoilerRoom.Power);
            */

            /*
            Tariff tariff1 = new DayTill100KvtHouseTariff();
            tariff1 = new Tax(tariff1, 0.1);
            tariff1.GetInfo();

            Tariff tariff2 = new DayOver100KvtApartmentTariff();
            tariff2 = new Compensation(tariff2, 0.5);
            tariff2 = new Coefficient(tariff2, 0.8);
            tariff2.GetInfo();
            */

            Administrator admin = new Administrator(1, "test", "test", "test", 1);
            SecurityContext.SetUser(admin);

            var optionsBuilder = new DbContextOptionsBuilder<oblEnergoContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;")
                    .Options;
            EFUnitOfWork unitOfWork = new EFUnitOfWork(options);
            RegionDTO region1 = new RegionDTO() { Id = 1 };
            CityDTO city1 = new CityDTO(region1) { Id = 1 };
            StreetDTO street1 = new StreetDTO(city1) { Id = 1 };
            BuildingDTO building1 = new BuildingDTO(street1) { Id = 1 };
            AppartmentDTO appartment1 = new AppartmentDTO(building1) { Id = 1, Balance = 0, Number = 17, NumberOfInhabitants = 2 };
            
            AppartmentService appartmentService = new AppartmentService(unitOfWork);
            appartmentService.AddAppartment(appartment1);

            List<AppartmentDTO> appartmentDTOs = appartmentService.GetAppartments(building1, 0).ToList();
            Console.WriteLine(appartmentDTOs.Count);
        }
    }
}

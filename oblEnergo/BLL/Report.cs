using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BLL.DTO;
using BLL.Services.Impl;
using DAL.EF;
using System.Linq;

namespace CCL.Report
{
    abstract class Report
    {
        public void Generate()
        {
            GetInfo();
            Create();
            Send();
        }
        protected abstract void GetInfo();
        protected abstract void Create();
        protected abstract void Send();
    }

    class UserReport : Report
    {
        private AppartmentService appartmentService;
        private int appartmentId;
        AppartmentDTO appartment;
        public UserReport(EFUnitOfWork unitOfWork, int id)
        {
            appartmentService = new AppartmentService(unitOfWork);
            appartmentId = id;
        }
        
        protected override void GetInfo()
        {
            appartment = appartmentService.GetAppartment(appartmentId);
        }
        protected override void Create()
        {

        }
        protected override void Send()
        {

        }
    }

    class SpecialistReport : Report
    {
        private AppartmentService appartmentService;
        private BuildingService BuildingService;
        private StreetService StreetService;
        private CityService CityService;
        private RegionService RegionService;

        private List<AppartmentDTO> appartmentDTOs;
        private List<BuildingDTO> buildingDTOs;
        private List<StreetDTO> streetDTOs;
        private List<CityDTO> cityDTOs;
        private List<RegionDTO> regionDTOs; 

        public SpecialistReport(EFUnitOfWork unitOfWork)
        {
            appartmentService = new AppartmentService(unitOfWork);
            BuildingService = new BuildingService(unitOfWork);
            StreetService = new StreetService(unitOfWork);
            CityService = new CityService(unitOfWork);
            RegionService = new RegionService(unitOfWork);
        }
        protected override void GetInfo()
        {
            appartmentDTOs = appartmentService.GetAllAppartments().ToList();
            buildingDTOs = BuildingService.GetAllBuildings().ToList();
            streetDTOs = StreetService.GetAllStreets().ToList();
            cityDTOs = CityService.GetAllCities().ToList();
            regionDTOs = RegionService.GetAllRegions().ToList();
        }
        protected override void Create()
        {
            
        }
        protected override void Send()
        {

        }
    }

}

using System;
using Xunit;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identity;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Tests
{
    public class RegionServiceTests
    {
        //check constructor to null argument
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullExeption()
        {
            IUnitOfWork nullUnitOfWork = null;

            Assert.Throws<ArgumentNullException>(() => new RegionService(nullUnitOfWork));
        }

        [Fact]
        public void GetRegions_UserIsOwner_ThrowMethodAccessExeption()
        {
            //crete object of Owner
            User user = new Owner(1, "test", "testovich", "test@test", 101);
            SecurityContext.SetUser(user);
            
            //create double of UnitOfWork
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IRegionService regionService = new RegionService(mockUnitOfWork.Object);

            //call GetRegion and catch exeption
            Assert.Throws<MethodAccessException>(() => regionService.GetRegions(0));
        }

        [Fact]
        public void GetRegions_RegionsFromDAL_CorrectMappingToRegionDTO()
        {
            User user = new Administrator(2, "test_admin", "test_admin", "test@test", 102);
            SecurityContext.SetUser(user);
            var regionService = GetRegionService();

            var regionDto = regionService.GetRegions(0).FirstOrDefault();

            Assert.True(regionDto.Id == 1
                && regionDto.Name == "Test"
                && regionDto.UsedEnergy == 0);
        }

        IRegionService GetRegionService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var region = new Region() { Id = 1, Name = "Test", UsedEnergy = 0 };
            var mockDbSet = new Mock<IRegionRepository>();

            mockDbSet.Setup(z => z.Find(It.IsAny<Func<Region, bool>>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Region>() { region });

            mockContext.Setup(context => context.Regions).Returns(mockDbSet.Object);

            IRegionService regionService = new RegionService(mockContext.Object);
            return regionService;
        }
    }
}

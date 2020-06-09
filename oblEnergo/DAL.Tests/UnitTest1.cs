using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Moq;

namespace DAL.Tests
{
    class TestRegionRepository
        : BaseRepository<Region>
    {
        public TestRegionRepository(DbContext context)
            : base(context)
        {

        }
    }
    public class UnitTest1
    {
        [Fact]
        public void Create_InputRegionInstance_CalledAddMethodOfDBSetWithRegionInstance()
        {
            //create options
            DbContextOptions options = new DbContextOptionsBuilder<oblEnergoContext>().Options;

            //create double oblEnergoContext, DbSet<Region>
            var mockContext = new Mock<oblEnergoContext>(options);
            var mockDbSet = new Mock<DbSet<Region>>();

            //adjust setup so it returns mockDbSet::DbSet<Region> if oblEnergoContext::Set<Region>() called
            mockContext.Setup(context => context.Set<Region>()).Returns(mockDbSet.Object);

            //create TestRegionRepository and object Region
            var repository = new TestRegionRepository(mockContext.Object);
            Region region = new Mock<Region>().Object;

            //call Create
            repository.Create(region);

            //verify that method Add was called with parameter 'region' once
            mockDbSet.Verify(dbSet => dbSet.Add(region), Times.Once());

        }
        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions options = new DbContextOptionsBuilder<oblEnergoContext>().Options;
            var mockContext = new Mock<oblEnergoContext>(options);
            var mockDbSet = new Mock<DbSet<Region>>();

            //adjust setup so it returns mockDbSet::DbSet<Region> if oblEnergoContext::Set<Region>() called
            mockContext.Setup(context => context.Set<Region>()).Returns(mockDbSet.Object);

            //create object Region
            Region region = new Region() { Id = 1 };

            //adjust setup so it returns Region object if DbSet<Region>::Find called
            mockDbSet.Setup(mock => mock.Find(region.Id)).Returns(region);
            var repository = new TestRegionRepository(mockContext.Object);

            //call Get (that call Find)
            var actualRegion = repository.Get(region.Id);

            //Verify that method DbSet<Region>::Find(Region::id) with correct argument was called once
            mockDbSet.Verify(dbSet => dbSet.Find(region.Id), Times.Once());

            //Verify that DbSet<Region>::Find returns the same object as DbSet<Region>::Get
            Assert.Equal(region, actualRegion);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions options = new DbContextOptionsBuilder<oblEnergoContext>().Options;
            var mockContext = new Mock<oblEnergoContext>(options);
            var mockDbSet = new Mock<DbSet<Region>>();

            //adjust setup so it returns mockDbSet::DbSet<Region> if oblEnergoContext::Set<Region>() called
            mockContext.Setup(context => context.Set<Region>()).Returns(mockDbSet.Object);

            var repository = new TestRegionRepository(mockContext.Object);

            //create Region object
            Region region = new Region() { Id = 1 };
            //adjust setup so it returns Region object if DbSet<Region>::Find called
            mockDbSet.Setup(mock => mock.Find(region.Id)).Returns(region);

            //call Delete (that call Get)
            repository.Delete(region.Id);

            //Verify that method DbSet<Region>::Find(Region::id) with correct argument was called once
            mockDbSet.Verify(dbSet => dbSet.Find(region.Id), Times.Once());

            //Verify that method DbSet<Region>::Remove(Region) with correct argument was called once
            mockDbSet.Verify(dbSet => dbSet.Remove(region), Times.Once());
        }

    }
}

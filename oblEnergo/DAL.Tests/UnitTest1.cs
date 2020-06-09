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
        public void Test1()
        {

        }
    }
}

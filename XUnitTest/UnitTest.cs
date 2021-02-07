using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamesApplication.Controllers;
using NamesApplication.DbContexts;
using NamesApplication.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class UnitTest : IDisposable
    {
        protected readonly DataContext _context;

        public UnitTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "NABA Database Test").Options;

            _context = new DataContext(options);

            _context.Database.EnsureCreated();

            Seed(_context);
        }

        private void Seed(DataContext context)
        {
            IEnumerable<Name> names = new[]
            {
            new Name { Id = new Guid(), FirstName = "AAA", LastName = "BBB" },
            new Name { Id = new Guid(), FirstName = "CCC", LastName = "DDD" },
            new Name { Id = new Guid(), FirstName = "EEE", LastName = "FFF" }
            };

            context.Names.AddRange(names);
            context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public void GetNamesTypeCheck()
        {
            NamesController namesController = new NamesController(_context);
            var result = namesController.GetNames();

            Assert.IsType<ActionResult<IEnumerable<Name>>>(result);
        }

        [Fact]
        public void GetNameTypeCheck()
        {
            NamesController namesController = new NamesController(_context);
            var result = namesController.GetName("AAA", "BBB");

            Assert.IsType<ActionResult<Name>>(result);
        }

        [Fact]
        public void CreateNameTypeCheck()
        {
            NamesController namesController = new NamesController(_context);

            Name testName = new Name { Id = new Guid(), FirstName = "GGG", LastName = "HHH" };

            var result = namesController.CreateName(testName);

            Assert.IsType<ActionResult<Name>>(result);
        }

            
    }
}
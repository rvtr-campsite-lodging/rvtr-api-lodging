using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RVTR.Lodging.DataContext.Databases;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{
    /// <summary>
    /// Unit testing for repository functionality
    /// </summary>
    public class Repository_Test
    {
        private BedModel _bm = new BedModel() { BedId = 1, Size = "King", NumberOfBeds = 1 };

        /// <summary>
        /// Test the delete functionality of the generic repository by inserting then deleting from the repository
        /// and verifying count
        /// </summary>
        [Fact]
        public void Test_Delete()
        {
            var options = new DbContextOptionsBuilder<LodgingDbContext>()
                    .UseInMemoryDatabase(databaseName: "Repo_delete_test").Options;

            using (var ldb = new LodgingDbContext(options))
            {
                var sut = new Repository<BedModel>(ldb);
                List<BedModel> bedList = sut.Select().ToList();
                Assert.True(sut.Insert(_bm));
                ldb.SaveChanges();
                Assert.True(sut.Delete(_bm.BedId));
                ldb.SaveChanges();
                Assert.True(0 == sut.Select().ToList().Count());
            }
        }

        /// <summary>
        /// Test the Insert functionality of the repository by inserting into
        /// repository and verifying count
        /// </summary>
        [Fact]
        public void Test_Insert()
        {
            var options = new DbContextOptionsBuilder<LodgingDbContext>()
                      .UseInMemoryDatabase(databaseName: "InMemoryDb").Options;

            using (var ldb = new LodgingDbContext(options))
            {
                var sut = new Repository<BedModel>(ldb);
                List<BedModel> bedList = sut.Select().ToList();
                Assert.True(0 == sut.Select().ToList().Count());
                Assert.True(sut.Insert(_bm));
                ldb.SaveChanges();
                Assert.True(1 == sut.Select().ToList().Count());
            }
        }

        /// <summary>
        /// ///  Test the update functionality of the repository by
        ///  inserting an item to the database and attempting to
        /// update it
        /// </summary>
        [Fact]
        public void Test_Update()
        {
            var options = new DbContextOptionsBuilder<LodgingDbContext>()
                      .UseInMemoryDatabase(databaseName: "Test_Update").Options;

            using (var ldb = new LodgingDbContext(options))
            {
                var sut = new Repository<BedModel>(ldb);
                List<BedModel> bedList = sut.Select().ToList();
                Assert.True(sut.Insert(_bm));
                ldb.SaveChanges();
                _bm.NumberOfBeds = 10;
                sut.Update(_bm);
                ldb.SaveChanges();
                Assert.True(10 == sut.Select().ToList().First().NumberOfBeds);
            }
        }

        /// <summary>
        /// Test the select functionality of the repository by inserting an item into
        /// the database and verifying the size of items
        /// </summary>
        [Fact]
        public void Test_Select()
        {
            var options = new DbContextOptionsBuilder<LodgingDbContext>()
                      .UseInMemoryDatabase(databaseName: "Test_Select").Options;

            using (var ldb = new LodgingDbContext(options))
            {
                var sut = new Repository<BedModel>(ldb);
                List<BedModel> bedList = sut.Select().ToList();
                Assert.True(sut.Insert(_bm));
                BedModel _bm2 = sut.Select(1);
                ldb.SaveChanges();
                Assert.True(_bm2.Size == sut.Select().ToList().First().Size);
            }
        }
    }
}

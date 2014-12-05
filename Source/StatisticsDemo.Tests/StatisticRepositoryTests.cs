using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsDemo.Tests
{
    [TestFixture]
    public class StatisticRepositoryTests
    {
        [Test]
        public void StatisticRepository_Should_Be_Initializable()
        {
            // arrange + act
            var target = new StatisticRepository();

            // assert - that we get an object
            target.Should().NotBeNull();
        }

        [Test]
        public void StatisticRepository_FetchAllByDate_Should_Only_Return_Items_For_A_Specific_Date()
        {
            // arrange
            var expectedDate = new DateTime(2014, 12, 3);
            var repo = new StatisticRepository();

            // act
            var target = repo.FetchAllByDate(expectedDate).ToList();

            // assert - that we get an object
            target.Should().NotBeNull();

            // assert - that at least one item is returned
            target.Count().Should().BeGreaterOrEqualTo(1);

            // assert - that all returned values equal the 'expectedDate'
            foreach (var view in target)
            {
                view.StatisticalDate.Date.Should().Be(expectedDate);
            }
        }
        [Test]
        public void StatisticRepository_CountByDateAndId_should_Return_Numbers_Of_Views_Foreach_PictureId()
        {
            // arrange
            var repo = new StatisticRepository();
            // act
            var target = repo.CountByDateAndId();
            //assert - that there is something in
            target.Should().NotBeEmpty();
            //assert - that all returned values are correct
            foreach(var viewSum in target){
                viewSum.Should().NotBeNull();
                viewSum.PictureId.Should().BeGreaterThan(0);
                viewSum.StatisticalDate.Should().BeBefore(DateTime.Now.Date);
                viewSum.Views.Should().BeGreaterThan(0);

            }

        }
        [Test]
        public void StatisticRepository_Expected_Numbers_Of_Count()
        {
            // arrange
            var items = new List<PictureStatistic>();
            
            items.Add(new PictureStatistic{Id = 1 , IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-2)});
            items.Add(new PictureStatistic { Id = 2, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 3, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 4, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 5, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 6, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 7, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 8, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 9, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 10, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 11, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 12, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 13, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 14, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 15, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-2) });

            //arange
            var repo = new StatisticRepository(items);
            // arrange
            var expectedAmount = 12;
            //act
            var target = repo.CountByDateAndId();
            //assert - that we dont have an empty object
            target.Should().NotBeEmpty();
            //assert - that the returnvalue return the right amount 
            target.Count.Should().Be(expectedAmount);
            //assert - that all returned values are correct
            foreach (var viewSum in target)
            {
                viewSum.Should().NotBeNull();
                viewSum.PictureId.Should().BeGreaterThan(0);
                viewSum.StatisticalDate.Should().BeBefore(DateTime.Now.Date);
                viewSum.Views.Should().BeGreaterThan(0);
            }
        }
        [Test]
        public void StatisticRepository_Hits_Per_Date_Should_Return_Views_Per_Date()
        {
            var items = new List<PictureStatistic>();

            items.Add(new PictureStatistic { Id = 1, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 2, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 3, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 4, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 5, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 6, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 7, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 8, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 9, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 10, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 11, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 12, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 13, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 14, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 15, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-2) });

            //arange
            var repo = new StatisticRepository(items);

            // act
            var target = repo.HitsPerDate();

            // assert - that we get an object
            target.Should().NotBeNull();

            // assert - that at least one item is returned
            target.Count().Should().BeGreaterOrEqualTo(1);

            // assert - that all returned views are greater than 0
            foreach (var view in target)
            {
                view.Views.Should().BeGreaterThan(0);
            }
        }
        [Test]
        public void StatisticRepository_CountByDateAndId_Should_Count_PictureId_Once_Per_Date()
        {
            // arrange
            var items = new List<PictureStatistic>();

            items.Add(new PictureStatistic { Id = 1, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 2, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 3, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 4, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 5, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 6, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 7, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 8, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 9, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 10, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 11, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 12, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 13, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 14, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 15, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-2) });

            //arange
            var repo = new StatisticRepository(items);
            //act
            var target = repo.CountByDateAndId();
            //assert - that we dont have an empty object
            target.Should().NotBeEmpty();
            //assert - that we have them only one time
            target.GroupBy(p => p).Any(c => c.Count() > 1).Should().BeFalse();// true is more than 1 false is 1 or less
            
        }
        [Test]
        public void StatisticRepository_CountByDateAndId_Should_Return_All_Dates_Once()
        {
            // arrange
            var items = new List<PictureStatistic>();

            items.Add(new PictureStatistic { Id = 1, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 2, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 3, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 4, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 5, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 6, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 7, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 8, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 9, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 10, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 11, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 12, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 13, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 14, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 15, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-2) });

            //arange
            var repo = new StatisticRepository(items);
            //act
            var target = repo.HitsPerDate();
            //assert - that we dont have an empty object
            target.Should().NotBeEmpty();
            //assert - that we have them only one time
            target.GroupBy(p => p.StatisticalDate).Any(c => c.Count() > 1).Should().BeFalse();
        }
    }
}

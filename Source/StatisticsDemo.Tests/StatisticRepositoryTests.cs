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
            //assert
            target.Should().NotBeEmpty();
            //assert
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
            items.Add(new PictureStatistic { Id = 5, IpAddress = "", PictureId = 1, StatisticalDate = DateTime.Now.AddDays(-6) });
            items.Add(new PictureStatistic { Id = 6, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 7, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 8, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 9, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 10, IpAddress = "", PictureId = 2, StatisticalDate = DateTime.Now.AddDays(-6) });
            items.Add(new PictureStatistic { Id = 11, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-2) });
            items.Add(new PictureStatistic { Id = 12, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-3) });
            items.Add(new PictureStatistic { Id = 13, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-4) });
            items.Add(new PictureStatistic { Id = 14, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-5) });
            items.Add(new PictureStatistic { Id = 15, IpAddress = "", PictureId = 3, StatisticalDate = DateTime.Now.AddDays(-6) });

            //arange
            var repo = new StatisticRepository(items);
            //act
            var target = repo.CountByDateAndId();
            //assert
            target.Should().NotBeEmpty();
            //assert
            target.Count.Should().Equals(1);
            //assert
            foreach (var viewSum in target)
            {
                viewSum.Should().NotBeNull();
                viewSum.PictureId.Should().BeGreaterThan(0);
                viewSum.StatisticalDate.Should().BeBefore(DateTime.Now.Date);
                viewSum.Views.Should().BeGreaterThan(0);
            }
        }
    }
}

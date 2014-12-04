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
            repo.CountByDateAndId();
        }
    }
}

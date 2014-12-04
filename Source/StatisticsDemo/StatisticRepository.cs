using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsDemo
{
    /// <summary>
    /// Provides logic especially for the PictureStatistic class.
    /// </summary>
    public class StatisticRepository
    {
        private ICollection<PictureStatistic> PictureStatistics { get; set; }

        public StatisticRepository()
        {
            PictureStatistics = new List<PictureStatistic>();

            // note: this is just for ***testing*** purposes, you wouldn't do this in a constructor in real life
            // when this class is initialized, create a collection of picturestatistics
            var startDate = new DateTime(2015, 1, 1);
            for (int i = 0; i < 999; i++)
            {
                PictureStatistics.Add(new PictureStatistic()
                {
                    Id = i,
                    //IpAddress = "...",
                    PictureId = 1000 + i,
                    StatisticalDate = startDate.AddHours(-i)
                });
            }

        }

        public IEnumerable<PictureStatistic> FetchAllByDate(DateTime date)
        {
            return PictureStatistics.Where(p => p.StatisticalDate.Date == date.Date);
        }

        public void CountByDateAndId()
        {
            var viewsGroupedByDateAndPictureId = PictureStatistics
                .Where(p => p.StatisticalDate.Date < DateTime.Now.Date)
                // group everything , by the statistical DATE AND PICTUREID
                .GroupBy(p => new { p.StatisticalDate.Date, p.PictureId }, p => p, 
                (key, g) => new
                         {
                             Date = key.Date,
                             ViewsForThisDay = g.ToList(),
                             PictureId = key.PictureId
                         });
            //return for each group by
            foreach (var view in viewsGroupedByDateAndPictureId)
            {
                Console.WriteLine("On {0}, there were {1} views for picture: {2}", view.Date.Date, view.ViewsForThisDay.Count, view.PictureId);
            }
        }

    }
}

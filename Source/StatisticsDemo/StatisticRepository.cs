using System;
using System.Collections;
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

        public StatisticRepository(List<PictureStatistic> listOfPictureStatistics)
        {
            PictureStatistics = listOfPictureStatistics;
        }

        public IEnumerable<PictureStatistic> FetchAllByDate(DateTime date)
        {
            return PictureStatistics.Where(p => p.StatisticalDate.Date == date.Date);
        }

        public List<ViewsSum> CountByDateAndId()
        {
            
            var ViewSumList = new List<ViewsSum>();
            var viewsGroupedByDateAndPictureId = PictureStatistics
                .Where(p => p.StatisticalDate.Date < DateTime.Now.Date)
                // group everything by the statistical DATE AND PICTUREID
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
                var viewcount = new ViewsSum();
                Console.WriteLine("On {0}, there were {1} views for picture: {2}", view.Date.Date, view.ViewsForThisDay.Count, view.PictureId);
                viewcount.PictureId = view.PictureId;
                viewcount.StatisticalDate = view.Date.Date;
                viewcount.Views = view.ViewsForThisDay.Count;
                ViewSumList.Add(viewcount);
            }
            return ViewSumList;
        }
        public List<DayHits> HitsPerDate()
        {
           
            var dayHitsList = new List<DayHits>();
            var viewsGroupedByDateAndPictureId = PictureStatistics
                .Where(p => p.StatisticalDate.Date < DateTime.Now.Date)
                // group everything , by the statistical DATE
                .GroupBy(p => p.StatisticalDate.Date, p => p,
                (key, g) => new
                {
                    Date = key,
                    ViewsForThisDay = g.ToList()
                    
                });
            foreach (var view in viewsGroupedByDateAndPictureId)
            {
                var dayHits = new DayHits();
                Console.WriteLine("On {0}, there were {1} views", view.Date.Date, view.ViewsForThisDay.Count);
                dayHits.StatisticalDate = view.Date.Date;
                dayHits.Views = view.ViewsForThisDay.Count;
                dayHitsList.Add(dayHits);
            }
            return dayHitsList;
        }
        
    }

}
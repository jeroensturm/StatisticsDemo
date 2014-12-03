using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsDemo
{
    public class PictureStatistic
    {
        public int Id { get; set; }
        public int PictureId { get; set; }
        public DateTime StatisticalDate { get; set; }
        public string IpAddress { get; set; }

        public PictureStatistic()
        {
            StatisticalDate = DateTime.Now;
        }
    }
}

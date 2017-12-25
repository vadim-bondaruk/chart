using Infrastructure.Models;
using System.Collections.Generic;

namespace Common.Models
{
    public class Param : BaseEntity
    {
       
        public double CoefficientA { get; set; }
        public double CoefficientB { get; set; }
        public double CoefficientC { get; set; }
        public double Step { get; set; }
        public double RangeFrom { get; set; }
        public double RangeTo { get; set; }

        public ICollection<CacheData> Points { get; set; }
    }
}

using Infrastructure.Models;

namespace Common.Models
{
    public class CacheData : BaseEntity
    {
        public double PointX { get; set; }
        public double PointY { get; set; }

        public int ParamId { get; set; }
        public Param Param { get; set; }
    }
}

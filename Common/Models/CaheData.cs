namespace Common.Models
{
    public class CaheData
    {
        public int CacheDataId { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }

        public int ParamId { get; set; }
        public Param Param { get; set; }
    }
}

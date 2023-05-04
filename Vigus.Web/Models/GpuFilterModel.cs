namespace Vigus.Web.Models
{
    public class GpuFilterModel
    {
        public string? Name { get; set; }
        public int? ModelId { get; set; }
        public int? SeriesId { get; set; }
        public int? MemorySize { get; set; }
        public int? MinTdp { get; set; }
        public int? MaxTdp { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Vigus.Web.Models
{
    public class GpusViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string? FullGpuName { get; set; }

        [Required]
        [Range(1, 100)]
        public int? Cores { get; set; }

        [Required]
        [Display(Name = "TDP (W)")]
        public string? TdpInWatts { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Price ($)")]
        public string? PriceInDollars { get; set; }

        [Required]
        [Display(Name = "Memory Size (GB)")]
        public string? MemorySizeInGb { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Series Name")]
        public string? ModelName { get; set; }

        [Required]
        [Display(Name = "Image Name")]
        public string? ImageName { get; set; }
    }
}

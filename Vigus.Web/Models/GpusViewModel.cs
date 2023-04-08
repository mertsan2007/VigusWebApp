using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vigus.Web.Models
{
    public class GpusViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string? FullGpuName { get; set; }
        
        [Required]
        public int? Cores { get; set; }
        
        [Required]
        [Display(Name = "TDP (W)")]
        public string? TdpInWatts { get; set; }
        
        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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
        
        public ICollection<SelectListItem>? Technologies { get; set; }

        public ICollection<SelectListItem>? SupportedDriverVersions { get; set; }

        public string? ImageName { get; set; }
    }
}

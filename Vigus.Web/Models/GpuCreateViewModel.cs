using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Vigus.Web.Models
{
    public class GpuCreateViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(1, 5000)]
        public int? Cores { get; set; }

        [Required]
        [Range(1, 700)]
        public int? Tdp { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 3000)]
        public decimal? Price { get; set; }

        [Required]
        [Display(Name = "Memory Size")]
        [Range(3, 30)]
        public int? MemorySize { get; set; }
        
        public string? Description { get; set; }

        [Required]
        public int? ModelId { get; set; }

        [Display(Name = "Driver Versions")]
        public ICollection<SelectListItem>? SupportedDriverVersions { get; set; }

        public int? ImageId { get; set; }
    }
}

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
        [Range(1, 100)]
        public int? Cores { get; set; }

        [Required]
        public int? Tdp { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        [Display(Name = "Memory Size")]
        public int? MemorySize { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int? ModelId { get; set; }

        [Display(Name = "Driver Versions")]
        public ICollection<SelectListItem>? SupportedDriverVersions { get; set; }

        public int? ImageId { get; set; }
    }
}

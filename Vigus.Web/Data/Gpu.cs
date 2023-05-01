using System.ComponentModel.DataAnnotations;

namespace Vigus.Web.Data;

public class Gpu : EntityBase
{
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

    [Range(1, 5000)]
    public decimal? Price { get; set; }
    
    [Required]
    [Display(Name = "Memory Size")]
    [Range(2, 100)]
    public int MemorySize { get; set; }
    
    public string? Description { get; set; }

    [Required]
    public int? ModelId { get; set; }
    public virtual GpuModel? Model { get; set; }

    [Display(Name = "Driver Versions")]
    public virtual ICollection<DriverVersion>? SupportedDriverVersions { get; set; }

    [Required]
    public int? ImageId { get; set; }
    public virtual Image? Image { get; set; }
}
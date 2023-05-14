using System.ComponentModel.DataAnnotations;

namespace Vigus.Web.Data;

public class DriverVersion : EntityBase
{
    [Required] public string? Name { get; set; }

    public string? Description { get; set; }

    [Display(Name = "Known Issues")] public string? KnownIssues { get; set; }

    [Display(Name = "Fixed Changes")] public string? FixedChanges { get; set; }

    public virtual ICollection<Gpu>? Gpus { get; set; }

    public virtual ICollection<OsVersion>? OsVersions { get; set; }
}
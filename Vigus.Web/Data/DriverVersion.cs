namespace Vigus.Web.Data;

public class DriverVersion : EntityBase
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? KnownIssues { get; set; }

    public string? FixedChanges { get; set; }

    public virtual ICollection<Gpu>? Gpus { get; set; }

    public virtual ICollection<OsVersion>? OsVersions { get; set; }
    //vigus software 1.13, 1.14
}
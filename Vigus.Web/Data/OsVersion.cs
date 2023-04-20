namespace Vigus.Web.Data
{
    public class OsVersion : EntityBase
    {
        public string? Name { get; set; }

        public virtual ICollection<DriverVersion>? DriverVersions { get; set; }
    }
}

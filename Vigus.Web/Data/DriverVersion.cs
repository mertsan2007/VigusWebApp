namespace Vigus.Web.Data;

public class DriverVersion : EntityBase
{
    public string? Name { get; set; }
    public virtual ICollection<Gpu>? Gpus { get; set; }
    //vigus software 1.13, 1.14
}
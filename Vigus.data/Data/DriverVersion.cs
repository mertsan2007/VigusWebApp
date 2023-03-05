namespace Vigus.data.Data;

public class DriverVersion : EntityBase
{
    public string? Name { get; set; }
    public virtual List<Gpu>? Gpus { get; set; }
    //vigus software 1.13, 1.14
}
﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vigus.Web.Data;

public class DriverVersion : EntityBase
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Display(Name = "Known Issues")]
    public string? KnownIssues { get; set; }

    [Display(Name = "Fixed Changes")]
    public string? FixedChanges { get; set; }

    public virtual ICollection<Gpu>? Gpus { get; set; }

    [Display(Name = "OS Versions")]
    public virtual ICollection<OsVersion>? OsVersions { get; set; } = new List<OsVersion>();
    
    [NotMapped]
    public int[]? SelectedItems { get; set; }
}
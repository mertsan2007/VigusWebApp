﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vigus.Web.Data
{
    public class GpuImage:EntityBase
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Name { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public int GpuId { get; set; }
        public virtual Gpu? Gpu { get; set; }
    }
}

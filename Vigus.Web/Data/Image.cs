using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vigus.Web.Data
{
    public class Image : EntityBase
    {
        [Required]
        public string? Title { get; set; }

        public string? Name { get; set; }

        [NotMapped]
        [Required]
        public IFormFile? File { get; set; }

        public virtual ICollection<Gpu>? Gpus { get; set; }

        public virtual ICollection<GpuTechnology>? Technologies { get; set; }
    }
}

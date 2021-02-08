using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Models
{
    public abstract class DomainBase
    {
        [NotMapped]
        public bool IsNew { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Models
{
    public class Customer : DomainBase
    {
        public Customer() => Vehicles = new HashSet<Vehicle>();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        
        [StringLength(50)]
        public string CustomerName { get; set; }
        
        [StringLength(150)]
        public string Address { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
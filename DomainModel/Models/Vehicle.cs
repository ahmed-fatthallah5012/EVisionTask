using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models
{
    public class Vehicle : DomainBase
    {
        [Key]
        [StringLength(17)]
        public string VehicleId { get; set; }
        
        [StringLength(6)]
        public string RegisterNumber { get; set; }

        public bool ShowStatus { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
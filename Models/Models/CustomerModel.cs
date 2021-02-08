using System.Collections.Generic;

namespace Models.Models
{
    public class CustomerModel : ModelBase
    {
        public CustomerModel() => Vehicles = new HashSet<VehicleModel>();

        public int CustomerId { get; set; }
        
        public string CustomerName { get; set; }
        
        public string Address { get; set; }

        public ICollection<VehicleModel> Vehicles { get; set; }
    }
}
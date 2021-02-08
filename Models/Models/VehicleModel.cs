namespace Models.Models
{
    public class VehicleModel : ModelBase
    {
        
        public string VehicleId { get; set; }
        
        public string RegisterNumber { get; set; }

        public bool ShowStatus { get; set; }

        public int CustomerId { get; set; }

        public CustomerModel Customer { get; set; }
    }
}
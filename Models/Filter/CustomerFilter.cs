namespace Models.Filter
{
    public class CustomerFilter
    {
        public int CustomerId { get; set; }
        public bool HasVehicleStatus { get; set; }
        public string CustomerName { get; set; }
    }
}
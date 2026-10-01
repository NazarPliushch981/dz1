namespace dz1.Models
{
    public class InsuranceViewModel
    {
        public int EngineCapacity { get; set; }
        public string CityType { get; set; }
        public int DriverExperienceYears { get; set; }
        public bool HasDiscountCategory { get; set; }
        public double CalculatedPrice { get; set; }
        public string ErrorMessage { get; set; }
    }
}
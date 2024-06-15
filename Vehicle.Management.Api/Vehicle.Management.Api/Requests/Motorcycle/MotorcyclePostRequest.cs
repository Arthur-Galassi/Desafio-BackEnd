namespace Vehicle.Management.Api.Requests.Motorcycle
{
    public record MotorcyclePostRequest
    {
        public string LicensePlate { get; set; } = default!;
        public string VehicleModel { get; set; } = default!;
        public int VehicleYear { get; set; } = default!;
        public string VehicleColor { get; set; } = default!;
    }
}

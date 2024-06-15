namespace Vehicle.Management.Api.Requests.Abstractions
{
    public interface IRequestContextHolder
    {
        public string RequestUser { get; set; } 
    }
}

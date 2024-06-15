using Vehicle.Management.Api.Requests.Abstractions;

namespace Vehicle.Management.Api.Requests
{
    public abstract class RequestContextHolder : IRequestContextHolder
    {
        public string RequestUser { get; set; } = string.Empty;
    }
}

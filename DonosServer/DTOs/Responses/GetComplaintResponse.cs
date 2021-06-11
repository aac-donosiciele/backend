using System.Collections.Generic;

namespace DonosServer.API.DTOs.Responses
{
    public class GetComplaintResponse
    {
        public IEnumerable<GetComplaintLogResponse> History { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupLand.WebAPI.Constracts.Responses
{
    public class BadReqErrorResponse
    {
        public List<BadReqErrorModel> Errors { get; set; } = new List<BadReqErrorModel>();
    }
}

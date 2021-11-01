using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupLand.WebAPI.Constracts.Responses
{
    public class BadReqErrorModel
    {
        public string FieldName { get; set; }
        public string MessageCode { get; set; }
    }
}

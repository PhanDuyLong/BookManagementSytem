using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupLand.WebAPI.Constracts.Responses
{
    public class NotExistModel
    {
        public string MessageCode { get; set; }
        public List<string> FieldErrors { get; set; }
    }
}

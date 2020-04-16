using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22.Contract.v1.Responses
{
    public class AuthFailResponse
    {
        public IEnumerable<string> Errors { get; set; }

    }
}

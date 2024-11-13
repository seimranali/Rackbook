using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application
{
    public class GenericResult<TResponse> where TResponse : class
    {
        public TResponse? Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}

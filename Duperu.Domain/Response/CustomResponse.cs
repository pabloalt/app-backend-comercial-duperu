using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Domain.Response
{
    public class CustomResponse<T>
    {
        public string message { get; set; } = string.Empty;
        public T? data { get; set; }
        public List<string> error { get; set; } = new List<string>();

        public CustomResponse()
        {
            error = new List<string>();
        }

        public CustomResponse(string message, T ? data)
        {
            this.message = message;
            this.data = data;
        }
    }
}

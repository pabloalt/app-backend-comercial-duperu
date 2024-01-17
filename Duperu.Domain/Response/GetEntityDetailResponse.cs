using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Domain.Response
{
    public class GetEntityDetailResponse
    {
        public int id { get; set; }
        public string codigo { get; set; } 
        public string description { get; set; } 
        public string full_name { get; set; }

    }
}

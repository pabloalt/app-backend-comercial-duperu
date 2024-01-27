using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Domain.Response
{
    public class GetListUserByIdRolResponse
    {
        public string full_name { get; set; }
        public string user_code { get; set; }
        public string active_directory_account { get; set; }
        public int id_rol { get; set; }
        public string description { get; set; }

    }
}

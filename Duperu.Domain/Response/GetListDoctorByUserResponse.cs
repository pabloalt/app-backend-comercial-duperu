using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Domain.Response
{
    public class GetListDoctorByUserResponse
    { 
        public int id { get; set; }
        public int cmp { get; set; }
        public string full_name_doctor { get; set; }
        public string code_sap { get; set; }
        public string category { get; set; }
        public string local_address { get; set; }
        public string local_district { get; set; }
        public string code_closeup { get; set; }
        public string specialty { get; set; }
        public string previous_contract_end_date { get; set; }
        public int renovation { get; set; }
        public int previous_contract_count { get;}
         
    }
}

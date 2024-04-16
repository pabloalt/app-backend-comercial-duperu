using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Domain.Response
{
    public class GetListMedicalAgreementResponse
    {
        public int year_medical_agreement { get; set; }
        public string  medical_agreement_number { get; set; }
        public DateTime medical_agreement_application_date { get; set; }
        public string full_medical_name { get; set; }
        public string full_name_medical_visitor { get; set; }
        public int status { get; set; }
        public string description { get; set; }
        public string medical_district { get; set; }
        public string branch_id { get; set; }
        public string code_closeup_doctor { get; set; }
 
    }
}

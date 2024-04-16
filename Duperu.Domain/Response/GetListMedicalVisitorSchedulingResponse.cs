using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Domain.Response
{
    public class GetListMedicalVisitorSchedulingResponse
    {
        public int id { get; set; }
        public string full_medical_name { get; set; }
        public string code_closeup_doctor { get; set; }
        public string local_district { get; set; }
        public string cod_visitador { get; set; }
        public string full_name_medical_visitor { get; set; }
        public string status { get; set; }
        public string dsc_status { get; set; }
        public DateTime fecha_programacion { get; set; }

    }
}

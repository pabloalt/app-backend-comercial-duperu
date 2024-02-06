using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Domain.Response
{
    public class GetMedicalProductIndicatorResponse
    {
        public int id { get; set; }
        public string load_period { get; set; } = string.Empty;
        public string product_type { get; set; } = string.Empty;
        public string formula_brand { get; set; } = string.Empty;
        public double compete { get; set; } = 0;
        public double own { get; set; } = 0;
        public double px_total { get; set; } = 0;
        public double doctor_prescription_value { get; set; } = 0;
        public double own_medical_prescription_value { get; set; } = 0;
        public double visitor_recipe_value { get; set; } = 0;
        public double own_visitor_recipe_value { get; set; } = 0;
        public double total_value { get; set; } = 0;
        public double own_value { get; set; } = 0;
        public string code_closeup_doctor { get; set; }
    }
}

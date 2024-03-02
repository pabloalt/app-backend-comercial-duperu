using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Duperu.Domain.Model
{
    public class MedicalAgreementModel
    {
        public DateTime medical_agreement_application_date { get; set; }
        public int year_medical_agreement { get; set; }
        public string medical_agreement_number { get; set; } = string.Empty;
        public int status { get; set; }
        public int branch_id { get; set; }
        public int cmp_medical { get; set; }
        public string full_name_medical  { get; set; } = string.Empty;
        public string medical_sap_code { get; set; } = string.Empty;
        public string doctor_specialty { get; set; } = string.Empty;
        public string medical_category { get; set; } = string.Empty;
        public string medical_local { get; set; } = string.Empty;
        public string medical_district { get; set; } = string.Empty;

        public DateTime term_agreement_start_date { get; set; }  
        public DateTime term_agreement_end_date { get; set; } 
        public DateTime? term_agreement_last_contract_end_date { get; set; } 

        public int term_agreement_id_payment_form { get; set; }  
        public int term_agreement_id_renewal { get; set; } 
        public double term_agreement_amount_agreement { get; set; }

        public double ind_cup_assessment { get; set; }  
        public double ind_cup_investment { get; set; }  
        public string ind_cup_currency_code { get; set; } = string.Empty;
        public List<objective_medical_agreement>? ind_cup_objective_medical_list { get; set; } = new List<objective_medical_agreement>();
        public double ind_cup_amount_payments { get; set; } 
        public double ind_cup_initial_disbursement { get; set; }
        public double ind_cup_total_goals { get; set; } 
        public double ind_cup_total { get; set; } 

        public double ind_cup_tam_total_compete { get; set; } 
        public double ind_cup_tam_total_px { get; set; } 
        public double ind_cup_tam_own { get; set; } 
        public double ind_cup_tam_per_ms_negotiated { get; set; } 
        public double ind_cup_tam_per_ms_current { get; set; } 
        public double ind_cup_tam_per_ms_reach { get; set; } 
        public double ind_cup_tam_per_ms_reach_monthly { get; set; } 
        public double ind_cup_tam_per_previous_goal { get; set; } 
        public double ind_cup_tam_objective { get; set; } 
        public double ind_cup_tam_objective_two { get; set; } 
        public double ind_cup_tam_objective_three { get; set; } 
        public double ind_cup_tam_objective_four { get; set; }
         
        public double ind_cup_tam_total_value  { get; set; }
        public double ind_cup_tam_medical_prescription_value  { get; set; }
        public double ind_cup_tam_own_recipe_value  { get; set; } 
        public double ind_cup_tam_balance_payable  { get; set; } 
        public double ind_cup_tam_to_value_reach { get; set; } 
        public double ind_cup_tam_to_value_reach_monthly  { get; set; } 
        public double ind_cup_tam_previous_value_goal  { get; set; } 
        public double ind_cup_tam_objective_value_one  { get; set; } 
        public double ind_cup_tam_objective_value_two  { get; set; } 
        public double ind_cup_tam_objective_value_three  { get; set; } 
        public double ind_cup_tam_objective_value_four  { get; set; } 
         
        public string  observation { get; set; } = string.Empty;
        public string cod_responsible_visitor { get; set; } = string.Empty;
        public string cod_responsible_commercial_analyst { get; set; } = string.Empty;
        public string cod_responsible_supervisor { get; set; } = string.Empty;
       
        public string cod_approval_analista_comercial { get; set; } = string.Empty;
        public string cod_approval_supervisor { get; set; } = string.Empty;
        public string cod_approval_Manager_comercial { get; set; } = string.Empty;
        public string cod_approval_general_manager { get; set; } = string.Empty;

        public string user_creation { get; set; } = string.Empty;
        public DateTime creation_date { get; set; }
        public string? modification_user { get; set; } = string.Empty;
        public DateTime? modification_date { get; set; }
    }


    public class objective_medical_agreement
    {
        public int target_number { get; set; }
        public double target_amount { get; set; }        
    }
}



namespace Duperu.Domain.Response
{
    public class MedicalAgreementResponse
    {
        public string medical_agreement_number { get; set; } = string.Empty;
        public int medical_agreement_year { get; set; }
        public DateTime medical_agreement_date { get; set; }
        
    }
}

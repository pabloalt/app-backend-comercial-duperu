using Duperu.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Usecase.GetListMedicalAgreement
{
    public class GetListMedicalAgreementRequest : IRequest<List<GetListMedicalAgreementResponse>>
    {


        public int? year_medical_agreement { get; set; }
        public string? medical_agreement_number { get; set; }
        public string? cod_responsible_visitor { get; set; }
        public string? code_closeup_doctor { get; set; }
 
        public DateTime medical_agreement_application_date_initial { get; set; }
        public DateTime medical_agreement_application_date_final { get; set; }
    }
}

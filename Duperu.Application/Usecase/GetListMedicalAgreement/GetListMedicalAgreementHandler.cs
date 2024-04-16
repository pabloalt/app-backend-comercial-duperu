using Duperu.Application.Repository;
using Duperu.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Usecase.GetListMedicalAgreement
{
    public class GetListMedicalAgreementHandler : IRequestHandler<GetListMedicalAgreementRequest, List<GetListMedicalAgreementResponse>>
    {

        private ICommercialRepository _commercialRepository;

        public GetListMedicalAgreementHandler(ICommercialRepository commercialRepository)
        {
            _commercialRepository = commercialRepository;
        } 

        public async Task<List<GetListMedicalAgreementResponse>> Handle(GetListMedicalAgreementRequest request, CancellationToken cancellationToken)
        {
            return await _commercialRepository.GetListMedicalAgreement(request.year_medical_agreement, request.medical_agreement_number, request.cod_responsible_visitor, request.code_closeup_doctor, request.medical_agreement_application_date_initial, request.medical_agreement_application_date_final);
        }
    }
}

using Duperu.Application.Repository;
using Duperu.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Usecase.CreateMedicalAgreement
{
    public class CreateMedicalAgreementHandler : IRequestHandler<CreateMedicalAgreementRequest, MedicalAgreementResponse>
    {
        private readonly ICommercialRepository _repository;

        public CreateMedicalAgreementHandler(ICommercialRepository repository)
        {
            _repository = repository;
        }
         
        public async Task<MedicalAgreementResponse> Handle(CreateMedicalAgreementRequest request, CancellationToken cancellationToken)
        {


            request.year_medical_agreement = Convert.ToInt16(await _repository.GetValueParameterById(1)) ;
            request.medical_agreement_number = await _repository.GetValueParameterById(2);

            int currentYear = await _repository.GetMedicalAgreementCurrentlyYear();

            if (currentYear == request.year_medical_agreement)
            {
                int nextCorrelative = Convert.ToInt16(request.medical_agreement_number) + 1;
                await _repository.UpdateCorrelative(nextCorrelative);
            }
            else
            {
                // Si no, actualizar el año y reiniciar el correlativo
                int newYear = request.year_medical_agreement + 1;

                await _repository.UpdateCorrelative(2);
                await _repository.UpdateYear(newYear);

                request.medical_agreement_number = "1";
                request.year_medical_agreement = newYear;
            }

            var response = await _repository.CreateMedicalAgreement(request);
            return response;
        }
    }
}

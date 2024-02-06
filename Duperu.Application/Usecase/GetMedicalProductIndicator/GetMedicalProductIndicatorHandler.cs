using Duperu.Application.Repository;
using Duperu.Application.Usecase.GetListDoctorByUser;
using Duperu.Domain.Response;
using MediatR; 

namespace Duperu.Application.Usecase.GetMedicalProductIndicator
{
    public class GetMedicalProductIndicatorHandler : IRequestHandler<GetMedicalProductIndicatorRequest, List<GetMedicalProductIndicatorResponse>>
    {

        private ICommercialRepository _commercialRepository;
        public GetMedicalProductIndicatorHandler(ICommercialRepository commercialRepository)
        {
            _commercialRepository = commercialRepository;
        }

        public async Task<List<GetMedicalProductIndicatorResponse>> Handle(GetMedicalProductIndicatorRequest request, CancellationToken cancellationToken)
        {
            return await _commercialRepository.GetListMedicalProductIndicator(request.code_closeup_doctor);
        }
    }
}

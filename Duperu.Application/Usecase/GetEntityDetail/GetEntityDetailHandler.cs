using Duperu.Application.Repository;
using Duperu.Domain.Response;
using MediatR;

namespace Duperu.Application.Usecase.GetEntityDetail
{
    public class GetEntityDetailHandler : IRequestHandler<GetEntityDetailRequest, List<GetEntityDetailResponse>>
    {
        private ICommercialRepository _commercialRepository;

        public GetEntityDetailHandler(ICommercialRepository commercialRepository)
        {
            _commercialRepository = commercialRepository;
        }

        public async Task<List<GetEntityDetailResponse>> Handle(GetEntityDetailRequest request, CancellationToken cancellationToken)
        {
            return await _commercialRepository.GetEntityDetailById(request.business_entity_id);
        }
    }
}

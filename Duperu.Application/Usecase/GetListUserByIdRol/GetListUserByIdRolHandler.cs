using Duperu.Application.Repository;
using Duperu.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Usecase.GetListUserByIdRol
{
    public class GetListUserByIdRolHandler : IRequestHandler<GetListUserByIdRolRequest, List<GetListUserByIdRolResponse>>
    {
        private ICommercialRepository _commercialRepository;

        public GetListUserByIdRolHandler(ICommercialRepository commercialRepository)
        {
            _commercialRepository = commercialRepository;
        }
        public async Task<List<GetListUserByIdRolResponse>> Handle(GetListUserByIdRolRequest request, CancellationToken cancellationToken)
        {
            return await _commercialRepository.GetListUserByIdRol(request.id_rol);
        }
    }
}

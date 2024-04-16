using Duperu.Application.Repository;
using Duperu.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Usecase.GetListDoctorByUser
{
    public class GetListDoctorByUserHandler : IRequestHandler<GetListDoctorByUserRequest, List<GetListDoctorByUserResponse>>
    {

        private ICommercialRepository _commercialRepository;

        public GetListDoctorByUserHandler(ICommercialRepository commercialRepository)
        {
            _commercialRepository = commercialRepository;
        }

        public async Task<List<GetListDoctorByUserResponse>> Handle(GetListDoctorByUserRequest request, CancellationToken cancellationToken)
        {
            return await _commercialRepository.GetListDoctorByUser(request.code_user);
        }
    }
}

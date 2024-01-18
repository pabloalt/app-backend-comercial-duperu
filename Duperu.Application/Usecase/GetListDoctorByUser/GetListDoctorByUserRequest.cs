using Duperu.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Usecase.GetListDoctorByUser
{
    public class GetListDoctorByUserRequest : IRequest<List<GetListDoctorByUserResponse>>
    {
        public string? code_user { get; set; }
    }
}

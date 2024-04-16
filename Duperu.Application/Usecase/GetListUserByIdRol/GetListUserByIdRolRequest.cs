using Duperu.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Usecase.GetListUserByIdRol
{
    public class GetListUserByIdRolRequest : IRequest<List<GetListUserByIdRolResponse>>
    {
        public int? id_rol { get; set; }      

    }
}

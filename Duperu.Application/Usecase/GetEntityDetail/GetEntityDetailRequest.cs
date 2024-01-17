using Duperu.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Usecase.GetEntityDetail
{
    public class GetEntityDetailRequest : IRequest<List<GetEntityDetailResponse>>
    {
        public int business_entity_id { get; set; }

    }

}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duperu.Domain.Response;

namespace Duperu.Application.Usecase.GetMedicalProductIndicator
{
    public class GetMedicalProductIndicatorRequest : IRequest<List<GetMedicalProductIndicatorResponse>>
    { 
        public string? code_closeup_doctor { get; set; }
    }
}

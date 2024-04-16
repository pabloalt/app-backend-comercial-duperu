using Duperu.Domain.Model;
using Duperu.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Usecase.CreateMedicalAgreement
{
    public class CreateMedicalAgreementRequest : MedicalAgreementModel, IRequest<MedicalAgreementResponse>
    {
    }
}

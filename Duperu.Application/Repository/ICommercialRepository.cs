using Duperu.Application.Usecase.GetMedicalProductIndicator;
using Duperu.Domain.Model;
using Duperu.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Application.Repository
{
    public interface ICommercialRepository
    {
         
        Task<List<GetEntityDetailResponse>> GetEntityDetailById(int id);
        Task<List<GetListDoctorByUserResponse>> GetListDoctorByUser(string code_user);
        Task<List<GetMedicalProductIndicatorResponse>> GetListMedicalProductIndicator(string code_closeup_doctor);
        Task<List<GetListUserByIdRolResponse>> GetListUserByIdRol(int? id_rol);
        Task<int> GetMedicalAgreementCurrentlyYear();
        Task<int> UpdateCorrelative(int number);
        Task<String> GetValueParameterById(int parameterId);
        Task<int> UpdateYear(int year);
        Task<MedicalAgreementResponse> CreateMedicalAgreement(MedicalAgreementModel request);
        Task<int> CreateObjectiveMedicalAgreement(MedicalAgreementModel request);

    }
}

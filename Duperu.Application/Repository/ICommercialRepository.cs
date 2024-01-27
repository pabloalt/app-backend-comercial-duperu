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
        Task<List<GetListUserByIdRolResponse>> GetListUserByIdRol(int? id_rol);
 
        
    }
}

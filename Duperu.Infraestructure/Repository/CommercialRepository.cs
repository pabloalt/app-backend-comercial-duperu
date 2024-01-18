using Dapper;
using Duperu.Application.Repository;
using Duperu.Domain.Response;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duperu.Infraestructure.Repository
{
    public class CommercialRepository : ICommercialRepository
    {
        private readonly IDbConnection _connection;

        public CommercialRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<GetEntityDetailResponse>> GetEntityDetailById(int business_entity_id)
        {
            try
            {
                string query = @"
                select
                id,
                codigo_oficial as codigo,
                descripcion as description,
                codigo_oficial || '-' || descripcion full_name
                from com.detalle_entidad_comercial
                where 
                estado = 1 and
                id_entidad_comercial=@business_entity_id ;            
    
                ";
                var arg = new { business_entity_id};

                IEnumerable<GetEntityDetailResponse> result = await _connection.QueryAsync<GetEntityDetailResponse>(query, arg);
                return result.ToList();
            } 
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public async Task<List<GetListDoctorByUserResponse>> GetListDoctorByUser(string code_user)
        {
            try
            {
                string query = @"
                select
                    PRVM.id AS ID,
                    PRVM.CMP AS CMP, 
                    CMED.nome as FULL_NAME_DOCTOR, 
                    'M' || LPAD( CAST(CAST(CMED.CDGMED AS INTEGER) AS VARCHAR), 11, '0') as CODE_SAP,
                    1 as CATEGORY,
                    CMED.LOCAL_D AS LOCAL_ADDRESS,
                    CMED.BAIRRO AS LOCAL_DISTRICT,
                    CMED.CDGMED_REG AS CODE_CLOSEUP,
                    CMED.cdgesp1 AS SPECIALTY,
                    '' AS PREVIOUS_CONTRACT_END_DATE,
                    4 as RENOVATION
                FROM CUP.MEDICO CMED
                INNER JOIN com.programacion_visita_medico PRVM ON (CAST(CMED.CRM AS INTEGER)= PRVM.CMP AND PRVM.ESTADO=1 ) 
                WHERE 
                (PRVM.cod_visitador = @code_user OR @code_user IS NULL)    
                ";
                var arg = new { code_user };

                IEnumerable<GetListDoctorByUserResponse> result = await _connection.QueryAsync<GetListDoctorByUserResponse>(query, arg);
                return result.ToList();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }



    }
}

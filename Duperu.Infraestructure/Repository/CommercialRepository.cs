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
    }
}

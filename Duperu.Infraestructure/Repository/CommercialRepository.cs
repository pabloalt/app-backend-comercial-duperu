using AutoMapper.Execution;
using Dapper;
using Duperu.Application.Repository;
using Duperu.Domain.Model;
using Duperu.Domain.Response;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Duperu.Infraestructure.Repository
{
    public class CommercialRepository : ICommercialRepository
    {
        private readonly IDbConnection _connection;

        public CommercialRepository(IDbConnection connection)
        {
            _connection = connection;
        }

 

        public async Task<MedicalAgreementResponse> CreateMedicalAgreement(MedicalAgreementModel request)
        {
            try
            {
                using TransactionScope trans = new(TransactionScopeAsyncFlowOption.Enabled);

                        string query = @"  
                            INSERT INTO com.acuerdo_medico
		                    ( 
                                fecha_solicitud_acuerdo_medico,
                                anio_acuerdo_medico,
                                numero_acuerdo_medico,
                                estado,
                                id_sucursal,
                                cmp_medico,
                                nombre_apellido_medico,
                                codigo_sap_medico,
                                especialidad_medico,
                                categoria_medico,
                                local_medico,
                                distrito_medico,
                                termino_acuerdo_fecha_incicio,
                                termino_acuerdo_fecha_fin,
                                termino_acuerdo_fecha_fin_ultimo,
                                termino_acuerdo_id_forma_pago,
                                termino_acuerdo_id_renovacion,
                                termino_acuerdo_cant_acuerdo,
                                ind_cup_valoracion,
                                ind_cup_inversion,
                                ind_cup_codigo_moneda,
                                ind_cup_cantidad_pagos,
                                ind_cup_desembolso_inicial,
                                ind_cup_total_objetivos,
                                ind_cup_total,
                                ind_cup_tam_total_compite,
                                ind_cup_tam_total_px,
                                ind_cup_tam_propio,
                                ind_cup_tam_per_ms_negociado,
                                ind_cup_tam_per_ms_actual,
                                ind_cup_tam_per_ms_alcanzar,
                                ind_cup_tam_per_ms_alcanzar_mensual,
                                ind_cup_tam_per_objetivo_anterior,
                                ind_cup_tam_objetivo,
                                ind_cup_tam_objetivo_dos,
                                ind_cup_tam_objetivo_tres,
                                ind_cup_tam_objetivo_cuatro,
                                observacion,
                                cod_responsable_visitador,
                                cod_responsable_analista_comercial,
                                cod_responsable_supervisor,
                                cod_aprobacion_analista_comercial,
                                cod_aprobacion_supervisor,
                                cod_aprobacion_Gerente_comercial,
                                cod_aprobacion_Gerente_general,
                                fecha_creacion,
                                usuario_creacion
		                    )
		                    VALUES(
			                    @medical_agreement_application_date,
                                @year_medical_agreement,			                    
                                LPAD(@medical_agreement_number, 8, '0'),
			                    @status,
			                    @branch_id, 
			                    @cmp_medical, 
			                    @full_name_medical, 
			                    @medical_sap_code,
			                    @doctor_specialty,	
			                    @medical_category,	
			                    @medical_local,	
			                    @medical_district,	
			                    @term_agreement_start_date,	
			                    @term_agreement_end_date,	
			                    @term_agreement_last_contract_end_date,	
			                    @term_agreement_id_payment_form,	
			                    @term_agreement_id_renewal,	
			                    @term_agreement_amount_agreement,	
			                    @ind_cup_assessment,			
			                    @ind_cup_investment,	
			                    @ind_cup_currency_code,	
			                    @ind_cup_amount_payments,	
			                    @ind_cup_initial_disbursement,	
			                    @ind_cup_total_goals,	
			                    @ind_cup_total,	
			                    @ind_cup_tam_total_compete,	
			                    @ind_cup_tam_total_px,	
			                    @ind_cup_tam_own,		
			                    @ind_cup_tam_per_ms_negotiated,	 	
			                    @ind_cup_tam_per_ms_current,	 	
			                    @ind_cup_tam_per_ms_reach,	 	
			                    @ind_cup_tam_per_ms_reach_monthly,	 	
			                    @ind_cup_tam_per_previous_goal,	 	
			                    @ind_cup_tam_objective,	 	
			                    @ind_cup_tam_objective_two,	 	
			                    @ind_cup_tam_objective_three,	 	
			                    @ind_cup_tam_objective_four,
                                @observation,
			                    @cod_responsible_visitor,	 	
			                    @cod_responsible_commercial_analyst,	 	
			                    @cod_responsible_supervisor,	 	
			                    @cod_approval_analista_comercial,	 	
			                    @cod_approval_supervisor,	 	
			                    @cod_approval_Manager_comercial,	
                                @cod_approval_general_manager,
			                    (SELECT current_timestamp AT TIME ZONE 'America/Lima'), 
			                    @user_creation 
			                )
	                        returning numero_acuerdo_medico as medical_agreement_number, anio_acuerdo_medico as year_medical_agreement, fecha_solicitud_acuerdo_medico as medical_agreement_date;


                ";

                var reader = await _connection.ExecuteReaderAsync(query, request);

                MedicalAgreementResponse response = new() { };

                if (reader.Read())
                {
                    string Medical_Agreement_number = reader.GetString(0);
                    int Medical_Agreement_year = reader.GetInt16(1);
                    DateTime Medical_Agreement_date = reader.GetDateTime(2);      

                    response = new MedicalAgreementResponse()
                    {
                        medical_agreement_number = Medical_Agreement_number,
                        medical_agreement_year = Medical_Agreement_year,
                        medical_agreement_date = Medical_Agreement_date
                    };
                }
                reader.Close();
                trans.Complete();
                return response;
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
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
                    CMED.PERSONAL_ID as CATEGORY,
                    CMED.LOCAL_D AS LOCAL_ADDRESS,
                    CMED.BAIRRO AS LOCAL_DISTRICT,
                    CMED.CDGMED_REG AS CODE_CLOSEUP,
                    CMED.cdgesp1 AS SPECIALTY,
                    '' AS PREVIOUS_CONTRACT_END_DATE,
                    4 as RENOVATION,
                    0 as PREVIOUS_CONTRACT_COUNT 
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

        public async Task<List<GetListUserByIdRolResponse>> GetListUserByIdRol(int? id_rol)
        {
            try
            {
                string query = @"
                select 
                    usu.nombre_usuario|| ' ' || usu.apellido_usuario as full_name,	 
                    usu.codigo_usuario as user_code,
                    usu.cuenta_directorio_activo as active_directory_account,
                    urg.id_rol as id_rol,
                    crl.descripcion  as description
                from com.usuario_rol_grupo  urg 
                inner join com.rol crl on (urg.id_rol = crl.id and crl.estado= 1  )
                inner join com.usuario usu on (urg.codigo_usuario = usu.codigo_usuario and usu.estado= 1)
                where 
                urg.estado = 1 and 
                (urg.id_rol = @id_rol OR @id_rol IS NULL)    
                ";
                var arg = new { id_rol };

                IEnumerable<GetListUserByIdRolResponse> result = await _connection.QueryAsync<GetListUserByIdRolResponse>(query, arg);
                return result.ToList();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetMedicalAgreementCurrentlyYear()
        {
            try
            {
                string query = @"
					select date_part('year',(SELECT current_timestamp AT TIME ZONE 'America/Lima'));
				";
                IEnumerable<int> response = await _connection.QueryAsync<int>(query);
                return response.FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateCorrelative(int number)
        {
            try
            {
                const int correlativeId = 2;

                string query = @"
					update com.parametro set valor_parametro = @number where id = @correlativeId  returning valor_parametro;
				";
                var args = new { correlativeId, number };

                IEnumerable<int> response = await _connection.QueryAsync<int>(query, args);
                return response.FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }
         

        public async Task<int> UpdateYear(int year)
        {
            try
            {
                const int parameterId = 1;

                string query = @"
					update com.parametro set valor_parametro = @year where id = @parameterId  returning valor_parametro;
				";
                var args = new { parameterId, year };

                IEnumerable<int> response = await _connection.QueryAsync<int>(query, args);
                return response.FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }
 

 

        public async Task<string> GetValueParameterById(int parameterId)
        {
            try
            {

                string query = @"
					select 
                        valor_parametro as parameter_value
                    from com.parametro p
                    where 
                    p.estado = 1 and 
                    p.id=@parameterId
                    ;
				"
                ;

                var args = new { parameterId };

                IEnumerable<string> response = await _connection.QueryAsync<string>(query, args);
                return response.FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public async Task<List<GetMedicalProductIndicatorResponse>> GetListMedicalProductIndicator(string code_closeup_doctor)
        {
            try
            {
                string query = @"
                 select  
                    id ,
                    periodo_carga as load_period,
                    tipo_producto as product_type,	
                    marca_formula as formula_brand,	 
                    compite	as compete,
                    propio	as own,
                    px_total	as px_total,
                    valor_receta_medico	as doctor_prescription_value,
                    valor_receta_medico_propio	as own_medical_prescription_value,
                    valor_receta_visitador	as visitor_recipe_value,
                    valor_receta_visitador_propio as own_visitor_recipe_value,	
                    valor_total	as total_value,
                    valor_propio as own_value	 ,
                    codigo_medico as code_closeup_doctor
                    from com.indicador_producto_medico
                where  
                 (codigo_medico = @code_closeup_doctor OR @code_closeup_doctor IS NULL)   
                order by  compite;   
                ";
                var arg = new { code_closeup_doctor };

                IEnumerable<GetMedicalProductIndicatorResponse> result = await _connection.QueryAsync<GetMedicalProductIndicatorResponse>(query, arg);
                return result.ToList();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }
    }
}

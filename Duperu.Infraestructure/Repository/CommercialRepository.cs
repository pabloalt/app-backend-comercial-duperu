﻿using AutoMapper.Execution;
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
                                code_closeup_doctor,
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

                                ind_cup_tam_valor_total,
                                ind_cup_tam_valor_receta_medico,
                                ind_cup_tam_valor_receta_propio,
                                ind_cup_tam_saldo_pagar,
                                ind_cup_tam_valor_alcanzar,
                                ind_cup_tam_valor_alcanzar_mensual,
                                ind_cup_tam_valor_objetivo_anterior,
                                ind_cup_tam_valor,
                                ind_cup_tam_valor_dos,
                                ind_cup_tam_valor_tres,
                                ind_cup_tam_valor_cuatro,

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
                                @code_closeup_doctor,
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

                                @ind_cup_tam_total_value,
                                @ind_cup_tam_medical_prescription_value,
                                @ind_cup_tam_own_recipe_value,
                                @ind_cup_tam_balance_payable,
                                @ind_cup_tam_to_value_reach,
                                @ind_cup_tam_to_value_reach_monthly,
                                @ind_cup_tam_previous_value_goal,
                                @ind_cup_tam_objective_value_one,
                                @ind_cup_tam_objective_value_two,
                                @ind_cup_tam_objective_value_three,
                                @ind_cup_tam_objective_value_four,

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
	                        returning numero_acuerdo_medico as medical_agreement_number, anio_acuerdo_medico as medical_agreement_year, fecha_solicitud_acuerdo_medico as medical_agreement_date;


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

        public async Task<int> CreateObjectiveMedicalAgreement(MedicalAgreementModel request)
        {
            try
            {
                using TransactionScope trans = new(TransactionScopeAsyncFlowOption.Enabled);

                int hasCreate= 0;

                if (request.ind_cup_objective_medical_list != null && request.ind_cup_objective_medical_list.Any())
                {


                    string queryoam = @"
                        INSERT INTO com.objetivo_acuerdo_medico
                        (
                            anio_acuerdo_medico,
                            numero_acuerdo_medico,
                            numero_objetivo,
                            importe_objetivo,
                            estado,
                            usuario_creacion,
                            fecha_creacion  
                        )
                        VALUES
                        (
                            @year_medical_agreement,
                            @medical_agreement_number,
                            @number,
                            @amount,
                            1,
                            @user_creation, 
			                (SELECT current_timestamp AT TIME ZONE 'America/Lima')
			                    
                        )
                    ";

                    foreach (var item in request.ind_cup_objective_medical_list)
                    {
                        var argsoam = new
                        {
                            request.year_medical_agreement,
                            request.medical_agreement_number,
                            number = item.target_number,
                            amount = item.target_amount,
                            request.user_creation
                        }; 
                        
                        await _connection.ExecuteScalarAsync(queryoam, argsoam);
                    }


                }


                trans.Complete();

                return hasCreate;
            }
            catch (NpgsqlException err)
            {
                throw new NpgsqlException(err.Message);
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

        public async Task<List<GetListMedicalAgreementResponse>> GetListMedicalAgreement(int? year_medical_agreement, string? medical_agreement_number, string? cod_responsible_visitor, string? code_closeup_doctor, DateTime medical_agreement_application_date_initial, DateTime medical_agreement_application_date_final)
        {
            try
            {
                string query = @"
                select  
		                am.anio_acuerdo_medico as year_medical_agreement,
		                am.numero_acuerdo_medico as medical_agreement_number, 
	 	                am.fecha_solicitud_acuerdo_medico as medical_agreement_application_date,
	 	                am.nombre_apellido_medico as full_medical_name ,
	 	                (select  (nombre_usuario ||apellido_usuario) full_name_visitor  from com.usuario u   where codigo_usuario = am.cod_responsable_visitador) as full_name_medical_visitor,
	 	                am.estado as status,
	 	                dec.descripcion as description,
	 	                distrito_medico as medical_district,
	 	                am.id_sucursal as branch_id

                 from 	 	com.acuerdo_medico am  
                 inner join com.detalle_entidad_comercial dec on (CAST(am.estado AS TEXT) = dec.codigo_oficial  and dec.id_entidad_comercial =3)
                 where 
                 (am.anio_acuerdo_medico  =  @year_medical_agreement OR @year_medical_agreement IS NULL) AND
                 (upper(am.numero_acuerdo_medico) LIKE '%' || @medical_agreement_number|| '%' OR @medical_agreement_number IS NULL) AND
                 (upper(am.cod_responsable_visitador) LIKE '%' || @cod_responsible_visitor || '%' OR @cod_responsible_visitor IS NULL) AND
                 (upper(am.code_closeup_doctor) LIKE '%' || @code_closeup_doctor || '%' OR @code_closeup_doctor IS NULL) AND
                 (am.fecha_solicitud_acuerdo_medico BETWEEN 
					CASE
						WHEN @medical_agreement_application_date_initial IS NOT NULL 
						THEN @medical_agreement_application_date_initial 
						ELSE am.fecha_solicitud_acuerdo_medico END 
					AND 
					CASE
						WHEN @medical_agreement_application_date_final IS NOT NULL  
						THEN @medical_agreement_application_date_final 
						ELSE am.fecha_solicitud_acuerdo_medico END
				);
                ";
                var arg = new { year_medical_agreement, medical_agreement_number , cod_responsible_visitor, code_closeup_doctor, medical_agreement_application_date_initial, medical_agreement_application_date_final };

                IEnumerable<GetListMedicalAgreementResponse> result = await _connection.QueryAsync<GetListMedicalAgreementResponse>(query, arg);
                return result.ToList();

            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }
    }
}

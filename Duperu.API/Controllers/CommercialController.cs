using Duperu.Application.Usecase.CreateMedicalAgreement;
using Duperu.Application.Usecase.GetEntityDetail;
using Duperu.Application.Usecase.GetListDoctorByUser;
using Duperu.Application.Usecase.GetListUserByIdRol;
using Duperu.Application.Usecase.GetMedicalProductIndicator;
using Duperu.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Duperu.API
{
    [Route("api/request")]
    [ApiController]
    public class CommercialController : ControllerBase
    {


        private readonly IMediator _mediator;


        public CommercialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet(template: "businessentityid/{id}")]
        [SwaggerResponse(200, "Obtener detalle de entidadad", typeof(CustomResponse<string>))]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        [SwaggerResponse(500, "Ocurrio un error interno, por favor comunicate con el administrador del sistema.")]

        public async Task<IActionResult> GetEntityDetail(int id)
        {

            GetEntityDetailRequest request = new() { business_entity_id = id };
            var result = await _mediator.Send(request);

            return Ok(new CustomResponse<List<GetEntityDetailResponse>>($"Se obtuvieron {result.Count()} registro de la id entidad", result));
        }

        [HttpGet(template: "listdoctorbyuser")]
        [SwaggerResponse(200, "Obtener listado de doctores por visitador medico", typeof(CustomResponse<string>))]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        [SwaggerResponse(500, "Ocurrio un error interno, por favor comunicate con el administrador del sistema.")]

        public async Task<IActionResult> GetListDoctorByUser ([FromQuery] string? codeuser)
        {

            GetListDoctorByUserRequest request = new() { code_user = codeuser };
            var result = await _mediator.Send(request);

            return Ok(new CustomResponse<List<GetListDoctorByUserResponse>>($"Se obtuvieron {result.Count()} registro de medicos ", result));
        }

        [HttpGet(template: "listuser")]
        [SwaggerResponse(200, "Obtener listado de usuario por rol", typeof(CustomResponse<string>))]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        [SwaggerResponse(500, "Ocurrio un error interno, por favor comunicate con el administrador del sistema.")]

        public async Task<IActionResult> GetListUserByIdRol([FromQuery] int? idrol)
        {

            GetListUserByIdRolRequest request = new() { id_rol = idrol };
            var result = await _mediator.Send(request);

            return Ok(new CustomResponse<List<GetListUserByIdRolResponse>>($"Se obtuvieron {result.Count()} registro de usuarios ", result));
        }


        [HttpPost(template: "createmedicalagreement")]
        [SwaggerResponse(200, "Crear acuerdo Medico", typeof(CustomResponse<MedicalAgreementResponse>))]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        [SwaggerResponse(500, "Ocurrio un error interno")]
        public async Task<IActionResult> CreateMedicalAgreement([FromBody] CreateMedicalAgreementRequest request)
        {             
            var response = await _mediator.Send(request);
            return Ok(new CustomResponse<MedicalAgreementResponse>($"Se creó el  acuerdo Medico con el correlativo: {response.medical_agreement_number}", response));
        }



        [HttpGet(template: "listmedicalproductindicator")]
        [SwaggerResponse(200, "Obtener listado de doctores por visitador medico", typeof(CustomResponse<string>))]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        [SwaggerResponse(500, "Ocurrio un error interno, por favor comunicate con el administrador del sistema.")]

        public async Task<IActionResult> GetMedicalProductIndicator([FromQuery] string? codecloseupdoctor)
        {

            GetMedicalProductIndicatorRequest request = new() { code_closeup_doctor = codecloseupdoctor };
            var result = await _mediator.Send(request);

            return Ok(new CustomResponse<List<GetMedicalProductIndicatorResponse>>($"Se obtuvieron {result.Count()} registro de medicamentos asociado al medico con codigo : {codecloseupdoctor} ", result));
        }

    }
}

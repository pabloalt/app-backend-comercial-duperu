using Duperu.Application.Usecase.GetEntityDetail;
using Duperu.Application.Usecase.GetListDoctorByUser;
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


    }
}

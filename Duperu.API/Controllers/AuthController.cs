using Duperu.Application.Usecase.GetEntityDetail;
using Duperu.Application.Usecase.GetMedicalProductIndicator;
using Duperu.Domain.Model;
using Duperu.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography;
using System.Xml;

namespace Duperu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /*
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
        */
        /*
        [HttpPost("Register")]
        [SwaggerResponse(200, "Obtener detalle de entidadad", typeof(CustomResponse<string>))]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        [SwaggerResponse(500, "Ocurrio un error interno, por favor comunicate con el administrador del sistema.")]
        public IActionResult Register([FromBody] RegisterModel model)   
        {
            var user  = new UserModel { UserName = model.UserName };
            if(model.ConfirmPassword == model.Password)
            {
                using (HMACSHA512 hmac = new HMACSHA512())
                {
                    user.PasswordSalt = hmac.Key;
                    user.PasswordHast = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));
                }
            }
            else
            {
            return BadRequest("pasdada dony match");
            }
            

        }
        */

      

    }
}

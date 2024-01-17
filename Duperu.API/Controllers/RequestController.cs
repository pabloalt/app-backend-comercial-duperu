using Duperu.Application.Usecase.GetEntityDetail;
using Duperu.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Duperu.API
{
    [Route("api/request")]
    [ApiController]
    public class RequestController : ControllerBase
    {


        private readonly IMediator _mediator;


        public RequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }




        [HttpGet(template: "id/{id}")]
        [SwaggerResponse(200, "Obtener detalle de entidadad", typeof(CustomResponse<string>))]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        [SwaggerResponse(500, "Ocurrio un error interno, por favor comunicate con el administrador del sistema.")]

        public async Task<IActionResult> GetEntityDetail(int id)
        {

            GetEntityDetailRequest request = new() { business_entity_id = id };
            var result = await _mediator.Send(request);

            return Ok(new CustomResponse<List<GetEntityDetailResponse>>($"Se obtuvieron {result.Count()} registro de la id entidad", result));
        }
    }
}

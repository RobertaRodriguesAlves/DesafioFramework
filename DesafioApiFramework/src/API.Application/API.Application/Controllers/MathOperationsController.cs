using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Application.Service.Abstractions;

namespace API.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MathOperationsController : ControllerBase
    {
        private readonly IMathOperationsService _service;
        public MathOperationsController(IMathOperationsService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("{number}")]
        public async Task<ActionResult> Get(int number)
        {
            try
            {
                if (!ModelState.IsValid || number <= 0)
                    return BadRequest(ModelState);

                var result = await _service.Get(number);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

using System.Net;
using Api.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitRepoController : ControllerBase
    {
        private IGitRepoInterface _service;

        public GitRepoController(IGitRepoInterface service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

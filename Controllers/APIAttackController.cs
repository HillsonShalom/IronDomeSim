using IronDomeSim.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IronDomeSim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIAttackController : ControllerBase
    {
        private readonly APIAttackService _service;
        public APIAttackController(APIAttackService s)
        {
            _service = s;
        }

        [HttpGet]
        public async Task<IActionResult> MissilesImgs()
        {
            string asJson = JsonConvert.SerializeObject(await _service.GetAllMisslesImgs());
            return Ok(asJson);
        }
    }
}

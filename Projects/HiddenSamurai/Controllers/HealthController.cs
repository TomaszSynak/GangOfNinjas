using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiddenSamurai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public async Task Get()
        {
            Response.StatusCode = 200;
            await Response.WriteAsync($"Healthy <br><br> --- <br> Best <br> <i><small>{nameof(HiddenSamurai)}</small></i>");
        }
    }
}

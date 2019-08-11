using System.Linq;
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
            await Response.WriteAsync(
                "Healthy \n\r" +
                $"Headers: \n\r {string.Join("\n", Request.Headers.ToList().Select(h => $"{h.Key} - {h.Value}"))} \n\r" +
                " --- Best \n\r" +
                $"{nameof(HiddenSamurai)}");
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cakes.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly CakesContext _cakes;

        public AppController(CakesContext cakes)
        {
            _cakes = cakes;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cakes.Employees.ToListAsync());
        }
    }
}
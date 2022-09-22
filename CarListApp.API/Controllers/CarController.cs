using Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CarListApp.API.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ILoggerManager _logger;

        public CarController(ILoggerManager logger)
        {
            _logger = logger;
        }
       
    }
}

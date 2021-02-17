using Microsoft.AspNetCore.Mvc;
using Siemens.Service;
using Siemens.Model;
using Siemens.Helper;

namespace Siemens.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintController : ControllerBase
    {
        private IPrintFactory _factory;

        public PrintController(IPrintFactory factory)
        {
            _factory = factory;
        }

        [HttpPost("printpdf")]
        public IActionResult Print([FromBody]PrintModel model)
        {
            var printService = _factory.Create("pdf");
            printService.Print(model);
            return Ok();
        }

        [HttpPost("printfile")]
        public IActionResult PrintFile([FromBody]PrintModel model)
        {
            var printService = _factory.Create("file");
            printService.Print(model);
            return Ok();
        }

        [HttpPost("printpaper")]
        public IActionResult PrintPaper([FromBody]PrintModel model)
        {
            var printService = _factory.Create("paper");
            printService.Print(model);
            return Ok();
        }
    }
}
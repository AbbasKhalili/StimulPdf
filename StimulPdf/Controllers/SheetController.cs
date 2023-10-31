using Microsoft.AspNetCore.Mvc;
using StimulPdf.Services;

namespace StimulPdf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SheetController : ControllerBase
    {
        private readonly ISheetFacadeReporting _facadeReporting;

        public SheetController(ISheetFacadeReporting facadeReporting)
        {
            _facadeReporting = facadeReporting;
        }

        [HttpGet("PrintSheet")]
        public async Task<IActionResult> PrintSheet()
        {
            var result = await _facadeReporting.PrintSheet();
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "Sheet.pdf",
                Inline = false,
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            return File(result.Content, result.ContentType, "Sheet.pdf");
        }
    }
}
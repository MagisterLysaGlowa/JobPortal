using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UlpoadFileController : ControllerBase
    {
        private readonly ILogger<UlpoadFileController> logger;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UlpoadFileController(ILogger<UlpoadFileController> logger, IWebHostEnvironment webHostEnvironment)
        {
            this.logger = logger;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                // Store the content.
                var httpContent = HttpContext.Request;

                //check for null
                if (httpContent is null)
                    return BadRequest();

                // check if the context contains multiple file.
                if (httpContent.Form.Files.Count > 0)
                {
                    // loop through
                    foreach (var file in httpContent.Form.Files)
                    {
                        // get file path 
                        var filePath = Path.Combine(webHostEnvironment.ContentRootPath, "SeverResources/Uploads");

                        // check if director exist; if NO then create.
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        //copy the file to the folder
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                        }
                    }
                    return Ok(httpContent.Form.Files.Count.ToString() + " file(s) uploaded");
                }
                return BadRequest("No file selected");

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("GetImage/{fileName}")]
        public async Task<IActionResult> Get(string fileName)
        {
            var uploadsFolder = Path.Combine(webHostEnvironment.ContentRootPath, "SeverResources/Uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (System.IO.File.Exists(filePath))
            {
                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                return File(imageBytes, "image/jpeg"); // You can set the appropriate content type here based on your image type.
            }
            else
            {
                return NotFound("Image not found.");
            }
        }


    }
}
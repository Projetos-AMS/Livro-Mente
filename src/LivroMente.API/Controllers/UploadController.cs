using LivroMente.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IBlobService _blobService;

        public UploadController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost("")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult> UploadProfilePicture(IFormFile file)
        {
            if (file == null) return BadRequest("File not found.");

            var result = await _blobService.UploadFileBlobAsyn(
                "livromente",
                file.OpenReadStream(),
                file.ContentType,
                file.FileName);

            var toReturn = result.AbsoluteUri;
            return Ok(new { path = toReturn });
        }
    }
}
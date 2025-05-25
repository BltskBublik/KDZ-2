using Microsoft.AspNetCore.Mvc;

namespace FileStoringService.Controllers;

[ApiController]
[Route("file")]
public class FileController : ControllerBase
{
    private static readonly string UploadDir = "uploads";
    static FileController() => Directory.CreateDirectory(UploadDir);

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var id = Guid.NewGuid().ToString();
        var path = Path.Combine(UploadDir, id + ".txt");
        using var stream = System.IO.File.Create(path);
        await file.CopyToAsync(stream);
        return Ok(new { file_id = id });
    }

    [HttpGet("get/{id}")]
    public IActionResult Get(string id)
    {
        var path = Path.Combine(UploadDir, id + ".txt");
        if (!System.IO.File.Exists(path)) return NotFound();
        var content = System.IO.File.ReadAllText(path);
        return Ok(new { content });
    }
}

using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers;

[ApiController]
[Route("gateway")]
public class GatewayController : ControllerBase
{
    private readonly HttpClient _client = new();

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] IFormFile file)
    {
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
        var response = await _client.PostAsync("http://filestoringservice/file/upload", content);
        return Content(await response.Content.ReadAsStringAsync(), "application/json");
    }

    [HttpGet("analyze/{id}")]
    public async Task<IActionResult> Analyze(string id)
    {
        var response = await _client.GetAsync($"http://fileanalysisservice/analysis/analyze/{id}");
        return Content(await response.Content.ReadAsStringAsync(), "application/json");
    }
}

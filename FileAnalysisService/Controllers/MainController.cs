using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace FileAnalysisService.Controllers;

[ApiController]
[Route("analysis")]
public class AnalysisController : ControllerBase
{
    private readonly HttpClient _client = new();

    [HttpGet("analyze/{id}")]
    public async Task<IActionResult> Analyze(string id)
    {
        var response = await _client.GetAsync($"http://filestoringservice/file/get/{id}");
        var data = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        if (data == null || !data.ContainsKey("content")) return NotFound();

        var text = data["content"];
        var paragraphs = text.Split("

").Length;
        var words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
        var characters = text.Length;

        return Ok(new { paragraphs, words, characters });
    }
}

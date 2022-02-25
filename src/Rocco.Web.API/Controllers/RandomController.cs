using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Rocco.Web.API.Configurations;
using System.Net;

namespace Rocco.Web.API.Controllers;
[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class RandomController : ControllerBase
{
    private readonly GeneralSettings _generalSettingsOption;
    private readonly IHttpClientFactory _httpClientFactory;

    public RandomController(IOptions<GeneralSettings> generalSettingsOption, IHttpClientFactory httpClientFactory)
    {
        if (httpClientFactory is null)
        {
            throw new ArgumentNullException(nameof(httpClientFactory));
        }

        _generalSettingsOption = generalSettingsOption.Value ?? throw new ArgumentNullException(nameof(generalSettingsOption));
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet("getrandom", Name = "GetRandom")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int[]))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetRandom()
    {
        using (var client = _httpClientFactory.CreateClient("RandomNumber.WebApi"))
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, _generalSettingsOption.UrlRandomService);
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest(response);
                }
                var data = await response.Content.ReadFromJsonAsync<int[]>();
                return Ok(JsonConvert.SerializeObject(new { Result = data?.First() }));
            }


            catch (HttpRequestException ex) { return GetMessage(ex.Message); }
            catch (Exception ex) { return GetMessage($"Ups: something happends: {ex.Message}"); }
        }



    }

    private IActionResult GetMessage(string message)
    {
        return BadRequest(JsonConvert.SerializeObject(new { error = message }));
    }
}

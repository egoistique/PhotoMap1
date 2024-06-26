﻿namespace PhotoMap.API.Controllers;

using AutoMapper;
using PhotoMap.Services.UserAccount;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;

    public AuthController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpPost]
    public async Task<IActionResult> AuthenticateAsync([FromBody] LoginRequest request)
    {
        try
        {
            var client = _clientFactory.CreateClient();

            //var tokenRequest = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5027/connect/token");
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, "http://host.docker.internal:10001/connect/token");
            tokenRequest.Content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", request.Username),
                    new KeyValuePair<string, string>("password", request.Password),
                    new KeyValuePair<string, string>("scope", "points_read points_write"),
                });


            var clientId = "frontend";
            var clientSecret = "A3F0811F2E934C4F1114CB693F7D785E";
            var credentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            tokenRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

            var tokenResponse = await client.SendAsync(tokenRequest);

            if (!tokenResponse.IsSuccessStatusCode)
            {
                return BadRequest("Authentication failed.");
            }

            var responseContent = await tokenResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Response Content: " + responseContent);
            var tokenContent = JsonSerializer.Deserialize<TokenResponse>(responseContent);


            Console.WriteLine(tokenContent.AccessToken);

            return Ok(tokenContent.AccessToken);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class TokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("scope")]
    public string Scope { get; set; }
}




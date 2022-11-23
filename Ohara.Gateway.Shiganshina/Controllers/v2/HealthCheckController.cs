using Microsoft.AspNetCore.Mvc;

namespace Pajuhesh.Gateway.Shiganshina.Controllers.v2;

[ApiVersion("2.0")]
public class HealthCheck : BaseApiController
{
    [MapToApiVersion("2.0")]
    [HttpGet("ping")]
    public string Ping()
    {
        return "Poke";
    }
}
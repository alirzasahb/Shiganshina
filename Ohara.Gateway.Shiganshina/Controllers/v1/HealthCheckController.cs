using Microsoft.AspNetCore.Mvc;

namespace Pajuhesh.Gateway.Shiganshina.Controllers.v1;

[ApiVersion("1.0")]
public class HealthCheck : BaseApiController
{
    [MapToApiVersion("1.0")]
    [HttpGet("ping")]
    public string Ping()
    {
        return "Pong";
    }
}
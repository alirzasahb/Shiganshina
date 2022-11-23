using Microsoft.AspNetCore.Mvc;

namespace Pajuhesh.Gateway.Shiganshina.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseApiController : Controller
{
}
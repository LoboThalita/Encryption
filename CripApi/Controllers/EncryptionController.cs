using Microsoft.AspNetCore.Mvc;

namespace CripApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EncryptionController : ControllerBase
{
    private readonly ICriptografiaService _service;

    public EncryptionController(ICriptografiaService service)
    {
        _service = service;
    }

    [HttpPost("criptografar")]
    public IActionResult Criptografar([FromBody] string texto)
    {
        var resultado = _service.CriptografarTexto(texto);
        return Ok(resultado);
    }

    [HttpPost("descriptografar")]
    public IActionResult Descriptografar([FromBody] string textoCriptografado)
    {
        var resultado = _service.DescriptografarTexto(textoCriptografado);
        return Ok(resultado);
    }
}

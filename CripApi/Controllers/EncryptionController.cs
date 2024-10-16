using CripApi.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CripApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EncryptionController(IEncryptionService service) : ControllerBase
{
    private readonly IEncryptionService _service = service;

    [HttpPost("criptografar")]
    public IActionResult Criptografar(string text)
    {
        var resultado = _service.EncryptText(text);
        return Ok(resultado);
    }

    [HttpPost("descriptografar")]
    public IActionResult Descriptografar(string encryptedText, int privateKey, int n)
    {
        var resultado = _service.DecryptText(encryptedText, privateKey, n);
        return Ok(resultado);
    }
}

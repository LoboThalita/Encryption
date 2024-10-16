using CripApi.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CripApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EncryptionController(IEncryptionService encryptionService, IDecryptionService decryptionService) : ControllerBase
{
    private readonly IEncryptionService _encryptionService = encryptionService;
    private readonly IDecryptionService _decryptionService = decryptionService;

    [HttpPost("criptografar")]
    public IActionResult Criptografar(string text)
    {
        var resultado = _encryptionService.EncryptText(text);
        return Ok(resultado);
    }

    [HttpPost("descriptografar")]
    public IActionResult Descriptografar(string encryptedText, int privateKey, int n)
    {
        var resultado = _decryptionService.DecryptText(encryptedText, privateKey, n);
        return Ok(resultado);
    }
}

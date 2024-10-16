using CripApi.Models.Entities.Requests;
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
    public IActionResult Criptografar([FromBody] EncryptRequest encryptRequest)
    {
        var resultado = _encryptionService.EncryptText(encryptRequest.Text);
        return Ok(resultado);
    }

    [HttpPost("descriptografar")]
    public IActionResult Descriptografar(DecryptRequest decryptRequest)
    {
        var resultado = _decryptionService.DecryptText(decryptRequest.EncryptedText, decryptRequest.PrivateKey, decryptRequest.N);
        return Ok(resultado);
    }
}

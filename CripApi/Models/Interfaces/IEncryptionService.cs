using CripApi.Models.Entities;

namespace CripApi.Models.Interfaces;

public interface IEncryptionService
{
    EncryptedText EncryptText(string text);
}

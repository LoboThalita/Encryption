namespace CripApi.Models.Interfaces;

public interface IEncryptionService
{
    string EncryptText(string text);
    string DecryptText(string encryptedtext);
}

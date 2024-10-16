namespace CripApi.Models.Interfaces;

public interface IDecryptionService
{
    string DecryptText(string encryptedText, int privateKey, int n);
}

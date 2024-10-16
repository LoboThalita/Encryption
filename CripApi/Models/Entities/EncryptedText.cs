namespace CripApi.Models.Entities;

public class EncryptedText(string originalText, string encrypted, int publicKey, int privateKey, int n)
{
    public string OriginalText { get; set; } = originalText;
    public string Encrypted { get; set; } = encrypted;
    public int PublicKey { get; set; } = publicKey;
    public int PrivateKey { get; set; } = privateKey;
    public int N { get; set; } = n;
}
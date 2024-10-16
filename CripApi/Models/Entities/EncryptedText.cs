namespace CripApi.Models.Entities;

public class EncryptedText(string encryptedText, (int e, int n) publicKey, (int d, int n) privateKey, string originalText)
{
    public string OriginalText { get; set; } = originalText;
    public string Encrypted { get; set; } = encryptedText;
    public (int e, int n) PublicKey { get; set; } = publicKey;
    public (int d, int n) PrivateKey { get; set; } = privateKey;

    public override string ToString()
    {
        return $"Texto original: {OriginalText}\n" +
               $"Texto criptografado: {Encrypted}\n" +
               $"Chave pública (e, n): ({PublicKey.e}, {PublicKey.n})\n" +
               $"Chave privada (d, n): ({PrivateKey.d}, {PrivateKey.n})";
    }
}

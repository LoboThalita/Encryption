namespace CripApi.Models.Entities.Requests;

public class DecryptRequest
{
    public string EncryptedText { get; set; }
    public int PrivateKey { get; set; }
    public int N { get; set; }
}

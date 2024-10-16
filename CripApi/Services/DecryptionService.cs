using CripApi.Models.Interfaces;
using System.Text;

namespace CripApi.Services;

public class DecryptionService : IDecryptionService
{
    public string DecryptText(string encryptedText, int privateKey, int n)
    {
        StringBuilder decryptedText = new();

        string[] parts = encryptedText.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string part in parts)
        {
            if (int.TryParse(part, out int c))
            {
                int m = ModPow(c, privateKey, n);
                decryptedText.Append((char)m);
            }
        }
        return "Texto descriptografado: " + decryptedText.ToString();
    }

    private static int ModPow(int x, int y, int m)
    {
        if (y == 0)
            return 1;

        long p = ModPow(x, y / 2, m) % m;

        p = (p * p) % m;

        if (y % 2 == 0)
            return (int)p;
        else
            return (int)((x * p) % m);
    }
}

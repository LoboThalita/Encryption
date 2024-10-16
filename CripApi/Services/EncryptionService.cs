using CripApi.Models.Entities;
using CripApi.Models.Interfaces;
using System.Text;

namespace CripApi.Services;

public class EncryptionService : IEncryptionService
{
    public EncryptedText EncryptText(string text)
    {
        GenerateKeys(out int n, out int e, out int d);

        StringBuilder encryptedtext = new();
        foreach (char c in text)
        {
            int m = (int)c; // Convertendo diretamente o caractere para seu valor Unicode

            int crypted = ModPow(m, e, n);

            encryptedtext.Append(crypted.ToString() + " ");
        }

        return new EncryptedText(text, encryptedtext.ToString(), e, d, n);
    }
    private static void GenerateKeys(out int n, out int e, out int d)
    {
        Random random = new();

        int p = GenerateRandomPrimeNumber(random);
        int q = GenerateRandomPrimeNumber(random);

        n = p * q;
        int z = (p - 1) * (q - 1);

        e = GenerateRandomPublicKey(z, random);
        do
        {
            d = ModInverse(e, z);
        } while (d <= 1);
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

    private static int ModInverse(int a, int m)
    {
        for (int x = 1; x < m; x++)
        {
            if (a * x % m == 1)
                return x;
        }

        return 1;
    }

    private static int GenerateRandomPublicKey(int z, Random random)
    {
        int e = random.Next(2, z);

        while (Mdc(e, z) != 1)
        {
            e = random.Next(2, z);
        }

        return e;
    }

    private static int Mdc(int a, int b)
    {
        while (b != 0)
        {
            int aux = b;
            b = a % b;
            a = aux;
        }
        return a;
    }

    private static int GenerateRandomPrimeNumber(Random random)
    {
        int number = random.Next(10, 100);

        while (!ItsPrimeNumber(number))
        {
            number = random.Next(10, 100);
        }
        return number;
    }

    private static bool ItsPrimeNumber(int number)
    {
        if (number <= 1)
            return false;

        if (number <= 3)
            return true;

        if (number % 2 == 0 || number % 3 == 0)
            return false;

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
                return false;
        }

        return true;
    }
}

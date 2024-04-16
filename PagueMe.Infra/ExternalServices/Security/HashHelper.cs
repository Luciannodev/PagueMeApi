using System.Security.Cryptography;
using System.Text;

namespace PagueMe.Infra.ExternalServices.Security;

public class HashHelper
{
    private static HashAlgorithm _algoritmo = SHA256.Create();

    public static string EncryptPassword(string password)
    {
        ASCIIEncoding encoding = ConfigureHMAC();

        byte[] messageBytes = encoding.GetBytes(password);
        byte[] hashmessage = _algoritmo.ComputeHash(messageBytes);

        StringBuilder HashPassword = PasswordToHash(hashmessage);

        return HashPassword.ToString();
    }

    public static bool CheckPassword(string senhaDigitada, string senhaCadastrada)
    {
        ConfigureHMAC();
        if (string.IsNullOrEmpty(senhaCadastrada))
            throw new NullReferenceException("Cadastre uma senha.");

        var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));

        StringBuilder HashPassword = PasswordToHash(encryptedPassword);

        return HashPassword.ToString() == senhaCadastrada;
    }

    private static StringBuilder PasswordToHash(byte[] encryptedPassword)
    {
        var sb = new StringBuilder();
        foreach (var caractere in encryptedPassword)
        {
            sb.Append(caractere.ToString("X2"));
        }

        return sb;
    }

    private static ASCIIEncoding ConfigureHMAC()
    {
        var key = Environment.GetEnvironmentVariable("SECRET_KEY");
        if (string.IsNullOrEmpty(key))
        {
            throw new Exception("A chave secreta não está definida na variável de ambiente.");
        }

        var encoding = new ASCIIEncoding();
        byte[] keyByte = encoding.GetBytes(key);
        HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
        _algoritmo = hmacsha256;
        return encoding;
    }
}



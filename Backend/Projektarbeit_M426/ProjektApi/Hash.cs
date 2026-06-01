using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AutoProjektApi;

public class Hash
{
  public static string CreateSHA256(string input)
  {
    // erstellt ein zufälligen 16-Byte Salt
    var saltBytes = RandomNumberGenerator.GetBytes(16);

    // input: Passwort
    // saltBytes: zufälliger Salt
    // HMACSHA256: Algorithmus
    // 10000: Anzahl Iterationen
    // 32: länge in Bytes
    var hashedBytes = KeyDerivation.Pbkdf2
      (input, saltBytes, KeyDerivationPrf.HMACSHA256, 10000, 32);

    //Der Hash und der Salt werden Base64-kodiert, damit sie als Text speicherbar sind
    var hash = Convert.ToBase64String(hashedBytes);
    var salt = Convert.ToBase64String(saltBytes);

    //in hash kann kein punkt drinnen sein deswegen kombiniert man hash und salt mit punkt
    return $"{hash}.{salt}";
  }

  // erzeugt den Hash erneut und vergleicht ihn mit dem gespeicherten
  public static bool ValidateSHA256(string input, string hash)
  {
    //gespeicherter hash wird in hash und salt getrennt
    var hashsplited = hash.Split(".");

    var salt = hashsplited[1];
    var saltBytes = Convert.FromBase64String(salt);
    var passwordHash = hashsplited[0];

    // Passwort erneut mit dem gleichen Salt hashen
    var hashedBytes = KeyDerivation.Pbkdf2
      (input, saltBytes, KeyDerivationPrf.HMACSHA256, 10000, 32);

    var calculatedHash = Convert.ToBase64String(hashedBytes);

    //wenn neuer hash gleich ist wie gespeicherter dan ist passwort korrekt
    return calculatedHash == passwordHash;
  }
}

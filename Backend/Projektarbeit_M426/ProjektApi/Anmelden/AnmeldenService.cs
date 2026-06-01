using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using AutoProjektBusiness.Anmelden.Domain;
using Microsoft.IdentityModel.Tokens;

namespace AutoProjektApi.Anmelden;

public class AnmeldenService : IAnmeldenService
{
  private readonly IAnmeldenDomain _domain;

  public AnmeldenService(IAnmeldenDomain domain)
  {
    _domain = domain;
  }

  public async Task Anmelden(HttpContext context)
  {
    //streamReader objekt erstellen um body von frontend zulesen
    var reader = new StreamReader(context.Request.Body);
    //alles lesen
    var json = await reader.ReadToEndAsync();
    //zu JsonDocument Parsen
    var doc = JsonDocument.Parse(json);
    //mit RootElement "username" rauslesen
    var benutzername = doc.RootElement.GetProperty("username").ToString();
    var password = doc.RootElement.GetProperty("password").ToString();

    //nur mit dem benutzernamen den gesamten User mit passwordhash aus db laden
    var storeUser = await _domain.GetUserAsync(benutzername);

    //fals es überhaupt keinen user mit diesem Benutzernamen gibt ist das login sowieso falsch
    if (storeUser == null)
    {
      await context.Response.WriteAsJsonAsync(new { success = false });
      return;
    }

    //passwordhash in variable speichern
    var storedHash = storeUser.PasswordHash;
    //id in variable speichern
    var storedId = storeUser.Id;

    //password normal nicht hash aus frontend und gehashtes password aus db als parameter mit geben
    var isValid = Hash.ValidateSHA256(password, storedHash);

    //wen isValid = true das heisst password ist richtig und wir könne token erstellen
    if (isValid)
    {
      //claims sind die informationen welche im token gespeichert werden damit ich im frontend weiss wer eingeloggt ist
      var claims = new[]
      {
        new Claim(ClaimTypes.Name, benutzername),
        new Claim("id", storedId.ToString())
      };
      //erstellung des JWT-Tokens
      //issuer: Wer hat den Token erstellt
      //claims daten welche im token stehen
      //expires wie lange ist der token gültig hier 30 tage
      //signingCredentials token wird digital signiert damit ihn niemand fälschen kann mit secret was bei mir im Backend hardcoded ist damit niemand es im frontend sehen kann

      var token = new JwtSecurityToken(issuer: TokenInfos.Issuer, claims: claims, expires: DateTime.Now.AddDays(30),
        signingCredentials: new SigningCredentials(
          new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(TokenInfos.Secret)),
          SecurityAlgorithms.HmacSha256));

      //token objekt in string wandeln
      var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

      //im respons success true und den token string mit schicken
      await context.Response.WriteAsJsonAsync(new { success = true, token = tokenString });

      return;
    }

    await context.Response.WriteAsJsonAsync(new { success = false });


  }
}

using System.Text.Json;
using AutoProjektBusiness.Registrieren.Domain;
using AutoProjektBusiness.Shared;

namespace AutoProjektApi.Registrieren;

public class RegistrierenService : IRegistrierenService
{
  private readonly IRegistrierenDomain _domain;

  public RegistrierenService(IRegistrierenDomain domain)
  {
    _domain = domain;
  }

  public async Task RegistrierungSpeichernAsync(HttpContext context)
  {
    //wie bei Anmelden
    var reader = new StreamReader(context.Request.Body);
    var json = await reader.ReadToEndAsync();
    var doc = JsonDocument.Parse(json);
    var benutzername = doc.RootElement.GetProperty("username").ToString();
    var password = doc.RootElement.GetProperty("password").ToString();
    var hash = Hash.CreateSHA256(password);
    var email = doc.RootElement.GetProperty("email").ToString();

    var user = new User(email, hash, benutzername);

    var canRegistrieren = await _domain.RegistrierungSpeichernAsync(user);

    await context.Response.WriteAsJsonAsync(new
    {
      Success = canRegistrieren.Can,
      Message = canRegistrieren.Reason
    });

  }
}

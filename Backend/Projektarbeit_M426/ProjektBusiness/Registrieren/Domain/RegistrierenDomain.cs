using AutoProjektBusiness.Registrieren.Repository;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Registrieren.Domain;

public class RegistrierenDomain : IRegistrierenDomain
{

  private readonly IRegistrierenRepository _repository;

  public RegistrierenDomain(IRegistrierenRepository repository)
  {
    _repository = repository;
  }


  public async Task<CanResult> RegistrierungSpeichernAsync(User user)
  {
    //zuerst schauen ob man sich registrieren kann und dein benutzername oder email nicht bereits existieren
    var canRegistrierenAsync = await _repository.CanRegistrierenAsync(user);

    //Wen mann sich registrieren kann werden deien daten in der db gespeichert
    if (canRegistrierenAsync.Can)
    {
      await _repository.RegistrierungSpeichernAsync(user);
      return CanResult.Success();
    }

    //ansonsten fail und message
    return CanResult.Fail("Benutzername oder Email bereits vorhanden");
  }
}

using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Registrieren.Domain;

public interface IRegistrierenRepository
{
  Task RegistrierungSpeichernAsync(User user);

  Task<CanResult> CanRegistrierenAsync(User user);
}

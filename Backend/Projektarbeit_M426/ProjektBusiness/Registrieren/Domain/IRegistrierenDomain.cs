using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Registrieren.Domain;

public interface IRegistrierenDomain
{
  Task<CanResult> RegistrierungSpeichernAsync(User user);
}

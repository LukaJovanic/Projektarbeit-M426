using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Anmelden.Domain;

public interface IAnmeldenDomain
{
  Task<AnmeldenUser> GetUserAsync(string username);
}

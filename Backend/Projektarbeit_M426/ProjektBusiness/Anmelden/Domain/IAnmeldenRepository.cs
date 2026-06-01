using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Anmelden.Domain;

public interface IAnmeldenRepository
{
  Task<AnmeldenUser> GetHashAsync(string username);
}

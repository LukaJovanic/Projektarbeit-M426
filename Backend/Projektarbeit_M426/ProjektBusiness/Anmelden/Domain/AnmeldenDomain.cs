using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Anmelden.Domain;

public class AnmeldenDomain : IAnmeldenDomain
{
  private readonly IAnmeldenRepository _repository;

  public AnmeldenDomain(IAnmeldenRepository repository)
  {
    _repository = repository;
  }

  public async Task<AnmeldenUser> GetUserAsync(string username)
  {
    return await _repository.GetHashAsync(username);
  }
}

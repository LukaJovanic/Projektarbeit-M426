using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Create.Domain;

public class CreateDomain : ICreateDomain
{
  private readonly ICreateRepository _repository;

  public CreateDomain(ICreateRepository repository)
  {
    _repository = repository;
  }

  public async Task CreateCarAsync(Motorrad motorrad)
  {
    //repo aufrufen und car als parameter mitgeben
    await _repository.CreateCarAsync(motorrad);
  }
}

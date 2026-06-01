using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.GetMotorrad.Domain;

public class GetMotorradDomain : IGetMotorradDomain
{
  private readonly IGetMotorradRepository _repository;

  public GetMotorradDomain(IGetMotorradRepository repository)
  {
    _repository = repository;
  }

  public async Task<IList<Motorrad>> GetCarsAsync()
  {
    var cars = await _repository.GetCarsAsync();

    return cars;
  }
}

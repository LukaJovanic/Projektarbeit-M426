using AutoProjektBusiness.GetMotorrad.Domain;

namespace AutoProjektApi.GetMotorrad;

public class GetMotorradService : IGetMotorradService
{
  private readonly IGetMotorradDomain _domain;

  public GetMotorradService(IGetMotorradDomain domain)
  {
    _domain = domain;
  }

  public async Task GetCarsAsync(HttpContext context)
  {
     var cars = await _domain.GetCarsAsync();

     await context.Response.WriteAsJsonAsync(cars);
  }
}

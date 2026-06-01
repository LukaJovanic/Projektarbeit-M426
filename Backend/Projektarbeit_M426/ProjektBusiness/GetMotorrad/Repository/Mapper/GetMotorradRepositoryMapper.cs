using AutoProjektBusiness.Entities;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.GetMotorrad.Repository.Mapper;

public class GetMotorradRepositoryMapper : IGetMotorradRepositoryMapper
{
  public Motorrad MapToDomain(MotorradEntity entity)
  {
    var car = new Motorrad(entity.Title, entity.Description, entity.Price, entity.Brand, entity.Model
    ,entity.Kilometer, entity.Year, entity.ImageUrl);

    return car;
  }
}

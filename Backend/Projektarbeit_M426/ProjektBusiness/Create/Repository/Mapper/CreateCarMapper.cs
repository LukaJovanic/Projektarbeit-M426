using AutoProjektBusiness.Entities;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Create.Repository.Mapper;

public class CreateCarMapper : ICreateCarMapper
{
  //car zu entity mappen
  public MotorradEntity MapToEntity(Motorrad motorrad)
  {
    var entity = new MotorradEntity
    {
      Title = motorrad.Title,
      Description = motorrad.Description,
      Price = motorrad.Price,
      ImageUrl = motorrad.ImageUrl,
      Brand = motorrad.Brand,
      Kilometer = motorrad.Kilometer,
      Year = motorrad.Year,
      Model = motorrad.Model,

    };

    return entity;
  }
}

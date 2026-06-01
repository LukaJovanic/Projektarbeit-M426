using AutoProjektBusiness.Entities;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Create.Repository.Mapper;

public interface ICreateCarMapper
{
   MotorradEntity MapToEntity(Motorrad motorrad);
}

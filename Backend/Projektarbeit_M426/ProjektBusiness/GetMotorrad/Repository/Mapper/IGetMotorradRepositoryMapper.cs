using AutoProjektBusiness.Entities;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.GetMotorrad.Repository.Mapper;

public interface IGetMotorradRepositoryMapper
{
  Motorrad MapToDomain(MotorradEntity entity);
}

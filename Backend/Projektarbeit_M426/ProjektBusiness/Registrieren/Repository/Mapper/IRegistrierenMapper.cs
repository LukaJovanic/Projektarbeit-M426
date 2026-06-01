using AutoProjektBusiness.Entities;
using AutoProjektBusiness.Registrieren.Domain;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Registrieren.Repository.Mapper;

public interface IRegistrierenMapper
{
  UsersEntity MapToEntity(User user);
}

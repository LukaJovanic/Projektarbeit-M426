using AutoProjektBusiness.Entities;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Registrieren.Repository.Mapper;

public class RegistrierenMapper : IRegistrierenMapper
{

  //User zu UserEntity mappen
  public UsersEntity MapToEntity(User user)
  {
    return new UsersEntity
    {
      Email = user.Email,
      PasswordHash = user.PasswordHash,
      Benutzername = user.Benutzername
    };
  }
}

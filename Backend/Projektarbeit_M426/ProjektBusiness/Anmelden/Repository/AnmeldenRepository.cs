using AutoProjektBusiness.Anmelden.Domain;
using AutoProjektBusiness.NHibernateHelper;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Anmelden.Repository;

public class AnmeldenRepository : IAnmeldenRepository
{
  private readonly INHibernateConfig _hibernateConfig;

  public AnmeldenRepository(INHibernateConfig hibernateConfig)
  {
    _hibernateConfig = hibernateConfig;
  }



  public async Task<AnmeldenUser> GetHashAsync(string username)
  {
    //session öffnen
    var session = _hibernateConfig.OpenSession();
    //alle entities holen welche gleichen benutzernamen haben (kann nur eines sein)
    var query = session.QueryOver<Entities.UsersEntity>().Where(x => x.Benutzername == username);
    //aus liste einziges entity holen oder default(null)
    var result = await query.SingleOrDefaultAsync();
    //wen null also kein entity dan return null
    if (result == null)
    {
      return null;
    }
    //sonst neues AnmeldenUser objekt mit id, benutzername und passwordhash erstellen und unten returnen
    var anmeldeUser = new AnmeldenUser(result.Id, result.Benutzername, result.PasswordHash);

    return anmeldeUser;
  }
}

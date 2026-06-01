using AutoProjektBusiness.NHibernateHelper;
using AutoProjektBusiness.Registrieren.Domain;
using AutoProjektBusiness.Registrieren.Repository.Mapper;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Registrieren.Repository;

public class RegistrierenRepository : IRegistrierenRepository
{
  private readonly INHibernateConfig _hibernateConfig;
  private readonly IRegistrierenMapper _mapper;

  public RegistrierenRepository(INHibernateConfig hibernateConfig, IRegistrierenMapper mapper)
  {
    _hibernateConfig = hibernateConfig;
    _mapper = mapper;
  }

  //Registrierung speichern user als parameter
  public async Task RegistrierungSpeichernAsync(User user)
  {
    //session öffnen
    var session = _hibernateConfig.OpenSession();
    //transaction beginnen
    using var transaction = session.BeginTransaction();
    //user zu entity mappen
    var entity = _mapper.MapToEntity(user);
    //entity speichern
    await session.SaveAsync(entity);
    //commiten
    await transaction.CommitAsync();
  }

  //Prüfen ob man sich registrierne kann parameter user
  public async Task<CanResult> CanRegistrierenAsync(User user)
  {
    //session öffnen
    var session = _hibernateConfig.OpenSession();
    //benutzername aus user objekt holen
    var benutzername = user.Benutzername;
    //alle entities laden wo der benutername gleich ist wie oben
    var benutzernameQuery = session.QueryOver<Entities.UsersEntity>().Where(x => x.Benutzername == benutzername);
    //den einzigen benutzernamen aus der liste holen oder default(null)
    var benutzernameResult = await benutzernameQuery.SingleOrDefaultAsync();
    //wen enutezrname nicht null ist
    if (benutzernameResult != null)
    {
      //return fail und message
      return CanResult.Fail("Benutzername existiert bereits");
    }

    //genau gleich wie bei benutzername nur diesmal mit email
    var email = user.Email;
    var emailQuery = session.QueryOver<Entities.UsersEntity>().Where(x => x.Email == email);
    var emailResult = await emailQuery.SingleOrDefaultAsync();
    if (emailResult != null)
    {
      return CanResult.Fail("Email existiert bereits");
    }


    //wen beide listen emailQuery und benuternameQuery null sind einfacher gesagt wen es keinen benutezrname oder email gibt welche gleich sind wie deine ist es success
    return CanResult.Success();
  }
}

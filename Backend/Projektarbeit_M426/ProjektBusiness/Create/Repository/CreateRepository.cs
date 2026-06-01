using AutoProjektBusiness.Create.Domain;
using AutoProjektBusiness.Create.Repository.Mapper;
using AutoProjektBusiness.NHibernateHelper;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Create.Repository;

public class CreateRepository : ICreateRepository
{
  private readonly ICreateCarMapper _mapper;
  private readonly INHibernateConfig _hibernateConfig;

  public CreateRepository(ICreateCarMapper mapper, INHibernateConfig hibernateConfig)
  {
    _mapper = mapper;
    _hibernateConfig = hibernateConfig;
  }

  public async Task CreateCarAsync(Motorrad motorrad)
  {
    //session öffnen
    var session = _hibernateConfig.OpenSession();
    //transaction beginnen
    using var transaction = session.BeginTransaction();
    //car zu entity mappen
    var entity = _mapper.MapToEntity(motorrad);
    //entity speichern
    await session.SaveAsync(entity);
    //commiten
    await transaction.CommitAsync();
  }
}

using AutoProjektBusiness.Entities;
using AutoProjektBusiness.GetMotorrad.Domain;
using AutoProjektBusiness.GetMotorrad.Repository.Mapper;
using AutoProjektBusiness.NHibernateHelper;
using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.GetMotorrad.Repository;

public class GetMotorradRepository : IGetMotorradRepository
{
  private readonly INHibernateConfig _nHibernateConfig;
  private readonly IGetMotorradRepositoryMapper _mapper;

  public GetMotorradRepository(INHibernateConfig nHibernateConfig, IGetMotorradRepositoryMapper mapper)
  {
    _nHibernateConfig = nHibernateConfig;
    _mapper = mapper;
  }

  public async Task<IList<Motorrad>> GetCarsAsync()
  {
    var session = _nHibernateConfig.OpenSession();
    var transaction = session.BeginTransaction();
    var carsEntities = session.Query<MotorradEntity>().ToList();
    var cars = new List<Motorrad>();
    foreach (var carsEntity in carsEntities)
    {
      var car =  _mapper.MapToDomain(carsEntity);
      cars.Add(car);
    }

    return cars;
  }
}

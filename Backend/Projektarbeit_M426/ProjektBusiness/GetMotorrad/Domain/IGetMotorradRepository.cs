using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.GetMotorrad.Domain;

public interface IGetMotorradRepository
{
   Task<IList<Motorrad>> GetCarsAsync();
}

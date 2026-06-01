using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.GetMotorrad.Domain;

public interface IGetMotorradDomain
{
   Task<IList<Motorrad>> GetCarsAsync();
}

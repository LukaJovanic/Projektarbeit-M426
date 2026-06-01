using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Create.Domain;

public interface ICreateDomain
{
    Task CreateCarAsync(Motorrad motorrad);
}

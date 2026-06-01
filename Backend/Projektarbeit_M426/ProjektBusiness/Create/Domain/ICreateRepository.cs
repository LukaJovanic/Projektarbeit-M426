using AutoProjektBusiness.Shared;

namespace AutoProjektBusiness.Create.Domain;

public interface ICreateRepository
{
    Task CreateCarAsync(Motorrad motorrad);
}

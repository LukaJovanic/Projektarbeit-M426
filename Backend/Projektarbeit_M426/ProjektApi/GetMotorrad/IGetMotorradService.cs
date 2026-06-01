namespace AutoProjektApi.GetMotorrad;

public interface IGetMotorradService
{
    Task GetCarsAsync(HttpContext context);
}

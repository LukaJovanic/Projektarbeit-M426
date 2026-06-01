namespace AutoProjektApi.Registrieren;

public interface IRegistrierenService
{
  Task RegistrierungSpeichernAsync(HttpContext context);
}

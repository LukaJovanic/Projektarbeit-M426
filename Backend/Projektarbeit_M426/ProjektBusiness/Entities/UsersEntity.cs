namespace AutoProjektBusiness.Entities;

public class UsersEntity
{
  public virtual int Id { get; set; }
  public virtual string Email { get; set; } = null!;
  public virtual string PasswordHash { get; set; } = null!;

  public virtual string Benutzername { get; set; } = null!;

}

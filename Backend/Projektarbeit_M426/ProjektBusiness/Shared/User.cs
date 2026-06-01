namespace AutoProjektBusiness.Shared;

public class User
{

  public string Email { get; set; } = null!;

  public string PasswordHash { get; set; } = null!;

  public string Benutzername { get; set; } = null!;


  public User(string email, string passwordHash, string benutzername)
  {
    Email = email;
    PasswordHash = passwordHash;
    Benutzername = benutzername;
  }
}

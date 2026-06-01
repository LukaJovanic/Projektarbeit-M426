namespace AutoProjektBusiness.Shared;

public class AnmeldenUser
{

  public int Id { get; set; }

  public string Username { get; set; }

  public string PasswordHash { get; set; }

  public AnmeldenUser(int id, string username, string passwordHash)
  {
    Id = id;
    Username = username;
    PasswordHash = passwordHash;
  }
}

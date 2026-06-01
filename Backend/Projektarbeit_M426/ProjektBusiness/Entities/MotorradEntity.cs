namespace AutoProjektBusiness.Entities;

public class MotorradEntity
{
  public virtual int Id { get; set; }

  public virtual string Title { get; set; } = null!;
  public virtual string? Description { get; set; }
  public virtual decimal Price { get; set; }
  public virtual string? ImageUrl { get; set; }
  public virtual string? Brand { get; set; }
  public virtual string? Model { get; set; }
  public virtual int? Kilometer { get; set; }
  public virtual int? Year { get; set; }
}

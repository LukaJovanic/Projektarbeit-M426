namespace AutoProjektBusiness.Shared;

public class Motorrad
{

    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int? Kilometer { get; set; }
    public int? Year { get; set; }
    public string ImageUrl { get; set; }

    public Motorrad(string title, string description, decimal price, string brand, string model, int? kilometer, int? year, string imageUrl)
    {
      Title = title;
      Description = description;
      Price = price;
      Brand = brand;
      Model = model;
      Kilometer = kilometer;
      Year = year;
      ImageUrl = imageUrl;
    }
}

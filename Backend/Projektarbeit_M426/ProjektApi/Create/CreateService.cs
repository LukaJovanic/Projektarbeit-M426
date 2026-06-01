using System.Text.Json;
using AutoProjektBusiness.Create.Domain;
using AutoProjektBusiness.Shared;

namespace AutoProjektApi.Create;

public class CreateService : ICreateService
{
    private readonly IWebHostEnvironment _env;
    private readonly ICreateDomain _domain;

    public CreateService(IWebHostEnvironment env, ICreateDomain domain)
    {
        _env = env;
        _domain = domain;
    }

    public async Task CreateAsync(HttpContext context)
    {
        var form = await context.Request.ReadFormAsync();

        var title       = form["title"].ToString();
        var description = form["description"].ToString();
        var price       = decimal.Parse(form["price"].ToString());
        var brand       = form["brand"].ToString();
        var model       = form["model"].ToString();
        var kilometer   = int.Parse(form["kilometer"].ToString());
        int? year       = null;
        if (int.TryParse(form["year"].ToString(), out var yearValue))
        {
            year = yearValue;
        }


        string? imageUrl = null;

        //Angular sendet Bild als Formdata Feld mit dem Namen image
        var file = form.Files["image"];

        if (file != null && file.Length > 0)
        {
          // _env.WebRootPath zeigt auf wwwroot
          var webRoot = _env.WebRootPath;
          if (string.IsNullOrEmpty(webRoot))
          {
            //falls wwwroot noch nicht existiert
            //wird es im aktuellen Projektverzeichnis erstellt
            webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
          }

          //Unterordner: wwwroot/images/cars
          //hier kommen alle Autobilder rein
          var uploadsFolder = Path.Combine(webRoot, "images", "cars");
          //falls Ordner nicht existiert erstellen
          Directory.CreateDirectory(uploadsFolder);

          //Dateiname als guid + endung(z.B jpg)
          var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
          var filePath = Path.Combine(uploadsFolder, fileName);

          // Datei speichern
          using (var stream = new FileStream(filePath, FileMode.Create))
          {
            await file.CopyToAsync(stream);
          }

          // relativer Pfad (für DB)
          imageUrl = $"/images/cars/{fileName}";
        }

        var car = new Motorrad(title, description, price, brand, model, kilometer, year, imageUrl);

        await _domain.CreateCarAsync(car);

        await context.Response.WriteAsJsonAsync(new { success = true });

    }
}

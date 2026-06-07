using AutoProjektApi.Anmelden;
using AutoProjektApi.Create;
using AutoProjektApi.GetMotorrad;
using AutoProjektBusiness.NHibernateHelper;
using AutoProjektBusiness.Registrieren.Domain;
using AutoProjektBusiness.Registrieren.Repository;
using AutoProjektBusiness.Registrieren.Repository.Mapper;
using AutoProjektApi.Registrieren;
using AutoProjektBusiness.Anmelden.Domain;
using AutoProjektBusiness.Anmelden.Repository;
using AutoProjektBusiness.Create.Domain;
using AutoProjektBusiness.Create.Repository;
using AutoProjektBusiness.Create.Repository.Mapper;
using AutoProjektBusiness.GetMotorrad.Domain;
using AutoProjektBusiness.GetMotorrad.Repository;
using AutoProjektBusiness.GetMotorrad.Repository.Mapper;

var builder = WebApplication.CreateBuilder(args);


// API läuft unter http://localhost:5000
builder.WebHost.UseUrls("http://localhost:5000");


builder.Services.AddControllers();

// NhibernateConfig wird als Singleton registriert,
// weil die SessionFactory nur einmal erstellt werden soll
builder.Services.AddSingleton<INHibernateConfig, NHibernateConfig>();


//Registrieren
builder.Services.AddScoped<IRegistrierenMapper, RegistrierenMapper>();
builder.Services.AddScoped<IRegistrierenDomain, RegistrierenDomain>();
builder.Services.AddScoped<IRegistrierenRepository, RegistrierenRepository>();


//Anmelden
builder.Services.AddScoped<IRegistrierenService, RegistrierenService>();
builder.Services.AddScoped<IAnmeldenDomain, AnmeldenDomain>();
builder.Services.AddScoped<IAnmeldenRepository, AnmeldenRepository>();
builder.Services.AddScoped<IAnmeldenService, AnmeldenService>();

//Create
builder.Services.AddScoped<ICreateDomain, CreateDomain>();
builder.Services.AddScoped<ICreateRepository, CreateRepository>();
builder.Services.AddScoped<ICreateCarMapper, CreateCarMapper>();
builder.Services.AddScoped<ICreateService, CreateService>();

//GetCars
builder.Services.AddScoped<IGetMotorradDomain, GetMotorradDomain>();
builder.Services.AddScoped<IGetMotorradRepository, GetMotorradRepository>();
builder.Services.AddScoped<IGetMotorradRepositoryMapper, GetMotorradRepositoryMapper>();
builder.Services.AddScoped<IGetMotorradService, GetMotorradService>();


// Erlaubt Anfragen vom Angular-Frontend (egal von wo)
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll", policy =>
    policy.AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod());
});


builder.Services.AddAuthorization();

var app = builder.Build();
app.UseStaticFiles();
// cors aktivieren
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

// POST /registrieren ruft RegistrierenService auf
app.MapPost("/registrieren", async (HttpContext context, IRegistrierenService registrierenService) =>
{
  await registrierenService.RegistrierungSpeichernAsync(context);
});

app.MapPost("/anmelden", async (HttpContext HttpContext, IAnmeldenService anmeldenService) =>
{
  await anmeldenService.Anmelden(HttpContext);
});


app.MapPost("/create", async (HttpContext context, ICreateService createService) =>
{
  await createService.CreateAsync(context);
});


app.MapGet("/getmotorrad", async (HttpContext context, IGetMotorradService getMotorradService) =>
{
  await getMotorradService.GetCarsAsync(context);
});



app.Run();

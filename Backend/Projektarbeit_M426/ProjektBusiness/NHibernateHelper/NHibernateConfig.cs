using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace AutoProjektBusiness.NHibernateHelper;



public class NHibernateConfig : INHibernateConfig
{
  private ISessionFactory _sessionFactory; //wird einmal erstellt und dann wiederverwendet


  //erstellt eine SessionFactory
  private ISessionFactory CreateSessionFactory()
  {
    //MySQL connection string wird in einem Objekt erstellt
    var builder = new MySqlConnectionStringBuilder
    {
      Server = "localhost",
      Port = 3306,
      Database = "carapp_db",
      UserID = "root",
      Password = "admin123"
    };

    //Nhibernate konfigurationsobjekt
    var cfg = new Configuration();

    //einstellungen für kommunikation zwischen db und Nhibernate
    cfg.DataBaseIntegration(db =>
    {
      db.ConnectionString = builder.ToString(); //Verbindung zur db
      db.Driver<NHibernate.Driver.MySqlDataDriver>();
      db.Dialect<NHibernate.Dialect.MySQLDialect>(); //SQL dialekt für MySQL
      db.LogSqlInConsole = true; //SQL in der Konsole anzeigen
      db.LogFormattedSql = true;
    });

    // Der ModelMapper lädt alle Mapping Klassen aus diesem Assembly
    var mapper = new ModelMapper();
    mapper.AddMappings(GetType().Assembly.ExportedTypes);

    // Mapping wird NHibernateConfig hinzugefügt
    cfg.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

    // Am ende wird die SessionFactory gebaut passiert nur 1 mal
    return cfg.BuildSessionFactory();
  }


  //Diese Methode ruft man jedes mal auf wen man mit der db arbeitet
  public NHibernate.ISession OpenSession()
  {
    //Falls noch keine SessionFactory existiert, erstellt man sie mit der obigen methode einmal
    if (_sessionFactory == null)
    {
      _sessionFactory = CreateSessionFactory();
    }

    //Neue Session aus der SessionFactory öffnen (jedes mal bis aufs erste mal)
    return _sessionFactory.OpenSession();
  }
}

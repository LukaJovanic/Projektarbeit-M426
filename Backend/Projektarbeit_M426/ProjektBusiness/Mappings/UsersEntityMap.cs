using AutoProjektBusiness.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace AutoProjektBusiness.Mappings;

public class UsersEntityMap : ClassMapping<UsersEntity>
{
  public UsersEntityMap()
  {
    Table("users");
    SelectBeforeUpdate(true);

    Id(x => x.Id, m => m.Column("id"));

    Property(x => x.Email, Email);
    Property(x => x.PasswordHash, PasswordHash);
    Property(x => x.Benutzername, Benutzername);
  }

  private void Email(IPropertyMapper m)
  {
    m.Column("email");
    m.Type(NHibernateUtil.String);
    m.Length(255);
    m.NotNullable(true);
  }

  private void PasswordHash(IPropertyMapper m)
  {
    m.Column("password_hash");
    m.Type(NHibernateUtil.String);
    m.Length(255);
    m.NotNullable(true);
  }

  private void Benutzername(IPropertyMapper m)
  {
    m.Column("benutzername");
    m.Type(NHibernateUtil.String);
    m.Length(255);
    m.NotNullable(true);
  }


}

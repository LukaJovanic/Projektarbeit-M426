using AutoProjektBusiness.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace AutoProjektBusiness.Mappings;

public class MotorradEntityMap : ClassMapping<MotorradEntity>
{
    public MotorradEntityMap()
    {
        Table("cars");
        SelectBeforeUpdate(true);

        Id(x => x.Id, m => m.Column("id"));
        Property(x => x.Title, Title);
        Property(x => x.Description, Description);
        Property(x => x.Price, Price);
        Property(x => x.ImageUrl, ImageUrl);
        Property(x => x.Brand, Brand);
        Property(x => x.Model, Model);
        Property(x => x.Kilometer, Kilometer);
        Property(x => x.Year, Year);
    }



    private void Title(IPropertyMapper m)
    {
        m.Column("title");
        m.Type(NHibernateUtil.String);
        m.Length(255);
        m.NotNullable(true);
    }

    private void Description(IPropertyMapper m)
    {
        m.Column("description");
        m.Type(NHibernateUtil.StringClob);
        m.NotNullable(true);
    }

    private void Price(IPropertyMapper m)
    {
        m.Column("price");
        m.Type(NHibernateUtil.Decimal);
        m.NotNullable(true);
    }

    private void ImageUrl(IPropertyMapper m)
    {
        m.Column("image_url");
        m.Type(NHibernateUtil.String);
        m.Length(500);
        m.NotNullable(true);
    }

    private void Brand(IPropertyMapper m)
    {
        m.Column("brand");
        m.Type(NHibernateUtil.String);
        m.Length(100);
        m.NotNullable(true);
    }

    private void Model(IPropertyMapper m)
    {
        m.Column("model");
        m.Type(NHibernateUtil.String);
        m.Length(100);
        m.NotNullable(true);
    }

    private void Kilometer(IPropertyMapper m)
    {
        m.Column("kilometer");
        m.Type(NHibernateUtil.Int32);
        m.NotNullable(true);
    }

    private void Year(IPropertyMapper m)
    {
        m.Column("year");
        m.Type(NHibernateUtil.Int32);
        m.NotNullable(true);
    }

}

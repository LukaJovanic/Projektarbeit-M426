namespace AutoProjektBusiness.NHibernateHelper;

public interface INHibernateConfig
{
    public NHibernate.ISession OpenSession();
}

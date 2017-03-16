using NHibernate;

namespace Infrastructure.DataBase.NHibernateSession
{
    public static class NHibernateSessionManager
    {
        private const string NHIbernateSession = "NHIbernateSession";

        public static ISessionFactory SessionFactory { get; set; }

        public static ISession GetSession()
        {
            var session = System.Web.HttpContext.Current.Session;

            var nhSession = session[NHIbernateSession] as ISession;

            if (nhSession == null)
            {
                nhSession = SessionFactory.OpenSession();
                session[NHIbernateSession] = nhSession;
            }
            return nhSession;
        }
    }
}

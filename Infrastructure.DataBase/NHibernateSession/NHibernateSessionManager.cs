using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase.NHibernateSession
{
    public static class NHibernateSessionManager
    {
        private const string NhSession = "NhSession";

        public static ISessionFactory SessionFactory { get; set; }

        public static ISession GetSession()
        {
            var session = System.Web.HttpContext.Current.Session;

            var nhSession = session[NhSession] as ISession;

            if (nhSession == null)
            {
                nhSession = SessionFactory.OpenSession();
                session[NhSession] = nhSession;
            }
            return nhSession;
        }
    }
}

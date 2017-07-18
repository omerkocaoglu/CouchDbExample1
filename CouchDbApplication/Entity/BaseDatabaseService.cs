using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveSeat;
using System.Configuration;

namespace CouchDbApplication.Entity
{
    public class BaseDatabaseService
    {
        private CouchClient couchDbClient;
        public BaseDatabaseService()
        {
            if (couchDbClient == null)
            {
                couchDbClient = new CouchClient(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            }
        }
        public CouchClient CouchDbClinet
        {
            get
            {
                return couchDbClient;
            }
        }

        public CouchDatabase Db
        {
            get
            {
                CouchDbClinet.CreateDatabase(ConfigurationManager.AppSettings["databaseName"]);
                return couchDbClient.GetDatabase(ConfigurationManager.AppSettings["databaseName"]);
            }
        }
    }
}

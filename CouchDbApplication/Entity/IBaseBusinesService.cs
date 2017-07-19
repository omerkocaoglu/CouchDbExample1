using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchDbApplication.Entity
{
    public interface IBaseBusinesService
    {
        void InsertBusinessman(Business insertedEntity);
        void UpdateBusinessman(string businessId, byte[] array);
        Business DeleteBusinessman(string businessId);
        Business GetById(string Id);
        List<Business> GetAll();
        void DeleteDatabase();
    }
}

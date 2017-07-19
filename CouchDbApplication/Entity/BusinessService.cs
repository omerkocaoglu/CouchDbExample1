using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveSeat;
using Newtonsoft.Json;
using System.Net;

namespace CouchDbApplication.Entity
{
    public class BusinessService : BaseDatabaseService, IBaseBusinesService
    {
        public Business DeleteBusinessman(string businessId)
        {
            try
            {
                Business deletedBusiness = GetById(businessId);
                if (deletedBusiness == null)
                {
                    return null;
                }
                else
                {
                    Db.DeleteDocument(businessId, deletedBusiness.Rev);
                    return deletedBusiness;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void DeleteDatabase()
        {
            CouchDbClinet.DeleteDatabase("businessdb");
        }

        public void InsertBusinessman(Business insertedEntity)
        {
            Db.CreateDocument(insertedEntity);
        }

        public void UpdateBusinessman(string businessId, byte[] array)
        {
            Document updatingBusiness = Db.GetDocument(businessId);
            string value = ASCIIEncoding.Default.GetString(array,1,array.Length-1);
            switch (ASCIIEncoding.Default.GetString(array,0,1))
            {
                case "1":
                    updatingBusiness["name"] = value;
                    Db.SaveDocument(updatingBusiness);
                    break;
                case "2":
                    updatingBusiness["surname"] = value;
                    Db.SaveDocument(updatingBusiness);
                    break;
                case "3":
                    updatingBusiness["department"] = value;
                    Db.SaveDocument(updatingBusiness);
                    break;
                case "4":
                    updatingBusiness["birthdate"] = value;
                    Db.SaveDocument(updatingBusiness);
                    break;
                case "5":
                    updatingBusiness["phone"] = value;
                    Db.SaveDocument(updatingBusiness);
                    break;
                case "6":
                    updatingBusiness["city"] = value;
                    Db.SaveDocument(updatingBusiness);
                    break;
                case "7":
                    updatingBusiness["country"] = value;
                    Db.SaveDocument(updatingBusiness);
                    break;
            }
        }

        public Business GetById(string Id)
        {
            try
            {
               return JsonConvert.DeserializeObject<Business>(Db.GetDocument(Id).ToString());
            }
            catch
            {
                return null;
            }
        }

        public List<Business> GetAll()
        {
            List<Business> businessList = new List<Business>();
            ViewResult asd = Db.GetAllDocuments();
            foreach (var item in asd.Rows)
            {
               Business busines = JsonConvert.DeserializeObject<Business>((Db.GetDocument(item["id"].ToString())).ToString());
                businessList.Add(busines);
            }
            return businessList;
        }
    }
}

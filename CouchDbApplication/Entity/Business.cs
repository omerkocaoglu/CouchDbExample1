using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveSeat.Interfaces;
using System.ComponentModel;

namespace CouchDbApplication.Entity
{
    public class Business : IBaseObject
    {        
        [EntityAttributes]
        [DisplayName("Id")]
        public string Id { get; set; }
        public string Rev { get; set; }
        public string Type
        {
            get
            {
                return typeof(Business).Name;
            }
        }
        [EntityAttributes]
        [DisplayName("Ad")]
        public string Name { get; set; }
        [EntityAttributes]
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [EntityAttributes]
        [DisplayName("Bölüm Adı")]
        public string Department { get; set; }
        [EntityAttributes]
        [DisplayName("Doğum Tarihi")]
        public string Birthdate { get; set; }
        [EntityAttributes]
        [DisplayName("Telefon No")]
        public string Phone { get; set; }
        [EntityAttributes]
        [DisplayName("Şehir")]
        public string City { get; set; }
        [EntityAttributes]
        [DisplayName("Ülke")]
        public string Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace Norbit.CRM.Tyganov.Practic13.WebApiVesrion2
{
    public class DataController : ApiController
    {
        // Создадим экземпляр класса провайдер, который будет обращаться к нашей базе данных.
        private static Provider _db = ProviderFactory.GetProvider();
        // GET api/Data
        public IEnumerable<string> Get()
        {
            var sellersList = _db.GetSellers();
            var resultList = new List<string>();

            foreach (var seller in sellersList)
            {
                resultList.Add(seller.ToString());
            }
            return resultList;
        }
        // GET api/Data/5
        public string Get(int id)
        {
            return _db.GetSeller(id);
        }
        // POST api/<controller>
        public void Post([FromBody] string value)
        {
            try
            {
                var sellerStrings = value.Split(',');
                var seller = new Sellers(int.Parse(sellerStrings[0]), sellerStrings[1],
                    int.Parse(sellerStrings[2]), int.Parse(sellerStrings[3]),
                    int.Parse(sellerStrings[4]));
                _db.PushSeller(seller);
            }
            catch
            {
                throw new ArgumentException(value + "Не удалось доабвить");
            }
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _db.DeleteSeller(id);
        }
    }
}
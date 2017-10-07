using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using retail_Shop.Models.Interface;
using retail_Shop.Models.Properties;
using System.Web.Script.Serialization;

namespace retail_Shop.Models
{
    public class RetailClass : IRetailCustomer
    {
        static JavaScriptSerializer js = new JavaScriptSerializer();
        public CustomerInfo GetCustomerData(string username)
        {

            string customers = DBAccess.readJson("retail_customer.json");
            List<CustomerInfo> lstcustomer = js.Deserialize<List<CustomerInfo>>(customers);

            
            var customer = lstcustomer.Where(x => x.User_name == username).FirstOrDefault();
            return customer;
        }
        public void SaveCustomerData(string username)
        {
            string customers = DBAccess.readJson("retail_customer.json");
            List<CustomerInfo> lstcustomer = js.Deserialize<List<CustomerInfo>>(customers);
            foreach (var customer in lstcustomer.Where(w => w.User_name == username))
            {
                customer.Disc_flag = "1";
            }
            DBAccess.Save(js.Serialize(lstcustomer), "retail_customer.json");
        }
        public List<ItemInfo> GetItemData()
        {

            string items = DBAccess.readJson("retailtems.json");
            List<ItemInfo> lstitem = js.Deserialize<List<ItemInfo>>(items);
            

            return lstitem;
        }
        public void SaveReceipt(ReceiptInfo rec)
        {
          // var recdata= js.Serialize(rec);
            DBAccess.appendReceiptInJson( "receipt.json",rec);
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using retail_Shop.Models.Properties;

namespace retail_Shop.Models.Interface
{
    interface IRetailCustomer
    {
        CustomerInfo GetCustomerData(string username);
        void SaveCustomerData(string username);
        List< ItemInfo> GetItemData();
        void SaveReceipt(ReceiptInfo rec);
    }
}

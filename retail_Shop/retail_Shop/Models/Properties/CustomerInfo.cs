using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace retail_Shop.Models.Properties
{
    public class CustomerInfo
    {
        private string id;
        private string customer_name;
        private string user_name;
        
        private string disc_flag;
        private string customer_entry_date;
        private CustTypeInfo cust_Type_Info;

        public string Id { get { return id; } set { id = value; } }
        public string Customer_name { get { return customer_name; } set { customer_name = value; } }
        public string User_name { get { return user_name; } set { user_name = value; } }
        
        public string Disc_flag { get { return disc_flag; } set { disc_flag = value; } }
        public string Customer_entry_date { get { return customer_entry_date; } set { customer_entry_date = value; } }
        public CustTypeInfo Cust_Type_Info { get { return cust_Type_Info; } set { cust_Type_Info = value; } }
    }
    public class ItemInfo
    {
        private string id;
        private string item_name;
        private double price;
        private string item_category;
        
        public string Id { get { return id; } set { id = value; } }
        public string Item_name { get { return item_name; } set { item_name = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string Item_category { get { return item_category; } set { item_category = value; } }
        
    }
    public class ReceiptInfo
    {
        private string id;
        private List<ItemInfo> item_detail;
        private double discount;
        private double totalprice;

        public string Id { get { return id; } set { id = value; } }
        public List<ItemInfo> Item_detail { get { return item_detail; } set { item_detail = value; } }
        public double Discount { get { return discount; } set { discount = value; } }
        public double Totalprice { get { return totalprice; } set { totalprice = value; } }

    }
    public class CustTypeInfo
    {
        private string id;
        private string customer_type;
        private double price_disc;
        

        public string Id { get { return id; } set { id = value; } }
        public string Customer_type { get { return customer_type; } set { customer_type = value; } }
        public double Price_disc { get { return price_disc; } set { price_disc = value; } }
        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using retail_Shop.Models.Interface;
using retail_Shop.Models;
using retail_Shop.Models.Properties;

namespace retail_Shop.Controllers
{
    public class RetailController : Controller
    {
        // GET: Retail
        public ActionResult customerlogin()
        {

            return View();
        }

        public ActionResult customerdetail()

        {
            IRetailCustomer cretail = new RetailClass();
            var user = Convert.ToString(RouteData.Values["user"]);
            var customer = cretail.GetCustomerData(user);
            var items = cretail.GetItemData();
            ViewBag.Customer = customer;
            ViewBag.Items = items;
            return View();
        }
        public ActionResult receiptdetail()
        {
            IRetailCustomer cretail = new RetailClass();
            var user = Convert.ToString(RouteData.Values["user"]);
            var customer = cretail.GetCustomerData(user);
            var itemSel = Request["id"].ToString();
            itemSel = itemSel.Remove(0, 1);
            var items = cretail.GetItemData();
            ViewBag.Customer = customer;
            var Items = items.Where(x => itemSel.IndexOf(x.Id) != -1).Select(v => v).ToList();
            double totalnongroceryprice = items.Where(x => itemSel.IndexOf(x.Id) != -1 && x.Item_category != "grocery").Select(v => v.Price).Sum();
            double totalprice = items.Where(x => itemSel.IndexOf(x.Id) != -1).Select(v => v.Price).Sum();

            double perc = customer.Cust_Type_Info.Price_disc;
            DateTime dt = DateTime.Now.AddYears(-2);

            double disc = (customer.Disc_flag != "1"  ) ? (totalnongroceryprice * perc / 100) : 0;

            double otherdiscount = Convert.ToDouble(Convert.ToInt32(((totalprice - disc) / 100)) * 5);
            totalprice = totalprice - (disc + otherdiscount);

            ReceiptInfo rec = new ReceiptInfo
            {
                Discount = disc + otherdiscount,
                Item_detail = Items,
                Totalprice = totalprice

            };
            cretail.SaveReceipt(rec);
            cretail.SaveCustomerData(user);
            ViewBag.Receipt = rec;
            ViewBag.disc = disc;
            ViewBag.otherdiscount = otherdiscount;
            return View();
        }

    }
}
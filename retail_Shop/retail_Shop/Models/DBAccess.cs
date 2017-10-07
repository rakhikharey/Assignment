using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using retail_Shop.Models.Properties;
using System.Web.Script.Serialization;

namespace retail_Shop.Models
{
    public static class DBAccess
    {
        static string jsonFilePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["path"]);
        public static string readJson(string jsonfilename)
        {
            string sContents = string.Empty;
            try
            {
                using (FileStream fs = new FileStream((jsonFilePath + jsonfilename), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        sContents = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                // commonMethods.LogError(ex);
            }
            return sContents;
        }

        public static string appendReceiptInJson(string jsonfilename, ReceiptInfo receiptInfo)
        {
            string sContents = string.Empty;
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<ReceiptInfo> recInfo = new List<ReceiptInfo>();
            try
            {
                using (FileStream fs = new FileStream((jsonFilePath + jsonfilename), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        sContents = sr.ReadToEnd();
                    }
                }
                if (sContents != "")
                    recInfo = js.Deserialize<List<ReceiptInfo>>(sContents);
                recInfo.Add(receiptInfo);
                sContents = js.Serialize(recInfo);
                File.WriteAllText(jsonFilePath + jsonfilename, sContents);
            }
            catch (Exception ex)
            {
                // commonMethods.LogError(ex);
            }
            return sContents;
        }
        public static void Save(string json, string jsonfilename)
        {
            //if (File.Exists(jsonFilePath + jsonfilename))
            //{
            //    File.Delete(jsonFilePath + jsonfilename);
            //    File.Create(jsonFilePath + jsonfilename);
            //}
            File.WriteAllText(jsonFilePath + jsonfilename, json);
        }
    }
}
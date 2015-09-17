using System;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using EduSoft.Utils;

namespace QLSV.Web.Common
{
    public class Util
    {
        private bool Validate(string user, string pass)
        {
            pass = HashIt("123456789a");
            var newpass = PasswordUtil.HashPassword(pass);
            var newpass1 = PasswordUtil.AQDecoding(pass);
            var newpass2 = PasswordUtil.AQEncoding(pass);

            const bool flag = false;
            return flag;
        }

        private string HashIt(string pass)
        {
            //Phan nay la thuat toan bam password
            return pass;
        }

        public bool Checkdangky()
        {
            var b = false;
            try
            {
                var xmlread = new XmlDocument();
                xmlread.Load(HttpContext.Current.Server.MapPath("~/App_Data/data.xml"));
                var xmlelement = xmlread.DocumentElement;
                if (xmlelement != null)
                {
                    {
                        //var star = xmlelement.SelectSingleNode("StarDate").InnerText;
                        var end = xmlelement.SelectSingleNode("EndDate").InnerText;
                        //var startDate = Convert.ToDateTime(star);
                        var endDate = Convert.ToDateTime(end);
                        if (endDate > DateTime.Now)
                        {
                            b = true;
                        }
                    }

                }
            }
            catch (Exception)
            {

            }
            return b;
        }

        public void SaveDateXml(DateTime start, DateTime end)
        {
            try
            {
                var xdoc = new XDocument(
                           new XDeclaration("1.0", "utf-8", "yes"),
                           new XElement("config",
                               new XElement("StarDate",start),
                               new XElement("EndDate", end)));
                xdoc.Save(HttpContext.Current.Server.MapPath("~/App_Data/data.xml"));
            }
            catch (Exception)
            {
            }
        }
    }
}
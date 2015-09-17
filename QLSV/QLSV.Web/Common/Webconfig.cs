using System.Configuration;

namespace QLSV.Web.Common
{
    public static class Webconfig
    {
        public static readonly string Dbeduweb = ConfigurationManager.AppSettings["dbeduweb"];
        
    }
}
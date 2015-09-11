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
    }
}
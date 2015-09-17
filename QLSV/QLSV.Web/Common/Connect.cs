using System.Data;
using System.Data.SqlClient;

namespace QLSV.Web.Common
{
    public static class Connect
    {
        public static DataTable sp_checkData(string masv, string matkhau)
        {

            var dt = new DataTable();
            try
            {
                var connect = new SqlConnection(Webconfig.Dbeduweb);
                using (var con = connect)
                {
                    using (var cmd = new SqlCommand("sp_CheckDangNhap"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.Add("@masv", SqlDbType.VarChar).Value = masv;
                        cmd.Parameters.Add("@matkhau", SqlDbType.VarChar).Value = matkhau;
                        con.Open();
                        var adt = new SqlDataAdapter { SelectCommand = cmd };
                        adt.Fill(dt);
                        con.Close();
                    }
                }

            }
            catch{}
            return dt;
        }
    }
}
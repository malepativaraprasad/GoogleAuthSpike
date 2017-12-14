using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleAuthSpike
{
    public class DataAccess
    {
        public GoogleAuthModel GetGoogleAuthDetails(string memberNumber)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            GoogleAuthModel result = new GoogleAuthModel();
            try
            {
                conn = new SqlConnection("Data Source=NYLICVMJWDBQA1;Initial Catalog=Jwaala_1000 ;Integrated Security=False;User ID=Jwaala;Password=Jwaala;MultipleActiveResultSets=True");
                conn.Open();

                SqlCommand cmd = new SqlCommand("p_GetUserGoogleAuthDetails", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MemberNumber", memberNumber));

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    result.Username = rdr["Username"].ToString();
                    result.Id = rdr["Id"].ToString();
                    result.PassCodeGoogleSecret = rdr["PasscodeGoogleSecret"].ToString();
                    result.PassCodeGoogleActive = Convert.ToBoolean(rdr["PassCodeGoogleActive"]);
                    result.DbUserId = rdr["DbUserId"].ToString();
                    result.CoreKey = rdr["CoreKey"].ToString();
                }
                return result;
            }
            finally
            {
                if (conn != null)
                { conn.Close(); }
                if (rdr != null)
                { rdr.Close(); }
            }
        }
    }
}

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Magic_API.Models
{
    public class DB
    {



        private int mint_CommandTimeout = 30000;

        public DataTable ExecStoredProc(string sProcName, string[] sParamName, string[] sParamValue)
        {
            string mstr_ConnectionString;
            SqlConnection mobj_SqlConnection;
            SqlCommand mobj_SqlCommand;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;

            DataTable DT = new DataTable();
            mstr_ConnectionString = ConfigurationManager.ConnectionStrings["MagicCS"].ToString();

            mobj_SqlConnection = new SqlConnection(mstr_ConnectionString);
            mobj_SqlCommand = new SqlCommand();
            mobj_SqlCommand.CommandTimeout = mint_CommandTimeout;
            mobj_SqlCommand.Connection = mobj_SqlConnection;

            using (mobj_SqlConnection)
            {
                try
                {
                    if (mobj_SqlConnection.State == ConnectionState.Closed)
                    {
                        mobj_SqlConnection.Open();
                    }

                    cmd = new SqlCommand(sProcName, mobj_SqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = mint_CommandTimeout;
                    da = new SqlDataAdapter(sProcName, mobj_SqlConnection);
                    da.SelectCommand = cmd;
                    int i;

                    for (i = 0; i < sParamName.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(sParamName[i].ToString(), sParamValue[i].ToString());
                    }

                    da.Fill(DT);

                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }

                    if (da != null)
                    {
                        da.Dispose();
                    }

                }
                catch
                {
                    //throw;
                }
                finally
                {
                    if (mobj_SqlConnection.State == ConnectionState.Open)
                    {
                        mobj_SqlConnection.Close();
                    }
                }
            }
            return DT;
        }
    }
}
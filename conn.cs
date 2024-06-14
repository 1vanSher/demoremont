using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace demoremont
{
    public class conn
    {
        public static DataSet ds;
        public static DataTable dt;
        public static NpgsqlConnection connstr = new NpgsqlConnection("Host=localhost;Port=5432;Database=demoremont;Username=postgres;Password=123456");

        public static void setData(string sql)
        {
            try
            {
                connstr.Open();
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter(sql, connstr);
                ds = new DataSet();
                ds.Reset();
                nda.Fill(ds);
                dt = ds.Tables[0];
            }
            finally
            {
                connstr.Close();
            }
        }

        public static void refdata(string sql)
        {
            try
            {
                connstr.Open();
                NpgsqlCommand comm = new NpgsqlCommand(sql, connstr);
                comm.ExecuteNonQuery();
            }
            finally {
                connstr.Close();
            }

        }
    }
}

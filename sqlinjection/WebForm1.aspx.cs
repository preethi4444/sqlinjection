using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace sqlinjection
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            //{
            //    string sql = "SELECT * FROM productinventory WHERE productname = @SearchText";
            //    using (SqlCommand sqlCmd = new SqlCommand(sql, sqlConn))
            //    {
            //        sqlCmd.Parameters.AddWithValue("@SearchText", TextBox1.Text);
            //        sqlConn.Open();

            //        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
            //        {
            //            sqlAdapter.Fill(dt);
            //        }
            //    }
            //}

            //if (dt.Rows.Count > 0)
            //{
            //    GridView1.DataSource = dt;
            //    GridView1.DataBind();
            //}
            SqlConnection conn = new SqlConnection(@"Data Source=EPINHYDW008B\MSSQLSERVER1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from productinventory where productname = '" + TextBox1.Text + "'", conn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            conn.Close();


        }
    }
}
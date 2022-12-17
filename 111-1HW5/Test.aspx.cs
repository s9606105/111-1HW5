using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _111_1HW5
{
    public partial class Test : System.Web.UI.Page
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLname"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            sconn.Open();
            SqlDataAdapter o_sda = new SqlDataAdapter("SELECT * FROM Users", sconn);
            DataSet o_d = new DataSet();
            o_sda.Fill(o_d, "hello");
            gd_View.DataSource = o_d;
            gd_View.DataBind();
            sconn.Close();
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                sconn.Open();
                SqlCommand scom = new SqlCommand("INSERT INTO Users (Name, Birthday)" +
                                                 "VALUES(@Name, @Datetime)", sconn);
                //SqlDataAdapter o_sda = new SqlDataAdapter("SELECT * FROM Users", sconn);
                //DataSet o_d = new DataSet();
                //o_sda.Fill(o_d, "hello");
                scom.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
                scom.Parameters["@Name"].Value = "阿貓阿狗";
                scom.Parameters.Add("@Datetime", SqlDbType.DateTime);
                scom.Parameters["@Datetime"].Value = "2000/10/10";

                scom.ExecuteNonQuery();
                //o_sda.InsertCommand = scom;
                sconn.Close();
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSharp_WebForm_UserLogin_SqlConnString_Final
{
    public partial class frmLogIn : System.Web.UI.Page
    {
    
    protected void Button1_Click(object sender, EventArgs e)
        {
            //1. from conn string
            /*
            string connectionString=null;
            /SqlConnection cnn=null;
            /connectionString = "Data Source=DESKTOP-SHJRQ9O\\SQLEXPRESS;Initial Catalog=DbEmployee; User ID=sa;Password=sa";
            cnn = new SqlConnection(connectionString);
            */

            string connectionString = null;
            SqlConnection cnn = null;
            cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnDbEmployee"].ConnectionString);
            cnn.Open();

            string uid = TxtUser.Text;
            string pass = TxtPass.Text;
           

            string qry = "select * from TblUser where name='" + uid + "' and pass='" + pass + "'";
            SqlCommand cmd = new SqlCommand(qry, cnn);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                Label4.Text = "Login Sucess......!!";
            }
            else
            {
                Label4.Text = "UserId & Password Is not correct Try again..!!";
            }

        }
    }
    
    
    
}
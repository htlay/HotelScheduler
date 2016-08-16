using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        }

        protected void login1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from [UserData] where UserName='" + TextBoxUserN.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int count = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (count == 1)
            {
                conn.Open();
                string checkPasswordQuery = "select password from [UserData] where UserName='" + TextBoxUserN.Text + "'";
                SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
                string password = passComm.ExecuteScalar().ToString().Replace(" ", "");
                if (password == TextBoxPassW.Text)
                {
                    Session["New"] = TextBoxUserN.Text;
                    Response.Write("Password is correct");
                    Response.Redirect("Reserve.aspx");
                }
                else
                {
                    Response.Write("Password is not correct");
                }
            }
            else
            {
                Response.Write("Username is not correct");
            }

            conn.Close();
        }
    }
}
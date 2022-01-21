using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class AddAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                conn.Open();
                string authenticate = "select count(*) from Login where username = '" + tb_Username.Text + "' ";
                SqlCommand com = new SqlCommand(authenticate, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp == 1)
                {
                    Response.Write("User already exists");
                }
                conn.Close();
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (tb_cfmPass.Text != tb_Pass.Text)
            {
                Response.Write("Error! Re-confirm Password");
                tb_Pass.Text = "";
                tb_cfmPass.Text = "";
                tb_Pass.Focus();
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                    conn.Open();
                    string insertQuery = "insert into Login (username, password, NRIC, name, accountType) values (@username, @password, @nric, @name, @accountType)";
                    SqlCommand com = new SqlCommand(insertQuery, conn);
                    com.Parameters.AddWithValue("@username", tb_Username.Text);
                    com.Parameters.AddWithValue("@password", tb_Pass.Text);
                    com.Parameters.AddWithValue("@nric", tb_NRIC.Text);
                    com.Parameters.AddWithValue("@name", tb_Name.Text);
                    com.Parameters.AddWithValue("@accountType", radio_employer.SelectedItem.ToString());
                    com.ExecuteNonQuery();
                    Response.Write("Registration Successful");
                    Response.Redirect("LoginPage.aspx");
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error:" + ex.ToString());
                }
            }
        }

        protected void clrBtn_Click(object sender, EventArgs e)
        {
            tb_cfmPass.Text = "";
            tb_Name.Text = "";
            tb_Username.Text = "";
            tb_Pass.Text = "";
            tb_NRIC.Text = "";
            tb_Name.Focus();
            radio_employer.SelectedValue = "Employee";

        }

    }
}
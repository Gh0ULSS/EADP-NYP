using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP1
{
    public partial class LoginManagerEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int selected_Id = Convert.ToInt32(DropDownList1.Text);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Login SET username = '" + tb_Username.Text + "', name = '" + tb_Name.Text + "' , NRIC = '" + tb_Nric.Text + "' , password = '" + tb_Password.Text + "' , accountType = '" + radio_Employer.SelectedValue.ToString() + "'WHERE user_Id = " + selected_Id + ";";
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.BufferOutput = true;
            Response.Redirect("LoginManagerEdit.aspx");

        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginManager.aspx");
        }

        protected void btn_Load_Click(object sender, EventArgs e)
        {
            string username = "";
            string name = "";
            string nric = "";
            string password = "";
            string accountType = "";
            int selectedId = Convert.ToInt32(DropDownList1.Text);
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            conn.Open();

            string getInfo = "select username, name, NRIC, password, accountType from Login where user_Id = '" + selectedId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(getInfo, conn);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                username = row["username"].ToString();
                name = row["name"].ToString();
                nric = row["NRIC"].ToString();
                password = row["password"].ToString();
                accountType = row["accountType"].ToString();
                conn.Close();
            }
            tb_Name.Text = name;
            tb_Username.Text = username;
            tb_Password.Text = password;
            tb_Nric.Text = nric;
            radio_Employer.SelectedValue = accountType;
            
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            int selected_Id = Convert.ToInt32(DropDownList1.Text);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "DELETE FROM Login WHERE user_Id = " + selected_Id+ "";
            cmd.ExecuteNonQuery();

            conn.Close();
            Response.BufferOutput = true;
            Response.Redirect("LoginManagerEdit.aspx");
        }
    }
}
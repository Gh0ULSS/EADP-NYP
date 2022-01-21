using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbUser.Text == "admin" || tbPass.Text == "admin")
            {
                Response.Redirect("LoginManager.aspx");
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            conn.Open();
            string checkUser = "select count(*) from Login where username = '" + tbUser.Text + "' ";
            SqlCommand com = new SqlCommand(checkUser, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();

            if (temp == 1)
            {
                conn.Open();
                string checkPass = "select password from Login where  username = '" + tbUser.Text + "'";
                SqlCommand passComm = new SqlCommand(checkPass, conn);
                string password = passComm.ExecuteScalar().ToString().Replace(" ", "");
                if (password == tbPass.Text)
                {
                    Session["User"] = tbUser.Text;
                    /*conn.Open();*/
                    string getIdConn = "select user_Id from Login where username = '" + tbUser.Text + "'";
                    SqlCommand IdComm = new SqlCommand(getIdConn, conn);
                    string getId = IdComm.ExecuteScalar().ToString().Replace(" ", "");
                    string getNameConn = "select name from Login where username = '" + tbUser.Text + "'";
                    SqlCommand nameComm = new SqlCommand(getNameConn, conn);
                    string getName = nameComm.ExecuteScalar().ToString().Replace(" ", "");
                    Session["User"] = tbUser.Text;
                    Session["Id"] = getId;
                    Session["Name"] = getName;
                    Response.Write("Password Match");

                    // attempt to get accountType and store it into Session
                    string getAccounttypeConn = "select accountType from Login where username = '" + tbUser.Text + "'";
                    da = new SqlDataAdapter(getAccounttypeConn.ToString(),conn);
                    da.Fill(ds, "Login");

                    DataRow row = ds.Tables["Login"].Rows[0];  // get first row

                    // Store accountType into Session from database
                    Session["accountType"] = row["accountType"].ToString();

                    // to test retrieval of accountType from database and display it (PASS)
                    //Label4.Text = Session["accountType"].ToString();

                    if ((String)Session["accountType"] == "Employee")
                    {
                        // Response.Redirect("WebForm1.aspx"); (PASS)
                        Response.Redirect("HomeEmployee.aspx");
                    }
                    else if ((String)Session["accountType"] == "Employer")
                    {
                        Response.Redirect("HomeEmployer.aspx");
                    } 

                }
                else
                {
                    Response.Write("Password not Matching");
                }

            }
            else
            {
                Response.Write("Username is not correct");
            }
            conn.Close();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbUser.Text = "";
            tbPass.Text = "";
            tbUser.Focus();
        }

        protected void viewButton_Click(object sender, EventArgs e)
        {
            if (tbPass.TextMode != TextBoxMode.SingleLine)
            {
                tbPass.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                tbPass.TextMode = TextBoxMode.Password;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAccount.aspx");
        }
    }
}
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
    public partial class EmployerUpdate : System.Web.UI.Page
    {

        String proff , info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
            //   string id = (string)(Session["Id"]);
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            conn.Open();
            string query = "select * from Employer where user_Id = " + Session["Id"];
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            //Response.Write("database connected");
            foreach (DataRow row in dt.Rows)
            {
                proff = row["Profession"].ToString();
                info = row["Info"].ToString();
            }

            LblTitle.Text = Session["Name"].ToString();
            TBProf.Text = proff;
            TBInfo.Text = info;
            conn.Close();
        }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            string id = (string)(Session["Id"]);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            conn.Open();
            string query = "UPDATE Employer SET Profession=@Profession, Info=@Info WHERE user_Id = " + Session["Id"];
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Profession", TBProf.Text);
            cmd.Parameters.AddWithValue("@Info", TBInfo.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("EmployerProfile.aspx");
        }

        protected void TBConfirm_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBNew_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
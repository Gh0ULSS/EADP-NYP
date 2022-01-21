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
    public partial class EmployeeUpdate : System.Web.UI.Page
    {

        String proff, skill, stats;

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
           
                //string id = (string)(Session["Id"]);
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Employee SET Profession='" + TBprof.Text + "', Skills='" + TBskills.Text + "' , Status= '" + DDLstatus.SelectedValue.ToString() + "' WHERE Employee_Id=1";
                cmd.ExecuteNonQuery();

                conn.Close();

                Response.Redirect("EmployeeProfile.aspx");
            

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // string id = (string)(Session["Id"]);

                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                conn.Open();
                string query = "select * from Employee where Employee_Id =1";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
                //Response.Write("database connected");
                foreach (DataRow row in dt.Rows)
                {
                    proff = row["Profession"].ToString();
                    skill = row["Skills"].ToString();
                    stats = row["Status"].ToString();
                }

                LblTitle.Text = Session["Name"].ToString();
                TBprof.Text = proff;
                TBskills.Text = skill;
                DDLstatus.SelectedValue = stats;

                conn.Close();
            }
        }

    }
}
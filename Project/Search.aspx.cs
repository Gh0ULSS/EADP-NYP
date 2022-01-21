using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Project.Entity_Layer;
using System.Text;


namespace Project
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // DON"T TOUCH!!!!!!!
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                lbValS.Visible = true;
            }
            else if (ddSearchT.SelectedValue == "-- Select Type --")
            {
                lbValS.Visible = true;
            }
            else
            {
                if (ddSearchT.SelectedValue == "Users")
                {
                    SqlConnection connet = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                    string findU = "SELECT user_Id, username, name FROM Login WHERE (username LIKE '%' + @username + '%' OR name LIKE '%' + @name + '%' )";
                    SqlCommand comm = new SqlCommand(findU, connet);


                    comm.Parameters.Add("@username", SqlDbType.VarChar).Value = tbSearch.Text;
                    comm.Parameters.Add("@name", SqlDbType.VarChar).Value = tbSearch.Text;

                    connet.Open();
                    comm.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = comm;
                    DataSet ds = new DataSet();

                    da.Fill(ds, "username");
                    da.Fill(ds, "name");
                    gvUser.DataSource = ds;
                    gvUser.DataBind();
                    gvUser.Visible = true;


                    connet.Close();
                }


                else
                {
                    SqlConnection connet = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                    string findU = "SELECT * FROM JobsDB WHERE (Job_Name LIKE '%' + @jobName + '%' OR Job_Desc LIKE '%' + @jobDesc + '%' ) AND Job_Status = 'Active' ";
                    SqlCommand comm = new SqlCommand(findU, connet);


                    comm.Parameters.Add("@jobName", SqlDbType.VarChar).Value = tbSearch.Text;
                    comm.Parameters.Add("@jobDesc", SqlDbType.VarChar).Value = tbSearch.Text;

                    connet.Open();
                    comm.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = comm;
                    DataSet ds = new DataSet();

                    da.Fill(ds, "Job_Id");
                    da.Fill(ds, "Job_Name");
                    da.Fill(ds, "Job_PayType");
                    da.Fill(ds, "Job_PayRate");
                    da.Fill(ds, "Job_StartDate");
                    da.Fill(ds, "Job_EndDate");
                    gvJobs.DataSource = ds;
                    gvJobs.DataBind();
                    gvJobs.Visible = true;


                    connet.Close();
                }

            }
 
        }




        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = gvUser.SelectedRow;
            string userid = row.Cells[0].Text;
            Session["SUser_Id"] = userid;
            string name = row.Cells[2].Text;
            Session["SName"] = name;
            Response.Redirect("EmployeeProfile.aspx");
        }

        protected void gvJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvJobs.SelectedRow;
            string jobsid = row.Cells[0].Text;
            Session["SJobs_Id"] = jobsid;
            Response.Redirect("JobDisplay.aspx");
        }
    }
}
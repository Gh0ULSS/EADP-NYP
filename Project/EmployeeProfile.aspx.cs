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
    public partial class EmployeeProfile : System.Web.UI.Page
    {

        String name, proff, skill, stats;
        //String user = (string)(Session["user_Id"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Session["SUser_Id"] != null)
                {
                    DataTable dt = new DataTable();
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                    conn.Open();
                    string query = "select * from Employee where user_Id = " + Session["SUser_Id"];
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                    //Response.Write("database connected");
                    foreach (DataRow row in dt.Rows)
                    {
                        proff = row["Profession"].ToString();
                        skill = row["Skills"].ToString();
                        stats = row["Status"].ToString();
                    }

                    LblTitle.Text = Session["SName"].ToString();
                    LblName.Text = Session["SName"].ToString();
                    LblProf.Text = proff;
                    LblSkill.Text = skill;
                    LblStatus.Text = stats;

                    conn.Close();

                    BtnUpdate.Visible = false;
                    BtnAbsence.Visible = false;
                }
                else if(Session["Id"] != null)
                {
                    DataTable dt = new DataTable();
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                    conn.Open();
                    string query = "select * from Employee where user_Id = " + Session["Id"];
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
                    LblName.Text = Session["Name"].ToString();
                    LblProf.Text = proff;
                    LblSkill.Text = skill;
                    LblStatus.Text = stats;

                    conn.Close();
                }

              //string id = (string)(Session["Id"]);

               

            }
        }

        protected void BtnAbsence_Click(object sender, EventArgs e)
        {
            Response.Redirect("AbsenceForm.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeUpdate.aspx");
        }

    

    }
}
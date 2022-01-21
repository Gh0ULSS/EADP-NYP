using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["MJob_Id"] != null)
            {


                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                conn.Open();
                string getJob = "select * from JobsDB WHERE Job_Id = '" + Session["MJob_Id"] + "' ";
                SqlDataAdapter adpt = new SqlDataAdapter(getJob, conn);
                DataSet job = new DataSet();
                adpt.Fill(job);

                foreach (DataRow dr in job.Tables[0].Rows)
                {

                    lbDJID.Text += job.Tables[0].Rows[0]["Job_Id"].ToString();

                    lbDJTitle.Text += job.Tables[0].Rows[0]["Job_Name"].ToString();
                    lbDJCat.Text += job.Tables[0].Rows[0]["Job_Categ"].ToString();
                    lbDQua.Text += job.Tables[0].Rows[0]["Job_Qualif"].ToString();
                    lbDPRate.Text += job.Tables[0].Rows[0]["Job_PayRate"].ToString();
                    lbDPType.Text += job.Tables[0].Rows[0]["Job_PayType"].ToString();
                    lbDSDate.Text += job.Tables[0].Rows[0]["Job_StartDate "].ToString(); //DON'T TOUCH
                    lbDEDate.Text += job.Tables[0].Rows[0]["Job_EndDate"].ToString();
                    lbDPloyer.Text += job.Tables[0].Rows[0]["Job_PloyerName"].ToString();
                    lbDJDesc.Text += job.Tables[0].Rows[0]["Job_Desc"].ToString();

                }
            }
            else
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                conn.Open();
                string getJob = "select * from JobsDB WHERE Job_Id = '" + Session["SJobs_Id"] + "' ";
                SqlDataAdapter adpt = new SqlDataAdapter(getJob, conn);
                DataSet job = new DataSet();
                adpt.Fill(job);

                foreach (DataRow dr in job.Tables[0].Rows)
                {
                    lbDJID.Text += job.Tables[0].Rows[0]["Job_Id"].ToString();

                    lbDJTitle.Text += job.Tables[0].Rows[0]["Job_Name"].ToString();
                    lbDJCat.Text += job.Tables[0].Rows[0]["Job_Categ"].ToString();
                    lbDQua.Text += job.Tables[0].Rows[0]["Job_Qualif"].ToString();
                    lbDPRate.Text += job.Tables[0].Rows[0]["Job_PayRate"].ToString();
                    lbDPType.Text += job.Tables[0].Rows[0]["Job_PayType"].ToString();
                    lbDSDate.Text += job.Tables[0].Rows[0]["Job_StartDate "].ToString(); //DON'T TOUCH
                    lbDEDate.Text += job.Tables[0].Rows[0]["Job_EndDate"].ToString();
                    lbDPloyer.Text += job.Tables[0].Rows[0]["Job_PloyerName"].ToString();
                    lbDJDesc.Text += job.Tables[0].Rows[0]["Job_Desc"].ToString();

                }
            }


        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

            if (Session["SJobs_Id"] != null)
            {
                Response.Redirect("Search.aspx");
            }
            else
            {
                Response.Redirect("JobMatching.aspx");
            }

        }
        
  
    }
}
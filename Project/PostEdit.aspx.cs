/*Created by:
 * Daisuke Low, 162438E
 * 
 * Content:
 * - Backend code for the post edit page
 * - Update a database entry in the JobsDB table
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace ITP213_Project
{
    public partial class PostEdit : System.Web.UI.Page
    {
        //SQL Connection
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            //Loads fields

            //Variables
            String jobName = "";
            String jobDesc = "";
            String jobCateg = "";
            String jobQualif = "";
            String payType = "";
            String payRate = "";
            String startDate = "";
            String endDate = "";
            String jobStatus = "";

            //Converting selector's data
            int selectedJob = Convert.ToInt32(ddSelector.Text);

            //Data table
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");

            //Connect
            con.Open();
            //Query
            string query = "SELECT Job_Name, Job_Desc, Job_Categ, Job_Qualif, Job_PayType, Job_PayRate, Job_StartDate, Job_EndDate, Job_Status FROM JobsDB WHERE Job_Id = "+selectedJob+"";
            //Data formatting
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);

            //Get values from data source
            foreach (DataRow row in dt.Rows)
            {
                jobName = row["Job_Name"].ToString();
                jobDesc = row["Job_Desc"].ToString();
                jobCateg = row["Job_Categ"].ToString();
                jobQualif = row["Job_Qualif"].ToString();
                payType = row["Job_PayType"].ToString();
                payRate = row["Job_PayRate"].ToString();
                startDate = row["Job_StartDate"].ToString();
                endDate = row["Job_EndDate"].ToString();
                jobStatus = row["Job_Status"].ToString();

                con.Close();
            }

            //Place values inside fields
            tbName.Text = jobName;
            tbDescription.Text = jobDesc;
            ddCategory.Text = jobCateg;
            ddQualifications.Text = jobQualif;
            ddPayType.Text = payType;
            tbRate.Text = payRate;
            calendarStart.SelectedDate = Convert.ToDateTime(startDate);
            calendarEnd.SelectedDate = Convert.ToDateTime(endDate);
            ddStatus.Text = jobStatus;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Updates selected job post

            //Get today's DateTime, for use of Job Create date
            DateTime creationDate = DateTime.Today.Date;

            //Validation
            if (tbName.Text == "")
            {
                lbValidation.Visible = true;
            }
            else if (tbDescription.Text == "")
            {
                lbValidation.Visible = true;
            }
            else if (ddCategory.SelectedValue == "-- Select Type --")
            {
                lbValidation.Visible = true;
            }
            else if (ddQualifications.SelectedValue == "-- Select Qualification --")
            {
                lbValidation.Visible = true;
            }
            else if (tbRate.Text == "")
            {
                lbValidation.Visible = true;
            }
            else
            {
                //Converting selector's data
                int selectedJob = Convert.ToInt32(ddSelector.Text);

                //If validation label was active before, this will remove it
                lbValidation.Visible = false;

                //Connection code
                con.Open();
                //Sends these codes through while the connection is open
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE JobsDB SET Job_Name = '" + tbName.Text+"', Job_Desc = '"+tbDescription.Text+"' , Job_Categ = '"+ddCategory.Text+"' , Job_Qualif = '"+ddQualifications.Text+"' , Job_PayType = '"+ddPayType.Text+"' , Job_PayRate = '"+tbRate.Text+"',  Job_StartDate = '"+calendarStart.SelectedDate.ToString("yyyy-MM-dd") + "', Job_EndDate = '"+calendarEnd.SelectedDate.ToString("yyyy-MM-dd") + "', Job_Status = '"+ddStatus.Text+"'  WHERE Job_Id = " + selectedJob + ";";
                cmd.ExecuteNonQuery();

                con.Close();

                //Refreshes page
                Response.BufferOutput = true;
                Response.Redirect("PostEdit.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Deletes selected job post

            //Converting selector's data
            int selectedJob = Convert.ToInt32(ddSelector.Text);

            //Connection code
            con.Open();
            //Sends these codes through while the connection is open
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM JobsDB WHERE Job_Id = "+selectedJob+"";
            cmd.ExecuteNonQuery();

            con.Close();

            //Refreshes page
            Response.BufferOutput = true;
            Response.Redirect("PostEdit.aspx");

        }

        protected void btnRecommend_Click(object sender, EventArgs e)
        {
            //Codes to generate recommendation

            //"if" to ensure someone filled in necessary fields
            if (ddCategory.SelectedValue == "-- Select Type --")
            {
                lbRecommend.Text = "Please select a category of jobs";
            }
            else
            {

                //aveRate stores the value returned, aveRateDec stores the value in decimal so as to convert back to String in two decimal places
                String aveRate = "";
                Decimal aveRateDec = 0;
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");

                //Connect
                con.Open();
                //Query
                string query = "SELECT AVG(Job_PayRate) FROM JobsDB WHERE Job_Categ = '" + ddCategory.Text + "' AND Job_PayType = '" + ddPayType.Text + "'";
                //Data formatting
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);

                aveRate = dt.Rows[0][0].ToString();

                //Convert to 2 decimal places
                aveRateDec = Convert.ToDecimal(aveRate);


                //Recommendation display
                lbRecommend.Text = "Average rate for " + ddCategory.Text + " jobs " + ddPayType.Text + " : $";
                lbRecRate.Text = " " + aveRateDec.ToString("#.##");

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            //When this button is clicked, fields reset
            tbName.Text = "";
            tbDescription.Text = "";
            ddCategory.SelectedIndex = -1;
            ddQualifications.SelectedIndex = -1;
            ddPayType.SelectedIndex = -1;
            tbRate.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it goes back to the navigation page
            Response.BufferOutput = true;
            Response.Redirect("JobNavigation.aspx");
        }
    }
}
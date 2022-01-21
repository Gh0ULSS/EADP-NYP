/*Created by:
 * Daisuke Low, 162438E
 * 
 * Content:
 * - Backend code for the details page
 * - Retrieve data 
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
    public partial class JobDetail : System.Web.UI.Page
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
            int selectedJob = Convert.ToInt32(ddSelectorView.Text);

            //Data table
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");

            //Connect
            con.Open();
            //Query
            string query = "SELECT Job_Name, Job_Desc, Job_Categ, Job_Qualif, Job_PayType, Job_PayRate, Job_StartDate, Job_EndDate, Job_Status FROM JobsDB WHERE Job_Id = " + selectedJob + "";
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
            tbCategory.Text = jobCateg;
            tbQualifications.Text = jobQualif;
            tbPayType.Text = payType;
            tbRate.Text = payRate;
            tbStartDate.Text = startDate;
            tbEndDate.Text = endDate;
            tbStatus.Text = jobStatus;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it goes back to the navigation page
            Response.BufferOutput = true;
            Response.Redirect("JobNavigation.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it goes to the edit page
            Response.BufferOutput = true;
            Response.Redirect("PostEdit.aspx");
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            //Sets pending to "No" (so emplpoyee doesn't appear)

            //Connection code
            con.Open();
            //Sends these codes through while the connection is open
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE RequestsDB SET Pending = 'No' WHERE User_Name = '"+ddEmpSelector.Text+"';";
            cmd.ExecuteNonQuery();

            con.Close();

            //Refreshes page
            Response.BufferOutput = true;
            Response.Redirect("JobDetailView.aspx");
        }
    }
}
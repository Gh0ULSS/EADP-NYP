/*Created by:
 * Daisuke Low, 162438E
 * 
 * Content:
 * - Backend code for the absence view page
 * - Accepts absence requests (read)
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213_Project
{
    public partial class AbsenceView : System.Web.UI.Page
    {
        //SQL Connection
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
           

            if (ddSelector.Text == "")
            {
                //Do nothing
            }
            else
            {
                //Connection code
                con.Open();
                //Sends these codes through while the connection is open
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Absence SET Pending = 'Read' WHERE Case_Id = " + Convert.ToInt32(ddSelector.Text) + ";";
                cmd.ExecuteNonQuery();

                con.Close();

                //Refreshes page
                Response.BufferOutput = true;
                Response.Redirect("AbsenceView.aspx");
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            //Loads fields

            //Variables
            String userName = "";
            String reason = "";
            String startDate = "";
            String endDate = "";

            //Converting selector's data
            int selectedCase = Convert.ToInt32(ddSelector.Text);

            //Data table
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");
            //Connect
            con.Open();
            //Query
            string query = "SELECT User_Name, Reason, StartDate, EndDate FROM Absence WHERE case_Id = " + selectedCase + "";
            //Data formatting
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);

            //Get values from data source
            foreach (DataRow row in dt.Rows)
            {
                userName = row["User_Name"].ToString();
                reason = row["Reason"].ToString();
                startDate = row["StartDate"].ToString();
                endDate = row["EndDate"].ToString();

                con.Close();
            }

            //Place values inside fields
            tbName.Text = userName;
            tbDetails.Text = reason;
            tbStartDate.Text = startDate;
            tbEndDate.Text = endDate;
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it goes back to the navigation page
            Response.BufferOutput = true;
            Response.Redirect("JobNavigation.aspx");
        }
    }
}
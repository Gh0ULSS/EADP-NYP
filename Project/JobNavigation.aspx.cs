/*Created by:
 * Daisuke Low, 162438E
 * 
 * Content:
 * - Navigation page to lead to other pages
 * - Removes job posts
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ITP213_Project
{
    public partial class JobNavigation : System.Web.UI.Page
    {
        //SQL Connection
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {
            //Pseudo notification

            //reqNo captures number of pending requests
            String reqNo = "";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");

            //Connect
            con.Open();
            //Query
            string query = "SELECT COUNT(Pending) FROM RequestsDB WHERE Pending = 'Pending'";
            //Data formatting
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);

            reqNo = dt.Rows[0][0].ToString();


            //Notification display
            btnRequests.Text = "View Work Requests (" + reqNo + ")";
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it leads to the job creation page
            Response.BufferOutput = true;
            Response.Redirect("PostCreation.aspx");
        }

        protected void btnRequests_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it leads to the page to view hire requests
            Response.BufferOutput = true;
            Response.Redirect("RequestViewP.aspx");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it leads to the page to view the job's information
            Response.BufferOutput = true;
            Response.Redirect("JobDetailView.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it leads to the job edit page
            Response.BufferOutput = true;
            Response.Redirect("PostEdit.aspx");
        }

        protected void btnAbsence_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it leads to the absence view
            Response.BufferOutput = true;
            Response.Redirect("AbsenceView.aspx");
        }
    }
}
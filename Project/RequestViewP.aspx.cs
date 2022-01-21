/*Created by:
 * Daisuke Low, 162438E
 * 
 * Content:
 * - Backend code for the request view (Pending) page
 * - Update whether a request is accepted or denied
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
    public partial class RequestView : System.Web.UI.Page
    {
        //SQL Connection
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            //Accepts the request (Updates Pending in RequestsDB to 'Yes') <- "Yes" stands for accepted

            //Validation
            if (ddSelector.Text == "")
            {
                //Do nothing
            }
            else {
                //Connection code
                con.Open();
                //Sends these codes through while the connection is open
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE RequestsDB SET Pending = 'Yes' WHERE Request_Id = " + Convert.ToInt32(ddSelector.Text) + ";";
                cmd.ExecuteNonQuery();

                con.Close();

                //Refreshes page
                Response.BufferOutput = true;
                Response.Redirect("RequestViewP.aspx");
            }
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            //Declines the request (Updates Pending in RequestsDB to 'No') <- "No" stands for declined

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
                cmd.CommandText = "UPDATE RequestsDB SET Pending = 'No' WHERE Request_Id = " + Convert.ToInt32(ddSelector.Text) + ";";
                cmd.ExecuteNonQuery();

                con.Close();

                //Refreshes page
                Response.BufferOutput = true;
                Response.Redirect("RequestViewP.aspx");
            }

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            //Brings to the page with the relevant filter enabled
            if (ddFilter.Text == "View Pending")
            {
                //Do nothing
            }
            else if (ddFilter.Text == "View Accepted")
            {
                //Brings to page with filter enabled in the data source string
                Response.BufferOutput = true;
                Response.Redirect("RequestViewA.aspx");
            }
            else
            {
                Response.BufferOutput = true;
                Response.Redirect("RequestViewD.aspx");
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it goes back to the navigation page
            Response.BufferOutput = true;
            Response.Redirect("JobNavigation.aspx");
        }
    }
}
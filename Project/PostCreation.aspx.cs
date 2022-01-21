/*Created by:
 * Daisuke Low, 162438E
 * 
 * Content:
 * - Backend code for the post creation page
 * - Create a database entry in the JobsDB table
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
    public partial class PostCreation : System.Web.UI.Page
    {
        //SQL Connection
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MainDataBase.mdf;Integrated Security=True;Connect Timeout=30");


        protected void Page_Load(object sender, EventArgs e)
        {
            string id = (string)(Session["Id"]);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it sends the text entered in all fields to the database
            string employerName = (string)(Session["Name"]);

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
                try
                {
                    //If validation label was active before, this will remove it
                    lbValidation.Visible = false;

                    //Connection code
                    con.Open();
                    //Sends these codes through while the connection is open
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO JobsDB (Job_Name, Job_Desc, Job_Categ, Job_Qualif, Job_PayType, Job_Payrate, Job_PloyerName, Job_StartDate, Job_EndDate, Job_Status) VALUES ('" + tbName.Text + "' , '" + tbDescription.Text + "' , '" + ddCategory.Text + "' , '" + ddQualifications.Text + "' , '" + ddPayType.Text + "' , '" + tbRate.Text + "' , '" + employerName + "' , '" + calendarStart.SelectedDate.ToString("yyyy-MM-dd") + "' , '" + calendarEnd.SelectedDate.ToString("yyyy-MM-dd") + "' , 'Active')";
                    cmd.ExecuteNonQuery();

                    con.Close();

                    //Success message
                    String message = "Success! Post has been created.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
                }
                catch
                {
                    //In case something goes wrong
                    String failure = "Failed, please make sure all fields are filled and payrate is a number.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + failure + "');", true);

                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //When this button is clicked, it goes back to the navigation page
            Response.BufferOutput = true;
            Response.Redirect("JobNavigation.aspx");
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

    }
}
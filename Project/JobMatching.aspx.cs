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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["category"] != null)
            {
                if (Session["payType"] != null)
                {
                    if (Session["startDate"] != null)
                    {
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                        conn.Open();
                        SqlCommand dis = new SqlCommand
                        ("select Job_Id,Job_Name,Job_PayType,Job_PayRate,Job_StartDate,Job_EndDate from JobsDB where Job_Categ = '" + ddCat.SelectedValue + "' and Job_PayType = '" + ddPayType.SelectedValue + "' and Job_StartDate = '" + calendarStart.SelectedDate.ToString(calendarStart.SelectedDate.Year + "/" + calendarStart.SelectedDate.Month + "/" + calendarStart.SelectedDate.Day) + "' and Job_Status = 'Active' ", conn);
                        GridViewDMatch.DataSource = dis.ExecuteReader();
                        GridViewDMatch.DataBind();

                        conn.Close();
                    }
                    else
                    {
                        GridViewDMatch.Visible = false;
                    }

                }
                else
                {
                    GridViewDMatch.Visible = false;
                }
            }
            else
            {
                GridViewDMatch.Visible = false;
            }


        }


        protected void ButtonMatch_Click(object sender, EventArgs e)
        {

            DateTime Today = DateTime.Today.Date;

            if (ddCat.SelectedValue == "-- Select Type --")
            {
                lbValidate.Visible = true;
            }

            else if (ddPayType.SelectedValue == "-- Select Type --")
            {
                lbValidate.Visible = true;
            }

            else if (calendarStart.SelectedDate < Today.Date)
            {
                lbValidateSDate.Visible = true;
            }

            else
            {


                //decimal inputPayRate = Convert.ToDecimal(tbPayAmt.Text);


                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                conn.Open();
                SqlCommand dis = new SqlCommand
                ("select Job_Id,Job_Name,Job_PayType,Job_PayRate,Job_StartDate,Job_EndDate from JobsDB where Job_Categ = '" + ddCat.SelectedValue + "' and Job_PayType = '" + ddPayType.SelectedValue + "' and Job_StartDate = '" + calendarStart.SelectedDate.ToString(calendarStart.SelectedDate.Year + "/" + calendarStart.SelectedDate.Month + "/" + calendarStart.SelectedDate.Day) + "' and Job_Status = 'Active' ", conn);
                //and JobPayRate > = '" + tbPayAmt.Text + "' and Job_PayType = '"+ ddPayType.SelectedValue + "' and Job_StartDate > = '" +Today.Date+ "'", con);
                GridViewDMatch.DataSource = dis.ExecuteReader();
                GridViewDMatch.DataBind();
                GridViewDMatch.Visible = true;

                conn.Close();

                Session["category"] = ddCat.SelectedValue;
                Session["payType"] = ddPayType.SelectedValue;
                Session["startDate"] = calendarStart.SelectedDate.ToString(calendarStart.SelectedDate.Year + "/" + calendarStart.SelectedDate.Month + "/" + calendarStart.SelectedDate.Day);

            }





        }

        protected void GridViewDMatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewDMatch.SelectedRow;
            string jobId = row.Cells[0].Text;
            Session["MJob_Id"] = jobId;
            Response.Redirect("JobDisplay.aspx");
        }
    }





}
using Project.Data_Access_Layer;
using Project.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JobDAO dao = new JobDAO();
            List<Payments> pay = dao.GetDuePayments();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pay.Count ; i++)
            {
               sb.Append(pay[i].Job_Name + " " + pay[i].Payment_Amount + " " + pay[i].End_Date.ToShortDateString() + "<br>");
               Labelduepayments.Text = sb.ToString();
            }
            
            if (!Page.IsPostBack == true)
            {
                // do something when page loads for first time
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            JobDAO dao = new JobDAO();
            Details detail = dao.RetrieveDataBySelectedDate(Calendar1.SelectedDate.Date);

            if (detail == null)
            {
                LabelJob.Text = "";
                LabelJobType.Text = "";
                LabelAmount.Text = "";
                LabelPayType.Text = "";
                LabelStartDate.Text = "";
                LabelEndDate.Text = "";
                LabelErrorMsg.Text = "No Job posted";
            }
            else
            {
                try
                {
                    LabelJob.Text = detail.Job_Name;
                    LabelJobType.Text = detail.Job_Type;
                    LabelAmount.Text = detail.Payment_Amount.ToString();
                    LabelPayType.Text = detail.Pay_Type.ToString();
                    LabelStartDate.Text = detail.Start_Date.ToShortDateString();
                    LabelEndDate.Text = detail.End_Date.ToShortDateString();
                    LabelErrorMsg.Text = "";
                }
                catch
                {
                    // try catch block just in case to handle exceptions
                }
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

            JobDAO dao = new JobDAO();
            List<date> dates = dao.getDate();

            // for every dates in dates list , if the date on calendar is equal 
            // to the dates in the date list --> color them red

            for (int i = 0; i < dates.Count; i++)
            {
                if (e.Day.Date == dates[i].Start_Date)
                {
                    e.Cell.BackColor = System.Drawing.Color.Red;
                }
            }

        }

        protected void DropDownListPreference_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownListPreference.SelectedIndex == 1)
            {
                JobDAO dao = new JobDAO();
                List<Payments> pay = dao.GetDuePaymentsHourly();

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < pay.Count; i++)
                {
                    sb.Append(pay[i].Job_Name + " " + pay[i].Payment_Amount + " " + pay[i].End_Date.ToShortDateString() + "<br>");
                    Labelduepayments.Text = sb.ToString();
                }
            }
            else if(DropDownListPreference.SelectedIndex == 2)
            {
                JobDAO dao = new JobDAO();
                List<Payments> pay = dao.GetDuePaymentsMonthly();

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < pay.Count; i++)
                {
                    sb.Append(pay[i].Job_Name + " " + pay[i].Payment_Amount + " " + pay[i].End_Date.ToShortDateString() + "<br>");
                    Labelduepayments.Text = sb.ToString();
                }
            }
        }
    }
}
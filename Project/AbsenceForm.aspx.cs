using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Project
{
    public partial class AbsenceForm : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            string currentDate = DateTime.Today.ToShortDateString();
            CompareValidator1.ValueToCompare = currentDate;

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            conn.Open();

            //Response.Write("database connected");
            conn.Close();


        }

        protected void CalendarStart_SelectionChanged(object sender, EventArgs e)
        {
            TBStart.Text = CalendarStart.SelectedDate.ToShortDateString();
        }

        protected void CalendarEnd_SelectionChanged(object sender, EventArgs e)
        {
            TBEnd.Text = CalendarEnd.SelectedDate.ToShortDateString();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            string userName = (string)(Session["name"]);

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            conn.Open();
            string query = "INSERT INTO Absence (StartDate,EndDate,Reason,user_Name,Pending) VALUES (@start,@end,@reason, @username, 'Pending')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@start", DateTime.Parse(TBStart.Text).Date);
            cmd.Parameters.AddWithValue("@end", DateTime.Parse(TBEnd.Text).Date);
            cmd.Parameters.AddWithValue("@reason", TBReason.Text);
            cmd.Parameters.AddWithValue("@username", userName);
            //image error
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Absent Form Sent Successfully!");
            Response.Redirect("EmployeeProfile.aspx");
        }
    }
}
using Project.Data_Access_Layer;
using Project.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class JobHistory : System.Web.UI.Page
    { 

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!Page.IsPostBack)
            {
                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistory();
                GridView1.Visible = true;
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            } 
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListFilter.SelectedIndex == 1)
            {
                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryHourly();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 2)
            {
                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryMonthly();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 4)
            {
                
                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryRetail();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 5)
            {

                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryLogistics();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 6)
            {

                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryMarketing();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 7)
            {

                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryService();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 8)
            {

                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryFoodandBeverage();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 9)
            {

                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryEngineering();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 10)
            {

                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryMedicine();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 11)
            {

                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryIT();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
            if (DropDownListFilter.SelectedIndex == 12)
            {

                JobDAO dao = new JobDAO();
                List<jobhistory> historylist = dao.RetrieveJobHistoryOther();
                GridView1.DataSource = historylist;
                GridView1.DataBind();
            }
        }
    }
}
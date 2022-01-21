using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class EmployerProfile : System.Web.UI.Page
    {

        String name, proff, info;

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployerUpdate.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //   string id = (string)(Session["Id"]);
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
                conn.Open();
                string query = "select * from Employer where user_Id = " + Session["Id"];
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
                //Response.Write("database connected");
                foreach (DataRow row in dt.Rows)
                {
                    proff = row["Profession"].ToString();
                    info = row["Info"].ToString();
                }

                LblTitle.Text = Session["Name"].ToString();
                LblName.Text = Session["Name"].ToString();
                LblProff.Text = proff;
                LblInfo.Text = info;
                conn.Close();
            }

        }
    }
}
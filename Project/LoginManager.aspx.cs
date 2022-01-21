using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class LoginManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       protected void testBtn_Click(object sender, EventArgs e)
        {
            string id = (string)(Session["Id"]);
            Response.Write(id);
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginManagerEdit.aspx");
        }
    }
}
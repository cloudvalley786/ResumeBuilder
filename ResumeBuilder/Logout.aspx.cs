using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResumeBuilder
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Session["Name"] = null;
            Session["Email"] = null;
            Session["ContactNo"] = null;
            Session["SessionID"] = null;
            Session.Abandon();
            Session.Clear();
            Request.Cookies.Clear();
            Response.Cookies.Clear();
            Response.Redirect("~/Login.aspx", false);
        }
    }
}
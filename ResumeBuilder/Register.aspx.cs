using ResumeBuilder.connectors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResumeBuilder
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string desc = CLOVA.RegisterUser(txtEmail.Text, txtPassword.Text, txtName.Text, txtContact.Text);
                if (desc.ToLower().Contains("success"))
                {
                    Session["Success"] = desc;
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Session["Error"] = desc;
                    return;
                }
            }
            catch (System.Threading.ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnRegister_Click", "2030","0", "Register");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }


        }
    }
}
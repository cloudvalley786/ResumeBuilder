using ResumeBuilder.connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResumeBuilder
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCurPassword.Text == txtNewPassword.Text)
                {
                    Session["Error"] = "Current Password & New Password must be different.";
                    return;
                }
                string desc = CLOVA.UserChangePassword(Convert.ToInt32(Session["UserID"]), txtCurPassword.Text, txtNewPassword.Text);
                if (desc.ToLower().Contains("success"))
                {
                    Session["Success"] = desc;
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
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnChangePass_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "ChangePassword");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }

        }
    }
}
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if(!Page.IsPostBack)
            //GetConnectionString();
        }

        private void GetConnectionString()
        {
            try
            {
                string guid = string.Empty;
                guid = Request.QueryString["Guid"];
                DataTable dt;
                string desc=CLOVA.GetConnectionString(guid, out dt);
                if (desc.ToLower().Contains("success"))
                {
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            Session["ConnString"] = dt.Rows[0]["ConnString"].ToString();
                        }
                    }
                }
                else
                {
                    Session["Error"] = "9999 - Other Vendor Software related Error on Server.";
                    return;
                }
               
            }
            catch (System.Threading.ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                Log.FileLogError(ex.Message, ex.StackTrace.ToString(), "GetConnectionString", "2030", "0", "Login");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt;
                string sessionID = GetSessionId();
                string desc = CLOVA.UserAuth(txtEmail.Text, txtPassword.Text, sessionID, out dt);
                if (desc.ToLower().Contains("success"))
                {
                    if (dt != null)
                    {
                        Session["UserID"] = dt.Rows[0]["ID"].ToString();
                        Session["Name"] = dt.Rows[0]["EName"].ToString();
                        Session["Email"] = dt.Rows[0]["EmailID"].ToString();
                        Session["ContactNo"] = dt.Rows[0]["ContactNo"].ToString();
                        Session["SessionID"] = sessionID;
                    }
                    Session["Success"] = desc;
                    Response.Redirect("CreateProfile.aspx");
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
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnLogin_Click", "2030","0", "Login");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        #region session Management
        public static string GetSessionId()
        {
            string sessionId = string.Empty;
            try
            {
                System.Web.SessionState.SessionIDManager Manager = new System.Web.SessionState.SessionIDManager();
                sessionId = Manager.CreateSessionID(HttpContext.Current);
            }
            catch (Exception ex)
            {
                sessionId = "N/A";
            }
            return sessionId;
        }
        #endregion

        private string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

    }
}
using ResumeBuilder.connectors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;

namespace ResumeBuilder
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        static string _Server = ConfigurationSettings.AppSettings["EmailServer"].ToString().Trim();
        static string _Email = ConfigurationSettings.AppSettings["Email"].ToString().Trim();
        static string _Pwd = ConfigurationSettings.AppSettings["Password"].ToString().Trim();
        static int _Port = Convert.ToInt32(ConfigurationSettings.AppSettings["Port"].ToString().Trim());
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnForget_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt;
                string desc = CLOVA.EmployerForgotPassword(txtEmail.Text,out dt);
                if (desc.ToLower().Contains("success"))
                {
                    if (dt != null)
                    {
                        MailMessage mail = new MailMessage(_Email, txtEmail.Text);
                        mail.Subject = "Share It: Password Recovery";
                        mail.Body = "Hi, " + dt.Rows[0]["Name"] + "<br />As requested, here is your login details:<br /><br />Your Username: " + txtEmail.Text + "<br /><br />Your Password: " + dt.Rows[0]["Password"] + "<br /><br />Thank you for trusting us! Hope to hear from you soon!<br /><br /><br />Regards,<br />Cloud Valley";
                        mail.IsBodyHtml = true;

                        SmtpClient SmtpServer = new SmtpClient();
                        SmtpServer.Host = _Server;
                        SmtpServer.EnableSsl = true;
                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                        NetworkCred.UserName = _Email;
                        NetworkCred.Password = _Pwd;
                        SmtpServer.UseDefaultCredentials = true;
                        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                        SmtpServer.Credentials = NetworkCred;
                        SmtpServer.Port = _Port;
                        SmtpServer.Send(mail);
                        Session["Success"] = "Your Password Details Sent to your mail.";
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Session["Success"] = "Password Reset request initiated!";
                    return;
                }
                txtEmail.Text = string.Empty;
            }
            catch (System.Threading.ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnForget_Click", "2030","0", "ForgetPassword");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }


        }
    }
}
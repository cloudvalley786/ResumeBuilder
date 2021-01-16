using ResumeBuilder.connectors;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ResumeBuilder
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        static Byte[] data = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["UserID"] != null)
                {
                    string sessionID = Convert.ToString(Session["SessionID"]);
                    lblTitle.InnerText=Session["Name"].ToString();
                    lblEmail.InnerText = Session["Email"].ToString();
                    lblMobile.InnerText = Session["ContactNo"].ToString();
                    hndUserID.Value = Session["UserID"].ToString();
                    string desc = CLOVA.ValidateUserSession(Convert.ToInt32(Session["UserID"]), sessionID);
                    if (!desc.ToLower().Contains("success"))
                    {
                        Session["Error"] = desc;
                        Response.Redirect("~/Logout.aspx");
                    }

                }
                else
                {
                    Response.Redirect("~/Logout.aspx");
                }

            }
            catch (Exception)
            {
            }

            if(!Page.IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty((hndUserID.Value)))
                    {
                        DataTable dt;
                        string desc = CLOVA.GetEmployerPhoto(Convert.ToInt32(hndUserID.Value), out dt);
                        if (desc.ToLower().Contains("success"))
                        {
                            try
                            {
                                if (dt != null)
                                {
                                    hndID.Value = dt.Rows[0]["ID"].ToString();
                                    if (!string.IsNullOrEmpty(dt.Rows[0]["Photo"].ToString()))
                                    {
                                        Byte[] data = Convert.FromBase64String(dt.Rows[0]["Photo"].ToString());
                                        previewImage.ImageUrl = "data:image;base64," + Convert.ToBase64String(data);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            Session["Error"] = desc;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.LogError(ex.Message, ex.StackTrace.ToString(), "Page_Load", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "Layout");
                    Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
                }
               
            }
        }


        protected void btnDummy_Click(object sender, EventArgs e)
        {
            BinaryReader reader = new BinaryReader(rdImgUpload.UploadedFiles[0].InputStream);
            data = reader.ReadBytes((int)rdImgUpload.UploadedFiles[0].InputStream.Length);
            previewImage.ImageUrl = "data:image;base64," + Convert.ToBase64String(data);
            lnkUpload.Visible = true;

        }

        protected void lnkUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string id = string.IsNullOrEmpty((hndID.Value)) ? "0" : hndID.Value;
                string employerID = "";
                string desc = CLOVA.AddUpdateEmployerPhoto(Convert.ToInt32(id), Convert.ToInt32(hndUserID.Value), Convert.ToBase64String(data), Convert.ToInt32(hndUserID.Value),
                Convert.ToInt32(hndUserID.Value), out employerID);
                
                if (desc.ToLower().Contains("success"))
                {
                    hndID.Value = employerID;
                    Session["EmployerID"] = employerID;
                    lnkUpload.Visible = false;
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
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "lnkUpload_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "Layout");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }
    }
}
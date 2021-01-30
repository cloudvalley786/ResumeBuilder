using System;
using ResumeBuilder.connectors;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResumeBuilder
{
    public partial class Jobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!Page.IsPostBack)
			{
                try
                {
                    GetData();
                }
                catch (Exception ex)
                {
                    Log.LogError(ex.Message, ex.StackTrace.ToString(), "Page_Load", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "Jobs");
                    Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
                }
            }
		}

        private void GetData()
        {
            try
            {
                DataTable dt;
                string desc = CLOVA.GetJobsData(Convert.ToInt32(Session["UserID"].ToString()), out dt);
                if (desc.ToLower().Contains("success"))
                {
                    if(dt.Rows.Count>0)
                    {
                        grdJobs.DataSource = dt;
                        grdJobs.DataBind();
                        lblMsg.Visible = false;
                    }
                    else
                    {
                        lblMsg.Text = "No records has been added.";
                        lblMsg.Visible = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "GetData", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "Jobs");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void lnkApply_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = sender as LinkButton;
                int rowno = Convert.ToInt32(lnk.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdJobs.Rows[rowno].FindControl("hfID");
                string desc = CLOVA.EmployerJobApply(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(hfid.Value));
                if (desc.ToLower().Contains("success"))
                {
                    GetData();
                    Session["Success"] = desc;
                    return;
                }
                else
                {
                    Session["Error"] = desc;
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "lnkApply_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "Jobs");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void grdJobs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string val = e.Row.Cells[8].Text;

                LinkButton lnkButton = (LinkButton)e.Row.FindControl("lnkApply");
                Label lbl = (Label)e.Row.FindControl("lblStatus");
                if (val=="0")
                {
                    lnkButton.Visible = true;
                    lbl.Visible = false;
                }
                else
                {
                    lbl.Text = "Applied";
                    lnkButton.Visible = false;
                    lbl.Visible = true;
                }
            }
        }
    }
}
using ResumeBuilder.connectors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ResumeBuilder
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hndUserID.Value = Session["UserID"].ToString();
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
                                ProfileImg.ImageUrl = "data:image;base64," + Convert.ToBase64String(data);
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
                GetEmployerData();
            }
        }

        private void GetEmployerData()
        {
            try
            {
                DataSet ds;
                string desc = CLOVA.GetEmployerData(Convert.ToInt32(hndUserID.Value), out ds);
                if (desc.ToLower().Contains("success"))
                {
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            
                            hndUserID.Value = ds.Tables[0].Rows[0]["UserID"].ToString();
                            lblName.InnerText = ds.Tables[0].Rows[0]["NameFirst"].ToString() + " " + ds.Tables[0].Rows[0]["NameMiddle"].ToString() + " " + ds.Tables[0].Rows[0]["NameLast"].ToString();
                            lblSpecilization.InnerText = ds.Tables[0].Rows[0]["Specilization"].ToString();
                            lblObjective.InnerText= ds.Tables[0].Rows[0]["Objective"].ToString();
                            lblEmail.InnerText = ds.Tables[0].Rows[0]["Email"].ToString();
                            lblContactNo.InnerText = ds.Tables[0].Rows[0]["Mobile"].ToString();
                            lblAddress.InnerText = ds.Tables[0].Rows[0]["City"].ToString() +", " + ds.Tables[0].Rows[0]["Country"].ToString();
                           
                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            EduData(ds.Tables[1]);
                        }

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            ExpData(ds.Tables[2]);
                        }

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            LanguagesData(ds.Tables[3]);
                        }

                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            SkillsData(ds.Tables[4]);
                        }

                        if (ds.Tables[5].Rows.Count > 0)
                        {
                            ReferencesData(ds.Tables[5]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "Page_Load/CLOVA.GetEmployerData", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "GetEmployerData");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        public void EduData(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                lblEducation.Text += @"<div class='content'>
            <h3>" + row["CompletionYear"].ToString() + @"</h3>
               <p>" + row["Institute"].ToString() + @"<br/>
               <em>" + row["Degree"].ToString() + @"</em></p>
            </div>";
            }
        }

        public void ExpData(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                string EndDate = row["Present"].ToString().ToLower() == "true" ? "Present" : row["EndDate"].ToString();
                lblExperience.Text += @"<div class='content'>
            <h3>" + row["StartDate"].ToString() + @" - " + EndDate + @"</h3>
            <p>" + row["CompanyName"].ToString() + @"<br />
              <em>" + row["JobRole"].ToString() + @"</em></p>
            <ul class='info'>
              <li>" + row["WorkDescription"].ToString() + @"</li>
              </ul>
          </div>";
            }
        }

        public void LanguagesData(DataTable dt)
        {
            lblLanguages.Text = @"<ul class='skills'>";
            foreach (DataRow row in dt.Rows)
            {
                lblLanguages.Text += @"<li>" + row["Language"].ToString() + @"<span> [" + row["Proficiency"].ToString() + @"]</span></li>";

            }
            lblLanguages.Text += @"</ul>";
        }

        public void SkillsData(DataTable dt)
        {
            lblSkills.Text = @"<ul class='skills'>";
            foreach (DataRow row in dt.Rows)
            {
                lblSkills.Text += @"<li>" + row["Skill"].ToString() + @"<span> [" + row["Proficiency"].ToString() + @"]</span></li>";
               
            }
            lblSkills.Text += @"</ul>";
        }

        public void ReferencesData(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                lblReferences.Text += @"<div class='content'>
            <h3>" + row["RefName"].ToString() + @"</h3>
            <p>" + row["CompanyName"].ToString() + @"<br />
              <em>" + row["JobTitle"].ToString() + @"</em> 
              <em>" + row["Email"].ToString() + @"</em></p>
          </div>";
            }
        }

    }
}
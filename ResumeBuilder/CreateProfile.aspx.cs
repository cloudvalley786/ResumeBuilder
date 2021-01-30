using ResumeBuilder.connectors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ResumeBuilder
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDOB();
                FillLovs();
                hndUserID.Value= Session["UserID"].ToString();
                try
                {
                    hndID.Value = Session["EmployerID"].ToString();
                }
                catch (Exception)
                {
                }
                txtFirstName.Text = Session["Name"].ToString();
                txtEmail.Text = Session["Email"].ToString();
                txtMobile.Text = Session["ContactNo"].ToString();
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
                    if(ds!=null)
                    {
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            hndID.Value=ds.Tables[0].Rows[0]["ID"].ToString();
                            hndUserID.Value = ds.Tables[0].Rows[0]["UserID"].ToString();
                            txtFirstName.Text = ds.Tables[0].Rows[0]["NameFirst"].ToString();
                            txtMiddleName.Text = ds.Tables[0].Rows[0]["NameMiddle"].ToString();
                            txtLastName.Text = ds.Tables[0].Rows[0]["NameLast"].ToString();
                            txtArabicName.Text = ds.Tables[0].Rows[0]["ArabicName"].ToString();
                            txtFatherName.Text = ds.Tables[0].Rows[0]["FathersName"].ToString();
                            cbEmployeesGender.SelectedValue = ds.Tables[0].Rows[0]["GenderID"].ToString();
                            cbMaritialStatus.SelectedValue = ds.Tables[0].Rows[0]["MaritialStatus"].ToString();
                            try
                            {
                                string[] dob = ds.Tables[0].Rows[0]["DateOfBirth"].ToString().Split('-');
                                ddlYear.Text = dob[0];
                                ddlMonth.SelectedIndex = Convert.ToInt32(dob[1])-1;
                                ddlDay.Text = dob[2];
                            }
                            catch (Exception){}
                            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                            cbCountry.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
                            txtPresentAddress.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                            txtPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                            txtSpecilization.Text = ds.Tables[0].Rows[0]["Specilization"].ToString();
                            txtObjective.Text = ds.Tables[0].Rows[0]["Objective"].ToString();
                            rdIqamaTransfer.SelectedValue = ds.Tables[0].Rows[0]["IqamaTransfer"].ToString().ToLower() =="true"?"1":"0";
                            txtExperience.Text = ds.Tables[0].Rows[0]["Experience"].ToString();
                            //hndID.Value = ds.Tables[0].Rows[0]["Photo"].ToString();
                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            grdEducation.DataSource = ds.Tables[1];
                            grdEducation.DataBind();
                            EducationID.Disabled = false;
                        }
                        else
                        {
                            EducationID.Disabled = true;
                        }

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            grdExperience.DataSource = ds.Tables[2];
                            grdExperience.DataBind();
                            ExperienceID.Disabled = false;
                        }
                        else
                        {
                            ExperienceID.Disabled = true;
                        }

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            grdLanguage.DataSource = ds.Tables[3];
                            grdLanguage.DataBind();
                        }

                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            grdSkills.DataSource = ds.Tables[4];
                            grdSkills.DataBind();
                        }

                        if (ds.Tables[5].Rows.Count > 0)
                        {
                            grdReferences.DataSource = ds.Tables[5];
                            grdReferences.DataBind();
                        }
                    }
                }

                }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "Page_Load/CLOVA.GetEmployerData", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        private void FillLovs()
        {
            try
            {
                DataTable dt;
                DataRow dr;
                // Gender //
                CLOVA.GetEmployerLovs("Gender", out dt);
                dr = dt.NewRow(); 
                dr["ID"] = 0;
                dr["EName"] = "-Select One-";
                dt.Rows.InsertAt(dr, 0); 
                cbEmployeesGender.DataSource = dt;
                cbEmployeesGender.DataTextField = "EName";
                cbEmployeesGender.DataValueField = "ID";
                cbEmployeesGender.DataBind();
                // Marital Status //
                CLOVA.GetEmployerLovs("Marital Status", out dt);
                dr = dt.NewRow();
                dr["ID"] = 0;
                dr["EName"] = "-Select One-";
                dt.Rows.InsertAt(dr, 0);
                cbMaritialStatus.DataSource = dt;
                cbMaritialStatus.DataTextField = "EName";
                cbMaritialStatus.DataValueField = "ID";
                cbMaritialStatus.DataBind();
                // Degree //
                CLOVA.GetEmployerLovs("Degree", out dt);
                dr = dt.NewRow();
                dr["ID"] = 0;
                dr["EName"] = "-Select One-";
                dt.Rows.InsertAt(dr, 0);
                cbDegree.DataSource = dt;
                cbDegree.DataTextField = "EName";
                cbDegree.DataValueField = "ID";
                cbDegree.DataBind();
                // Degree Completion Year//
                FillCompletionYear();
                
                // Company Type //
                CLOVA.GetEmployerLovs("Company Type", out dt);
                dr = dt.NewRow();
                dr["ID"] = 0;
                dr["EName"] = "-Select One-";
                dt.Rows.InsertAt(dr, 0);
                cbCompanyType.DataSource = dt;
                cbCompanyType.DataTextField = "EName";
                cbCompanyType.DataValueField = "ID";
                cbCompanyType.DataBind();
                // Role //
                CLOVA.GetEmployerLovs("Role", out dt);
                dr = dt.NewRow();
                dr["ID"] = 0;
                dr["EName"] = "-Select One-";
                dt.Rows.InsertAt(dr, 0);
                cbRole.DataSource = dt;
                cbRole.DataTextField = "EName";
                cbRole.DataValueField = "ID";
                cbRole.DataBind();
                // Proficiency //
                CLOVA.GetEmployerLovs("Proficiency", out dt);
                dr = dt.NewRow();
                dr["ID"] = 0;
                dr["EName"] = "-Select One-";
                dt.Rows.InsertAt(dr, 0);
                cbSkillProficiency.DataSource = dt;
                cbSkillProficiency.DataTextField = "EName";
                cbSkillProficiency.DataValueField = "ID";
                cbSkillProficiency.DataBind();
                cbLanguageProficiency.DataSource = dt;
                cbLanguageProficiency.DataTextField = "EName";
                cbLanguageProficiency.DataValueField = "ID";
                cbLanguageProficiency.DataBind();
                // Nationality //
                CLOVA.GetEmployerLovs("Nationality", out dt);
                dr = dt.NewRow();
                dr["ID"] = 0;
                dr["EName"] = "-Select One-";
                dt.Rows.InsertAt(dr, 0);
                cbCountry.DataSource = dt;
                cbCountry.DataTextField = "EName";
                cbCountry.DataValueField = "ID";
                cbCountry.DataBind();
                cbEduCountry.DataSource = dt;
                cbEduCountry.DataTextField = "EName";
                cbEduCountry.DataValueField = "ID";
                cbEduCountry.DataBind();
                cbExperienceCountry.DataSource = dt;
                cbExperienceCountry.DataTextField = "EName";
                cbExperienceCountry.DataValueField = "ID";
                cbExperienceCountry.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "FillLovs", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
            }
        }

        private void FillCompletionYear()
        {
            for (int i = 1980; i <= 2021; i++)
            {
                ddlCompletionYear.Items.Add(i.ToString());
            }
            ddlCompletionYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        }

        private void FillDOB()
        {
            //Fill Years
            for (int i = 1950; i <= 2021; i++)
            {
                ddlYear.Items.Add(i.ToString());
            }
            ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

            //Fill Months
            ddlMonth.Items.Clear();
            ListItem lt = new ListItem();
            for (int i = 1; i <= 12; i++)
            {
                lt = new ListItem();
                lt.Text = Convert.ToDateTime(i.ToString() + "/1/1900").ToString("MMMM");
                lt.Value = i.ToString();
                ddlMonth.Items.Add(lt);
            }
            ddlMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected

            //Fill days
            FillDays();
        }

        public void FillDays()
        {
            ddlDay.Items.Clear();
            //getting numbner of days in selected month & year
            int noofdays = DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));

            //Fill days
            for (int i = 1; i <= noofdays; i++)
            {
                ddlDay.Items.Add(i.ToString());
            }
            ddlDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDays();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDays();
        }
        protected void btnPersonalInfo(object sender, EventArgs e)
        {
            try
            {
                string id = string.IsNullOrEmpty((hndID.Value)) ? "0" : hndID.Value;
                DateTime dob = Convert.ToDateTime(ddlYear.Text + "-" + ddlMonth.Text + "-" + ddlDay.Text);
                string employerID = "";
                string desc= CLOVA.AddUpdateEmployerInfo(Convert.ToInt32(id), Convert.ToInt32(hndUserID.Value), txtFirstName.Text,
                txtMiddleName.Text, txtLastName.Text, txtArabicName.Text, txtFatherName.Text, Convert.ToInt32(cbEmployeesGender.SelectedValue),
                Convert.ToInt32(cbMaritialStatus.SelectedValue), dob, txtEmail.Text, txtMobile.Text, txtCity.Text,
                Convert.ToInt32(cbCountry.SelectedValue), txtPresentAddress.Text, txtPermanentAddress.Text, "", txtSpecilization.Text, txtObjective.Text, Convert.ToInt32(rdIqamaTransfer.SelectedValue),txtExperience.Text, Convert.ToInt32(hndUserID.Value),
                Convert.ToInt32(hndUserID.Value),out employerID);
                Session["employerID"] = employerID;
                hndID.Value = employerID;
                if (desc.ToLower().Contains("success"))
                {
                    RadTab eduTab = RadTabStrip1.FindTabByText("Education");
                    eduTab.Enabled = true;
                    eduTab.Selected = true;
                    RadMultiPage1.SelectedIndex = 1;
                    RadTab perTab = RadTabStrip1.FindTabByText("Personal");
                    perTab.Enabled = false;
                    hndEduID.Value = hndExpID.Value = hndLngID.Value = hndSklID.Value = hndRefID.Value = "";
                }
                else
                {
                    Session["Error"] = desc;
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnPersonalInfo", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnEducation(object sender, EventArgs e)
        {
            hndEduID.Value = txtInstitute.Text = txtMajorSubjects.Text = txtEduCity.Text = txtObtainMarks.Text =
            txtTotalMarks.Text = txtPercentage.Text = string.Empty;
            cbDegree.SelectedValue = "0";
            cbEduCountry.SelectedValue = "0";
            ddlCompletionYear.ClearSelection();
            RadTab expTab = RadTabStrip1.FindTabByText("Experience");
            expTab.Enabled = true;
            expTab.Selected = true;
            RadMultiPage1.SelectedIndex = 2;
            RadTab eduTab = RadTabStrip1.FindTabByText("Education");
            eduTab.Enabled = false;

        }

        protected void btnEducationBack(object sender, EventArgs e)
        {
            hndEduID.Value = txtInstitute.Text = txtMajorSubjects.Text = txtEduCity.Text = txtObtainMarks.Text =
            txtTotalMarks.Text = txtPercentage.Text = string.Empty;
            cbDegree.SelectedValue = "0";
            cbEduCountry.SelectedValue = "0";
            ddlCompletionYear.ClearSelection();
            RadTab perTab = RadTabStrip1.FindTabByText("Personal");
            perTab.Selected = true;
            perTab.Enabled = true;
            RadTab eduTab = RadTabStrip1.FindTabByText("Education");
            eduTab.Enabled = false;
            RadMultiPage1.SelectedIndex = 0;
           
        }

        protected void btnEducationAdd(object sender, EventArgs e)
        {
            try
            {
                string id = string.IsNullOrEmpty((hndEduID.Value)) ? "0" : hndEduID.Value;
                string desc = CLOVA.AddUpdateEmployerEdu(Convert.ToInt32(id), Convert.ToInt32(hndID.Value), txtInstitute.Text,
                    Convert.ToInt32(cbDegree.SelectedValue), txtMajorSubjects.Text, ddlCompletionYear.Text, txtCity.Text, Convert.ToInt32(cbEduCountry.SelectedValue),
                    Convert.ToInt32(txtObtainMarks.Text), Convert.ToInt32(txtTotalMarks.Text), Convert.ToDouble(txtPercentage.Text),
                    Convert.ToInt32(hndUserID.Value), Convert.ToInt32(hndUserID.Value));
                if (desc.ToLower().Contains("success"))
                {
                    hndEduID.Value = txtInstitute.Text = txtMajorSubjects.Text = txtEduCity.Text = txtObtainMarks.Text =
                    txtTotalMarks.Text = txtPercentage.Text = string.Empty;
                    cbDegree.SelectedValue="0";
                    cbEduCountry.SelectedValue = "0";
                    ddlCompletionYear.ClearSelection();
                    ddlCompletionYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;
                    DataTable dt;
                    CLOVA.GetEmployerEducation(Convert.ToInt32(hndID.Value), out dt);
                    grdEducation.DataSource = dt;
                    grdEducation.DataBind();
                    EducationID.Disabled = false;
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
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnEducationAdd", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnExperience(object sender, EventArgs e)
        {
            hndExpID.Value = txtCompanyName.Text  = txtDescription.Text = txtLeavingReason.Text = string.Empty;
            cbCompanyType.SelectedValue = "0";
            cbRole.SelectedValue = "0";
            cbExperienceCountry.SelectedValue = "0";
            dtStartDate.Clear();
            dtEndDate.Clear();
            chkPresent.Checked = false;
            RadTab lanTab = RadTabStrip1.FindTabByText("Languages");
            lanTab.Enabled = true;
            lanTab.Selected = true;
            RadMultiPage1.SelectedIndex = 3;
            RadTab expTab = RadTabStrip1.FindTabByText("Experience");
            expTab.Enabled = false;
        }

        protected void btnExperienceBack(object sender, EventArgs e)
        {
            hndExpID.Value = txtCompanyName.Text = txtDescription.Text = txtLeavingReason.Text = string.Empty;
            cbCompanyType.SelectedValue = "0";
            cbRole.SelectedValue = "0";
            cbExperienceCountry.SelectedValue = "0";
            dtStartDate.Clear();
            dtEndDate.Clear();
            chkPresent.Checked = false;
            RadTab eduTab = RadTabStrip1.FindTabByText("Education");
            eduTab.Selected = true;
            eduTab.Enabled = true;
            RadTab expTab = RadTabStrip1.FindTabByText("Experience");
            expTab.Enabled = false;
            RadMultiPage1.SelectedIndex = 1;
        }

        protected void btnExperienceAdd(object sender, EventArgs e)
        {
            try
            {
                string id = string.IsNullOrEmpty((hndExpID.Value)) ? "0" : hndExpID.Value;
                string desc = CLOVA.AddUpdateEmployerExp(Convert.ToInt32(id), Convert.ToInt32(hndID.Value), txtCompanyName.Text,
                    Convert.ToInt32(cbCompanyType.SelectedValue), Convert.ToInt32(cbExperienceCountry.SelectedValue), Convert.ToInt32(cbRole.SelectedValue),
                    Convert.ToDateTime(dtStartDate.SelectedDate), Convert.ToDateTime(dtEndDate.SelectedDate),
                    Convert.ToInt32(chkPresent.Checked),txtDescription.Text, txtLeavingReason.Text,
                    Convert.ToInt32(hndUserID.Value), Convert.ToInt32(hndUserID.Value));
                if (desc.ToLower().Contains("success"))
                {
                    hndExpID.Value = txtCompanyName.Text = txtDescription.Text = txtLeavingReason.Text = string.Empty;
                    cbCompanyType.SelectedValue = "0";
                    cbRole.SelectedValue = "0";
                    cbExperienceCountry.SelectedValue = "0";
                    dtStartDate.Clear();
                    dtEndDate.Clear();
                    chkPresent.Checked = false;
                    txtLeavingReason.Text = string.Empty;
                    txtLeavingReason.Enabled = true;
                    dtEndDate.Enabled = true;
                    DataTable dt;
                    CLOVA.GetEmployerExperience(Convert.ToInt32(hndID.Value), out dt);
                    grdExperience.DataSource = dt;
                    grdExperience.DataBind();
                    ExperienceID.Disabled = false;
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
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnEducationAdd", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
           
        }

        protected void btnLanguages(object sender, EventArgs e)
        {
            hndLngID.Value = txtLanguage.Text = string.Empty;
            cbLanguageProficiency.SelectedValue = "0";
            RadTab sklTab = RadTabStrip1.FindTabByText("Skills");
            sklTab.Enabled = true;
            sklTab.Selected = true;
            RadMultiPage1.SelectedIndex = 4;
            RadTab lanTab = RadTabStrip1.FindTabByText("Languages");
            lanTab.Enabled = false;
        }

        protected void btnLanguagesBack(object sender, EventArgs e)
        {
            hndLngID.Value = txtLanguage.Text = string.Empty;
            cbLanguageProficiency.SelectedValue = "0";
            RadTab expTab = RadTabStrip1.FindTabByText("Experience");
            expTab.Selected = true;
            expTab.Enabled = true;
            RadTab lanTab = RadTabStrip1.FindTabByText("Languages");
            lanTab.Enabled = false;
            RadMultiPage1.SelectedIndex = 2;
        }

        protected void btnLanguagesAdd(object sender, EventArgs e)
        {
            try
            {
                string id = string.IsNullOrEmpty((hndLngID.Value)) ? "0" : hndLngID.Value;
                string desc = CLOVA.AddUpdateEmployerLng(Convert.ToInt32(id), Convert.ToInt32(hndID.Value), txtLanguage.Text,
                    Convert.ToInt32(cbLanguageProficiency.SelectedValue),Convert.ToInt32(hndUserID.Value), Convert.ToInt32(hndUserID.Value));
                if (desc.ToLower().Contains("success"))
                {
                    hndLngID.Value = txtLanguage.Text = string.Empty;
                    cbLanguageProficiency.SelectedValue = "0";
                    DataTable dt;
                    CLOVA.GetEmployerLanguage(Convert.ToInt32(hndID.Value), out dt);
                    grdLanguage.DataSource = dt;
                    grdLanguage.DataBind();
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
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnLanguagesAdd", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnSkills(object sender, EventArgs e)
        {
            hndSklID.Value = txtSkills.Text = string.Empty;
            cbSkillProficiency.SelectedValue = "0";
            RadTab refTab = RadTabStrip1.FindTabByText("References");
            refTab.Enabled = true;
            refTab.Selected = true;
            RadMultiPage1.SelectedIndex = 5;
            RadTab sklTab = RadTabStrip1.FindTabByText("Skills");
            sklTab.Enabled = false;
        }

        protected void btnSkillsBack(object sender, EventArgs e)
        {
            hndSklID.Value = txtSkills.Text = string.Empty;
            cbSkillProficiency.SelectedValue = "0";
            RadTab lanTab = RadTabStrip1.FindTabByText("Languages");
            lanTab.Selected = true;
            lanTab.Enabled = true;
            RadTab sklTab = RadTabStrip1.FindTabByText("Skills");
            sklTab.Enabled = false;
            RadMultiPage1.SelectedIndex = 3;
        }

        protected void btnSkillsAdd(object sender, EventArgs e)
        {
            try
            {
                string id = string.IsNullOrEmpty((hndSklID.Value)) ? "0" : hndSklID.Value;
                string desc = CLOVA.AddUpdateEmployerSkl(Convert.ToInt32(id), Convert.ToInt32(hndID.Value), txtSkills.Text,
                    Convert.ToInt32(cbSkillProficiency.SelectedValue), Convert.ToInt32(hndUserID.Value), Convert.ToInt32(hndUserID.Value));
                if (desc.ToLower().Contains("success"))
                {
                    hndSklID.Value = txtSkills.Text = string.Empty;
                    cbSkillProficiency.SelectedValue = "0";
                    DataTable dt;
                    CLOVA.GetEmployerSkills(Convert.ToInt32(hndID.Value), out dt);
                    grdSkills.DataSource = dt;
                    grdSkills.DataBind();
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
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnSkillsAdd", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnReferencesBack(object sender, EventArgs e)
        {
            hndRefID.Value = txtReferenceName.Text = txtReferenceJob.Text = txtReferenceCompany.Text = txtReferenceContact.Text =
            txtReferenceEmail.Text = string.Empty;
            RadTab sklTab = RadTabStrip1.FindTabByText("Skills");
            sklTab.Selected = true;
            sklTab.Enabled = true;
            RadTab refTab = RadTabStrip1.FindTabByText("References");
            refTab.Enabled = false;
            RadMultiPage1.SelectedIndex = 4;
        }

        protected void btnReferencesAdd(object sender, EventArgs e)
        {
            try
            {
                string id = string.IsNullOrEmpty((hndRefID.Value)) ? "0" : hndRefID.Value;
                string desc = CLOVA.AddUpdateEmployerRef(Convert.ToInt32(id), Convert.ToInt32(hndID.Value), txtReferenceName.Text,
                    txtReferenceJob.Text, txtReferenceCompany.Text, txtReferenceContact.Text, txtReferenceEmail.Text, Convert.ToInt32(hndUserID.Value), Convert.ToInt32(hndUserID.Value));
                if (desc.ToLower().Contains("success"))
                {
                    hndRefID.Value = txtReferenceName.Text = txtReferenceJob.Text = txtReferenceCompany.Text = txtReferenceContact.Text =
                    txtReferenceEmail.Text= string.Empty;
                    DataTable dt;
                    CLOVA.GetEmployerReferences(Convert.ToInt32(hndID.Value), out dt);
                    grdReferences.DataSource = dt;
                    grdReferences.DataBind();
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
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnSkillsAdd", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnSubmit(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/viewProfile.aspx");
            }
            catch (System.Threading.ThreadAbortException){}
            catch (Exception){}
        }

        protected void btnEduedit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdEducation.Rows[rowno].FindControl("hfEduID");
                hndEduID.Value = hfid.Value;
                cbDegree.SelectedValue = grdEducation.Rows[rowno].Cells[3].Text;
                txtInstitute.Text = grdEducation.Rows[rowno].Cells[5].Text;
                txtMajorSubjects.Text = grdEducation.Rows[rowno].Cells[6].Text;
                ddlCompletionYear.Text = grdEducation.Rows[rowno].Cells[7].Text;
                txtEduCity.Text = grdEducation.Rows[rowno].Cells[8].Text;
                cbEduCountry.SelectedValue = grdEducation.Rows[rowno].Cells[13].Text;
                txtObtainMarks.Text = grdEducation.Rows[rowno].Cells[10].Text;
                txtTotalMarks.Text = grdEducation.Rows[rowno].Cells[11].Text;
                txtPercentage.Text = grdEducation.Rows[rowno].Cells[12].Text;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnedit_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnEduDel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdEducation.Rows[rowno].FindControl("hfEduID");
                CLOVA.DeleteEmployerEducation(Convert.ToInt32(hfid.Value));
                DataTable dt;
                CLOVA.GetEmployerEducation(Convert.ToInt32(hndID.Value), out dt);
                grdEducation.DataSource = dt;
                grdEducation.DataBind();
                if(dt.Rows.Count>0)
                {
                    EducationID.Disabled = false;
                }
                else
                {
                    EducationID.Disabled = true;
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnEduDel_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnExpedit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdExperience.Rows[rowno].FindControl("hfExpID");
                hndExpID.Value = hfid.Value;
                txtCompanyName.Text = grdExperience.Rows[rowno].Cells[3].Text;
                cbCompanyType.SelectedValue = grdExperience.Rows[rowno].Cells[4].Text;
                cbRole.SelectedValue = grdExperience.Rows[rowno].Cells[6].Text;
                dtStartDate.SelectedDate = Convert.ToDateTime(grdExperience.Rows[rowno].Cells[8].Text);
                chkPresent.Checked = Convert.ToBoolean(grdExperience.Rows[rowno].Cells[10].Text);
                if(chkPresent.Checked)
                {
                    txtLeavingReason.Text = string.Empty;
                    dtEndDate.SelectedDate = null;
                    txtLeavingReason.Enabled = false;
                    dtEndDate.Enabled = false;
                }
                else
                {
                    dtEndDate.SelectedDate = Convert.ToDateTime(grdExperience.Rows[rowno].Cells[9].Text);
                    txtLeavingReason.Text = grdExperience.Rows[rowno].Cells[13].Text;
                }
                try
                {
                    dtEndDate.SelectedDate = Convert.ToDateTime(grdExperience.Rows[rowno].Cells[9].Text);
                }
                catch (Exception)
                {
                    dtEndDate.SelectedDate = null;
                }
                cbExperienceCountry.SelectedValue = grdExperience.Rows[rowno].Cells[14].Text;
                txtDescription.Text = grdExperience.Rows[rowno].Cells[12].Text;

            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnExpedit_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnExpDel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdExperience.Rows[rowno].FindControl("hfExpID");
                CLOVA.DeleteEmployerExperience(Convert.ToInt32(hfid.Value));
                DataTable dt;
                CLOVA.GetEmployerExperience(Convert.ToInt32(hndID.Value), out dt);
                grdExperience.DataSource = dt;
                grdExperience.DataBind();
                if (dt.Rows.Count > 0)
                {
                    ExperienceID.Disabled = false;
                }
                else
                {
                    ExperienceID.Disabled = true;
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnExpDel_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnLngedit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdLanguage.Rows[rowno].FindControl("hfLngID");
                hndLngID.Value = hfid.Value;
                txtLanguage.Text = grdLanguage.Rows[rowno].Cells[3].Text;
                cbLanguageProficiency.SelectedValue = grdLanguage.Rows[rowno].Cells[4].Text;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnLngedit_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnLngDel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdLanguage.Rows[rowno].FindControl("hfLngID");
                CLOVA.DeleteEmployerLanguage(Convert.ToInt32(hfid.Value));
                DataTable dt;
                CLOVA.GetEmployerLanguage(Convert.ToInt32(hndID.Value), out dt);
                grdLanguage.DataSource = dt;
                grdLanguage.DataBind();
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnLngDel_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnSkledit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdSkills.Rows[rowno].FindControl("hfSklID");
                hndSklID.Value = hfid.Value;
                txtSkills.Text = grdSkills.Rows[rowno].Cells[3].Text;
                cbSkillProficiency.SelectedValue = grdSkills.Rows[rowno].Cells[4].Text;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnSkledit_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnSklDel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdSkills.Rows[rowno].FindControl("hfSklID");
                CLOVA.DeleteEmployerSkills(Convert.ToInt32(hfid.Value));
                DataTable dt;
                CLOVA.GetEmployerSkills(Convert.ToInt32(hndID.Value), out dt);
                grdLanguage.DataSource = dt;
                grdLanguage.DataBind();
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnSklDel_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnRefedit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdReferences.Rows[rowno].FindControl("hfRefID");
                hndRefID.Value = hfid.Value;
                txtReferenceName.Text = grdReferences.Rows[rowno].Cells[3].Text;
                txtReferenceJob.Text = grdReferences.Rows[rowno].Cells[4].Text;
                txtReferenceCompany.Text = grdReferences.Rows[rowno].Cells[5].Text;
                txtReferenceContact.Text = grdReferences.Rows[rowno].Cells[6].Text;
                txtReferenceEmail.Text = grdReferences.Rows[rowno].Cells[7].Text;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnRefedit_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

        protected void btnRefDel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgedt = sender as ImageButton;
                int rowno = Convert.ToInt32(imgedt.Attributes["RowIndex"].ToString());
                HiddenField hfid = (HiddenField)grdReferences.Rows[rowno].FindControl("hfRefID");
                CLOVA.DeleteEmployerReferences(Convert.ToInt32(hfid.Value));
                DataTable dt;
                CLOVA.GetEmployerReferences(Convert.ToInt32(hndID.Value), out dt);
                grdReferences.DataSource = dt;
                grdReferences.DataBind();
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message, ex.StackTrace.ToString(), "btnRefDel_Click", "2030", Convert.ToInt32(Session["UserID"]).ToString(), "CreateProfile");
                Session["Error"] = "2030 - Other Vendor Software related Error on Server.";
            }
        }

    }
}
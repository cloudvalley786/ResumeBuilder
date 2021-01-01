<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="ResumeBuilder.CreateProfile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function validatePersonalInfo() {
            debugger;
            var txtFirstName = document.getElementById('ContentPlaceHolder1_txtFirstName').value;
            var txtFatherName = document.getElementById('ContentPlaceHolder1_txtFatherName').value;
            var cbMaritialStatus = document.getElementById('ContentPlaceHolder1_cbMaritialStatus').value;
            var cbEmployeesGender = document.getElementById('ContentPlaceHolder1_cbEmployeesGender').value;
            var ddlYear = document.getElementById('ContentPlaceHolder1_ddlYear').value;
            var ddlMonth = document.getElementById('ContentPlaceHolder1_ddlMonth').value;
            var ddlDay = document.getElementById('ContentPlaceHolder1_ddlDay').value;
            var txtEmail = document.getElementById('ContentPlaceHolder1_txtEmail').value;
            var txtMobile = document.getElementById('ContentPlaceHolder1_txtMobile').value;
            var txtCity = document.getElementById('ContentPlaceHolder1_txtCity').value;
            var txtCountry = document.getElementById('ContentPlaceHolder1_txtCountry').value;
            var txtPresentAddress = document.getElementById('ContentPlaceHolder1_txtPresentAddress').value;
            var txtPermanentAddress = document.getElementById('ContentPlaceHolder1_txtPermanentAddress').value; 
            var txtSpecilization = document.getElementById('ContentPlaceHolder1_txtSpecilization').value;
            var txtObjective = document.getElementById('ContentPlaceHolder1_txtObjective').value;
            if (txtFirstName == "" || txtFatherName == "" || cbMaritialStatus == "0" || cbEmployeesGender == "0" || ddlYear == "" || ddlMonth == "" || ddlDay == "" || txtEmail == "" || txtMobile == "" || txtCity == "" || txtCountry == "" || txtPresentAddress == "" || txtPermanentAddress == "" || txtSpecilization == "" || txtObjective =="") {
                document.getElementById('messageInfo').style.color = 'red';
                document.getElementById('messageInfo').innerHTML = 'Please fill all mandatory <b>(*)</b> fields!';
                return false;
            }
            else {
                return true;
            }
        }

        function validateEducation() {
            debugger;
            var cbDegree = document.getElementById('ContentPlaceHolder1_cbDegree').value;
            var txtInstitute = document.getElementById('ContentPlaceHolder1_txtInstitute').value;
            var txtMajorSubjects = document.getElementById('ContentPlaceHolder1_txtMajorSubjects').value;
            //var ddlCompletionYear = document.getElementById('ContentPlaceHolder1_ddlCompletionYear').value;
            var txtEduCity = document.getElementById('ContentPlaceHolder1_txtEduCity').value;
            var txtEduCountry = document.getElementById('ContentPlaceHolder1_txtEduCountry').value;
            var txtObtainMarks = document.getElementById('ContentPlaceHolder1_txtObtainMarks').value;
            var txtTotalMarks = document.getElementById('ContentPlaceHolder1_txtTotalMarks').value;
            var txtPercentage = document.getElementById('ContentPlaceHolder1_txtPercentage').value;
            if (txtInstitute == "" || txtInstitute == "" || cbDegree == "0" || txtEduCity == "" || txtEduCountry == "" || txtObtainMarks == "" || txtTotalMarks == "" || txtPercentage == "") {
                document.getElementById('messageEdu').style.color = 'red';
                document.getElementById('messageEdu').innerHTML = 'Please fill all mandatory <b>(*)</b> fields!';
                return false;
            }
            else {
                return true;
            }
        }

        function validateExperience() {
            debugger;
            var txtCompanyName = document.getElementById('ContentPlaceHolder1_txtCompanyName').value;
            var txtExperienceCountry = document.getElementById('ContentPlaceHolder1_txtExperienceCountry').value;
            var cbCompanyType = document.getElementById('ContentPlaceHolder1_cbCompanyType').value;
            var cbRole = document.getElementById('ContentPlaceHolder1_cbRole').value;
            var txtLeavingReason = document.getElementById('ContentPlaceHolder1_txtLeavingReason').value;
            var dtStartDate = $find("<%=dtStartDate.ClientID %>");
             var dtEndDate = $find("<%=dtEndDate.ClientID %>");

            if (txtCompanyName == "" || txtExperienceCountry == "" || cbCompanyType == "0" || cbRole == "0" || dtStartDate.get_dateInput().get_value() == "") {
                document.getElementById('messageExp').style.color = 'red';
                document.getElementById('messageExp').innerHTML = 'Please fill all mandatory <b>(*)</b> fields!';
                return false;
            }
            if (!(document.getElementById('ContentPlaceHolder1_chkPresent').checked) && (txtLeavingReason == "" || dtEndDate.get_dateInput().get_value() == "")) {
                document.getElementById('messageExp').style.color = 'red';
                document.getElementById('messageExp').innerHTML = 'Please fill all mandatory <b>(*)</b> fields!';
                return false;
            }
            else {
                return true;
            }
        }

        function validateLanguage() {
            debugger;
            var txtLanguage = document.getElementById('ContentPlaceHolder1_txtLanguage').value;
            var cbLanguageProficiency = document.getElementById('ContentPlaceHolder1_cbLanguageProficiency').value;
            if (txtLanguage == "" || cbLanguageProficiency == "0") {
                document.getElementById('messageLng').style.color = 'red';
                document.getElementById('messageLng').innerHTML = 'Please fill all mandatory <b>(*)</b> fields!';
                return false;
            }
            else {
                return true;
            }
        }

        function validateSkill() {
            debugger;
            var txtSkills = document.getElementById('ContentPlaceHolder1_txtSkills').value;
            var cbSkillProficiency = document.getElementById('ContentPlaceHolder1_cbSkillProficiency').value;
            if (txtSkills == "" || cbSkillProficiency == "0") {
                document.getElementById('messageSkl').style.color = 'red';
                document.getElementById('messageSkl').innerHTML = 'Please fill all mandatory <b>(*)</b> fields!';
                return false;
            }
            else {
                return true;
            }
        }

        function validateRefernce() {
            debugger;
            var txtReferenceName = document.getElementById('ContentPlaceHolder1_txtReferenceName').value;
            var txtReferenceJob = document.getElementById('ContentPlaceHolder1_txtReferenceJob').value;
            var txtReferenceCompany = document.getElementById('ContentPlaceHolder1_txtReferenceCompany').value;
            var txtReferenceEmail = document.getElementById('ContentPlaceHolder1_txtReferenceEmail').value;
            if (txtReferenceName == "" || txtReferenceJob == "" || txtReferenceCompany == "" || txtReferenceEmail == "") {
                document.getElementById('messageRef').style.color = 'red';
                document.getElementById('messageRef').innerHTML = 'Please fill all mandatory <b>(*)</b> fields!';
                return false;
            }
            else {
                return true;
            }
        }

        var calPer = function () {
            debugger;
            var txtObtainMarks = document.getElementById('ContentPlaceHolder1_txtObtainMarks').value;
            var txtTotalMarks = document.getElementById('ContentPlaceHolder1_txtTotalMarks').value;

            if (txtObtainMarks == "" || txtTotalMarks == "") { return }
            else { document.getElementById('ContentPlaceHolder1_txtPercentage').value = Math.round((txtObtainMarks / txtTotalMarks) * 100) }

        }
        function allowOnlyNumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function check() {
            debugger
            var datepicker = $find("<%=dtEndDate.ClientID %>");
            if (document.getElementById('ContentPlaceHolder1_chkPresent').checked) {
                $("#ContentPlaceHolder1_txtLeavingReason").attr("disabled", "disabled");
                datepicker.set_enabled(false);
                document.getElementById('ContentPlaceHolder1_txtLeavingReason').value = '';
                datepicker.set_selectedDate(null);
                $("#lblLR").hide();
                $("#lblED").hide();
            }
            else {
                $("#ContentPlaceHolder1_txtLeavingReason").removeAttr("disabled");
                datepicker.set_enabled(true);
                $("#lblLR").show();
                $("#lblED").show();
            }

        };

    </script>
    <style>
        body {
            width: 100%;
            margin: 5px;
        }

        .table-condensed tr th {
            border: 0px solid #0053a1;
            color: white;
            background-color: #0053a1;
            text-align:center;
        }

        .table-condensed, .table-condensed tr td {
            border: 0px solid #000;
        }

        tr:nth-child(even) {
            background: #f8f7ff
        }

        tr:nth-child(odd) {
            background: #fff;
        }
        .hiddencol { display: none; }
    </style>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="demo-container no-bg">
                <telerik:RadTabStrip RenderMode="Lightweight" runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Silk">
                    <Tabs>
                        <telerik:RadTab Text="Personal" Width="190px" PageViewID="Personal"></telerik:RadTab>
                        <telerik:RadTab Text="Education" Width="190px" PageViewID="Education" Enabled="false"></telerik:RadTab>
                        <telerik:RadTab Text="Experience" Width="190px" PageViewID="Experience" Enabled="false"></telerik:RadTab>
                        <telerik:RadTab Text="Languages" Width="190px" PageViewID="Languages" Enabled="false"></telerik:RadTab>
                        <telerik:RadTab Text="Skills" Width="190px" PageViewID="Skills" Enabled="false"></telerik:RadTab>
                        <telerik:RadTab Text="References" Width="190px" PageViewID="References" Enabled="false"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">
                    <telerik:RadPageView runat="server" ID="Personal">

                        <div class="container center">
                            <div class="col-lg-6 col-lg-offset-3">
                                <br />
                                <h2>Personal Information</h2>
                                <img src="Content/common/images/line.png" class="img-responsive center-block" alt="img" />
                            </div>
                            <!-- END OF DIV offset-3 -->
                        </div>
                        <!-- END OF DIV container center -->
                        <div class=" text-center">
                            <span id='messageInfo'></span>

                        </div>
                        <asp:HiddenField ID="hndID" runat="server" />
                        <asp:HiddenField ID="hndUserID" runat="server" />
                        <div class="box">

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    First Name:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Middle Name:
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtMiddleName" CssClass="form-control" placeholder="Middle Name"></asp:TextBox>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Last Name:
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                                </div>
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Arabic Name:
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtArabicName" CssClass="form-control" placeholder="Arabic Name"></asp:TextBox>
                                </div>


                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Father's Name:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtFatherName" CssClass="form-control" placeholder="Father Name"></asp:TextBox>
                                </div>

                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Gender:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="cbEmployeesGender" runat="server" Width="100%"></asp:DropDownList>
                                </div>

                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Maritial Status:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="cbMaritialStatus" runat="server" Width="100%"></asp:DropDownList>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Date of Birth:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlYear" runat="server" Width="25%" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlMonth" runat="server" Width="25%" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlDay" runat="server" Width="20%">
                                    </asp:DropDownList>


                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Email:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Mobile:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control" placeholder="Mobile"></asp:TextBox>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    City:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" placeholder="City"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Country:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtCountry" CssClass="form-control" placeholder="Country"></asp:TextBox>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Present Address:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtPresentAddress" CssClass="form-control" placeholder="Present Address"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Permanent Address:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtPermanentAddress" CssClass="form-control" placeholder="Permanent Address"></asp:TextBox>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                             <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Specilization:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtSpecilization" CssClass="form-control" placeholder="Specilization"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Objective:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtObjective" CssClass="form-control" placeholder="Objective"></asp:TextBox>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class=" text-center">
                                <button class="btn btn-success button text-center" runat="server"
                                    id="PersonalInfo" type="button" onserverclick="btnPersonalInfo" onclick="if (!validatePersonalInfo()) { return false;};" name="PersonalInfo">
                                    <i class="fa fa-save"></i>&nbsp;Save & Continue
                                </button>
                            </div>


                        </div>
                        <!-- END OF DIV box -->


                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="Education">

                        <div class="container center">
                            <div class="col-lg-6 col-lg-offset-3">
                                <br />
                                <h2>Education</h2>
                                <img src="Content/common/images/line.png" class="img-responsive center-block" alt="img" />
                            </div>
                            <!-- END OF DIV offset-3 -->
                        </div>
                        <!-- END OF DIV container center -->
                        <div class=" text-center">
                            <span id='messageEdu'></span>

                        </div>
                        <asp:HiddenField ID="hndEduID" runat="server" />
                        <div class="box">

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Degree:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="cbDegree" runat="server" Width="100%"></asp:DropDownList>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Institute:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtInstitute" CssClass="form-control" placeholder="Institute"></asp:TextBox>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Major Subjects:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtMajorSubjects" CssClass="form-control" placeholder="Major Subjects"></asp:TextBox>
                                </div>
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Completion Year:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlCompletionYear" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </div>


                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    City:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtEduCity" CssClass="form-control" placeholder="City"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Country:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtEduCountry" CssClass="form-control" placeholder="Country"></asp:TextBox>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Obtain Marks:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtObtainMarks" onkeyup='calPer();' CssClass="form-control" onkeypress="return allowOnlyNumber(event);" placeholder="Obtain Marks"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Total Marks:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtTotalMarks" onkeyup='calPer();' onkeypress="return allowOnlyNumber(event);" CssClass="form-control" placeholder="Total Marks"></asp:TextBox>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Percentage:
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtPercentage" Enabled="false" CssClass="form-control" placeholder="Percentage"></asp:TextBox>
                                </div>

                            </div>
                            <!-- END OF DIV row -->

                            <div class=" text-center">
                                <button class="btn btn-danger button text-center" runat="server"
                                    id="EducationBack" type="button" onserverclick="btnEducationBack" name="EducationBack">
                                    <i class="fa fa-angle-double-left"></i>&nbsp;Back
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="EducationAddID" type="button" onserverclick="btnEducationAdd" onclick="if (!validateEducation()) { return false;};" name="btnEducationAdd">
                                    <i class="fa fa-save"></i>&nbsp;Add
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="EducationID" type="button" onserverclick="btnEducation" name="EducationID">
                                    <i class="fa fa-angle-double-right"></i>&nbsp;Next
                                </button>
                            </div>
                            <div id="panel" class=" text-center">
                                        <asp:GridView ID="grdEducation"  runat="server" EmptyDataText="No records has been added." CssClass="table table-condensed" AutoGenerateColumns="false" ShowFooter="false">
                                            <Columns>
                                                 <asp:TemplateField  HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfEduID" Value='<%# Eval("ID") %>' runat="server" />
                                            <asp:ImageButton ID="btnEduedit" runat="server"
                                                src="Content/common/images/iBtnedit.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnEduedit_Click" />
                                             <asp:ImageButton ID="btnEduDel" runat="server"
                                                src="Content/common/images/iBtnDel.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnEduDel_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                <asp:BoundField DataField="EmployerID" HeaderText="EmployerID" Visible="false" />
                                                <asp:BoundField DataField="DegreeID" HeaderText="DegreeID" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                                                <asp:BoundField DataField="Degree" HeaderText="Degree" />
                                                <asp:BoundField DataField="Institute" HeaderText="Institute" />
                                                <asp:BoundField DataField="MajorSubjects" HeaderText="Subjects" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                                                <asp:BoundField DataField="CompletionYear" HeaderText="Completion Year" />
                                                <asp:BoundField DataField="City" HeaderText="City" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"/>
                                                <asp:BoundField DataField="Country" HeaderText="Country" />
                                                <asp:BoundField DataField="ObtainMarks" HeaderText="Obtained Marks" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                                                <asp:BoundField DataField="TotalMarks" HeaderText="Total Marks"  ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"/>
                                                <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                                            </Columns>
                                        </asp:GridView>
                            </div>


                        </div>
                        <!-- END OF DIV box -->









                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="Experience">
                        <div class="container center">
                            <div class="col-lg-6 col-lg-offset-3">
                                <br />
                                <h2>Experience</h2>
                                <img src="Content/common/images/line.png" class="img-responsive center-block" alt="img" />
                            </div>
                            <!-- END OF DIV offset-3 -->
                        </div>
                        <!-- END OF DIV container center -->
                        <div class=" text-center">
                            <span id='messageExp'></span>

                        </div>
                        <asp:HiddenField ID="hndExpID" runat="server" />
                        <div class="box">
                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Company Name:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                                </div>

                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Country:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtExperienceCountry" CssClass="form-control" placeholder="Country"></asp:TextBox>
                                </div>


                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">

                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Company Industry:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="cbCompanyType" runat="server" Width="100%"></asp:DropDownList>
                                </div>

                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Role:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="cbRole" runat="server" Width="100%"></asp:DropDownList>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Present:
                                </label>
                                <div class="col-sm-4">
                                    <asp:CheckBox ID="chkPresent" runat="server" Text="" onclick="check()" />
                                </div>

                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Leaving Reason:<font face="Arial"><span class="style1" id="lblLR">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtLeavingReason" CssClass="form-control" placeholder="Leaving Reason"></asp:TextBox>
                                </div>

                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Start Date:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <telerik:RadDatePicker ID="dtStartDate" Width="100%" runat="server" Culture="en-US" WrapperTableCaption="" DateInput-MinDate="1/1/1950 12:00:00 AM" MinDate="1/1/1950 12:00:00 AM" DateInput-DateFormat="dd/MMM/yyyy" DateInput-DisplayDateFormat="dd/MMM/yyyy">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" EnableKeyboardNavigation="True"></Calendar>
                                        <DateInput DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MMM/yyyy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                            <FocusedStyle Resize="None"></FocusedStyle>
                                            <DisabledStyle Resize="None"></DisabledStyle>
                                            <InvalidStyle Resize="None"></InvalidStyle>
                                            <HoveredStyle Resize="None"></HoveredStyle>
                                            <EnabledStyle Resize="None"></EnabledStyle>
                                        </DateInput>
                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>

                                </div>
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    End Date:<font face="Arial"><span class="style1" id="lblED">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <telerik:RadDatePicker ID="dtEndDate" Width="100%" runat="server" Culture="en-US" WrapperTableCaption="" DateInput-MinDate="1/1/1950 12:00:00 AM" MinDate="1/1/1950 12:00:00 AM" DateInput-DateFormat="dd/MMM/yyyy" DateInput-DisplayDateFormat="dd/MMM/yyyy">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" EnableKeyboardNavigation="True"></Calendar>
                                        <DateInput DisplayDateFormat="dd/MMM/yyyy" DateFormat="dd/MMM/yyyy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                            <FocusedStyle Resize="None"></FocusedStyle>
                                            <DisabledStyle Resize="None"></DisabledStyle>
                                            <InvalidStyle Resize="None"></InvalidStyle>
                                            <HoveredStyle Resize="None"></HoveredStyle>
                                            <EnabledStyle Resize="None"></EnabledStyle>
                                        </DateInput>
                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                </div>

                            </div>


                            <!-- END OF DIV row -->



                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Description:
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="3" Columns="5" CssClass="form-control" placeholder="Description"></asp:TextBox>
                                </div>

                            </div>
                            <!-- END OF DIV row -->

                            <div class=" text-center">
                                <button class="btn btn-danger button text-center" runat="server"
                                    id="ExperienceBack" type="button" onserverclick="btnExperienceBack" name="ExperienceBack">
                                    <i class="fa fa-angle-double-left"></i>&nbsp;Back
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="ExperienceAddID" type="button" onserverclick="btnExperienceAdd" onclick="if (!validateExperience()) { return false;};" name="btnExperienceAdd">
                                    <i class="fa fa-save"></i>&nbsp;Add
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="ExperienceID" type="button" onserverclick="btnExperience" name="btnExperience">
                                    <i class="fa fa-angle-double-right"></i>&nbsp;Next
                                </button>
                            </div>

                        <div id="panel" class="text-center">
                                        <asp:GridView ID="grdExperience" runat="server" EmptyDataText="No records has been added." CssClass="table table-condensed" AutoGenerateColumns="false" ShowFooter="false">
                                            <Columns>
                                                 <asp:TemplateField  HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfExpID" Value='<%# Eval("ID") %>' runat="server" />
                                            <asp:ImageButton ID="btnExpedit" runat="server"
                                                src="Content/common/images/iBtnedit.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnExpedit_Click" />
                                             <asp:ImageButton ID="btnExpDel" runat="server"
                                                src="Content/common/images/iBtnDel.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnExpDel_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                <asp:BoundField DataField="EmployerID" HeaderText="EmployerID" Visible="false" />
                                                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                                                <asp:BoundField DataField="CompanyTypeID" HeaderText="CompanyTypeID" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                                                <asp:BoundField DataField="CompanyType" HeaderText="CompanyType" />
                                                <asp:BoundField DataField="JobRoleID" HeaderText="JobRoleID" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                                                <asp:BoundField DataField="JobRole" HeaderText="Designation" />
                                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                                                <asp:BoundField DataField="EndDate" HeaderText="End Date" />
                                                <asp:BoundField DataField="Present" HeaderText="Present" />
                                                <asp:BoundField DataField="Country" HeaderText="Country" />
                                                <asp:BoundField DataField="WorkDescription" HeaderText="WorkDescription" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                                                <asp:BoundField DataField="LeavingReason" HeaderText="Leaving Reason" />
                     
                                            </Columns>
                                        </asp:GridView>
                            </div>

                        </div>
                        <!-- END OF DIV box -->
                    </telerik:RadPageView>

                    <telerik:RadPageView runat="server" ID="Languages">
                        <div class="container center">
                            <div class="col-lg-6 col-lg-offset-3">
                                <br />
                                <h2>Languages</h2>
                                <img src="Content/common/images/line.png" class="img-responsive center-block" alt="img" />
                            </div>
                            <!-- END OF DIV offset-3 -->
                        </div>
                        <!-- END OF DIV container center -->

                        <div class=" text-center">
                            <span id='messageLng'></span>

                        </div>
                        <asp:HiddenField ID="hndLngID" runat="server" />
                        <div class="box">
                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Language:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtLanguage" CssClass="form-control" placeholder="Language"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Proficiency:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="cbLanguageProficiency" runat="server" Width="100%"></asp:DropDownList>
                                </div>

                            </div>
                            <!-- END OF DIV row -->

                            <div class=" text-center">
                                <button class="btn btn-danger button text-center" runat="server"
                                    id="LanguagesBackID" type="button" onserverclick="btnLanguagesBack" name="LanguagesBack">
                                    <i class="fa fa-angle-double-left"></i>&nbsp;Back
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="LanguagesAddID" type="button" onserverclick="btnLanguagesAdd" onclick="if (!validateLanguage()) { return false;};" name="btnLanguagesAdd">
                                    <i class="fa fa-save"></i>&nbsp;Add
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="LanguagesID" type="button" onserverclick="btnLanguages" name="btnLanguages">
                                    <i class="fa fa-angle-double-right"></i>&nbsp;Next
                                </button>
                            </div>

                                <div id="panel" class=" text-center">
                                        <asp:GridView ID="grdLanguage" runat="server" EmptyDataText="No records has been added." CssClass="table table-condensed" AutoGenerateColumns="false" ShowFooter="false">
                                            <Columns>
                                                 <asp:TemplateField  HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfLngID" Value='<%# Eval("ID") %>' runat="server" />
                                            <asp:ImageButton ID="btnLngedit" runat="server"
                                                src="Content/common/images/iBtnedit.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnLngedit_Click" />
                                             <asp:ImageButton ID="btnLngDel" runat="server"
                                                src="Content/common/images/iBtnDel.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnLngDel_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                <asp:BoundField DataField="EmployerID" HeaderText="EmployerID" Visible="false" />
                                                <asp:BoundField DataField="Language" HeaderText="Language" />
                                                <asp:BoundField DataField="ProficiencyID" HeaderText="ProficiencyID" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                                                <asp:BoundField DataField="Proficiency" HeaderText="Proficiency" />
                                            </Columns>
                                        </asp:GridView>
                            </div>

                        </div>
                        <!-- END OF DIV box -->
                    </telerik:RadPageView>

                    <telerik:RadPageView runat="server" ID="Skills">
                        <div class="container center">
                            <div class="col-lg-6 col-lg-offset-3">
                                <br />
                                <h2>Skills</h2>
                                <img src="Content/common/images/line.png" class="img-responsive center-block" alt="img" />
                            </div>
                            <!-- END OF DIV offset-3 -->
                        </div>
                        <!-- END OF DIV container center -->
                        <div class=" text-center">
                            <span id='messageSkl'></span>

                        </div>
                        <asp:HiddenField ID="hndSklID" runat="server" />
                        <div class="box">
                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Skill:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtSkills" CssClass="form-control" placeholder="Skills"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Proficiency:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="cbSkillProficiency" runat="server" Width="100%"></asp:DropDownList>
                                </div>

                            </div>
                            <!-- END OF DIV row -->

                            <div class=" text-center">
                                <button class="btn btn-danger button text-center" runat="server"
                                    id="SkillsBackID" type="button" onserverclick="btnSkillsBack" name="SkillsBack">
                                    <i class="fa fa-angle-double-left"></i>&nbsp;Back
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="SkillsAddID" type="button" onserverclick="btnSkillsAdd" onclick="if (!validateSkill()) { return false;};" name="btnSkillsAdd">
                                    <i class="fa fa-save"></i>&nbsp;Add
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="SkillsID" type="button" onserverclick="btnSkills" name="btnSkills">
                                    <i class="fa fa-angle-double-right"></i>&nbsp;Next
                                </button>
                            </div>

                             <div id="panel" class=" text-center">
                                        <asp:GridView ID="grdSkills" runat="server" EmptyDataText="No records has been added." CssClass="table table-condensed" AutoGenerateColumns="false" ShowFooter="false">
                                            <Columns>
                                                 <asp:TemplateField  HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfSklID" Value='<%# Eval("ID") %>' runat="server" />
                                            <asp:ImageButton ID="btnSkledit" runat="server"
                                                src="Content/common/images/iBtnedit.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnSkledit_Click" />
                                             <asp:ImageButton ID="btnSklDel" runat="server"
                                                src="Content/common/images/iBtnDel.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnSklDel_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                <asp:BoundField DataField="EmployerID" HeaderText="EmployerID" Visible="false" />
                                                <asp:BoundField DataField="Skill" HeaderText="Skill" />
                                                <asp:BoundField DataField="ProficiencyID" HeaderText="ProficiencyID" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                                                <asp:BoundField DataField="Proficiency" HeaderText="Proficiency" />
                                            </Columns>
                                        </asp:GridView>
                            </div>

                        </div>
                        <!-- END OF DIV box -->
                    </telerik:RadPageView>

                    <telerik:RadPageView runat="server" ID="References">
                        <div class="container center">
                            <div class="col-lg-6 col-lg-offset-3">
                                <br />
                                <h2>References</h2>
                                <img src="Content/common/images/line.png" class="img-responsive center-block" alt="img" />
                            </div>
                            <!-- END OF DIV offset-3 -->
                        </div>
                        <!-- END OF DIV container center -->
                        <div class=" text-center">
                            <span id='messageRef'></span>

                        </div>
                        <asp:HiddenField ID="hndRefID" runat="server" />
                        <div class="box">
                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Reference Name:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtReferenceName" CssClass="form-control" placeholder="Reference Name"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Job Title:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtReferenceJob" CssClass="form-control" placeholder="Job Title"></asp:TextBox>
                                </div>

                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Company Name:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtReferenceCompany" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                                </div>


                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Contact No.:
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtReferenceContact" CssClass="form-control" placeholder="Contact Number"></asp:TextBox>
                                </div>

                            </div>
                            <!-- END OF DIV row -->

                            <div class="form-group row">
                                <label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
                                    Email:<font face="Arial"><span class="style1">*</span></font>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="txtReferenceEmail" CssClass="form-control" placeholder="Reference"></asp:TextBox>
                                </div>
                            </div>
                            <!-- END OF DIV row -->

                            <div class=" text-center">
                                <button class="btn btn-danger button text-center" runat="server"
                                    id="ReferencesBackID" type="button" onserverclick="btnReferencesBack" name="ReferencesBack">
                                    <i class="fa fa-angle-double-left"></i>&nbsp;Back
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="ReferencesAdd" type="button" onserverclick="btnReferencesAdd" onclick="if (!validateRefernce()) { return false;};" name="btnReferencesAdd">
                                    <i class="fa fa-save"></i>&nbsp;Add
                                </button>
                                <button class="btn btn-success button text-center" runat="server"
                                    id="SubmitID" type="button" onserverclick="btnSubmit" name="btnSubmit">
                                    <i class="fa fa-angle-double-right"></i>&nbsp;Finish
                                </button>
                            </div>

                        <div id="panel" class=" text-center">
                                        <asp:GridView ID="grdReferences" runat="server" EmptyDataText="No records has been added." CssClass="table table-condensed" AutoGenerateColumns="false" ShowFooter="false">
                                            <Columns>
                                                 <asp:TemplateField  HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfRefID" Value='<%# Eval("ID") %>' runat="server" />
                                            <asp:ImageButton ID="btnRefedit" runat="server"
                                                src="Content/common/images/iBtnedit.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnRefedit_Click" />
                                             <asp:ImageButton ID="btnRefDel" runat="server"
                                                src="Content/common/images/iBtnDel.png" Height="20px" RowIndex='<%# Container.DisplayIndex %>' OnClick="btnRefDel_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                <asp:BoundField DataField="EmployerID" HeaderText="EmployerID" Visible="false" />
                                                <asp:BoundField DataField="RefName" HeaderText="Reference Name" />
                                                <asp:BoundField DataField="JobTitle" HeaderText="Designation" />
                                                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                                                <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                            </Columns>
                                        </asp:GridView>
                            </div>

                        </div>
                        <!-- END OF DIV box -->
                    </telerik:RadPageView>

                </telerik:RadMultiPage>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

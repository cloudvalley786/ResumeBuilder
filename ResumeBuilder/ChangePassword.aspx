<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ResumeBuilder.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        var check = function () {
            debugger;
            var txtNewPass = document.getElementById('ContentPlaceHolder1_txtNewPassword').value;
			var txtConfirmPassword = document.getElementById('ContentPlaceHolder1_txtConfirmPassword').value;
            if (txtNewPass === "") {
                document.getElementById('newPassMsg').style.color = 'red';
                document.getElementById('newPassMsg').innerHTML = 'Confirm Password field cannot be empty.';
                return;
            }
            
			if (!txtNewPass.match(/((?=.*\d)(?=.*[a-zA-Z])(?=.*\W).{8,8})/)) {
				document.getElementById('newPassMsg').style.color = 'red';
				document.getElementById('newPassMsg').innerHTML = 'Password should at least 8 character, at least one special character, one upper case and one digit.';
				return;
			}
			else
			{
                document.getElementById('newPassMsg').innerHTML = '';
            }
			if (txtConfirmPassword === "") {
                document.getElementById('confirmPassMsg').style.color = 'red';
                document.getElementById('confirmPassMsg').innerHTML = 'Confirm Password field cannot be empty.';
                return;
            }
            if (!txtConfirmPassword.match(/((?=.*\d)(?=.*[a-zA-Z])(?=.*\W).{8,8})/)) {
                document.getElementById('confirmPassMsg').style.color = 'red';
                document.getElementById('confirmPassMsg').innerHTML = 'Password should at least 8 character, at least one special character, one upper case and one digit.';
                return;
			}
			else {
                document.getElementById('confirmPassMsg').innerHTML = '';
            }
            if (txtNewPass != txtConfirmPassword) {
                document.getElementById('confirmPassMsg').style.color = 'red';
                document.getElementById('confirmPassMsg').innerHTML = 'The New password and its confirm password are not the same.';
				return;
			}
            if (txtNewPass == txtConfirmPassword) {
                document.getElementById('newPassMsg').innerHTML = '';
				document.getElementById('confirmPassMsg').innerHTML = '';
				return true;
            }
        }
</script>
       <div class="container center">
						<div class="col-lg-6 col-lg-offset-3">
                            <br />
							<h2>Change Password</h2>
							<img src="Content/common/images/line.png" class="img-responsive center-block" alt="img" />
						</div> <!-- END OF DIV offset-3 -->
					</div> <!-- END OF DIV container center -->
					
						
								<div class="box">
									<div class="form-group row">
										<label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
											 Current Password:<font face="Arial"><span class="style1">*</span></font>
											</label>
											<div class="col-sm-4">
												<asp:TextBox runat="server"  TextMode="Password" ID="txtCurPassword" CssClass="form-control" placeholder="Current Password"></asp:TextBox>
											<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCurPassword" ForeColor="Red" ValidationGroup="vRegister"  ErrorMessage="Current Password field cannot be empty."></asp:RequiredFieldValidator>
											</div>

										
											
										</div> <!-- END OF DIV row -->

									<div class="form-group row">
										<label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
												New Password:<font face="Arial"><span class="style1">*</span></font>
											</label>
											<div class="col-sm-4">
												<asp:TextBox runat="server" TextMode="Password" ID="txtNewPassword" CssClass="form-control" onkeyup='check();' placeholder="New Password"></asp:TextBox>
                                                <span id='newPassMsg'></span></div>
										

										
											<label for="smFormGroupInput" class="col-sm-2 col-form-label col-form-label-sm">
												Confirm Password:<font face="Arial"><span class="style1">*</span></font>
											</label>
											<div class="col-sm-4">
												<asp:TextBox runat="server" TextMode="Password" ID="txtConfirmPassword" CssClass="form-control" onkeyup='check();' placeholder="Confirm Password"></asp:TextBox>
                                                 <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword" Display="Dynamic" ForeColor="Red" ValidationGroup="vRegister"  ErrorMessage="Confirm Password field cannot be empty."></asp:RequiredFieldValidator>--%>
                                                <span id='confirmPassMsg'></span>
											</div>
										
										</div> <!-- END OF DIV row -->

									<div class=" text-center">
                                        <asp:Button ID="btnChangePass" class="btn btn-success button text-center" ValidationGroup="vRegister" OnClientClick="if (!check()) { return false;};" OnClick="btnChangePass_Click" runat="server" Text="Submit" />
										
										</div>
										

								</div> <!-- END OF DIV box -->

</asp:Content>

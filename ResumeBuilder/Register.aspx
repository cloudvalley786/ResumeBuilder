<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ResumeBuilder.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Sign Up</title>

    <!-- Font Icon -->
    <link href="Content/common/css/material-design-iconic-font.min.css" rel="stylesheet" />
    
    <!-- Main css -->
     <link href="Content/common/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/common/css/style.css" rel="stylesheet" />
    <link href="Content/common/css/toastr.min.css" rel="stylesheet" />
      <script language="javascript" type="text/javascript">
          window.history.forward(-1);
        var check = function () {
            debugger;
            var txtPassword = document.getElementById('txtPassword').value;
            var txtConfirmPassword = document.getElementById('txtConfirmPassword').value;
            if (txtConfirmPassword === "")
            {
                document.getElementById('message').style.color = 'red';
                document.getElementById('message').innerHTML = 'Confirm Password field cannot be empty.';
                $('#lockicon').css({ 'margin-bottom': '29px' });
                return;
            }
            if (txtPassword != txtConfirmPassword) {
                document.getElementById('message').style.color = 'red';
                document.getElementById('message').innerHTML = 'Password and its confirm password are not the same.';
                $('#lockicon').css({ 'margin-bottom': '29px' });
            }
            if (txtPassword == txtConfirmPassword) {
                document.getElementById('message').innerHTML = '';
                $('#lockicon').css({ 'margin-bottom': '0px' });
            }
        }
</script>
</head>
  <body>
       <div class="main">

       <!-- Sign up form -->
        <section class="signup">
            <div class="container">
                <div class="signup-content">
                    <div class="signup-form">
                        <h2 class="form-title">Register</h2>
                        <form runat="server">
                            <div class="form-group">
                                <label for="name"><i class="zmdi zmdi-account material-icons-name" style="margin-bottom:25px"></i></label>
                                <asp:TextBox ID="txtName" runat="server" placeholder="Your Name"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ForeColor="Red" ValidationGroup="vRegister"  ErrorMessage="Name field cannot be empty."></asp:RequiredFieldValidator>
                            
                            </div>
                            <div class="form-group">
                                <label for="email"><i class="zmdi zmdi-email" style="margin-bottom:25px"></i></label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Your Email"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="vRegister"  ErrorMessage="Email field cannot be empty."></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="phone"><i class="zmdi zmdi-phone" style="margin-bottom:25px"></i></label>
                                <asp:TextBox ID="txtContact" runat="server" placeholder="Your Contact No"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtContact" ForeColor="Red" ValidationGroup="vRegister"  ErrorMessage="Contact No field cannot be empty."></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="pass"><i class="zmdi zmdi-lock" style="margin-bottom:25px"></i></label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" onkeyup='check();' placeholder="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="vRegister"  ErrorMessage="Password field cannot be empty."></asp:RequiredFieldValidator>
                            
                            </div>
                            <div class="form-group">
                                <label for="re-pass"><i class="zmdi zmdi-lock-outline" id="lockicon"></i></label>
                                 <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" onkeyup='check();' placeholder="Repeat your password"></asp:TextBox>
                                <span id='message'></span>
                            </div>
                            <div class="form-group form-button">
                                <asp:Button ID="btnRegister" class="btn btn-primary button text-center" ValidationGroup="vRegister" OnClientClick="check();" OnClick="btnRegister_Click" runat="server" Text="Register" />
                            </div>
                            
                        </form> <div class="form-group">
                                 <p class="text-center"><a href="Login.aspx" id="signin">Already have an account?</a></p>
                              </div>
                    </div>
                    <div class="signup-image">
                        <figure><img src="Content/common/images/signup-image.jpg" alt="sing up image"></figure>
                    </div>
                </div>
            </div>
        </section>

    </div>

    <!-- JS -->
      <script src="Content/common/js/jquery.min.js"></script>
      <script src="Content/common/js/main.js"></script>
      <script src="Content/common/javascripts/toastr.min.js"></script>
       <%
           if (Session["Error"] != null)
           {
               Response.Write("<script> toastr.error('" + Session["Error"] + "')</script>");
               Session["Error"] = null;
           }
           if (Session["Success"] != null)
           {
               Response.Write("<script> toastr.success('" + Session["Success"] + "')</script>");
               Session["Success"] = null;
           }
    %>


    <script type="text/javascript">
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": false,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "showDuration": "3000",
            "hideDuration": "1000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    </script>
</body>
</html>


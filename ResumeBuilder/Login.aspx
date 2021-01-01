<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ResumeBuilder.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Login</title>

    <!-- Font Icon -->
    <link href="Content/common/css/material-design-iconic-font.min.css" rel="stylesheet" />

    <!-- Main css -->
    <link href="Content/common/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/common/css/style.css" rel="stylesheet" />
    <link href="Content/common/css/toastr.min.css" rel="stylesheet" />
</head>
  <body>
       <div class="main">

        <!-- Sing in  Form -->
        <section class="sign-in">
            <div class="container">
                <div class="signin-content">
                    <div class="signin-image">
                        
                        <figure><img src="Content/common/images/signin-image.jpg" alt="sing up image"></figure>
                        
                    </div>

                    <div class="signin-form">
                        <h2 class="form-title">Login</h2>
                        <form  runat="server">
                            <div class="form-group">
                                <label for="your_name"><i class="zmdi zmdi-email" style="margin-bottom:25px"></i></label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="vLogin"  ErrorMessage="Email field cannot be empty."></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="your_pass"><i class="zmdi zmdi-lock" style="margin-bottom:25px"></i></label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="vLogin"  ErrorMessage="Password field cannot be empty."></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group form-button">
                                <asp:Button ID="btnLogin" class="btn btn-primary button text-center" ValidationGroup="vLogin" OnClick="btnLogin_Click" runat="server" Text="Login" />
										
                            </div>
                        </form>
                        <div class="form-group">
                            <p class="text-center"><a href="ForgetPassword.aspx" id="forget">Forgot Password?</a></p>
                            <p class="text-center">Don't have account? <a href="Register.aspx" id="signup">Sign up here</a></p>
                        </div>
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
        window.history.forward(-1);
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

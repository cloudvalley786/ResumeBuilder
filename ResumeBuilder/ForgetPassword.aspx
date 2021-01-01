<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="ResumeBuilder.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Account Recovery</title>

    <!-- Font Icon -->
    <link href="Content/common/css/material-design-iconic-font.min.css" rel="stylesheet" />
    
    <!-- Main css -->
     <link href="Content/common/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/common/css/style.css" rel="stylesheet" />
    <link href="Content/common/css/toastr.min.css" rel="stylesheet" />
      
</head>
  <body>
       <div class="main">

       <!-- Account Recovery form -->
        <section class="sign-in">
            <div class="container">
                <div class="signin-content">
                     <div class="signin-image">
                        
                        <figure><img src="Content/common/images/signin-image.jpg" alt="sing up image"></figure>
                        
                    </div>
                    <div class="signin-form"  style="margin-top:70px">
                        <h2 class="form-title">Account Recovery</h2>
                        <form runat="server">

                            <div class="form-group">
                                <label for="email"><i class="zmdi zmdi-email" style="margin-bottom:25px"></i></label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Your Email"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ForeColor="Red" ValidationGroup="vForget"  ErrorMessage="Email field cannot be empty."></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group form-button">
                                <asp:Button ID="btnForget" class="btn btn-primary button text-center" ValidationGroup="vForget" OnClick="btnForget_Click" runat="server" Text="Submit" />
                            </div>
                            
                        </form> <div class="form-group">
                                 <p class="text-center"><a href="Login.aspx" id="signin">Login?</a></p>
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


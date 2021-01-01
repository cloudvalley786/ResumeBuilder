<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="ResumeBuilder.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/common/css/blue.css" rel="stylesheet" />
    <script src="Content/common/js/html2canvas.min.js"></script>
    <script src="Content/common/js/jspdf.min.js"></script>
    <script src="Content/common/js/jquery.blockUI.js"></script>
   <style>
        .page-loader-wrapper {
            position: absolute !important;
            left: 48.7% !important;
            top: 50% !important;
            z-index: 9999 !important;
            display: none;
        }

        .overlay {
            position: absolute;
            left: 0px;
            top: 0px;
            z-index: 3000;
            background-color: rgb(170, 170, 170);
            opacity: 0.5;
            width: 100%;
            height: 968px;
        }
    </style>

    <script>
        function savePDFSample() {
            //debugger
            //$.blockUI({ message: '<img id="imgloader" class="imgClass" src="data:image/gif;base64,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" />' });
           
            $('#<%=pdfDiv.ClientID %>').hide();
            var element = document.getElementById("wrapper");
            //debugger;
            var hgt = element.clientHeight;
            var wdth = element.clientWidth;
            html2canvas(element, { scale: 2,allowTaint: true, letterRendering: true }).then(function (canvas) {
                var img = canvas.toDataURL("image/png");
                var pdf = new jsPDF('1', 'pt');
                var width = pdf.internal.pageSize.getWidth();
                var height = pdf.internal.pageSize.height;
                pdf.addImage(img, 'jpeg', 20, height * 0.01, width * 0.92, width);
                pdf.save("Resume.pdf");
            })
            $('#<%=pdfDiv.ClientID %>').show();
           // $.unblockUI();
        }

        function PrintPanel() {
            var printWindow = window.open('', '', 'height=512,width=512');
            $('#<%=pdfDiv.ClientID %>').hide();
            printWindow.document.write('<link rel="stylesheet" href="../Content/common/css/blue.css">');

            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write();
            printWindow.document.write($('#wrapper')[0].innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            $('#<%=pdfDiv.ClientID %>').show();
            setTimeout(function () {
                printWindow.print();
            },
                500);
            return false;
        }

    </script>
   <asp:HiddenField ID="hndID" runat="server" />
   <asp:HiddenField ID="hndUserID" runat="server" />
    <%--<link href="Content/common/css/print.css" rel="stylesheet" />--%>
    <div id="wrapper">
  <div class="wrapper-top"></div>
  <div class="wrapper-mid">
    <!-- Begin Paper -->
    <div id="paper">
      <div class="paper-top"></div>
      <div id="paper-mid">
        <div class="entry">
          <!-- Begin Image -->
          <asp:Image class="portrait" id="ProfileImg" runat="server" alt="" />
          <!-- End Image -->
          <!-- Begin Personal Information -->
          <div class="self">
            <h1 class="name"><span id="lblName" runat="server"></span></h1>
              <span id="lblSpecilization" style="color:#1b4491;font-size:12px;" runat="server"></span>
            <ul>
              <li class="ad"><span id="lblAddress" runat="server"></span></li>
              <li class="mail"><span id="lblEmail" runat="server"></span></li>
              <li class="tel"><span id="lblContactNo" runat="server"></span></li>
              <%--<li class="web">www.businessweb.com</li>--%>
            </ul>
          </div>
          <!-- End Personal Information -->
          <!-- Begin Social -->
          <div class="social" id="pdfDiv" runat="server">
            <ul>
              <li><a class='north' href="#" onclick="PrintPanel();" title="Print"><img src="Content/common/images/icn-print.jpg" alt="" /></a></li>
            <%--<li><a class='north' href="#" onclick="savePDFSample();" title="Resume.pdf"><img src="Content/common/images/icn-save.jpg" alt="Download the pdf version" /></a></li>--%>
            </ul>
          </div>
          <!-- End Social -->
        </div>
        <!-- Begin 1st Row -->
        <div class="entry">
          <h2>OBJECTIVE</h2>
          <p><span id="lblObjective" runat="server"></span></p>
        </div>
        <!-- End 1st Row -->
        <!-- Begin 2nd Row -->
        <div class="entry">
          <h2>EDUCATION</h2>
          <asp:Label ID="lblEducation" runat="server"></asp:Label>
        </div>
        <!-- End 2nd Row -->
        <!-- Begin 3rd Row -->
        <div class="entry">
          <h2>EXPERIENCE</h2>
          <div class="content">
            <asp:Label ID="lblExperience" runat="server"></asp:Label>
          </div>
          
        </div>
        <!-- End 3rd Row -->
        <!-- Begin 4th Row -->
          <div class="entry">
          <h2>LANGUAGES</h2>
          <div class="content">
              <asp:Label ID="lblLanguages" runat="server"></asp:Label>
          </div>
        </div>
        <div class="entry">
          <h2>SKILLS</h2>
          <div class="content">
              <asp:Label ID="lblSkills" runat="server"></asp:Label>
          </div>
        </div>
        <!-- End 4th Row -->
          <div class="entry">
          <h2>REFERENCES</h2>
              <asp:Label ID="lblReferences" runat="server"></asp:Label>
          
        </div>
      </div>
      <div class="clear"></div>
      <div class="paper-bottom"></div>
    </div>
    <!-- End Paper -->
  </div>
  <div class="wrapper-bottom"></div>
</div>
<div id="message"><a href="#top" id="top-link">Go to Top</a></div>
<!-- End Wrapper -->
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="ResumeBuilder.Jobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
 <div id="panel" class=" text-center">
                                        <asp:GridView ID="grdJobs"  runat="server" OnRowDataBound="grdJobs_RowDataBound" EmptyDataText="No records has been added." CssClass="table table-condensed" AutoGenerateColumns="false" ShowFooter="false">
                                            <Columns>
                                                 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                           <img src = 'Content/common/images/job.png' class='img-responsive' alt='' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                 
                                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                <asp:BoundField DataField="Country" HeaderText="Job Location" />
                                                <asp:BoundField DataField="Position" HeaderText="Position" />
                                                <asp:BoundField DataField="Certificate" HeaderText="Qualification" />
                                                <asp:BoundField DataField="ContractType" HeaderText="Contract Type" />
                                                <asp:BoundField DataField="ExperienceRequired" HeaderText="Experience" />
                                                <asp:BoundField DataField="JobDescription" HeaderText="Job Description" />
                                                <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                                                <asp:TemplateField  HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfID" Value='<%# Eval("ID") %>' runat="server" />
                                             <asp:LinkButton ID="lnkApply" OnClick="lnkApply_Click" RowIndex='<%# Container.DisplayIndex %>' ForeColor="Blue" Style="text-decoration: underline;" runat="server">Apply</asp:LinkButton>
                                             <asp:Label runat="server" Visible="false" ID="lblStatus"> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                            </div>
</asp:Content>

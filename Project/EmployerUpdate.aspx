<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterEmployer.Master" AutoEventWireup="true" CodeBehind="EmployerUpdate.aspx.cs" Inherits="Project.EmployerUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 935px;
        }
        .auto-style2 {
            height: 445px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div>
             <table class="auto-style2">
                <tr>
                    <td class="auto-style4">Update 
                        <asp:Label ID="LblTitle" runat="server"></asp:Label>
                        &#39;s Profile</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
               
                <tr>
                    <td class="auto-style4">Profession:&nbsp; 
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TBProf" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Profession" ControlToValidate="TBProf" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Company Info:
                        </td>
                    <td class="auto-style1">
                        &nbsp;<asp:TextBox ID="TBInfo" TextMode="MultiLine" runat="server" Height="63px" Width="283px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Company Information" ControlToValidate="TBInfo" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
              
                <tr>
                    <td>

                        <asp:Button ID="BtnConfirm" runat="server" Text="Confirm" OnClick="BtnConfirm_Click" />

                    </td>
                    <td class="auto-style1">

                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Profession" HeaderText="Profession" SortExpression="Profession" />
                <asp:BoundField DataField="Info" HeaderText="Info" SortExpression="Info" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Profession], [Info] FROM [Employer]"></asp:SqlDataSource>

</asp:Content>

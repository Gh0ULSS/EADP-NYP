<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterEmployer.Master" AutoEventWireup="true" CodeBehind="EmployerProfile.aspx.cs" Inherits="Project.EmployerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style4 {
            width: 328px;
        }
        .auto-style5 {
            width: 100%;
            height: 402px;
        }
        .auto-style6 {
            height: 96px;
        }
        .auto-style7 {
            width: 328px;
            height: 70px;
        }
        .auto-style8 {
            height: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div>
            <table class="auto-style5">
                <tr>
                    <td class="auto-style4">&nbsp;
                        <asp:Label ID="LblTitle" runat="server"></asp:Label>
                        &#39;s Profile</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">Name:</td>
                    <td class="auto-style8">
                        <asp:Label ID="LblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Profession:&nbsp; 
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="LblProff" runat="server"></asp:Label>
                    </td>
                </tr>
               <tr>
                    <td class="auto-style4">Comapny Info:</td>
                    <td class="auto-style6">
                        <asp:Label ID="LblInfo" runat="server"></asp:Label>
                    </td>
                </tr>
              
                <tr>
                    <td>

                        <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />

                    </td>
                    <td>

                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Visible="False" Width="206px">
            <Columns>
                <asp:BoundField DataField="Profession" HeaderText="Profession" SortExpression="Profession" />
                <asp:BoundField DataField="Info" HeaderText="Info" SortExpression="Info" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Profession], [Info] FROM [Employer]"></asp:SqlDataSource>

</asp:Content>

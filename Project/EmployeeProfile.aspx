<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeProfile.aspx.cs" Inherits="Project.EmployeeProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <style type="text/css">
        .auto-style1 {
            height: 64px;
        }
        .auto-style2 {
            height: 70px;
        }
        .auto-style3 {
            height: 72px;
        }
        .auto-style4 {
            height: 56px;
        }
        .auto-style5 {
            width: 220px;
        }
        .auto-style6 {
            height: 56px;
            width: 220px;
        }
        .auto-style7 {
            height: 72px;
            width: 220px;
        }
        .auto-style8 {
            height: 70px;
            width: 220px;
        }
        .auto-style9 {
            height: 64px;
            width: 220px;
        }
        .auto-style10 {
            width: 1002px;
            height: 396px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div>
            <table class="auto-style10" >
                <tr>
                    <td class="auto-style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LblTitle" runat="server"></asp:Label>
                        &#39;s Profile</td>
                    <td >
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name:</td>
                    <td class="auto-style4">
                        <asp:Label ID="LblName" runat="server"></asp:Label>
                    </td>
                </tr>
                
               
                <tr>
                    <td class="auto-style7">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Profession:
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="LblProf" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Skills:
                        </td>
                    <td class="auto-style2">
                        <asp:Label ID="LblSkill" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Job Status:
                        </td>
                    <td class="auto-style1">
                        <asp:Label ID="LblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
               
                
                <tr>
                    <td class="auto-style6">

                        <asp:Button ID="BtnUpdate" runat="server"  Text="Update" OnClick="BtnUpdate_Click"  />

                    </td>
                    <td>
                        <asp:Button ID="BtnAbsence" runat="server" OnClick="BtnAbsence_Click" Text="Absent Form" Width="146px" />

                          </td>
                </tr>
            </table>
        </div>
        <asp:SqlDataSource ID="SqlDataView" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Skills], [Profession], [Status] FROM [Employee]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataView" Visible="False" Enabled="False">
            <Columns>
                <asp:BoundField DataField="Skills" HeaderText="Skills" SortExpression="Skills" />
                <asp:BoundField DataField="Profession" HeaderText="Profession" SortExpression="Profession" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>

</asp:Content>

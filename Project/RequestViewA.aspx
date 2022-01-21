<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterEmployer.Master" AutoEventWireup="true" CodeBehind="RequestViewA.aspx.cs" Inherits="ITP213_Project.RequestViewA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 350px;
        }
        .auto-style4 {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lbRequest" runat="server" Font-Size="Larger" Text="Accepted Requests"></asp:Label>
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <!--Gridview to display requests-->
            <td class="auto-style3">
                <asp:GridView ID="gvRequests" runat="server" AutoGenerateColumns="False" DataKeyNames="Request_Id" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Request_Id" HeaderText="Request_Id" ReadOnly="True" SortExpression="Request_Id" InsertVisible="False" />
                        <asp:BoundField DataField="User_Name" HeaderText="User_Name" SortExpression="User_Name" />
                        <asp:BoundField DataField="Job_Name" HeaderText="Job_Name" SortExpression="Job_Name" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Request_Id], [User_Name], [Job_Name] FROM [RequestsDB] WHERE ([Pending] = @Pending)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Yes" Name="Pending" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddFilter" runat="server">
                    <asp:ListItem>View Accepted</asp:ListItem>
                    <asp:ListItem>View Pending</asp:ListItem>
                    <asp:ListItem>View Declined</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnLoad" runat="server" Text="Load" Width="180px" OnClick="btnLoad_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddSelector" runat="server" DataSourceID="SqlDataSource2" DataTextField="Request_Id" DataValueField="Request_Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Request_Id] FROM [RequestsDB] WHERE ([Pending] = @Pending)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Yes" Name="Pending" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnAccept" runat="server" Text="Accept Request" Width="180px" OnClick="btnAccept_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button ID="btnBack" runat="server" Text="Back" Width="180px" OnClick="btnBack_Click" />
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnDecline" runat="server" Text="Decline Request" Width="180px" OnClick="btnDecline_Click" />
            </td>
        </tr>

    </table>
</asp:Content>

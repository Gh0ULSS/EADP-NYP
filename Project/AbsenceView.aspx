<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterEmployer.Master" AutoEventWireup="true" CodeBehind="AbsenceView.aspx.cs" Inherits="ITP213_Project.AbsenceView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 350px;
        }
        .auto-style4 {
            width: 251px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lbRequest" runat="server" Font-Size="Larger" Text="Absence List"></asp:Label>
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <!--Gridview to display absence-->
            <td class="auto-style4">
                <asp:GridView ID="gvRequests" runat="server" AutoGenerateColumns="False" DataKeyNames="case_Id" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="case_Id" HeaderText="case_Id" ReadOnly="True" SortExpression="case_Id" InsertVisible="False" />
                        <asp:BoundField DataField="user_Name" HeaderText="user_Name" SortExpression="user_Name" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [case_Id], [user_Name] FROM [Absence] WHERE ([Pending] = @Pending)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Pending" Name="Pending" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddSelector" runat="server" DataSourceID="SqlDataSource2" DataTextField="case_Id" DataValueField="case_Id">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [case_Id] FROM [Absence] WHERE ([Pending] = @Pending)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Pending" Name="Pending" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="auto-style3">
                <asp:Button ID="btnLoad" runat="server" Text="Load" Width="180px" OnClick="btnLoad_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
            </td>
            <td>
                <asp:Label ID="lbDetails" runat="server" Text="Details:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
            </td>
            <td>
                <asp:TextBox ID="tbName" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="tbDetails" runat="server" Height="100px" TextMode="MultiLine" Width="350px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="auto-style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td>
                <asp:Label ID="lbStart" runat="server" Text="Start Date:"></asp:Label>
                <asp:TextBox ID="tbStartDate" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td>
                <asp:Label ID="lbEnd" runat="server" Text="End Date:"></asp:Label>
                &nbsp;<asp:TextBox ID="tbEndDate" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <!--Button to acknowledge the employer has read it-->
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button ID="btnBack" runat="server" Text="Back" Width="180px" OnClick="btnBack_Click" />
                <asp:Button ID="btnAccept" runat="server" Text="Accept" Width="180px" OnClick="btnAccept_Click" ForeColor="#009999" />
            </td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>

    </table>
</asp:Content>

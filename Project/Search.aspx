<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Project.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 210px;
        }
        .auto-style2 {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table style="width:100%; padding:5px; ">
        <tr style="text-wrap:normal; padding:5px;">
            <td class="auto-style1">
                <asp:TextBox ID="tbSearch" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddSearchT" runat="server">
                    <asp:ListItem Value="-- Select Type --">-- Select Type --</asp:ListItem>
                    <asp:ListItem Value="Users">Users</asp:ListItem>
                    <asp:ListItem Value="Jobs">Jobs</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
            </td>
        </tr>

               
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbValS" runat="server" Text="Please enter Search Items" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
  

            </table>

        <div>

        </div>

    <table>
        <tr>
            <td>
                
                <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False"  ShowHeaderWhenEmpty="True" DataKeyNames="user_Id"  Visible="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" CellPadding="4" ForeColor="#333333" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="user_Id" HeaderText="User Id" InsertVisible="False" ReadOnly="True" SortExpression="user_Id" />
                        <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" />
                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                        
                         <asp:CommandField ButtonType="Button" SelectText="View User" ShowSelectButton="True" />

                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
               
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [user_Id], [username ] AS username_, [name] FROM [Login]"></asp:SqlDataSource>
               
            </td>
        </tr>


        <tr>
            <td>
                <asp:GridView ID="gvJobs" runat="server" AutoGenerateColumns="False" DataKeyNames="Job_Id" CellPadding="4" ForeColor="#333333" Visible="False" OnSelectedIndexChanged="gvJobs_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Job_Id" HeaderText="Job Id" InsertVisible="False" ReadOnly="True" SortExpression="Job_Id" />
                        <asp:BoundField DataField="Job_Name" HeaderText="Job Name" SortExpression="Job_Name" />
                        <asp:BoundField DataField="Job_PayRate" HeaderText="Pay Rate" SortExpression="Job_PayRate" />
                        <asp:BoundField DataField="Job_PayType" HeaderText="Pay Type" SortExpression="Job_PayType" />
                        <asp:BoundField DataField="Job_StartDate " HeaderText="Start Date" SortExpression="Job_StartDate" />
                        <asp:BoundField DataField="Job_EndDate" HeaderText="End Date" SortExpression="Job_EndDate" />
                        <asp:CommandField ButtonType="Button" SelectText="View Job" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Job_Id], [Job_Name], [Job_StartDate ] AS Job_StartDate_, [Job_PayType], [Job_PayRate], [Job_EndDate] FROM [JobsDB]"></asp:SqlDataSource>
            </td>
        </tr>

    </table>


    

</asp:Content>

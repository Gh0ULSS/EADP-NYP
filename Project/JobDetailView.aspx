<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterEmployer.Master" AutoEventWireup="true" CodeBehind="JobDetailView.aspx.cs" Inherits="ITP213_Project.JobDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 180px;
        }
        .auto-style7 {
            width: 411px;
            height: 50px;
        }
        .auto-style8 {
            width: 146px;
        }
        .auto-style9 {
            width: 146px;
            height: 50px;
        }
        .auto-style10 {
            width: 411px;
        }
        .auto-style11 {
            width: 190px;
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <!--The job database-->
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">
                <!--The title of the page-->
                <asp:Label ID="lbTitle" runat="server" Text="Retrieve Job Details" Font-Size="Larger"></asp:Label>
            </td>
            <td class="auto-style10">
                &nbsp;</td>
        </tr>
        <tr>
            <!--Select the job to edit / delete-->
            <td class="auto-style11">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Job_Id" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Job_Id" HeaderText="Job_Id" InsertVisible="False" ReadOnly="True" SortExpression="Job_Id" />
                        <asp:BoundField DataField="Job_Name" HeaderText="Job_Name" SortExpression="Job_Name" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Job_Id], [Job_Name] FROM [JobsDB] WHERE ([Job_PloyerName] = @Job_PloyerName)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Job_PloyerName" SessionField="Name" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="auto-style9">
                <asp:Label ID="lbInstruction" runat="server" Text="Select job by ID:"></asp:Label>
                <asp:DropDownList ID="ddSelectorView" runat="server" DataSourceID="SqlDataSource3" DataTextField="Job_Id" DataValueField="Job_Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Job_Id] FROM [JobsDB] WHERE ([Job_PloyerName] = @Job_PloyerName)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Job_PloyerName" SessionField="Name" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [User_Name] FROM [RequestsDB] WHERE (([Job_Id] = @Job_Id) AND ([Pending] = @Pending))">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddSelectorView" Name="Job_Id" PropertyName="SelectedValue" Type="Int32" />
                        <asp:Parameter DefaultValue="Yes" Name="Pending" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="auto-style7">
                <asp:Button ID="btnLoad" runat="server" Text="Load" Width="180px" ForeColor="#009999" OnClick="btnLoad_Click" />
            </td>
        </tr>
         <tr>
            <!--The number of workers assigned-->
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style9">
                <asp:Label ID="lbEmpDisp" runat="server" Text="Employees:"></asp:Label>
             </td>
            <td class="auto-style10">
                <asp:DropDownList ID="ddEmpSelector" runat="server" DataSourceID="SqlDataSource2" DataTextField="User_Name" DataValueField="User_Name">
                </asp:DropDownList>
                <asp:Button ID="btnRemove" runat="server" Text="Remove Employee" Width="180px" ForeColor="#FF3300" OnClick="btnRemove_Click" />
             </td>
        </tr>
        <tr>
            <!--The name of the job-->
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style9">
                <asp:Label ID="lbName" runat="server" Text="Job Name:"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="tbName" runat="server" Width="350px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <!--The description of the job-->
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style9">
                <asp:Label ID="lbDescription" runat="server" Text="Job Description:"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="tbDescription" runat="server" Height="100px" TextMode="MultiLine" Width="350px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <!--The category of the job-->
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">
                <asp:Label ID="lbCategory" runat="server" Text="Job Category:"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="tbCategory" runat="server" Width="350px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <!--The qualification requirement of the job-->
            <td class="auto-style8">
                <asp:Label ID="lbQualifications" runat="server" Text="Qualification Requirements:"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="tbQualifications" runat="server" Width="350px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <!--The payment type the job offers-->
            <td class="auto-style9">
                <asp:Label ID="lbPayment" runat="server" Text="Payment Type:"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="tbPayType" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <!--The rate of payment type the job offers-->
            <td class="auto-style8">
                <asp:Label ID="lbRate" runat="server" Text="Rate:"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="tbRate" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="auto-style6">
                &nbsp;</td>
          
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <!--Set when the job Starts-->
            <td class="auto-style9">
                <asp:Label ID="lbStartDate" runat="server" Text="Job Start Date:"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="tbStartDate" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <!--Set the end date of the job-->
            <td class="auto-style9">
                Job End Date:</td>
            <td class="auto-style10">
                <asp:TextBox ID="tbEndDate" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <!--Blank-->
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style9">
                <asp:Label ID="lbStatus" runat="server" Text="Active Status:"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="tbStatus" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <!--Notify of update-->
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style10">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <!--Buttons to cancel and go back to previous page, and to reset fields, respectively-->
            <td class="auto-style9">
                <asp:Button ID="btnBack" runat="server" Text="Back / Cancel" Width="180px" ForeColor="#CC3300" OnClick="btnBack_Click" />
            </td>
            <td class="auto-style10">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="180px" ForeColor="Black" OnClick="btnEdit_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <!--Button to send data to the server to create the job post-->
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterEmployer.Master" AutoEventWireup="true" CodeBehind="JobNavigation.aspx.cs" Inherits="ITP213_Project.JobNavigation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbEmployerPage" runat="server" Font-Bold="False" Font-Size="Larger" Text="Employer's Page"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <!-- Grid view displays all jobs created -->
                <asp:GridView ID="gvJobsList" runat="server" AutoGenerateColumns="False" DataKeyNames="Job_Id" DataSourceID="SqlDataSource2">
                    <Columns>
                        <asp:BoundField DataField="Job_Id" HeaderText="Job_Id" InsertVisible="False" ReadOnly="True" SortExpression="Job_Id" />
                        <asp:BoundField DataField="Job_Name" HeaderText="Job_Name" SortExpression="Job_Name" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Job_Id], [Job_Name] FROM [JobsDB] WHERE ([Job_PloyerName] = @Job_PloyerName)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Job_PloyerName" SessionField="Name" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
                <asp:Button ID="btnCreate" runat="server" Text="Create Job Post" Width="180px" OnClick="btnCreate_Click" />
             </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="Edit / Delete A Job" Width="180px" OnClick="btnEdit_Click" />
             </td>
        </tr>
         <tr>
            <td class="auto-style1">
                <!--Brings you to another page to create a job post-->
             </td>
            <td>
                <!--Brings you to another page to view all job requests-->
             </td>
        </tr>
         <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="btnView" runat="server" Text="View Job Infos" Width="180px" OnClick="btnView_Click" />
             </td>
        </tr>
         <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                <!--Brings you to another page to view the info and workers of the selected job post-->
             </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <!--Removes job post (Sets active status as no)-->
             </td>
            <td>
                <!--Brings you to another page to edit the selected job post-->
                <asp:Button ID="btnRequests" runat="server" Text="View Job Requests" Width="178px" OnClick="btnRequests_Click" />
             </td>
        </tr>
        <tr>
            <td class="auto-style1">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <!--Goes to absence checking page-->
             </td>
            <td>
                <!--Brings you to another page to check absentee requests-->
                <asp:Button ID="btnAbsentee" runat="server" Text="View Absentees" Width="180px" OnClick="btnAbsence_Click" />
             </td>
        </tr>
    </table>
</asp:Content>

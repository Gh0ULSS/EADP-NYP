<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AbsenceForm.aspx.cs" Inherits="Project.AbsenceForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 387px;
        }
        .auto-style2 {
            height: 102px;
        }
        .auto-style3 {
            width: 212px;
        }
        .auto-style4 {
            height: 102px;
            width: 212px;
        }
        .auto-style5 {
            width: 212px;
            height: 75px;
        }
        .auto-style6 {
            height: 75px;
        }
        .auto-style7 {
            width: 341px;
        }
        .auto-style8 {
            height: 75px;
            width: 341px;
        }
        .auto-style9 {
            height: 102px;
            width: 341px;
        }
    .auto-style10 {
        height: 10px;
    }
    .auto-style11 {
        width: 341px;
        height: 10px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <table class="auto-style1">
            <tr>
                <td class="auto-style3">Attendance Form</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Period of Absence:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TBStart" runat="server" Enabled="False" TextMode="DateTime"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Start Date" ControlToValidate="TBStart" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TBStart" ErrorMessage="Invalid Start Date" ForeColor="Red" Operator="GreaterThanEqual" Type="Date">*</asp:CompareValidator>
                    <asp:Calendar ID="CalendarStart" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="CalendarStart_SelectionChanged" Width="254px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="TBEnd" runat="server" Enabled="False" TextMode="DateTime"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter End Date" ControlToValidate="TBEnd" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TBStart" ControlToValidate="TBEnd" ErrorMessage="Invalid End Date" ForeColor="Red" Operator="GreaterThanEqual" Type="Date">*</asp:CompareValidator>
                    <asp:Calendar ID="CalendarEnd" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="CalendarEnd_SelectionChanged" Width="254px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Reason of Absence:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="TBReason" runat="server" TextMode="MultiLine" Height="81px" Width="261px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Reason of Absence" ControlToValidate="TBReason" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
            <td class="auto-style10">
                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" />
            </td>
               
            <td class="auto-style11">

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Invalid End/Start Date or you didn't enter reason" Width="259px" />
                <asp:Label ID="LblRange" runat="server" ForeColor="Red"></asp:Label>
                <br />

            </td>

                </tr>
            <tr>
                <td>

                    &nbsp;</td>
            </tr>
            </table>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Visible="False">
                <Columns>
                    <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                    <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
                    <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [StartDate], [EndDate], [Reason] FROM [Absence]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [StartDate], [EndDate], [Reason] FROM [Absence]"></asp:SqlDataSource>
        </div>

</asp:Content>

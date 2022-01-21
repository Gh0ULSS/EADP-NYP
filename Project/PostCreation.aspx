<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterEmployer.Master" AutoEventWireup="true" CodeBehind="PostCreation.aspx.cs" Inherits="ITP213_Project.PostCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 101px;
            height: 50px;
        }
        .auto-style5 {
            width: 375px;
        }
        .auto-style6 {
            width: 180px;
        }
        .auto-style7 {
            width: 375px;
            height: 50px;
        }
        .auto-style8 {
            width: 101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%; margin-left:250px;">
        <tr>
            <!--The title of the page-->
            <td class="auto-style8">
                <asp:Label ID="lbTitle" runat="server" Text="Create Job Post" Font-Size="Larger"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:Label ID="lbValidation" runat="server" Text="* Please fill in all fields *" Font-Italic="True" ForeColor="#CC3300" Visible="False"></asp:Label>
                <asp:Label ID="lbRValidation" runat="server" ForeColor="#CC3300" Text="*Please enter a number for the rate*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <!--The name of the job-->
            <td class="auto-style1">
                <asp:Label ID="lbName" runat="server" Text="Job Name:"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="tbName" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <!--The description of the job-->
            <td class="auto-style1">
                <asp:Label ID="lbDescription" runat="server" Text="Job Description:"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="tbDescription" runat="server" Height="100px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <!--The category of the job-->
            <td class="auto-style8">
                <asp:Label ID="lbCategory" runat="server" Text="Job Category:"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddCategory" runat="server">
                    <asp:ListItem>-- Select Type --</asp:ListItem>
                    <asp:ListItem>Service</asp:ListItem>
                    <asp:ListItem>Food &amp; Beverage</asp:ListItem>
                    <asp:ListItem>Engineering</asp:ListItem>
                    <asp:ListItem>Medicine</asp:ListItem>
                    <asp:ListItem>Retail</asp:ListItem>
                    <asp:ListItem>Logistics</asp:ListItem>
                    <asp:ListItem>Marketing</asp:ListItem>
                    <asp:ListItem>IT</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <!--The qualification requirement of the job-->
            <td class="auto-style8">
                <asp:Label ID="lbQualifications" runat="server" Text="Qualification Requirements:"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddQualifications" runat="server">
                    <asp:ListItem>-- Select Qualification --</asp:ListItem>
                    <asp:ListItem>No Qualification</asp:ListItem>
                    <asp:ListItem>N-Level Cert.</asp:ListItem>
                    <asp:ListItem>O-Level Cert.</asp:ListItem>
                    <asp:ListItem>Higher Nitec</asp:ListItem>
                    <asp:ListItem>A-Level Cert.</asp:ListItem>
                    <asp:ListItem>Poly. Diploma</asp:ListItem>
                    <asp:ListItem>Uni. Degree</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <!--The payment type the job offers-->
            <td class="auto-style1">
                <asp:Label ID="lbPayment" runat="server" Text="Payment Type:"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:DropDownList ID="ddPayType" runat="server">
                    <asp:ListItem>Per Hour</asp:ListItem>
                    <asp:ListItem>Per Month</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <!--The rate of payment type the job offers-->
            <td class="auto-style8">
                <asp:Label ID="lbRate" runat="server" Text="Rate:"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:Label ID="lbDollar" runat="server" Text="$"></asp:Label>
                <asp:TextBox ID="tbRate" runat="server" Width="180px"></asp:TextBox>
                <asp:Button ID="btnRecommend" runat="server" Text="Need Help" Width="180px" OnClick="btnRecommend_Click" />
            </td>
            <td class="auto-style6">
                &nbsp;</td>
          
        </tr>
        <tr>
            <!--Recommendation-->
            <td class="auto-style8"></td>
            <td>
                <asp:Label ID="lbRecommend" runat="server"></asp:Label>
                <asp:Label ID="lbRecRate" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <!--Set when the job Starts-->
            <td class="auto-style1">
                <asp:Label ID="lbStartDate" runat="server" Text="Job Start Date:"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:Calendar ID="calendarStart" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
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
            <!--Set when the job ends-->
            <td class="auto-style1">
                <asp:Label ID="lbEndDate" runat="server" Text="Job End Date:"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:Calendar ID="calendarEnd" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
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
            <!--Blank-->
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <!--Notification that post is created-->
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="lbNotify" runat="server" Font-Italic="True" Text="Post has been created!" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <!--Buttons to cancel and go back to previous page, and to reset fields, respectively-->
            <td class="auto-style1">
                <asp:Button ID="btnCancel" runat="server" Text="Back / Cancel" Width="180px" ForeColor="#CC3300" OnClick="btnCancel_Click" />
            </td>
            <td class="auto-style5">
                <asp:Button ID="btnReset" runat="server" Text="Reset Fields" Width="180px" OnClick="btnReset_Click" />
            </td>
        </tr>
        <tr>
            <!--Button to send data to the server to create the job post-->
            <td class="auto-style1"></td>
            <td class="auto-style7">
                <asp:Button ID="btnCreate" runat="server" Text="Create Post" Width="180px" ForeColor="#009999" OnClick="btnCreate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

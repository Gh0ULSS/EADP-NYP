<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterEmployer.Master" AutoEventWireup="true" CodeBehind="JobTracker(RE).aspx.cs" Inherits="Project.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 984px;
            height: 632px;
        }
        .auto-style4{
            margin-left: 110px
        }
        .auto-style5 {
            height: 632px;
        }
        .auto-style6 {
            width: 100%;
        }
        .auto-style8 {
            margin-left:240px;
        }
        .auto-style9 {
            margin-left: 15px;
        }
        </style>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <table class="auto-style6">

        <tr>
   
        <td class="auto-style1">
        
        <asp:Calendar ID="Calendar1" class="calendar" runat="server" Height="466px" Width="652px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest"
        Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender">
        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
        <WeekendDayStyle BackColor="#CCCCFF" />

         </asp:Calendar>

         <h3 class="payment">Due Payments </h3>
         <asp:Label ID="Labelduepayments" class="dueinfo" runat="server" Height="60px"></asp:Label>
         <asp:Label ID="Label2" runat="server" CssClass="auto-style8" Text="Preference :"></asp:Label>

            <asp:DropDownList ID="DropDownListPreference" runat="server" CssClass="auto-style9" Height="20px" Width="90px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPreference_SelectedIndexChanged" >
                <asp:ListItem>-- Select --</asp:ListItem>
                <asp:ListItem>Hourly</asp:ListItem>
                <asp:ListItem>Monthly</asp:ListItem>
            </asp:DropDownList>

         </td>

        <td class="auto-style5">


        <asp:Panel ID="Panel1" runat="server" class="panel">

        <h3 class="heading">Details</h3>
        <hr class="line" />
        <h5 class="info">Job Name</h5>
        <asp:Label ID="LabelJob" runat="server" class="labels" Font-Names="Calibri" ForeColor="Blue" Font-Size="15pt" ></asp:Label>
        <h5 class="info">Job Type</h5>
        <asp:Label ID="LabelJobType" runat="server" class="labels" Font-Names="Calibri" ForeColor="Blue" Font-Size="15pt" ></asp:Label>
        <h5 class="info">Payment Amount</h5>
        <asp:Label ID="LabelAmount" runat="server" class="labels"  Font-Names="Calibri" ForeColor="Blue" Font-Size="15pt" ></asp:Label>
        <h5 class="info">Pay Type</h5>
        <asp:Label ID="LabelPayType" runat="server" class="labels" Font-Names="Calibri" ForeColor="Blue" Font-Size="15pt"></asp:Label>
        <h5 class="info">Start Date</h5>
        <h5 class="info">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
        <asp:Label ID="LabelStartDate" runat="server" Font-Names="Calibri" ForeColor="Blue" Font-Size="15pt"></asp:Label>
        </h5>
        <h5 class="info">End Date</h5>
        <h5 class="info">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
        <asp:Label ID="LabelEndDate" runat="server" Font-Names="Calibri" ForeColor="Blue" Font-Size="15pt"></asp:Label>
        <asp:Label ID="LabelErrorMsg" runat="server" class="auto-style4" ForeColor="Red"></asp:Label>
        </h5>

       
        <br />
        <br />

        </asp:Panel>

            </td>
        </tr>
       
    </table>


</asp:Content>

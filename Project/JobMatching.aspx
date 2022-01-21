<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="JobMatching.aspx.cs" Inherits="Project.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width:100%;">

        <tr>
            <td>
                <asp:Label ID="lbTit" runat="server" Text="Job Matching" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
    </table>

    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbCat" runat="server" Text="Job Category: "></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddCat" runat="server" Width="130px" >
                    <asp:ListItem>-- Select Type --</asp:ListItem>
                    <asp:ListItem Text ="Food and Beverage" Value ="Food and Beverage"></asp:ListItem>
                    <asp:ListItem Text ="Service" Value ="Service"></asp:ListItem>
                    <asp:ListItem Text ="Engineering" Value ="Engineering"></asp:ListItem>
                    <asp:ListItem Text ="Medicine" Value ="Medicine">Medicine</asp:ListItem>
                    <asp:ListItem Text ="Retail" Value ="Retail"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
                <tr>
            <td>
                &nbsp;</td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbPay" runat="server" Text = "Payment Type:"></asp:Label>
            </td>
         <td>
                <asp:DropDownList ID="ddPayType" runat="server">
                    <asp:ListItem>-- Select Type --</asp:ListItem>
                    <asp:ListItem Value ="Per Hour">Per Hour</asp:ListItem>
                    <asp:ListItem Value ="Per Month">Per Month</asp:ListItem>
                    </asp:DropDownList>
            </td>
        </tr>
                <tr>
            <td>
                &nbsp;</td>
            
        </tr>
                <tr>
            <!--Set when the job Starts-->
            <td class="auto-style1">
                <asp:Label ID="lbStartDate" runat="server" Text="Job Start Date:"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:Calendar ID="calendarStart" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" >
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
            <td>
                &nbsp;</td>
            
        </tr>
 
        </table>

    

    <table style="width:100%;">
        <tr>
            <td>
                <asp:Button ID="btnMatch" runat="server" OnClick="ButtonMatch_Click" Text="Match Me" />
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lbValidate" runat="server" Text="Select all fields before proceeding." ForeColor="Red" Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbValidateSDate" runat="server" Text="Please select a date that is today or after today." ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>

        
    </table>
    
    
    <div>

    </div>

    <table style="width:90%; padding-top:15px;">
        <tr>
            <td>
                <asp:GridView ID="GridViewDMatch" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Visible="False" OnSelectedIndexChanged="GridViewDMatch_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns >
                        
                        <asp:BoundField DataField="Job_Id" HeaderText ="" SortExpression="Job_Id"/>
                        <asp:BoundField DataField="Job_Name" HeaderText="" SortExpression="Job_Name" />
                        <asp:BoundField DataField="Job_PayRate" HeaderText="Payment Rate" SortExpression="Job_PayRate" />
                        <asp:BoundField DataField="Job_PayType" HeaderText="Payment Type" SortExpression="Job_PayType" />
                        <asp:BoundField DataField="Job_StartDate" HeaderText="Start Date" SortExpression="Job_StartDate" />
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


                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Job_Id], [Job_Name], [Job_PayType], [Job_PayRate], [Job_StartDate ] AS Job_StartDate_, [Job_EndDate] FROM [JobsDB]"></asp:SqlDataSource>


            </td>
        </tr>

    </table>
   
</asp:Content>

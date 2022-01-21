<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="JobHistory.aspx.cs" Inherits="Project.JobHistory" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 36px;
        }
        .auto-style2 {
            margin-left: 20px;
            margin-bottom:20px;
        }
        .auto-style3 {
            margin-left: 880px;
            margin-bottom:20px;
        }
    </style>
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
  <h2 class="title">&nbsp;&nbsp;&nbsp;&nbsp;Job History </h2>

      <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Filter By :" Font-Size="15px"></asp:Label>
      

      <asp:DropDownList ID="DropDownListFilter" runat="server" CssClass="auto-style2" AutoPostBack="True"
       OnSelectedIndexChanged="DropDownListFilter_SelectedIndexChanged">
          <asp:ListItem>-- By Pay Type --</asp:ListItem>
          <asp:ListItem>Hourly</asp:ListItem>
          <asp:ListItem>Monthly</asp:ListItem>
          <asp:ListItem>-- By Job Category --</asp:ListItem>
          <asp:ListItem>Retail</asp:ListItem>
          <asp:ListItem>Logistics</asp:ListItem>
          <asp:ListItem>Marketing</asp:ListItem>
          <asp:ListItem>Service</asp:ListItem>
          <asp:ListItem>Food &amp; Beverage</asp:ListItem>
          <asp:ListItem>Engineering</asp:ListItem>
          <asp:ListItem>Medicine</asp:ListItem>
          <asp:ListItem>IT</asp:ListItem>
          <asp:ListItem>Other</asp:ListItem>
      </asp:DropDownList>

    <asp:GridView ID="GridView1" runat="server" CssClass="auto-style1" Height="162px" Width="1350px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="  Job Name" DataField="Job_Name" />
            <asp:BoundField HeaderText="Job Category" DataField="Job_Type" />
            <asp:BoundField HeaderText="Payment Amount" DataField="Payment_Amount" />
            <asp:BoundField DataField="Pay_Type" HeaderText="Pay Type" />
            <asp:BoundField DataField="Start_Date" DataFormatString="{0:d}" HeaderText="Start Date" />
            <asp:BoundField DataField="End_Date" DataFormatString="{0:d}" HeaderText="End Date" />
            <asp:BoundField DataField="Active_Status" HeaderText="Active Status" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

  </asp:Content>

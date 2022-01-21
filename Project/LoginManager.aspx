<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="LoginManager.aspx.cs" Inherits="Project.LoginManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Current Active Accounts"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="user_Id" DataSourceID="SqlDataSource1" Height="195px" Width="1473px" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="user_Id" HeaderText="user_Id" ReadOnly="True" SortExpression="user_Id" InsertVisible="False" />
                    <asp:BoundField DataField="username " HeaderText="username " SortExpression="username " />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                    <asp:BoundField DataField="NRIC " HeaderText="NRIC " SortExpression="NRIC " />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="accountType" HeaderText="accountType" SortExpression="accountType" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT * FROM [Login]"></asp:SqlDataSource>
                <asp:Button ID="btn_edit" runat="server" OnClick="btn_edit_Click" Text="Edit/Delete Accounts" />
        </div>
       <!-- <asp:Button ID="testBtn" runat="server" OnClick="testBtn_Click" Text="Show Current Session" /> -->

</asp:Content>

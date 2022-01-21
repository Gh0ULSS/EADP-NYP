<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="LoginManagerEdit.aspx.cs" Inherits="EADP1.LoginManagerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style1 {
            width: 197px;
        }
        .auto-style2 {
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Edit/Delete Account Information"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="user_Id" DataSourceID="SqlDataSource1" CssClass="auto-style2" Height="213px" Width="909px" AllowSorting="True">
                <Columns>
                    <asp:BoundField DataField="user_Id" HeaderText="user_Id" InsertVisible="False" ReadOnly="True" SortExpression="user_Id" />
                    <asp:BoundField DataField="username " HeaderText="username " SortExpression="username " />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                    <asp:BoundField DataField="NRIC " HeaderText="NRIC " SortExpression="NRIC " />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="accountType" HeaderText="accountType" SortExpression="accountType" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT * FROM [Login]"></asp:SqlDataSource>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Select user_ID of the Account to be edited or deleted"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="user_Id" DataValueField="user_Id" style="margin-left: 0px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btn_Load" runat="server" CausesValidation="False" OnClick="btn_Load_Click" Text="Load Details" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="Username:"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tb_Username" runat="server" Width="143px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a Username" ForeColor="#FF3300" ControlToValidate="tb_Username"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label5" runat="server" Text="Name: "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tb_Name" runat="server" Width="142px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter a Name" ForeColor="#FF3300" ControlToValidate="tb_Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="NRIC:"></asp:Label>
                     </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tb_Nric" runat="server" Width="143px"></asp:TextBox>
                     </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter an NRIC" ForeColor="#FF3300" ControlToValidate="tb_Nric"></asp:RequiredFieldValidator>
                     </td>
                </tr>
                 <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label6" runat="server" Text="Account Type :"></asp:Label>
                     </td>
                    <td class="auto-style1">
                        <asp:RadioButtonList ID="radio_Employer" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">Employee</asp:ListItem>
                            <asp:ListItem>Employer</asp:ListItem>
                        </asp:RadioButtonList>
                     </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please choose an Account Type" ForeColor="#FF3300" ControlToValidate="radio_Employer"></asp:RequiredFieldValidator>
                     </td>
                </tr>
                 <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label7" runat="server" Text="Password:"></asp:Label>
                     </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tb_Password" runat="server" Width="147px"></asp:TextBox>
                     </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter a Password" ForeColor="#FF3300" ControlToValidate="tb_Password"></asp:RequiredFieldValidator>
                     </td>
                </tr>

            </table>
        </div>
        <asp:Button ID="btn_Submit" runat="server" Text="Submit Changes" OnClick="btn_Submit_Click" />
        <asp:Button ID="btn_Delete" runat="server" Text="Delete Selected Account" CausesValidation="False" OnClick="btn_Delete_Click" />
        <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Back" CausesValidation="False" />

</asp:Content>

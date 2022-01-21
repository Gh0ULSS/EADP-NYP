<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 276px;
        }
        .auto-style3 {
            height: 56px;
            width: 267px;
        }
        .auto-style4 {
            height: 56px;
            width: 749px;
            margin-left:550px;
            margin-top:100px;
        }
        .auto-style10 {
            height: 56px;
            width: 110px;
        }
        .auto-style13 {
            height: 97px;
            width: 110px;
        }
        .auto-style16 {
            height: 92px;
            width: 110px;
        }
        .auto-style17 {
            height: 92px;
            width: 276px;
        }
        .auto-style18 {
            width: 276px;
            height: 97px;
        }
        .auto-style19 {
            height: 92px;
            width: 267px;
        }
        .auto-style21 {
            width: 267px;
            height: 97px;
        }
        .auto-style22 {
            height: 94px;
            width: 110px;
        }
        .auto-style23 {
            height: 94px;
            width: 276px;
        }
        .auto-style24 {
            height: 94px;
            width: 267px;
        }
        .auto-style25 {
            margin-top: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div>
            <table class="auto-style4">
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Login" Font-Size="30px"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="Label2" runat="server" Text="Username: "></asp:Label>
                    </td>
                    <td class="auto-style17">
                        <asp:TextBox ID="tbUser" runat="server" CssClass="imageholder" Width="118px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUser" ErrorMessage="Please enter Username" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style19">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
                    </td>
                    <td class="auto-style23">
                        <asp:TextBox ID="tbPass" runat="server" TextMode="Password" CausesValidation="True" CssClass="auto-style25"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPass" ErrorMessage="Please enter Password" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style24">
                        <asp:Button ID="viewButton" runat="server" CausesValidation="False" OnClick="viewButton_Click" Text="View" ValidateRequestMode="Disabled" />
                    </td>
                </tr>
                <tr>
                  <td class="auto-style13">
                                            </td>
                    <td class="auto-style18">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Height="25px" />
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" CausesValidation="False" />
                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                        </td>
                    <td class="auto-style21">
                        <asp:Button ID="Button1" runat="server" Text="Create Account" OnClick="Button1_Click" CausesValidation="False" />
                                        </td>
                </tr>
            </table>
        </div>

</asp:Content>

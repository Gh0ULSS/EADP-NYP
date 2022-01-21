<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="Project.AddAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <table style="width:100%;">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="tb_Name" runat="server" Width="318px"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_Name" ErrorMessage="Please enter Name" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:Label ID="Label2" runat="server" Text="NRIC: "></asp:Label></td>
                    <td class="auto-style2"> <asp:TextBox ID="tb_NRIC" runat="server" Width="318px"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_NRIC" ErrorMessage="Please enter NRIC" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7"><asp:Label ID="Label3" runat="server" Text="Username: "></asp:Label></td>
                    <td class="auto-style8"> <asp:TextBox ID="tb_Username" runat="server" Width="318px"></asp:TextBox></td>
                    <td class="auto-style9">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_Username" ErrorMessage="Please enter a Username" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style1"><asp:Label ID="Label4" runat="server" Text="Password: "></asp:Label></td>
                    <td class="auto-style2"><asp:TextBox ID="tb_Pass" runat="server" Width="318px" TextMode="Password"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_Pass" ErrorMessage="Please enter a password" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                </tr>
                                <tr>
                    <td class="auto-style1"><asp:Label ID="Label5" runat="server" Text="Confirm Password: "></asp:Label></td>
                    <td class="auto-style2"> <asp:TextBox ID="tb_cfmPass" runat="server" Width="318px" TextMode="Password"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_cfmPass" ErrorMessage="Please confirm your password" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                </tr>
                               
                                <tr>
                    <td class="auto-style1"><asp:Label ID="Label6" runat="server" Text="Account Type:  "></asp:Label></td>
                    <td class="auto-style2"> 
                        <asp:RadioButtonList ID="radio_employer" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">Employee</asp:ListItem>
                            <asp:ListItem>Employer</asp:ListItem>
                        </asp:RadioButtonList>
                                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                                
                                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2"> 
                        &nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>

                 <tr>               
                    <td class="auto-style1"></td>
                    <td class="auto-style2">
                        <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" />
                        <asp:Button ID="clrBtn" runat="server" Text="Clear" OnClick="clrBtn_Click" />
                     </td>
                </tr>
            </table>
    
</asp:Content>

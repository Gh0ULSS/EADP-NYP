<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeUpdate.aspx.cs" Inherits="Project.EmployeeUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style2 {
            height: 503px;
            margin-bottom: 8px;
        }
        .auto-style5 {
            height: 32px;
        }
        .auto-style7 {
            width: 954px;
            height: 32px;
        }
        .auto-style8 {
            width: 954px;
            height: 87px;
        }
        .auto-style9 {
            width: 954px;
            height: 81px;
        }
        .auto-style10 {
            width: 954px;
            height: 88px;
        }
        .auto-style11 {
            width: 954px;
            height: 54px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div>
             <table class="auto-style2" >
                <tr>
                    <td class="auto-style10">Update
                        <asp:Label ID="LblTitle" runat="server"></asp:Label>
                        &#39;s Profile</td>
                    <td class="auto-style10" >
                        </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        Profession(Optional):
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="TBprof" runat="server" Width="242px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        Skills:
                        </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="TBskills" runat="server" Width="292px"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBskills" ErrorMessage="Enter your Skill/s" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                          </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        Job Status:
                        </td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="DDLstatus" runat="server" Width="249px">
                            <asp:ListItem Value="Null">--Select--</asp:ListItem>
                            <asp:ListItem Value="Part-time">Part-time</asp:ListItem>
                            <asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
                            <asp:ListItem Value="Freelance">Freelance</asp:ListItem>
                            <asp:ListItem Value="Intern">Intern</asp:ListItem>
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDLstatus" ErrorMessage="Please select a Status" ForeColor="Red" InitialValue="Null" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                         </td>
                </tr>
               
                <tr>
                    <td class="auto-style5">

                        <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="Confirm" />

                    </td>
                    <td class="auto-style7">

                       
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainDatabase %>" SelectCommand="SELECT [Profession], [Skills], [Status] FROM [Employee]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Visible="False">
            <Columns>
                <asp:BoundField DataField="Profession" HeaderText="Profession" SortExpression="Profession" />
                <asp:BoundField DataField="Skills" HeaderText="Skills" SortExpression="Skills" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>

</asp:Content>

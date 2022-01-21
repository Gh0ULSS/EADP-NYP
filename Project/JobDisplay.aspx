<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="JobDisplay.aspx.cs" Inherits="Project.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style type="text/css">
        .auto-style2 {
            width: 151px;
        }
        .auto-style3 {
            width: 151px;
            height: 20px;
        }
        .auto-style4 {
            width: 149px;
        }
        .auto-style5 {
            width: 146px;
            height: 20px;
        }
        .auto-style6 {
            width: 146px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div>
    </div>
    <table style=" align-self:center; padding-top:10px; padding-left:25%; width: 420px; height: 22px;">
        <tr>
            <th class="auto-style4" style="background-color: #237083; color: #FFFFFF; font-size: 18px">
                <asp:Label ID="lbDJTitle" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbDJID" runat="server" Text="" Visible="False"></asp:Label>
            </th>
            
        </tr>

    </table>

    <table>
        
        <tr>
            <td class="auto-style6">
                <asp:Label ID="lbJCat" runat="server" Text="Job Category: "></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="lbDJCat" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lbQua" runat="server" Text="Required Qualification: "></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="lbDQua" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lbPmt" runat="server" Text="Payment : "></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="lbDPRate" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbDPType" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        
        <tr>
            <td class="auto-style6">
                <asp:Label ID="lbStartDate" runat="server" Text="Start Date: "></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="lbDSDate" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="lbEndDate" runat="server" Text="End Date: "></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="lbDEDate" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    
    

           <tr>
            <td class="auto-style6">
                <asp:Label ID="lbployName" runat="server" Text="Employer name: "></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="lbDPloyer" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="lbJDesc" runat="server" Text="Job Description: "></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="lbDJDesc" runat="server" Text=""></asp:Label>
            </td>
            </tr>

        <tr>
            <td class="auto-style6">
                <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
            </td>
            
            <td class="auto-style2">
                <br />
            </td>

          

        </tr>
    </table>

</asp:Content>

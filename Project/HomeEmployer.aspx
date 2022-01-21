<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterEmployer.Master" AutoEventWireup="true" CodeBehind="HomeEmployer.aspx.cs" Inherits="Project.HomeEmployer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style type="text/css">
         .autostyle {
             margin-left:725px;
             margin-top:200px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript">
        var image1 = new Image()
        image1.src = "images/img1.jpg"
        var image2 = new Image()
        image2.src = "images/img2.png"
        var image3 = new Image()
        image3.src = "images/img3.jpg"
        var image4 = new Image()
        image4.src = "images/img4.jpg"
    </script>

    <img class="slideshow" src="images/img1.jpg" name="slide" />

    <asp:Button ID="Button1" runat="server" Text="Log out" CssClass="autostyle" Height="45px" Width="91px" OnClick="Button1_Click" />

    <script type="text/javascript">
        var step = 1
        function slideit() {
            document.images.slide.src = eval("image" + step + ".src")
            if (step < 4)
                step++
            else
                step = 1
            setTimeout("slideit()", 2500)
        }
        slideit()
    </script>

</asp:Content>

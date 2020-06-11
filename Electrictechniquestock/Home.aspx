<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Electrictechniquestock.Home" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="dist/js/pages/dashboard.js"></script>
    <script type="text/javascript" src="Home/main.js"></script>
    <script type="text/javascript" src="Home/jasny-bootstrap.min.js"></script>
    <script type="text/javascript" src="Home/modernizr.custom.js"></script>
    <script type="text/javascript" src="Home/owl.carousel.js"></script>
    <script type="text/javascript" src="Home/SmoothScroll.js"></script>
    <script type="text/javascript" src="Home/typed.js"></script>
    <link rel="stylesheet" href="Home/css/animate.css" />
    <link rel="stylesheet" href="Home/css/jasny-bootstrap.min.css" />
    <link rel="stylesheet" href="Home/css/owl.carousel.css" />
    <link rel="stylesheet" href="Home/css/owl.theme.css" />
    <link rel="stylesheet" href="Home/css/responsive.css"/>
    <link rel="stylesheet" href="Home/css/style.css" />
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="home">
        <div class="container text-center">
            <!-- Navigation -->
            <%--<nav id="menu" data-toggle="offcanvas" data-target=".navmenu">
                <span class="fa fa-bars"></span>
            </nav>--%>

            <div class="content">
                <h4> R&D Engineering</h4>
                <hr />
                <div class="header-text btn">
                    <h1><span id="head-title"></span></h1>
                </div>
            </div>
        </div>
    </div>

    <script>
      $(function(){
          $("#head-title").typed({
              strings: ["ยินดีต้อนรับ", "บริษัทขอนแก่นแหอวนจำกัด", "โดย R&D Engineering"],
            typeSpeed: 100,
            loop: true,
            startDelay: 100
          });
      });
    </script>
</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Electrictechniquestock.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <title>Sing in </title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <link rel="shortcut icon" type="image/x-icon" href="images/to-do-list-icon.png" />
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="Content/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="admin-lte/css/AdminLTE.css" />
    <link rel="stylesheet" type="text/css" href="plugins/datepicker/datepicker3.css" />
    <link rel="stylesheet" href="admin-lte/css/skins/_all-skins.min.css"/>
    <link rel="stylesheet" href="Content/bootstrap-datetimepicker.min.css" />
    <script type="text/javascript" src="scripts/jquery-2.2.3.js"></script>
    <script type="text/javascript" src="scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/moment-with-locales.js"></script>
    <script type="text/javascript" src="scripts/bootstrap-datetimepicker.min.js"></script>
    <link href="Content/StyleLogin.css" rel="stylesheet" />
</head>
<body>
    <%--defaultbutton="lbtnlogin"--%>
    <form id="form1" runat="server" defaultbutton="lbtnlogin">
        <div class="body"></div>
        <div class="row" >
            <div class="col-md-4 col-md-offset-4">
                <div style="text-align: center">
                    <img src="images/logo2.png" width="250px"/>
                     <h1 style="color: white; font-weight:bold"><span style="color: cornflowerblue; font-weight: bold"> R&D Engineering</span> </h1>
                    
                    <h1 style="color: white;" ><span style="color: cornflowerblue; font-weight: bold">เข้าสู่ระบบ</span> </h1>
                </div>
                <div method="post" style="margin-left: 20%; margin-right: 20%">  
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="tbusername" ValidationGroup="grouplogin" ForeColor="Yellow">*กรุณากรอกข้อมูลให้ครบ</asp:RequiredFieldValidator>--%>
                    <asp:TextBox ID="tbusername" runat="server" placeholder="Username" autofocus ></asp:TextBox>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="grouplogin" ControlToValidate="tbpassword" ForeColor="Yellow">*กรุณากรอกข้อมูลให้ครบ</asp:RequiredFieldValidator>--%>
                    <asp:TextBox ID="tbpassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                    <asp:LinkButton ID="lbtnlogin" runat="server" CssClass="btn btn-primary btn-block btn-large" OnClick="lbtnlogin_Click" ValidationGroup="grouplogin">LOGIN</asp:LinkButton>
                    <br />
                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
        <%--<div class="login">    
        </div>--%>
        <footer class="footer">
            <p style="color: white; margin-top: 30px">Copyright &copy; 2019 ฝ่ายผลิตชิ้นส่วนและอุปกรณ์. All rightsreserved. &copy;</p>
        </footer>
    </form>
</body>
</html>

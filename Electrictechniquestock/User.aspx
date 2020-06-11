<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Electrictechniquestock.User" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>


<asp:Content ID="Body" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:HiddenField ID="hfEmpID" runat ="server"  />

    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.46); padding: 2%; margin-top: 5%">
        <div class="text-center" style="padding: 0.5%">
            <h2>เพิ่มผู้ใช้งาน</h2>
            <section class="content">


                <asp:Panel ID="Panel1" runat="server">
                    <div class="row" style="padding: 5px">
                        <div class="col-md-4 text-right">
                            <label>รหัสพนักงาน :</label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="TxtEmp_id" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding: 5px">
                        <div class="col-md-4 text-right">
                            <label>ชื่อ :</label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtFname" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding: 5px">
                        <div class="col-md-4 text-right">
                            <label>นามสกุล :</label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtLname" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding: 5px">
                        <div class="col-md-4 text-right">
                            <label>ตำแหน่ง :</label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                 
                    <div class="row" style="padding: 5px">
                        <div class="col-md-4 text-right">
                            <label>สิทธิ์การเข้าถึง :</label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row" style="padding: 5px">
                        <div class="col-md-4 text-right">
                            <label>Username :</label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding: 5px">
                        <div class="col-md-4 text-right">
                            <label>Password :</label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="text-center" style="padding: 20px">
                           <asp:Button ID="tAddUser" runat="server" Text="เพิ่มสมาชิก" CssClass="btn btn-primary btn-lg" OnClick="btAdduser_Click"  />
                    </div>
            
                    </asp:Panel>

        </div>
    </section>
</asp:Content>

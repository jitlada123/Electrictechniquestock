<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PLCGroup.aspx.cs" Inherits="Electrictechniquestock.PLCGroup" %>


<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
     <script>
        $(document).ready(function () {

           $('#<%=tblStock.ClientID %>').DataTable({
               "scrollY": "60vh",
               "scrollCollapse": true,
               "paging": false,
               "scrollX": true
            });
       $('#<%=tbldetailadddisbursestock.ClientID %>').DataTable({
                "scrollY": "60vh",
                "scrollCollapse": true,
                "paging": false,
                "scrollX": true
            });
        });

         function modeldisbursestock() {
             $('#model_disbursestock').modal();
        }
         function modeldetailadddisbursestock() {
             $('#model_modeldetailadddisbursestock').modal();
        }

    </script>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyContent" runat="server">
  <div class="messagealert" id="alert_container"></div>
    <section class="content-header">
        <h1>Setting PLC GroupScan</h1>
    </section>
    <section class="content">
<%--        <div class="form-inline" style="padding: 10px">
            <label>สาขา :</label>
            <asp:DropDownList ID="ddlBranch" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn btn-primary"><span class="glyphicon glyphicon-search" aria-hidden="true"></span> ค้นหา</asp:LinkButton>
        </div>--%>
        
        <div class="text-right" style="margin-bottom:5px">
            <%--<asp:LinkButton ID="lbtnAdd" runat="server" CssClass="btn btn-success" OnClick="lbtnAdd_Click"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span> เพิ่ม</asp:LinkButton>--%>
            <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-warning" OnClick="lbtnEdit_Click"><span class="glyphicon glyphicon-edit" aria-hidden="true"></span> จ่าย</asp:LinkButton>
            <%--<asp:LinkButton ID="lbtnDel" runat="server" CssClass="btn btn-danger" OnClick="lbtnDel_Click"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span> ลบ</asp:LinkButton>--%>
        </div>
        <asp:Table ID="tblStock" runat="server" Width="100%" CssClass="display" CellSpacing="0">
            <asp:TableHeaderRow TableSection="TableHeader">
                <asp:TableHeaderCell>
                    <asp:LinkButton ID="lbtnselectall" runat="server" OnClick="lbtnselectall_Click"><span class="glyphicon glyphicon-check" aria-hidden="true"></span> เลือกทั้งหมด</asp:LinkButton>
                </asp:TableHeaderCell>
                     <asp:TableHeaderCell>ลำดับ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รหัสสิบหลัก</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รายการ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>กลุ่ม/ประเภท</asp:TableHeaderCell>
                    <asp:TableHeaderCell>ช่องเก็บ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>หน่วยนับ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>จำนวนคงเหลือ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รายละเอียด</asp:TableHeaderCell>
<%--                    <asp:TableHeaderCell>ผู้บันทึก</asp:TableHeaderCell>
                    <asp:TableHeaderCell>วันที่วันทึก</asp:TableHeaderCell>--%>
            </asp:TableHeaderRow>
        </asp:Table>
        <div style="margin-top: 5px" class="text-right">
            <asp:LinkButton ID="lbtnResetAll" runat="server" CssClass="btn btn-default" OnClick="lbtnResetAll_Click"><span class="glyphicon glyphicon-erase" aria-hidden="true"></span> รีเซตการเลือก</asp:LinkButton>
        </div>

        <div class="modal fade" id="model_disbursestock" role="dialog" style="border-radius:10px">
        <div class="modal-dialog">
            <!-- Modal content-->
          <div class="modal-content">
                <div class="modal-header text-center" style="padding: 35px 50px; background-color: #fff000;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3>รายการจ่ายอุปกรณ์ </h3>
                </div>
                <div class="modal-body" style="padding: 40px 50px;">
                    <div class="form-group">
                        
                        <asp:TextBox ID="tbstock_id" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                        <label>ชื่อรายการ :</label>
                        <asp:TextBox ID="tbItemname" runat="server" CssClass="form-control"></asp:TextBox>
                        <label>จำนวนจ่าย :</label>
                        <asp:TextBox ID="tbdisbursestcok" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                    <div class="text-right">
                        <asp:LinkButton ID="lbtnSaveEdit" runat="server" CssClass="btn btn-success" OnClick="lbtnSaveEdit_Click"><span class="glyphicon glyphicon-save" aria-hidden="true"></span> บันทึก</asp:LinkButton>
                        <asp:LinkButton ID="lbtnCancelEdit" runat="server" CssClass="btn btn-danger"><span class="glyphicon glyphicon-remove-circle" aria-hidden="true"></span> ยกเลิก</asp:LinkButton>
                    </div>
                </div>               
            </div>
        </div>
    </div>
      <div class="modal fade" id="model_modeldetailadddisbursestock" role="dialog"  style="border-radius:10px">
        <div class="modal-dialog">
            <!-- Modal content-->
          <div class="modal-content" >
                <div class="modal-header text-center"  style="padding: 35px 50px; background-color: #fff000;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3>รายละเอียด การรับและจ่ายอุปกรณ์ </h3>
                </div>
                <div class="modal-body" style="padding: 40px 50px;">
                    <div class="form-group">
        <asp:Table ID="tbldetailadddisbursestock" runat="server" Width="100%" CssClass="display" CellSpacing="0">
            <asp:TableHeaderRow TableSection="TableHeader">
                     <asp:TableHeaderCell>ลำดับ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>ประเภท</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รายการ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>กลุ่ม/ประเภท</asp:TableHeaderCell>
                    <asp:TableHeaderCell>ช่องเก็บ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>หน่วยนับ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>จำนวน</asp:TableHeaderCell>
                    <asp:TableHeaderCell>จำนวนคงเหลือ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>ผู้บันทึก</asp:TableHeaderCell>
                    <asp:TableHeaderCell>วันที่บันทึก</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
                    </div>
    <%--                <div class="text-right">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" OnClick="lbtnSaveEdit_Click"><span class="glyphicon glyphicon-save" aria-hidden="true"></span> บันทึก</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger"><span class="glyphicon glyphicon-remove-circle" aria-hidden="true"></span> ยกเลิก</asp:LinkButton>
                    </div>--%>
                </div>               
            </div>
        </div>
    </div>
    </section>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Electrictechniquestock.Add" %>


<asp:Content ID="Head" ContentPlaceHolderID="HeaderContent" runat="server">
     <script>
<%--        $(document).ready(function () {
         $('#<%=tblMachine.ClientID %>').DataTable({
                 "scrollY": "60vh",
                 "scrollCollapse": true,
                 "paging": false,
                 "scrollX": true
            });--%>
      <%--   $('#<%=tbmcepeanumber.ClientID %>').DataTable({
                "scrollY": "60vh",
                "scrollCollapse": true,
                "paging": false,
                "scrollX": true
            });--%>
        //});
         function modelAddnamestockgroup() {
            $('#Addnamestockgroup').modal();
        }
 
    </script>
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyContent" runat="server">
  <div class="messagealert" id="alert_container"></div>
    <section class="content-header">
        <h1>เพิ่มอุปกรณ์</h1>
    </section>
    <section class="content">
<%--        <div class="form-inline" style="padding: 10px">
            <label>สาขา :</label>
            <asp:DropDownList ID="ddlBranch" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn btn-primary"><span class="glyphicon glyphicon-search" aria-hidden="true"></span> ค้นหา</asp:LinkButton>
        </div>--%>

        <div class="form-inline" style="padding: 10px">
            <div class="form-group">
                  <asp:LinkButton ID="tbUploadexcell_Click" runat="server" CssClass="btn btn-primary" OnClick="Uploadexcell_Click"  ><span class="glyphicon glyphicon-upload" aria-hidden="true"></span> Uploadexcel</asp:LinkButton>
                </div>
            </div>
        <div class="form-inline" style="padding: 10px">
            <div class="form-group">
                        <label>รหัสสิบหลัก :</label>
                        <asp:TextBox ID="TxItemcode" runat="server" CssClass="form-control"></asp:TextBox>       
           </div>
            <div class="form-group">
                    <label>ชื่ออุปกรณ์ :</label>
                   <asp:TextBox ID="TxItemname" runat="server" CssClass="form-control"></asp:TextBox>
                  <asp:LinkButton ID="lbtnSearchItemname" runat="server" CssClass="btn btn-primary" OnClick="lbtnsearch_Itemname" ><span class="glyphicon glyphicon-search" aria-hidden="true"></span> ค้นหา</asp:LinkButton>
           </div>
              <div class="form-group">
             <asp:label ID="TXsearch" runat="server"></asp:label>
           </div>
            </div>
         <div class="form-inline" style="padding: 10px">
            <div class="form-group">
                        <label>กลุ่ม/ประเภท :</label>
                        <asp:DropDownList ID="ddlstockgroup" CssClass="form-control" runat="server"></asp:DropDownList>
                 <asp:LinkButton ID="lbtnmodelAddnamestockgroup" runat="server" CssClass="btn btn-primary" OnClick="lbtnOpenAddnamestockgroup"> เพิ่มกลุ่ม</asp:LinkButton>
           </div>

          </div>
          <div class="form-inline" style="padding: 10px">
                <div class="form-group">
                        <label>จำนวน :</label>
               <asp:TextBox ID="Txamount" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
            <div class="form-group">
                         <label>หน่วยนับ</label>
                          <asp:DropDownList ID="ddlunit" runat="server" CssClass="form-control" >
                           <asp:ListItem Text="---- เลือก ----" ></asp:ListItem>
                           <asp:ListItem Text="ตัว" Value="ตัว"></asp:ListItem>
                           <asp:ListItem Text="เมตร" Value="เมตร"></asp:ListItem>
                            </asp:DropDownList>
           </div>
           <div class="form-group">
                        <label>ช่องเก็บ :</label>
                        <asp:TextBox ID="Txstorage_number" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
              </div>
           <div class="form-inline" style="padding: 10px">
            <div class="form-group">
                        <label>หมายเหตุ :</label>
                        <asp:TextBox ID="Txremark" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
        </div>
        <div class="form-inline" style="padding: 10px">
             <div class="form-group">
           <%--<div style="text-align: right; margin-top: 10px">--%>
             <asp:LinkButton ID="lbtnAdd" runat="server" CssClass="btn btn-success" OnClick="lbtAddstock_Click"><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span> บันทึก</asp:LinkButton>
                  <asp:LinkButton ID="lbtncancel" runat="server" CssClass="btn btn-danger" OnClick="lbtncancelstock"><span class="glyphicon glyphicon-remove-circle" aria-hidden="true"></span> ยกเลิก</asp:LinkButton>
           <%--</div>--%>
                 </div>
        </div>
  <%--//----------------------------------------- add-------------------------------------------------//--%>
        <div class="modal fade" id="Addnamestockgroup" role="dialog" style="border-radius:10px">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header text-center" style="padding: 35px 50px; background-color: #59d042; color: white">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3>เพิ่มชื่อกุล่ม</h3>
                </div>
                <div class="modal-body" style="padding: 40px 50px;">            
                    <label>ชื่อกลุ่ม</label>
                    <asp:TextBox ID="txt_Groupname" runat="server" CssClass="form-control"></asp:TextBox>
                   
                    <div class="text-right">
                        <asp:LinkButton ID="lbtAddnamestockgroup" runat="server" CssClass="btn btn-success" onclick="Addnamestockgroup" ><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span> บันทึก</asp:LinkButton>
                        <asp:LinkButton ID="lbtnAddcancelAddnamestockgroupr" runat="server" CssClass="btn btn-danger"><span class="glyphicon glyphicon-remove-circle" aria-hidden="true"></span> ยกเลิก</asp:LinkButton>
                    </div>
                </div>               
            </div>
        </div>
    </div>
<%--        <div style="padding: 10px">
            <asp:Table ID="tblMachine" runat="server" Width="100%" height="300" CssClass="display" CellSpacing="0" >
                <asp:TableHeaderRow TableSection="TableHeader">
                    <asp:TableHeaderCell>อันดับ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>เบอร์เครื่องทอ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รุ่นเครื่อง</asp:TableHeaderCell>
                    <asp:TableHeaderCell>รุ่นอิแปะ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>กระสวยหน้าเครื่อง</asp:TableHeaderCell>
                    <asp:TableHeaderCell>ความยาวหน้า-หลัง</asp:TableHeaderCell>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <div style="text-align: right; margin-top: 10px">
                <%--<asp:LinkButton ID="lbtnOpenAdd" runat="server" CssClass="btn btn-success" OnClick="lbtnOpenAdd_Click"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span> เพิ่มเครื่องทอ</asp:LinkButton>--%>
            <%--</div>
        </div>--%>
        <%--    <div style="padding: 10px">
               <h3 class="text-center"></h3>
                  <h3 class="text-left">ข้อมูลรุ่นอีแปะเครื่องทอ   </h3> 
                  <h3><asp:label ID="label_mcepeanumber" runat="server" ></asp:label></h3>
                    <asp:Table ID="tbmcepeanumber" runat="server" Width="100%" CssClass="display" CellSpacing="0">
                        <asp:TableHeaderRow TableSection="TableHeader">
                            <asp:TableHeaderCell>ชื่อรุ่นอีแปะ</asp:TableHeaderCell>
                            <asp:TableHeaderCell></asp:TableHeaderCell>  
                            <asp:TableHeaderCell></asp:TableHeaderCell>                        
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <div style="text-align: right; margin-top: 10px">                    
                       <%--<asp:LinkButton ID="lbtnOpenAddmcepeanumber" runat="server" CssClass="btn btn-success" OnClick="lbtnOpenAddmcepeanumber_Click"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span> เพิ่มรุ่นอีแปะ</asp:LinkButton>
                    </div> 
              </div>--%>
    </section>
</asp:Content>

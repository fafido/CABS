<%@ Page Title="Dividend Payment Authorization" Language="VB" MasterPageFile="~/EscrowshareMaster.master" AutoEventWireup="false" CodeFile="DividendPaymentAuthorize.aspx.vb" Inherits="DividendPayAuthorize_New" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 47px;
        }
        .auto-style2 {
            width: 68px;
        }
        .auto-style3 {
            width: 74px;
        }
        .chosen-container{
                width: 100% !important;
          }
        .auto-style4 {
           /*background-color:#F16E20;*/
           background-image:linear-gradient(to bottom, #F16E20, #F16E20);
           color:white;
        }
         .auto-style5 {
           /*background-color:#F16E20;*/
           font-family:Arimo, Helvetica, Arial, sans-serif;
           background-image:linear-gradient(to bottom, #ffffff, #ffffff); 
           text-shadow:none; 
           color:#F16E20;
           font-weight:bold;
           border: thin solid #005AA9;
        }
         .auto-style6 {
           /*background-color:#F16E20;*/
           font-family:Arimo, Helvetica, Arial, sans-serif;
           font-weight:bold;
           background-image:linear-gradient(to bottom, #F16E20, #F16E20); 
           text-shadow:none; 
           box-shadow:none; 
           color:white;
        }
         .auto-style7 {
           /*background-color:#F16E20;*/
           font-family:Arimo, Helvetica, Arial, sans-serif;
        }
          .auto-style8 {
           background-image:linear-gradient(to bottom,#eeeeee,#eeeeee);
           font-family:Arimo, Helvetica, Arial, sans-serif;
           color:#777777;
           font-weight:bold;
           height: 24px;
        }
           .auto-style9 {
           font-family:Arimo, Helvetica, Arial, sans-serif;
           background-image:linear-gradient(to bottom, #ffffff, #ffffff);
           text-shadow:none;
           color:#005AA9;
           font-weight:bold;
           width:160px;
        }
           .auto-style10 {
           text-align:right;
        }
        .auto-style11 {
            background-image: linear-gradient(to bottom, #4CAF50, #4CAF50);
            color: white;
            font-weight:bold;
            font-family:Arimo, Helvetica, Arial, sans-serif;
            text-shadow:none;
            border: thin solid #4CAF50;
            cursor:pointer;
        }
        .auto-style12 {
            background-image: linear-gradient(to bottom, #F44336, #F44336);
            color: white;
            font-weight:bold;
            font-family:Arimo, Helvetica, Arial, sans-serif;
            text-shadow:none;
            border: thin solid #F44336;
        }
         </style>
    <script type = "text/javascript">
        function DisableButtons() {
            var inputs = document.getElementsByTagName("INPUT");
            for (var i in inputs) {
                if (inputs[i].type == "button" || inputs[i].type == "submit") {
                    inputs[i].disabled = true;
                }
            }
        }
        window.onbeforeunload = DisableButtons;
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageName" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LinkToPage" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-primary small">
         <asp:HiddenField ID="TabName" runat="server" />
            <div class="panel with-nav-tabs panel-primary" id="Tabs" style="margin-bottom:0px;">
                <div class="panel-heading" style="height:35px;">
                        <ul class="nav nav-tabs" style="height:35px;">
                            <li class="active" style="height:35px;margin-top:-23px;"><a href="#tab1ClientInformationUpdates" data-toggle="tab">Dividend Payment Authorization</a></li>
                        </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content" style="margin-bottom:-10px">
                        <div class="tab-pane fade in active" id="tab1DividendRepaymentAuthorization">
                             <div class="row label-info auto-style8" style="margin-top:-15px;">
                                <div class="col-xs-12 control-label">
                                    
                                </div>
                              </div>
                              <div class="row">
                                 <div class="col-xs-2 control-label auto-style10">
                                    Select Batch:
                                </div>
                                  <div class="col-xs-4">
                                    <asp:DropDownList ForeColor="Black" Font-Bold="true" AutoPostBack="true" ID="cmbBatchNo" runat="server" CssClass="col-xs-12 form-control input-sm chosen" AppendDataBoundItems="true">
                                      <asp:ListItem Text="" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                             </div>
                            <div class="row" runat="server" id="div4">
                                  <div class="col-xs-2 control-label auto-style10">
                                    Debit Account No.:
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPostAccountNumber" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row label-info auto-style8" id="divCheck" runat="server" visible="true">
                                  <div class="col-xs-2 control-label auto-style10">
                                </div>
                                 <div class="col-xs-2">
                                    <asp:CheckBox runat="server" ID="chkCheckAll" AutoPostBack="true" Text="Select All"></asp:CheckBox>
                                </div>
                                <div class="col-xs-2 control-label auto-style10">
                                   Total Amount:
                                </div>
                                <div class="col-xs-1">
                                    <asp:Button  CssClass="auto-style5  btn-sm" Visible="false" ID="btnGetTotalAmount" runat="server" Text=">>" />
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtTotalAmount" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                             </div>
                            <div class="row label-info auto-style8" id="div3" runat="server" visible="true">
                                <div class="col-xs-2 control-label auto-style10">
                                   Total Records Selected:
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtTotalAmount1" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                             </div>
                            <div class="row">
                                <div class="col-xs-12 center-block">
                                    <asp:Panel ID="dfPanel" runat="server" ScrollBars="Both" Height="300px">
                                        <asp:GridView ID="repGrpMembers1" Visible="true" runat="server" AutoGenerateColumns="true"
                                            HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                                            EmptyDataText="" EmptyDataRowStyle-CssClass="text-warning text-center">
                                            <AlternatingRowStyle CssClass="altrowstyle" />
                                            <HeaderStyle CssClass="header info" />
                                            <RowStyle CssClass="rowstyle" />
                                            <PagerStyle CssClass="pagination-ys" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkSelectToPost" runat="server" AutoPostBack="false" OnCheckedChanged="ChkSelectToPost_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Select" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblShareholder" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CDS Number")%>'></asp:Label>
                                                        <asp:Label ID="lblAMOUNT" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'></asp:Label>
                                                        <asp:Label ID="lblRecordID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                            </div>
                             <div class="row label-info auto-style8">
                                  <div class="col-xs-2 control-label auto-style10">
                                      
                                </div>
                                 <div class="col-xs-2">
                                     <asp:Button  CssClass="auto-style11  btn-sm" ID="btnAuthorize" runat="server" Text="Authorize" UseSubmitBehavior="false"/>
                                 </div>
                                  <div class="col-xs-2">
                                     <asp:Button  CssClass="auto-style12  btn-sm" ID="btnDiscard" runat="server" Text="Discard"/>
                                 </div>
                                 <div class="col-xs-2">
                                     <asp:Button  CssClass="auto-style12  btn-sm" ID="btnCancel" runat="server" Text="Cancel"/>
                                 </div>
                             </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "tab1DividendRepaymentAuthorization";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
          $(function () {
            $("[id*=btnAuthorize]").bind("click", function () {
                $("[id*=btnAuthorize]").val("posting...");
                $("[id*=btnAuthorize]").attr("disabled", true);
            });
        });
    </script>
</asp:Content>


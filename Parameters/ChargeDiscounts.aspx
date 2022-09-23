<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ChargeDiscounts.aspx.vb" Inherits="TransferSec_ChargesDiscounts" title="Charge Discounts setup" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/jquery.quicksearch.js"></script>
    <script type="text/javascript">
    $(function () {
        $('input#txtSearch').quicksearch('table#table_example tbody tr');
    });
</script>
  <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Cambria" BackColor="White" GroupingText="Charge Discounts setup">
       <table>
           <tr id="Tr1" runat="server">
                <td colspan="4">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel0a" runat="server">
                <td  style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel110" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Type" Theme="Glass">
                    </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                </td>
                <td style="width: 212px">
                    <dx:ASPxComboBox ID="cmbParticipantType" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                        <Items>
                            <dx:ListEditItem Text="" Value="" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
           <tr id="Tr4" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                         <input type="text" name="search" value="" id="txtSearch" style="width:250px;" autocomplete="off" placeholder="" />
                    </td>
           </tr>
           <tr id="Panel0a0001" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant" Theme="Glass">
                    </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                </td>
               <td style="width: 212px">
          <asp:Panel ID="dfPanel" runat="server" ScrollBars="Vertical" Visible="False">
            <asp:Repeater ID="grdParticipants" runat="server">
                <HeaderTemplate>
       <table style="margin-left: 10px; font-family:Cambria; font-size:x-small" id="table_example">
           <thead>
                <tr>
                    <th>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </th>
                    <th align="left">
                        <asp:Label ID="Label5" runat="server" Text="Code"></asp:Label>
                    </th>
                    <th align="left">
                        <asp:Label ID="Label7" runat="server" Text="Names"></asp:Label>
                    </th>
                    <th id="Th1" runat="server" visible="false">
                    </th>
                </tr>
            </thead>
            <tbody>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td>
                       <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack ="true"  OnCheckedChanged="chkSelect_CheckedChanged"/>
                    </td>
                    <td>
                        <asp:Label ID="lblCompany_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Company_Code")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCompany_name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Company_name")%>'></asp:Label>
                    </td>
                    <td id="tbHide" runat="server" visible="false">
                         <asp:Label ID="lblChargeCd" runat="server" Text='<%# Eval("ChargeCd") %>' Visible="false"></asp:Label>
                         <asp:Label ID="lblDiscountCd" runat="server" Text='<%# Eval("DiscountCd") %>' Visible="false"></asp:Label>
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
           </asp:Panel>
               </td>
            </tr>
           <tr id="Panel13a" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Discount On" Theme="Glass">
                    </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbChargeCode" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                  </tr>
           <tr id="Panel8b" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Discount Type" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <asp:RadioButtonList ID="rdbIndicator" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                            <asp:ListItem Text="%" Value="%"></asp:ListItem>
                            <asp:ListItem Text="Flat" Value="Flat"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
           <tr id="Tr3" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Percentage/Amount" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtPercAmount" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
           </tr>
           <tr id="Tr5" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry Date" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                         <dx:ASPxDateEdit ID="txtExpiryDate" runat="server" EditFormat="Custom" EditFormatString="dd MMMM yyyy" Theme="BlackGlass" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
           </tr>
           <tr id="PanelSAVE" runat="server">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnSaveDiscount" runat="server" Text="Save" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
           <tr id="panelUPDATE" runat="server" visible="false">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnUpdateDiscount" runat="server" Text="Update" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
           <tr id="panel00002" runat="server">
              <td colspan="4" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="List of all Discounts" Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
           <tr id="panel00003" runat="server">
                <td style="height: 18px;"></td>
                <td colspan="4" style="height: 18px">
                    <dx:ASPxGridView ID="grdChargesCreated" runat="server" AutoGenerateColumns="true" OnRowCommand="grdChargesCreated_RowCommand" KeyFieldName="ID" Theme="Glass" Width="840px">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Edit" CommandName="Select" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Delete"  OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Discount On">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ParticipantType") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Charge Desc">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ChargeDesc") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Percentage/Amount" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("PercAmount1") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Indicator" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Indicator") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Expiry Date" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ExpiryDate1") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr> 
           <tr id="Tr2" runat="server">
                 <td style="width:208px"></td>
            </tr>
            <tr id="Tr2w" runat="server">
                 <td style="width:208px"></td>
            </tr>
        </table> 
      </asp:Panel>
</asp:Content>


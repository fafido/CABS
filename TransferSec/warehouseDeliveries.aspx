<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="warehouseDeliveries.aspx.vb" Inherits="TransferSec_warehouseDeliveries" title="Warehouse Delivery" %>



<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRibbon" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width="100%" >
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Securities&gt;&gt;Warehouse Deposits" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="100%">

             <tr>
               
  <td  align="right" style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Warehouse Deposits" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label1" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbDeliveriestemp" runat="server" Height="22px" ValueType="System.String" Width="250px" AutoPostBack="True">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr runat="server" visible="false">
                <td colspan ="1" align="right" style="width:170px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientNoSe" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton1" CausesValidation="false" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass" style="height: 23px">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr  runat="server" visible="false">
                <td colspan ="1" align="right" >
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name/CNIC No/UIN No/Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" CausesValidation="false" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr  runat="server" visible="false">
                    <td colspan ="1"></td>
                <td colspan ="4">
                    <dx:ASPxListBox ID="lstNames" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="485px">
                    </dx:ASPxListBox>
                    </td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Holder Basic Details">

                <table width="100%">
<tr>
        <td colspan ="1" style="width:170px">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientID" runat="server" Theme="BlackGlass" Width="250px" enabled="false" >
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC No./ UIN No." Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td>
        <dx:ASPxTextBox ID="txtIdNo" runat="server" Theme="BlackGlass" Width="250px"  Height="19px" enabled="false" >
        </dx:ASPxTextBox>
        </td>

</tr>
                    
                    <tr>
                            <td style="width: 170px;" colspan="1">
                                <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtSurnames" runat="server" enabled="false" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>

                            <td colspan="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtForenames" runat="server"  enabled="false" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1" style="width:170px">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtmobile" runat="server" Height="19px" enabled="false" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel7" Font-Names="Cambria" GroupingText="Warehouse Deposits Details" Font-Size="Medium">

                <table width="100%">
<tr>
        
    <td>
        <br />
         
        <table class="auto-style1">
             <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label6" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbwarehouse" runat="server" enabled="false" AutoPostBack="True" Height="22px" ValueType="System.String" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxComboBox>
              <%--  </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Market Value(Estimate)" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label10" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtmarketvalue" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>--%>
            </tr>
            <tr>
                <td  style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Commodity" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbCompanySelect" Font-Names="Cambria"  enabled="false" runat="server" Height="22px" ValueType="System.String" Width="250px" AutoPostBack="True">
                    </dx:ASPxComboBox>
                </td>
               <%-- <td>
                    <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Compatiment No" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtCompatimentNo" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>--%>
            </tr>
           
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Unit Measure" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label3" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxComboBox ID="txtmeasurement"  Font-Names="Cambria" runat="server" enabled="false" AutoPostBack="True" Height="22px" ValueType="System.String" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxComboBox>
                </td>
               <%-- <td>
                    <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Shed No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtShelfNo" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>--%>
            </tr>
            <tr >
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label4" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtreceiptquantity" runat="server" Enabled="false" Height="19px" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
              <%--  <td>
                    <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lot No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtLotNumber" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>--%>
            </tr>
            <%--<tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label5" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxDateEdit ID="txtexpiry" runat="server" Theme="Glass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxDateEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel43" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Marks" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtmarks" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>--%>
           
      <%--      <tr>
                <td style="width: 167px; height: 27px;">
                    <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Silo No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px">
                    <dx:ASPxTextBox ID="txtsiloNo" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 27px">
                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Box No" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px">
                    <dx:ASPxTextBox ID="txtBoxNo" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 27px"></td>
            </tr>--%>
         <%--   <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Harvest Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxDateEdit ID="txtharvestdate" runat="server" Theme="Glass" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
<%--            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Packaging" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label7" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtpackaging" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Packages" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label9" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtpackages" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                              <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>--%>
           <%-- <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Wastage" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtwastage" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Charge" Theme="Glass">
                    </dx:ASPxLabel>
                    <asp:Label ID="Label8" runat="server" Font-Size="X-Small" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtother" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>--%>
            <tr>
             <%--   <td style="width: 167px">--%>
              <%--      <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Upload GRN (If any)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>--%>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel45" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Harvest Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>

                     <dx:ASPxTextBox ID="txtharvestdate" runat="server" Enabled="false" Height="19px" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="1">
                    <dx:ASPxButton ID="btnView" runat="server" Text="Save" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                 <td align="center" colspan="2">
                    <dx:ASPxButton ID="btnreject" runat="server" Text="Reject" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="5">&nbsp;</td>
            </tr>
        </table>
            </tr>
            <tr>
                <td align="center" colspan="5">&nbsp;</td>
            </tr>
        </table>
               
        </td>
   

</tr>
                 
                   
                 
        </table>
        </asp:Panel>

         <asp:Panel runat="server" ID="Panel4" visible="false" Font-Names="Cambria" GroupingText="Deposits" Font-Size="Medium">

                <table width="100%">
<tr>
        
    <td align="center">
        <dx:ASPxGridView ID="ASPxGridView3" runat="server" KeyFieldName="ID" Settings-ShowTitlePanel="true" SettingsText-Title="Deposits" Theme="Glass" Width="100%">
            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
            <SettingsPager Visible="False">
            </SettingsPager>
            <Settings ShowTitlePanel="True" />
            <SettingsText Title="Deposits" />
            <SettingsPopup>
                <EditForm AllowResize="True" Modal="True" />
            </SettingsPopup>
            <SettingsCommandButton>
                <SelectButton Text="Select">
                </SelectButton>
            </SettingsCommandButton>
        </dx:ASPxGridView>
    </td>
   

</tr>
                 
                    <tr>
                        <td align="center">
                            <dx:ASPxButton ID="btnSaveContract0" runat="server" Text="view" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                 
                    <tr>
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                 
        </table>
        </asp:Panel>
         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Portfolio Details" Font-Size="Medium" Visible="False">

                <table width="100%">
                    <tr>
                            
                        <td colspan ="8" align="center">
                            <dx:ASPxGridView ID="grdPortfolios" Width ="650px" runat="server" Theme="Aqua">
                            </dx:ASPxGridView>
                            <br />
                            <dx:ASPxGridView ID="grdunsettled" runat="server" Caption="PENDING TRADES" Theme="Aqua" Visible="False" Width="650px">
                            </dx:ASPxGridView>
                            <br />
                            <br />
                            <br />
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" Caption="Bonds" Theme="Glass" Visible="False" Width="640px">
                                <SettingsPager Visible="False">
                                </SettingsPager>
                            </dx:ASPxGridView>
                            </td>

                    </tr>
                
<tr>
        
    <td colspan ="8" align="center">
        <dx:ASPxLabel ID="lblCashBal" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass" Visible="False">
        </dx:ASPxLabel>
        <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Clear Screen" Theme="BlackGlass">
        </dx:ASPxButton>
    </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel6" Font-Names="Cambria" GroupingText="Movement Summaries" Font-Size="Medium" Visible="False">

                <table width="100%">
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="________________" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7"></td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDateEdit ID="txtBatchDate" runat="server" Theme="Aqua" Width="150px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDateEdit ID="txtBatchDate0" runat="server" Theme="Aqua" Width="150px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                           <td colspan ="8" align ="center">
                               <dx:ASPxButton ID="ASPxButton3" runat="server" Text="View" Theme="BlackGlass"></dx:ASPxButton>

                           </td>
                    </tr>
                    <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxGridView ID="rdMovements" runat="server" Theme="Aqua" Width="800px">
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Print Statement" Theme="BlackGlass" style="height: 23px"></dx:ASPxButton>
                            
                        </td>

                    </tr>
                   
                 
        </table>
        </asp:Panel>
        
</asp:Panel>
  
</div>
</asp:Content>



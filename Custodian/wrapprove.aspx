<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="wrapprove.aspx.vb" Inherits="wrapprove" title="Warehouse Receipt Approval" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRibbon" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Securities&gt;&gt;Warehouse Receipt Approval" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="100%">
            <tr>
                <td colspan ="1" style="width:170px" align="right">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txtClientNoSe" runat="server" Theme="Glass" Width="300px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass" style="height: 23px" Visible="False">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Warehouse Receipt" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" >
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="4">
                    <dx:ASPxListBox ID="lstNames" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="485px">
                    </dx:ASPxListBox>
                    </td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td ></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Holder Basic Details" >

                <table width="100%">
<tr>
        <td colspan ="1" style="height: 24px;width:170px">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1" style="height: 24px">
        <dx:ASPxTextBox ID="txtClientID" ReadOnly="True" runat="server" Theme="BlackGlass" Width="250px" >
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1" style="height: 24px">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC No./ UIN No." Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td style="height: 24px">
        <dx:ASPxTextBox ID="txtIdNo"  ReadOnly="True" runat="server" Theme="BlackGlass" Width="250px"  Height="19px">
        </dx:ASPxTextBox>
        </td>

</tr>
                    
                    <tr>
                            <td colspan="1">
                                <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtSurnames" runat="server" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>

                            <td colspan="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtForenames" runat="server" ReadOnly="True" style="margin-top: 0px" Theme="BlackGlass" Width="250">
                                </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td style="font-size: small">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="3">
                            <dx:ASPxTextBox ID="txtmobile" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="Panel8" runat="server" Font-Names="Cambria" GroupingText="Deposit Details" Font-Size="Medium">
                  <table >
<tr>
        
    <td>
        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Height="22px" style="margin-bottom: 0px" ValueType="System.String" Visible="False" Width="250px">
        </dx:ASPxComboBox>
        <br />
        <table style="width:100%">
            <tr>
                <td style="width: 198px">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Deposits" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" Height="22px" ValueType="System.String" Width="250px" AutoPostBack="True">
                    </dx:ASPxComboBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Product" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtproduct" runat="server" AutoPostBack="True" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px; height: 27px;">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px; width: 344px;">
                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" ReadOnly="True" AutoPostBack="True" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 27px">
                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse Accreditation No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px">
                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 27px"></td>
            </tr>
            
             <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Unit Measure" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxComboBox ID="ASPxComboBox3" ReadOnly="true" runat="server" AutoPostBack="True" Height="22px" ValueType="System.String" Width="250px">
                      
                    </dx:ASPxComboBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lot No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtLotNumber" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr >
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="ASPxTextBox3" ReadOnly="true" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                       
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Shed/Silo" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbshedsilo" ReadOnly="true" runat="server" AutoPostBack="True" Height="22px" Width="250px">
                      
                    </dx:ASPxComboBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxDateEdit ID="ASPxDateEdit1" ReadOnly="true" runat="server" Theme="Glass" Width="250px">
                      
                    </dx:ASPxDateEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Silo No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtsiloNo" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                       
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Declared Market Value" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtmarketvalue" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                     
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel43" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Marks" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtmarks" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
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
            <tr>
                <td style="width: 167px; height: 27px;">
                    <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Packaging" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px; width: 344px;">
                    <dx:ASPxComboBox ID="txtpackaging" ReadOnly="true" runat="server" AutoPostBack="True" Height="22px" Width="250px">
                        <Items>
                            <dx:ListEditItem Text="Bulk" Value="Bulk" />
                            <dx:ListEditItem Text="Bags" Value="Bags" />
                        </Items>
                      
                    </dx:ASPxComboBox>
                </td>
                <td style="height: 27px">
                    <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Weight Per Unit" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px">
                    <dx:ASPxTextBox ID="txtweight" ReadOnly="true" runat="server" AutoPostBack="True" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 27px"></td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Packages" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtpackages" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel53"  runat="server" Font-Names="Cambria" Font-Size="Small" Text="Storage Charge (PKR/Day/MT)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtcharge" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                      
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Wastage" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtwastage" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                     
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Charge" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtother" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                       
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Deposit Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxDateEdit ID="txtdeliverydate" ReadOnly="true" runat="server" Theme="Glass" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel45" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Harvest Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxDateEdit ID="ASPxDateEdit2" ReadOnly="true" runat="server" Theme="Glass" Width="250px">
                       <%-- <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>--%>
                    </dx:ASPxDateEdit>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Remarks" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtremarks" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
            
            <tr>
                <td style="width: 198px">
                    <dx:ASPxLabel ID="ASPxLabel21" runat="server" Visible="False" Font-Names="Cambria" Font-Size="Small" Text="Expiry" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Insurance Expiry" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Visible="False" Font-Size="Small" Text="Insurance Company" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
                    </dx:ASPxTextBox>
                    <dx:ASPxTextBox ID="txtinsrancecompany" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
                    </dx:ASPxTextBox>
                    <dx:ASPxDateEdit ID="ASPxDateEdit3" runat="server" Theme="Glass" Width="250px" Visible="False" ReadOnly="True">
                    </dx:ASPxDateEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse Operator" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Visible="False" Text="Insurance Policy Ref" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtwarehouseoperator" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
                    </dx:ASPxTextBox>
                    <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" Height="19px" ReadOnly="True" Visible="False" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td></td>
            </tr>
                     </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel7" Font-Names="Cambria" GroupingText="Warehouse Receipt Details" Font-Size="Medium">

                <table width="100%">

<tr>
        
    <td>
      
        <table style="width:100%">
            <tr>
                <td style="height: 26px;width:179px">
                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Commodity" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 26px;width:180px" >
                    <dx:ASPxComboBox ID="cmbCompanySelect" runat="server"  ReadOnly="True" Height="22px" ValueType="System.String" Width="250px" AutoPostBack="True">
                    </dx:ASPxComboBox>
                </td>
                <td align="left" style="padding-left:50px" valign="top" rowspan="13">
                  
                    <dx:ASPxGridView ID="ASPxGridView4" SettingsBehavior-AllowSort="false"  runat="server" KeyFieldName="Contract No." Settings-ShowTitlePanel="true" SettingsText-Title="Receipts" Theme="Glass">
                        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                        <SettingsPager Mode="ShowAllRecords"  >
                        </SettingsPager>
                        <Settings ShowTitlePanel="True" />
                        <SettingsText Title="Grading" />
                        <SettingsPopup>
                            <EditForm AllowResize="True" Modal="True" />
                        </SettingsPopup>
                        <SettingsCommandButton>
                            <SelectButton Text="Select">
                            </SelectButton>
                        </SettingsCommandButton>
                    </dx:ASPxGridView>
                </td>
                <td align="left" rowspan="13" valign="top">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 179px">
                    <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Receipt No" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtreceiptno" runat="server"  ReadOnly="True"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px" >
                    <dx:ASPxLabel ID="ASPxLabel38" runat="server"   Font-Names="Cambria" Font-Size="Small" Text="Warehouse Operator" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtwarehouse" runat="server"  ReadOnly="True"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px" >
                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtwarehousephysical" runat="server"  ReadOnly="True"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px" >
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Receipt Quantity" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtreceiptquantity" runat="server"  ReadOnly="True"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px" >
                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Grade" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtgrade" runat="server"   ReadOnly="True" Height="19px" Theme="BlackGlass" Width="250px" >
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px" >
                    <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxDateEdit ID="txtexpiry" runat="server"  ReadOnly="True" Theme="Glass" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
            </tr>
            <tr>
                <td style="width: 179px" >
                    <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Current Price" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtcurrentprice" runat="server"  ReadOnly="True"  Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px" >
                    <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Insurance Policy" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtpolicy" runat="server"   ReadOnly="True" Height="19px" Theme="BlackGlass" Width="250px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px" >
                    <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria"  Font-Size="Small" Text="Insurance Expiry" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtinsuranceexpiry" runat="server"   ReadOnly="True" Height="19px" Theme="BlackGlass" Width="250px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px">
                    <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Harvest Date" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtharvestdate" runat="server"   ReadOnly="True" Height="19px" Theme="BlackGlass" Width="250px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px" >&nbsp;</td>
                <td>
                    <dx:ASPxComboBox ID="cmbSecurities" runat="server" Height="22px"  style="margin-bottom: 0px" ValueType="System.String" Visible="False" Width="250px">
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td style="width: 179px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </td>
   

</tr>
                 
                   
                 
        </table>
        </asp:Panel>

         <br />
        <table class="auto-style1">
            <tr>
                <td align="center">
                    <dx:ASPxButton ID="btnView" runat="server" Text="Approve" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;<dx:ASPxButton ID="btnView0" runat="server" Text="Reject" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:TextBox ID="TextBox1" runat="server" Height="63px" TextMode="MultiLine" Visible="False" Width="289px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Created Warehouse Receipts" Font-Size="Medium">

                <table width="100%">
<tr>
        
    <td align="left">
        <table>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtsearch" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxButton ID="btnsearch" runat="server" Text="Search" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </td>
   

</tr>
                 
                    <tr>
                        <td align="center">
                            <dx:ASPxGridView ID="ASPxGridView3" runat="server" KeyFieldName="ID" Settings-ShowTitlePanel="true" SettingsText-Title="Receipts" Theme="Glass" Width="100%">
                                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                <SettingsPager Visible="True">
                                </SettingsPager>
                                <Settings ShowTitlePanel="True" />
                                <SettingsText Title="Receipts" />
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
                             <dx:ASPxCheckBox ID="chkPrintInfoCopy" runat="server" Text="Print Information Copy" Theme="Aqua">
                            </dx:ASPxCheckBox>
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


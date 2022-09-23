<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AddNewDerivContract.aspx.vb" Inherits="AddNewDerivContractt" title="Derivatives" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFormLayout" tagprefix="dx" %>

   



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

   



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>

   



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>

   



<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Derivatives&gt;Add New Contract" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Derivatives">

                <table width="810px">
                    <tr>
                            <td colspan ="6" align ="center">
                                &nbsp;</td>

                    </tr>
                    <tr>
                            <td colspan ="1" style="width: 387px; height: 23px;">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Contract No." Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="2" style="width: 63px; height: 23px;">
                            <dx:ASPxTextBox ID="txtContractNo" runat="server" Theme="Glass" Width="250px" ReadOnly="False">
                            </dx:ASPxTextBox>
                            </td>
                       
                        <td colspan ="1" style="width: 334px; height: 23px;">
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Contract Type" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxComboBox ID="cmbContrType" runat="server" Height="23px" Width="250px">
                                <Items>
                                    <dx:ListEditItem Text="Call Option" Value="Options Call" />
                                
                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan="1" style="width: 334px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" style="font-weight: 700" Text="Writer" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td style="width: 63px">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Visible="False">
                                <asp:ListItem Selected="True">Individual</asp:ListItem>
                                <asp:ListItem>Corporate</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="width: 63px">&nbsp;</td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" style="font-weight: 700" Text="Holder" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Visible="False">
                                <asp:ListItem Selected="True">Individual</asp:ListItem>
                                <asp:ListItem>Corporate</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Writer" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td style="width: 63px">
                            <dx:ASPxTextBox ID="txtSearchName" runat="server" Theme="Glass" Width="250px" Visible="False">
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 63px">
                            <dx:ASPxButton ID="btnSearchName" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="38px" Visible="False">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Holder" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtSearchName0" runat="server" Theme="Glass" Width="250px" Visible="False">
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnSearchName0" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="38px" Visible="False">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                            <td colspan ="1" style="width: 387px">
                                &nbsp;</td>
                        <td colspan ="2" style="width: 63px">
                            <dx:ASPxListBox ID="lstNames" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="293px" Visible="False">
                            </dx:ASPxListBox>
                            </td>
                        <td colspan ="1" style="width: 334px">
                            &nbsp;</td>
                        <td colspan ="2">
                            <dx:ASPxListBox ID="lstNames0" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Visible="False" Width="293px">
                            </dx:ASPxListBox>
                            </td>
                       


                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reg Number" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtWIDNo" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtWEmail" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Writer " Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtWforename" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Phone No." Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtWPhone" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px; height: 32px;">
                            <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Writer Full Name" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px; height: 32px;">
                            <dx:ASPxTextBox ID="txtWsurname" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px; height: 32px;">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Writer Address" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="height: 32px">
                            <dx:ASPxTextBox ID="txtWaddress" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                       
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Writer CDS No." Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtWCds" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Holder Address" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtHaddress" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px" Visible="False">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            &nbsp;</td>
                        <td colspan="2" style="width: 63px">
                            &nbsp;</td>
                        <td colspan="1" style="width: 334px">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px; height: 27px;">
                            <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Phone No." Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px; height: 27px;">
                            <dx:ASPxTextBox ID="txtHPhone" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Visible="False" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px; height: 27px;">
                            <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="height: 27px">
                            <dx:ASPxTextBox ID="txtHEmail" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Width="250px" Visible="False">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            &nbsp;</td>
                        <td colspan="2" style="width: 63px">
                            &nbsp;</td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Holder CDS No." Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtHCds" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Width="250px" Visible="False">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel45" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Holder Surname" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtHsurname" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Visible="False" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel43" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Holder Forenames" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtHforename" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Visible="False" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ID No." Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtHIDNo" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Visible="False" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">&nbsp;</td>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Details" Theme="Glass" style="font-weight: 700">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            &nbsp;</td>
                        <td colspan="1" style="width: 334px">&nbsp;</td>
                        <td colspan="2">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Name" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="cmbassetname" runat="server" Height="23px" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Description" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtAssetDesc" runat="server" Theme="Glass" Width="250px" Height="23px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Location" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtAssetLocation" runat="server" Height="23px" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Quality" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtAssetQuality" runat="server" Height="23px" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px; height: 28px;">
                            <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Type" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px; height: 28px;">
                            <dx:ASPxComboBox ID="cmbassettype" runat="server" Height="24px" Width="250px">
                                
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan="1" style="width: 334px; height: 28px;">
                            <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Strike Price" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="height: 28px">
                            <dx:ASPxTextBox ID="txtStrikePrice" runat="server" Height="23px" Theme="Glass" Width="250px" AutoPostBack="True">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Quantity" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtAssetQuantity" runat="server" AutoPostBack="True" Height="23px" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Settlement Date" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxDateEdit ID="dtpSettlementDate" runat="server" Height="23px" Width="250px">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px; height: 27px;">
                            <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Units" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px; height: 27px;">
                            <dx:ASPxTextBox ID="txtAssetUnits" runat="server" Height="23px" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px; height: 27px;">
                            <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Units in" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="height: 27px">
                            <dx:ASPxComboBox ID="ASPxComboBox1" runat="server">
                                <Items>
                                    <dx:ListEditItem Text="Barrels" Value="Barrels" />
                                       <dx:ListEditItem Text="Troy Ounces" Value="Troy Ounces" />
                                    <dx:ListEditItem Text="Pounds" Value="Pounds" />
                                    <dx:ListEditItem Text="Gallons" Value="Gallons" />
                                    <dx:ListEditItem Text="Tonnes" Value="Tonnes" />
                                    <dx:ListEditItem Text="Bushels" Value="Bushels" />
                                    <dx:ListEditItem Text="Thermal Units" Value="Thermal Units" />

                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Contract Value" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtAssetValue" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">
                            <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxDateEdit ID="dtpMaturityDate" runat="server" Height="23px" Width="250px">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenor" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtAssetValue0" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 334px">&nbsp;</td>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px; height: 80px;">
                            <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Comments" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px; height: 80px;">
                            <dx:ASPxMemo ID="txtTermsCond" runat="server" Height="71px" Width="320px">
                            </dx:ASPxMemo>
                        </td>
                        <td colspan="1" style="width: 334px; height: 80px;"></td>
                        <td colspan="2" style="height: 80px"></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">&nbsp;</td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxButton ID="btnSaveContract" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1" style="width: 334px">&nbsp;</td>
                        <td colspan="2">&nbsp;</td>
                       
                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px; width: 387px;">
                            </td>
                        <td colspan ="5" style="height: 18px">
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Glass" KeyFieldName="Contract No." Settings-ShowTitlePanel ="true" SettingsText-Title ="Derivatives" Width="640px">
                                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                <SettingsPager Visible="False">
                                </SettingsPager>
                                <Settings ShowTitlePanel="True" />
                                <SettingsText Title="Derivatives" />
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
                        <td colspan="1" style="height: 18px; width: 387px;">&nbsp;</td>
                        <td colspan="5" style="height: 18px">
                            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Derivatives Contract" ShowCollapseButton="True" ShowMaximizeButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" ShowRefreshButton="True" Theme="Office2003Blue" Width="718px">
        <contentcollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" ShowHeader="False" Theme="Office2003Blue" Width="100%">
        <panelcollection>
            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                <table class="dxflInternalEditorTable_Moderno" style="width: 100%">
                    <tr>
                        <td align="left" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="DERIVATIVE CONTRACT" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            &#160;</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="Writer Name" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="ASPxTextBox10" runat="server" DisplayFormatString="n" Theme="iOS" Width="280px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel59" runat="server" Text="Writer CDS" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" DisplayFormatString="n" Theme="iOS" Width="280px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel58" runat="server" Text="Writer Phone" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" DisplayFormatString="n" Theme="iOS" Width="280px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel55" runat="server" Text="Underlying Asset" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" DisplayFormatString="n" Theme="iOS" Width="280px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Security Code" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" DisplayFormatString="n" Theme="iOS" Width="280px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Contract Size" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Theme="iOS" Width="280px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 23px; width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Tick Size" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left" style="height: 23px">
                            <dx:ASPxTextBox ID="ASPxTextBox11" runat="server" Theme="iOS" Width="280px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Exercise Style" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" Theme="iOS" Width="280px">
                               
                                <masksettings mask="$&lt;0..99999g&gt;.&lt;00..99&gt;" />
                               
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Exercise Price" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                             <dx:ASPxSpinEdit ID="ASPxSpinEdit2" runat="server" DisplayFormatString="C" Theme="iOS" Width="170px">
                           </dx:ASPxSpinEdit>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel56" runat="server" Text="Type" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" Theme="iOS" Width="280px">
                                      <masksettings mask="$&lt;0..99999g&gt;.&lt;00..99&gt;" />                         
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel57" runat="server" Text="Settlement Date" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" Theme="iOS">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 230px">
                            <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Expiry Date" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" Theme="iOS">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style7" valign="top">
                            &nbsp;</td>
                        <td align="left" class="auto-style8">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style5"></td>
                        <td align="left">
                            <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Save" Theme="iOS" Width="161px">
<clientsideevents click="function(s, e) {
	lpanel.Show();
	e.processOnServer = true;
}"></clientsideevents>
</dx:ASPxButton>

                            <br />

                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style5" colspan="2">
                            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CONTRACT" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
                            <CR:CrystalReportSource ID="CONTRACT" runat="server">
                                <Report FileName="Reporting\contract.rpt">
                                </Report>
                            </CR:CrystalReportSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <br />
                            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lpanel" Modal="True" Text="Saving&amp;hellip;" Theme="iOS">
                            </dx:ASPxLoadingPanel>
                            <br />

                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">&nbsp;</td>
                    </tr>
                </table>
            </dx:PanelContent>
        </panelcollection>
    </dx:ASPxRoundPanel>
            </dx:PopupControlContentControl>
</contentcollection>
    </dx:ASPxPopupControl>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="1" style="width: 387px"></td>
                        <td colspan ="5" align="center">
                            <dx:ASPxButton ID="btnSaveContract0" runat="server" Text="view" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="1" style="width: 387px">
                            &nbsp;</td>
                        <td colspan ="5">
                            &nbsp;</td>

                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>


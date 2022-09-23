<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="allwr.aspx.vb" Inherits="allwr" title="View All Receipts" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRibbon" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;View All Receipts" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Created Warehouse Receipts" Font-Size="Medium">

                <table style="width:100%" >
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

                <table >
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

                <table >
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


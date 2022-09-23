<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OTCTrading.aspx.vb" Inherits="TransferSec_OTCTrading" title="OTC" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;O.T.C" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="PanelType" Font-Names="Cambria" GroupingText="Orders">

            <table width ="810px">
                <tr>
                        <td colspan ="1">
                            <asp:RadioButton ID="rdSingle" runat="server" GroupName="enquiryType" Text="Buy" />
                        </td>
                    <td colspan ="1">
                        <asp:RadioButton ID="rdSingle0" runat="server" GroupName="enquiryType" Text="Sell" />
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Text="Company" Theme="Glass">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="Glass" Width="200px">
                        </dx:ASPxComboBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Text="Security" Theme="Glass">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="cmbCompany0" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel81" runat="server" Font-Names="Cambria" Text="Clearing House" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="cmbCompany1" runat="server" Theme="Glass" ValueType="System.String" Width="200px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel82" runat="server" Font-Names="Cambria" Text="Contracts" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="cmbCompany3" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
               </tr>
                  <tr>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1" align="center"> 
                        
                      </td>
                      <td colspan ="1">
                          <dx:ASPxLabel ID="ASPxLabel83" runat="server" Font-Names="Cambria" Text="Contract Type" Theme="Glass">
                          </dx:ASPxLabel>
                      </td>
                      <td colspan="1">
                          <dx:ASPxComboBox ID="cmbCompany4" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                          </dx:ASPxComboBox>

                      </td>
                      <td colspan ="1"></td>
                      <td colspan ="1"></td>
                    
               </tr>
                
                        <tr>
                            <td colspan="8">
                                <asp:Panel ID="PanelEft" runat="server" Font-Names="Cambria" GroupingText="Client Details">
                                    <table>
                                    <tr>
                                        <td colspan ="6" align="center">
                                            <asp:RadioButton ID="rdSelf" runat="server" GroupName="MakerRep" Text="Self represented" />
                        <asp:RadioButton ID="rdBroker" runat="server" GroupName="MakerRep" Text="Broker represented" />
                                        </td>
                                    </tr>
                                        <tr>
                                                <td colspan ="1">
                                                    <dx:ASPxLabel ID="ASPxLabel84" runat="server" Font-Names="Cambria" Text="Client ID." Theme="Glass">
                                                    </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxTextBox ID="txtClientNo19" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                                </td>
                                            <td colspan ="1">&nbsp;</td>
                                            <td colspan ="1">&nbsp;</td>
                                            <td colspan ="1">
                                                <dx:ASPxLabel ID="ASPxLabel85" runat="server" Font-Names="Cambria" Text="Client Name" Theme="Glass">
                                                </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxTextBox ID="txtClientNo20" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                                </td>

                                        </tr>
                                        <tr>
                                                <td colspan ="1">
                                                    <dx:ASPxLabel ID="ASPxLabel86" runat="server" Font-Names="Cambria" Text="Client Broker" Theme="Glass">
                                                    </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxComboBox ID="cmbCompany2" runat="server" Theme="Glass" ValueType="System.String" Width="250px">
                                                </dx:ASPxComboBox>
                                                </td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>

                                        </tr>
                                        <tr>
                                                <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>

                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                </tr>
                 <tr>
                            <td colspan="8">
                                <asp:Panel ID="Panel2" runat="server" Font-Names="Cambria" GroupingText="Trade Details">
                                    <table>
                                    <tr>
                                        <td colspan ="6" align="center">
                                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="TradeDetails" Text="Market Order" />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="TradeDetails" Text="Limit Order" />
                                            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="TradeDetails" Text="Stop Loss" />
                                            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="TradeDetails" Text="Stop Limit" />
                                        </td>
                                    </tr>
                                        <tr>
                                                <td colspan ="1">
                                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Text="Quantity" Theme="Glass">
                                                    </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                                </td>
                                            <td colspan ="1">&nbsp;</td>
                                            <td colspan ="1">&nbsp;</td>
                                            <td colspan ="1">
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Text="Price/Unit" Theme="Glass">
                                                </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                                </td>

                                        </tr>
                                        <tr>
                                                <td colspan ="1">
                                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Text="Commerncing Date" Theme="Glass">
                                                    </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" Theme="Aqua" Width="250px">
                                                </dx:ASPxDateEdit>
                                                </td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1">
                                                <dx:ASPxLabel ID="ASPxLabel87" runat="server" Font-Names="Cambria" Text="Expiry Date" Theme="Glass">
                                                </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" Theme="Aqua" Width="250px">
                                                </dx:ASPxDateEdit>
                                                </td>

                                        </tr>
                                        <tr>
                                                <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>

                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                </tr>
                <tr>
                            <td colspan="8">
                                &nbsp;</td>
                </tr>
                        <tr>
                <td colspan ="8">
                    &nbsp;</td>
               
           </tr>
              
                <tr>
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Save Order" Theme="BlackGlass" Width="163px">
                    </dx:ASPxButton>
                    </td>
               
           </tr>

            </table>
        </asp:Panel>
         
                 
</asp:Panel>
  
</div>
</asp:Content>


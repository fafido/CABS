<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="MarketMakerApplication.aspx.vb" Inherits="TransferSec_MarketMakerApplication" title="OTC" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Market Makers" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="PanelSearch" Font-Names="Cambria" GroupingText="Maker Search">
        <table>
                <tr>
                        <td colspan ="3">
                            <dx:ASPxLabel ID="ASPxLabel88" runat="server" Font-Names="Cambria" Text="Client ID" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="4">
                        <dx:ASPxTextBox ID="txtClientNo21" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxButton ID="ASPxButton8" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="80px">
                        </dx:ASPxButton>
                        </td>

                </tr>
            <tr>
                        <td colspan ="3">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Text="Client Name" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="4">
                        <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="80px">
                        </dx:ASPxButton>
                        </td>

                </tr>

        </table>

</asp:Panel>
        <asp:Panel runat="server" ID="MakerDetails" Font-Names="Cambria" GroupingText="Maker Details">

            <table>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel89" runat="server" Font-Names="Cambria" Text="Client Surname" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel91" runat="server" Font-Names="Cambria" Text="Other Names" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                   <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel90" runat="server" Font-Names="Cambria" Text="Client ID." Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel92" runat="server" Font-Names="Cambria" Text="Email" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox12" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                   <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel93" runat="server" Font-Names="Cambria" Text="Mobile No." Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox13" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel94" runat="server" Font-Names="Cambria" Text="Telephone" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox14" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>

            </table>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Maker Clearing Arrangement">

            <table>
                <tr>
                        <td colspan ="8" align ="center">
                            <asp:RadioButton ID="RadioButton7" runat="server" GroupName="ClearingArragement" Text="Self Clearing" />
                            <asp:RadioButton ID="RadioButton8" runat="server" GroupName="ClearingArragement" Text="Agent Clearing" />
                        </td>

                </tr>
                <tr>
                    <td colspan ="8" align="left">
                        <dx:ASPxCheckBox ID="SettlementBank" runat="server" Text="Add new clearing instructions for transaction" Theme="RedWine">
                        </dx:ASPxCheckBox>
                    </td>
                </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Text="Bank" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Text="Branch" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="ASPxComboBox3" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                   <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Text="Account Number" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox11" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
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
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>

            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="TradingTypes" Font-Names="Cambria" GroupingText="Securities And Contracts">

            <table>

                <tr>

                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel95" runat="server" Font-Names="Cambria" Text="Company" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="ASPxComboBox4" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel96" runat="server" Font-Names="Cambria" Text="Security Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="ASPxComboBox5" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>

                    <td colspan ="1" style="height: 18px">
                        &nbsp;</td>
                    <td colspan ="1" style="height: 18px">
                        &nbsp;</td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px">
                        <dx:ASPxLabel ID="ASPxLabel98" runat="server" Font-Names="Cambria" Text="Contract Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1" style="height: 18px">
                        <dx:ASPxComboBox ID="ASPxComboBox7" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1" style="height: 18px"></td>
                    <td colspan ="1" style="height: 18px"></td>
                </tr>
                 <tr>
                            <td colspan="8">
                                <asp:Panel ID="Panel5" runat="server" Font-Names="Cambria" GroupingText="Trade Details">
                                    <table>
                                    <tr>
                                        <td colspan ="6" align="center">
                                            <asp:RadioButton ID="RadioButton9" runat="server" GroupName="TradeDetails" Text="Market Order" />
                        <asp:RadioButton ID="RadioButton10" runat="server" GroupName="TradeDetails" Text="Limit Order" />
                                            <asp:RadioButton ID="RadioButton11" runat="server" GroupName="TradeDetails" Text="Stop Loss" />
                                            <asp:RadioButton ID="RadioButton12" runat="server" GroupName="TradeDetails" Text="Stop Limit" />
                                        </td>
                                    </tr>
                                        <tr>
                                                <td colspan ="1">
                                                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Text="Quantity" Theme="Glass">
                                                    </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                                </td>
                                            <td colspan ="1">&nbsp;</td>
                                            <td colspan ="1">&nbsp;</td>
                                            <td colspan ="1">
                                                <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Text="Price/Unit" Theme="Glass">
                                                </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxTextBox ID="ASPxTextBox10" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                                </dx:ASPxTextBox>
                                                </td>

                                        </tr>
                                        <tr>
                                                <td colspan ="1">
                                                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Text="Commerncing Date" Theme="Glass">
                                                    </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxDateEdit ID="ASPxDateEdit3" runat="server" Theme="Aqua" Width="250px">
                                                </dx:ASPxDateEdit>
                                                </td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1"></td>
                                            <td colspan ="1">
                                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Text="Expiry Date" Theme="Glass">
                                                </dx:ASPxLabel>
                                                </td>
                                            <td colspan ="1">
                                                <dx:ASPxDateEdit ID="ASPxDateEdit4" runat="server" Theme="Aqua" Width="250px">
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

                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                        <td colspan ="8" align ="center">
                            <dx:ASPxButton ID="ASPxButton9" runat="server" Text="save" Theme="BlackGlass" Width="80px">
                            </dx:ASPxButton>
                        </td>

                </tr>
            </table>
        </asp:Panel>

                 
</asp:Panel>
  
</div>
</asp:Content>


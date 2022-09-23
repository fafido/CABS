<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AddNewTresuryBills.aspx.vb" Inherits="AddNewTreasuryBill" title="Treasury Bills" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table style="width: 868px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Treasury Bills&gt;Add New TB" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Treasury Bills" Width="846px">

                <table width="810px">
                    <tr>
                            <td align="left" colspan ="2" align ="center" style="height: 18px">
                                <table class="dxflInternalEditorTable">
                                    <tr>
                                        <td style="width: 118px">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">
                                            <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issuer" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbIssuer" runat="server" Height="23px" Width="250px">
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Series" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtSeries" runat="server" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">
                                            <dx:ASPxLabel ID="ASPxLabel43" runat="server" Font-Names="Cambria" Font-Size="Small" Text="TB Type" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbtbtype" runat="server" Height="23px" Width="250px" AutoPostBack="True">
                                                <Items>
                                                    <dx:ListEditItem Text="4 Week Bill" Value="4 Week Bill" />
                                                    <dx:ListEditItem Text="13 Week Bill" Value="13 Week Bill" />
                                                    <dx:ListEditItem Text="26 Week Bill" Value="26 Week Bill" />
                                                    <dx:ListEditItem Text="52 Week Bill" Value="52 Week Bill" />
                                                    <dx:ListEditItem Text="Cash Management Bill" Value="Cash Management Bill" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Face Value" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtFaceValue" runat="server" AutoPostBack="True" Height="23px" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">
                                            <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Multiples" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbmultiples" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                                                <Items>
                                                    <dx:ListEditItem Text="One Thousand" Value="1000" />
                                                    <dx:ListEditItem Text="Ten Thousand" Value="10000" />
                                                    <dx:ListEditItem Text="Hundred Thousand" Value="100000" />
                                                    <dx:ListEditItem Text="One Million" Value="1000000" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="No. of Notes" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtNoofNotes" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">
                                            <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Interest Rate (%)" Theme="Glass" ToolTip="Discount Percentage For Non Competitive Bids">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtDiscountYield" runat="server" AutoPostBack="True" Height="23px" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issue Price" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtIssuePrice" runat="server" Height="23px"  Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">
                                            <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issue Date" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="txtIssueDate" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="txtMaturityDate" runat="server" AutoPostBack="True" Height="23px" Width="250px" ReadOnly="True">
                                            </dx:ASPxDateEdit>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 27px; width: 118px;">
                                            <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenure(Days)" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="height: 27px">
                                            <dx:ASPxTextBox ID="txtTenure" runat="server" Height="23px" ReadOnly="True" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td style="height: 27px"></td>
                                        <td style="height: 27px">
                                            <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ISIN" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="height: 27px">
                                            <dx:ASPxTextBox ID="txtisin" runat="server" AutoPostBack="True" Height="23px" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 27px; width: 118px;">
                                            <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mode" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td colspan="4" style="height: 27px">
                                            <table class="dxflInternalEditorTable_Aqua" style="width: 38%">
                                                <tr>
                                                    <td>
                                                        <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" AutoPostBack="True" Text="Non-Competitive" Theme="Aqua">
                                                        </dx:ASPxCheckBox>
                                                    </td>
                                                    <td>
                                                        <dx:ASPxCheckBox ID="ASPxCheckBox2" runat="server" AutoPostBack="True" Text="Competitive" Theme="Aqua">
                                                        </dx:ASPxCheckBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 27px; width: 118px;">
                                            <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Format" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="height: 27px" colspan="4">
                                            <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" EnableTheming="True" RepeatDirection="Horizontal" Theme="Default">
                                                <Items>
                                                    <dx:ListEditItem Text="First Price Auction" Value="FP" />
                                                    <dx:ListEditItem Text="Multiple Price Auction" Value="MP" />
                                                </Items>
                                            </dx:ASPxRadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 27px; width: 118px;">
                                            <dx:ASPxLabel ID="ASPxLabel45" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Minimum Bid" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="height: 27px">
                                            <dx:ASPxTextBox ID="txtminimum" runat="server" Height="23px" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td style="height: 27px">&nbsp;</td>
                                        <td style="height: 27px">
                                            <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maximum Bid" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="height: 27px">
                                            <dx:ASPxTextBox ID="txtmaximum" runat="server" Height="23px" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">
                                            <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td colspan="4">
                                            <dx:ASPxMemo ID="txtDesc" runat="server" Height="71px" Width="369px">
                                            </dx:ASPxMemo>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">&nbsp;</td>
                                        <td colspan="4">
                                            <asp:Panel ID="Panel6" runat="server" GroupingText="Non Competititve Settings">
                                                <table class="dxflInternalEditorTable_Metropolis">
                                                    <tr>
                                                        <td style="width: 145px; height: 18px"></td>
                                                        <td style="height: 18px"></td>
                                                        <td style="height: 18px"></td>
                                                        <td style="height: 18px"></td>
                                                        <td style="height: 18px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 145px">
                                                            <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Opening Auction Date" Theme="Glass">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxDateEdit ID="txtNC_openingdate" runat="server" AutoPostBack="True" Height="21px" Width="140px">
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Closing Auction Date" Theme="Glass">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxDateEdit ID="txtNC_closingdate" runat="server" AutoPostBack="True" Height="21px" Width="140px">
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 145px">
                                                            <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Auction Open Time" Theme="Glass">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTimeEdit ID="txtNC_openingtime" runat="server" Height="21px" Width="140px">
                                                            </dx:ASPxTimeEdit>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Auction Close Time" Theme="Glass">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTimeEdit ID="txtNC_closingtime" runat="server" Height="21px" Width="140px">
                                                            </dx:ASPxTimeEdit>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <br />
                                            <asp:Panel ID="Panel7" runat="server" GroupingText="Competititve Settings">
                                                <table class="dxflInternalEditorTable_Metropolis">
                                                    <tr>
                                                        <td style="width: 145px; height: 18px"></td>
                                                        <td style="height: 18px"></td>
                                                        <td style="height: 18px"></td>
                                                        <td style="height: 18px"></td>
                                                        <td style="height: 18px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 145px">
                                                            <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Opening Auction Date" Theme="Glass">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxDateEdit ID="txtC_openingdate" runat="server" AutoPostBack="True" Height="21px" Width="140px">
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Closing Auction Date" Theme="Glass">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxDateEdit ID="txtC_closingdate" runat="server" AutoPostBack="True" Height="21px" Width="140px">
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 145px">
                                                            <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Auction Open Time" Theme="Glass">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTimeEdit ID="txtC_openingtime" runat="server" Height="21px" Width="140px">
                                                            </dx:ASPxTimeEdit>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Auction Close Time" Theme="Glass">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTimeEdit ID="txtC_closingtime" runat="server" Height="21px" Width="140px">
                                                            </dx:ASPxTimeEdit>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">&nbsp;</td>
                                        <td colspan="4">
                                            <dx:ASPxButton ID="btnSaveTB" runat="server" Text="Save Treasury Bill" Theme="BlackGlass">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px; width: 118px;"></td>
                                        <td colspan="4" style="height: 18px">
                                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" Caption="Treasury Bills" Theme="Metropolis" Width="640px">
                                                <SettingsPager Visible="False">
                                                </SettingsPager>
                                            </dx:ASPxGridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1" style="width: 486px; height: 18px;">
                            </td>
                        <td style="width: 63px; height: 18px;">
                            </td>
                       


                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px; height: 23px;">
                        </td>
                        <td style="width: 63px; height: 23px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan ="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                        

                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                            <td colspan ="1" style="width: 486px">
                                &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                       


                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                            &nbsp;</td>
                        <td style="width: 63px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px; height: 18px;">
                        </td>
                        <td style="height: 18px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">
                        </td>
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 486px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>


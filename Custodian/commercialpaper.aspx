<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="commercialpaper.aspx.vb" Inherits="Commercialpaper" title="Commercial Paper" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table style="width: 868px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Commercial Paper&gt;Add Commercial Paper" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Commercial Paper" Width="846px">

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
                                            <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ISIN" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtisin" runat="server" AutoPostBack="True" Height="23px" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
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
                                            <dx:ASPxTextBox ID="txtIssuePrice" runat="server" Height="23px" Theme="Glass" Width="250px">
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
                                            <dx:ASPxDateEdit ID="txtMaturityDate" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                                            </dx:ASPxDateEdit>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 27px; width: 118px;">
                                            <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenure(Days)" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="height: 27px">
                                            <dx:ASPxTextBox ID="txtTenure" runat="server" Height="23px" Theme="Glass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td style="height: 27px"></td>
                                        <td style="height: 27px">
                                            &nbsp;</td>
                                        <td style="height: 27px">
                                            &nbsp;</td>
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
                                            <asp:Panel ID="Panel6" runat="server" GroupingText="Commercial Paper Settings">
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px">&nbsp;</td>
                                        <td colspan="4">
                                            <dx:ASPxButton ID="btnSaveTB" runat="server" Width="176px" Text="Save Commercial Paper" Theme="BlackGlass" Height="21px">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px; width: 118px;"></td>
                                        <td colspan="4" style="height: 18px">
                                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" Caption="Commercial Paper" Theme="Metropolis" Width="640px">
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


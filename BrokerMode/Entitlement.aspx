<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Entitlement.aspx.vb" Inherits="BrokerMode_Entitlement" title="Entitlements" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Trades Export File Generation" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
      <%--      <tr>
                    <td style="width: 187px">
                        <asp:Label id="Label8" runat="server" Text="Trade Date From" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td style="width: 223px">
                            <BDP:BasicDatePicker id="BasicDatePicker1" runat="server" ReadOnly="True">
                            </BDP:BasicDatePicker>
                        </td>
                            <td style="width: 166px">
                                <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                                    Text="Trade Date To"></asp:Label>
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 248px">
                                        <BDP:BasicDatePicker id="BasicDatePicker2" runat="server" ReadOnly="True">
                                        </BDP:BasicDatePicker>
                                        </td>
                </tr>                --%>
                <tr><td colspan="5">
                    <asp:GridView ID="grdData1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="850px">
                            <Columns>
                                <asp:BoundField DataField="Investor Code" HeaderText="INVESTOR CODE" />
                                <asp:BoundField DataField="LASTNAME" HeaderText="LASTNAME" />
                                <asp:BoundField DataField="FIRSTNAME" HeaderText="FIRSTNAME" />
                                <asp:BoundField DataField="CUSTODIAN" HeaderText="CUSTODIAN" />
                                <asp:BoundField DataField="INVESTORTYPE" HeaderText="INVESTOR TYPE" />
                                <asp:BoundField DataField="COUNTRY" HeaderText="COUNTRY" />
                                <asp:BoundField DataField="TAX EXEMPT" HeaderText="TAX EXEMPT?" />
                                <asp:BoundField DataField="REGISTRATION ID" HeaderText="REGISTRATION ID" />
                                <asp:BoundField DataField="ADDRESS 1" HeaderText="ADDRESS 1" />
							    <asp:BoundField DataField="ADDRESS 2" HeaderText="ADDRESS 2" />
								<asp:BoundField DataField="BUSINESS PHONE" HeaderText="BUSINESS PHONE" />
								<asp:BoundField DataField="HOME PHONE" HeaderText="HOME PHONE" />
                                <asp:BoundField DataField="MOBILE PHONE" HeaderText="MOBILE PHONE" />
								<asp:BoundField DataField="EMAIL" HeaderText="E-MAIL" />
								<asp:BoundField DataField="SWIFT ADDRESS" HeaderText="SWIFT ADDRESS" />
									<asp:BoundField DataField="BANK NAME" HeaderText="BANK NAME" />
										<asp:BoundField DataField="BRANCH NUMBER" HeaderText="BRANCH NUMBER" />
											<asp:BoundField DataField="BRANCH NAME" HeaderText="BRANCH NAME" />
												<asp:BoundField DataField="BANK ACCOUNT" HeaderText="BANK ACCOUNT NUMBER" />
                                                	<asp:BoundField DataField="BANK ACCOUNT NAME" HeaderText="BANK ACCOUNT NAME" />
												<asp:BoundField DataField="COUNTER NAME" HeaderText="COUNTER NAME" />
												<asp:BoundField DataField="ISIN" HeaderText="ISIN" />
												<asp:BoundField DataField="QUANTITY" HeaderText="QUANTITY" />


                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </td></tr>
                <tr><td></td></tr>
                <tr>
                    <td style="width: 187px">
                        Company</td>
                        <td style="width: 223px">
                            <dx:ASPxComboBox ID="ASPxComboBox1" runat="server">
                                <Items>
                                    <dx:ListEditItem Text="OMZIL" Value="OMZIL" />
                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                            <td style="width: 166px">
                                &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                    <td style="width: 248px">
                                        &nbsp;</td>
                </tr>                
                <tr>
                    <td style="width: 187px">Date as at</td>
                    <td style="width: 223px">
                        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td style="width: 166px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 248px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 187px">
                        <asp:Label ID="Label2" runat="server" font-names="Verdana" font-size="Small" Text="File Name"></asp:Label>
                    </td>
                    <td style="width: 223px">
                        <asp:TextBox ID="txtFileName" runat="server" width="194px"></asp:TextBox>
                    </td>
                    <td style="width: 166px">
                        <asp:Label ID="lblFileloadstatus" runat="server" font-bold="True" font-names="Verdana" font-size="Small"></asp:Label>
                    </td>
                    <td></td>
                    <td style="width: 248px">
                        <asp:Label ID="Label5" runat="server" Text="1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 187px; height: 21px;">
                        &nbsp;</td>
                        <td style="width: 223px; height: 21px;">
                            <asp:Button id="btnSelect" runat="server" Text="Create File" 
                                style="width: 95px" Visible="False" />
                            <asp:Button ID="Button1" runat="server" Text="Create Entitlement" />
                    </td>
                            <td style="width: 166px; height: 21px;">
                                </td>
                                <td style="height: 21px">
                                    </td>
                                    <td style="width: 248px; height: 21px;">
                                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                                        <asp:Button ID="Button2" runat="server" Text="Button" Visible="False" />
                                        </td>
                </tr>                
            </table>
            <table>
                <tr>
                    <td colspan="2">
                       
                        </td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        </td>
                </tr>
            </table>
            <table>
            <tr>
                    <td colspan ="4" style="width: 850px; height: 18px;" align="center">
                        </td>                
                </tr>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>


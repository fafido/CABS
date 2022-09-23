<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OrderMaintenance.aspx.vb" Inherits="Trading_OrderMaintenance" title="Order Maintenance" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 230px" valign="top">
            <table>
            <tr>
                <td style="width: 573px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Orders Maintenance Form" width="842px"></asp:Label></td>
            </tr>
                
            </table>
            <table>

                <tr>
                        <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="2" style="text-align:center;"><asp:RadioButton text="Sell Order" groupname="OrderType" autopostback="true" id="rdSell" runat="server"></asp:RadioButton>
                        <asp:RadioButton text="Buy Order" groupname="OrderType" autopostback="true" id="rdBuy" runat="server"></asp:RadioButton>
                    </td>
                    <td colspan ="1" style ="text-align:center;">
                        <asp:Label ID="Label49" runat="server" Text="Company"></asp:Label>
                    </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbCompany" runat="server" autopostback="True" Height="22px" width="150px">
                        </asp:DropDownList>
                    </td>
                    <td colspan ="1">
                        <asp:Label ID="Label50" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Security Type"></asp:Label>
                    </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbSecurity" runat="server" autopostback="True" Height="22px" width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>

                    <td colspan ="1">
                        <asp:Label ID="Label47" runat="server" font-bold="False" font-names="Verdana" font-size="Small" text="Market board"></asp:Label>
                    </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbMarketboard" runat="server" Width="150px">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem>Normal Board</asp:ListItem>
                            <asp:ListItem>Odd Lot</asp:ListItem>
                            <asp:ListItem>Prompt Board</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:Label ID="Label48" runat="server" font-bold="False" font-names="Verdana" font-size="Small" text="Order Qualifier"></asp:Label>
                    </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbOrderQualifier" runat="server" Width="150px">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem Value="IOC">Immediate /Cancel Order</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                   <tr>

                    <td colspan ="1">
                        <asp:Label ID="Label46" runat="server" backcolor="Transparent" font-bold="False" font-names="Verdana" font-size="Small" width="138px">Order 
                        Preference</asp:Label>
                       </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbOrderPref" runat="server" AutoPostBack="True" width="150px">
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>L</asp:ListItem>
                        </asp:DropDownList>
                       </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <asp:Label ID="Label43" runat="server" font-bold="False" font-names="Verdana" font-size="Small" style="text-align: left; margin-top: 0px;" Text="Time in Force" width="104px"></asp:Label>
                       </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbOrderAttribute" runat="server" autopostback="True" Height="22px" width="150px">
                        </asp:DropDownList>
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
                   <tr>

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
                    
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 209px">
                        <asp:Label id="Label11" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Order Number:" width="144px" Visible="False"></asp:Label>
                    </td>
                        <td colspan="4">
                            <asp:TextBox id="txtOrderNumber" runat="server" width="300px" Visible="False"></asp:TextBox>
                            <asp:Button id="btnOrderSearch" runat="server" Text="&gt;&gt;" Visible="False" />
                    </td>
                    <td>

                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>                
                <tr>
                    <td style="width: 209px">
                        <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Number:" width="144px"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox id="txtshareholder" runat="server" width="300px"></asp:TextBox>
                        <asp:Button id="btnHolderNumSearch" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td>

                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    
                </tr>
                <tr>
                    <td style="width: 209px">
                        <asp:Label id="Label5" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Shareholder Name:"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:TextBox id="txtSearch" runat="server" style="margin-left: 2px" 
                            width="300px"></asp:TextBox>
                            <asp:Button id="btnSearchName" runat="server" Text="&gt;&gt;" />
                    </td>
                    <td>

                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan="1"></td>
                    <td colspan="5">
                        <asp:ListBox id="lstNames" runat="server" Height="67px" width="348px" 
                            autopostback="True"></asp:ListBox></td>
                    
                </tr>
                <tr>
                    <td style="width: 210px"></td>
                    <td align="right">
                        <asp:Button id="btnSelect" runat="server" Text="Select" /></td>
                    <td>

                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 210px"></td>
                    <td>
                        </td>
                    <td>

                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <table>
                    <tr>
                            <td colspan ="1">
                                <asp:Label ID="Label51" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Date Created"></asp:Label>
                            </td>
                        <td colspan ="1">
                            <BDP:BasicDatePicker ID="txtDateCreated" runat="server" Enabled="False" />
                            </td>
                        <td colspan ="1">
                            <asp:Label ID="Label44" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Target Date"></asp:Label>
                            </td>
                        <td colspan ="1">
                            <BDP:BasicDatePicker ID="txtTargetDate" runat="server" />
                            </td>
                        <td colspan ="1">
                            <asp:Label ID="Label45" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Expiry Date"></asp:Label>
                            </td>
                        <td colspan ="1">
                            <BDP:BasicDatePicker ID="txtExpiryDate" runat="server" />
                            </td>

                    </tr>
                <tr>

                        <td colspan ="1">
                            <asp:Label ID="Label6" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Order Quantity" width="112px"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtOrderShares" runat="server" autopostback="True"></asp:TextBox>
                        </td>
                    <td colspan ="1">
                        <asp:Label ID="Label3" runat="server" font-bold="False" font-names="Verdana" font-size="Small" style="text-align: left" Text="Base Price:" width="104px"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtSharePrice" runat="server" AutoPostBack="True"></asp:TextBox>
                        </td>
                    <td colspan ="1">
                        <asp:Label ID="Label8" runat="server" font-names="Verdana" font-size="Small" Text="Order Amount" width="125px"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtOrderAmount" runat="server" autopostback="True"></asp:TextBox>
                        </td>


                </tr>
                <tr>

                        <td colspan ="1">
                            <asp:Label ID="Label52" runat="server" font-names="Verdana" font-size="Small" Text="Available Shares" width="125px"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtPortfolioBalance" runat="server"></asp:TextBox>
                        </td>
                    <td colspan ="1">
                        <asp:Label ID="Label16" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Order number" width="104px"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtOrderNum" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                        </td>
                    <td colspan ="1">
                        <asp:Label ID="Label7" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Shareholder"></asp:Label>
                        </td>
                    <td colspan ="1">
                        <asp:TextBox ID="txtHolder" runat="server" ReadOnly="True"></asp:TextBox>
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
                <tr>

                        <td colspan="6" style="text-align: center;">
                            <asp:Button ID="btnPrintStatement" runat="server" Text="Save Order" width="169px" />
                            <asp:Button ID="btnClear0" runat="server" Text="Print Order Statement" />
                        </td>
                </tr>

            </table>
        </td>
    </tr>
</table>
        <br />
        <table style="width: 113%">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Company" Visible="False"></asp:Label>
                </td>
                <td style="width: 252px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 252px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 252px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label33" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Basic Fee" Visible="False"></asp:Label>
                </td>
                <td style="width: 252px">
                    <asp:TextBox ID="txtBasicCharges" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label34" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Stamp Duty" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStamp" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label36" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="M/Brokerage" Visible="False"></asp:Label>
                </td>
                <td style="width: 252px">
                    <asp:TextBox ID="txtMinBroke" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label37" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Transfer Fees" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTfees" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label39" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="V.B.C" Visible="False"></asp:Label>
                </td>
                <td style="width: 252px">
                    <asp:TextBox ID="txtValueB4" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label40" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Charges" Visible="False" width="96px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTotCharges" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 252px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label42" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Total Net Value" Visible="False" width="104px"></asp:Label>
                </td>
                <td style="width: 252px">
                    <asp:TextBox ID="TextBox13" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Text="Purchase  by:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblBuyer" runat="server" font-bold="False" font-names="Verdana" font-size="Small" Visible="False" width="99px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label38" runat="server" backcolor="Transparent" font-bold="False" font-names="Verdana" font-size="Small" Visible="False" width="96px">Sec 
                        Levy</asp:Label>
                </td>
                <td style="width: 252px">
                    <asp:TextBox ID="txtSecLevel" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label41" runat="server" backcolor="Transparent" font-bold="False" font-names="Verdana" font-size="Small" Visible="False" width="96px">Total 
                        Cost</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTotalCost" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label35" runat="server" backcolor="Transparent" font-bold="False" font-names="Verdana" font-size="Small" Visible="False" width="104px">P/Registration</asp:Label>
                </td>
                <td style="width: 252px">
                    <asp:TextBox ID="txtPReg" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label26" runat="server" backcolor="Transparent" font-bold="False" font-names="Verdana" font-size="Small" Height="16px" Visible="False" width="104px">Holder Names</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNames" runat="server" autopostback="true" Enabled="false" font-bold="True" Height="40px" ReadOnly="true" TextMode="MultiLine" Visible="False" width="148px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">&nbsp;</td>
                <td style="width: 252px" valign="top">&nbsp;</td>
                <td valign="top">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 252px">
                    <asp:Label ID="lblOrderType" runat="server" font-bold="False" font-names="Verdana" font-size="Small" style="text-align: left" Visible="False" width="104px"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 100%">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnUpdateOrder" runat="server" Text="Update Purchase Order" Visible="False" width="165px" />
                </td>
                <td>
                    <asp:Button ID="btnCancelOrder" runat="server" Text="Cancel Purchase Order" Visible="False" width="161px" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="Clear Purchase Order" Visible="False" width="167px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        </td>
        </tr>
        </table>
</asp:Panel>
</div>
</asp:Content>


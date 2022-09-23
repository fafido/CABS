<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SettlementExportFile.aspx.vb" Inherits="BrokerMode_SettlementExportFile" title="Paynet File Generation" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
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
                        Text="Settlement Export File Generation" width="848px"></asp:Label></td>
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
                <tr><td colspan="5"> <asp:GridView ID="grdData1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="850px">
                            <Columns>
                                <asp:BoundField DataField="Date" HeaderText="Date" />
                                <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                <asp:BoundField DataField="Account No" HeaderText="Account No" />
                                <asp:BoundField DataField="Account Name" HeaderText="Account Name" />
                                <asp:BoundField DataField="AMOUNT" HeaderText="Amount" />
                                <asp:BoundField DataField="Currency" HeaderText="Currency" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
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
                        </asp:GridView></td></tr>
                <tr><td></td></tr>
                <tr>
                    <td style="width: 187px">
                        <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" 
                            Text="File Name"></asp:Label>
                    </td>
                        <td style="width: 223px">
                            <asp:TextBox id="txtFileName" runat="server" width="194px"></asp:TextBox>
                        </td>
                            <td style="width: 166px">
                                <asp:Label id="lblFileloadstatus" runat="server" font-bold="True" 
                                    font-names="Verdana" font-size="Small"></asp:Label>
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 248px">
                                        <asp:Label ID="Label5" runat="server" Text="1"></asp:Label>
                                        </td>
                </tr>                
                <tr>
                    <td style="width: 187px; height: 21px;">
                        &nbsp;</td>
                        <td style="width: 223px; height: 21px;">
                            <asp:Button id="btnSelect" runat="server" Text="Create File" 
                                style="width: 95px" />
                            <asp:Button ID="Button1" runat="server" Text="Process Payment" />
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


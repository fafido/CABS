<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="TradesEFTExportFile.aspx.vb" Inherits="CDSMode_TradesEFTExportFile" title="Trades File Generation" %>

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
                        Text="Debit Order File Generation" width="848px"></asp:Label></td>
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
                                        </td>
                </tr>                
                <tr>
                    <td style="width: 187px; height: 21px;">
                        &nbsp;</td>
                        <td style="width: 223px; height: 21px;">
                            <asp:Button id="btnSelect" runat="server" Text="Create File" 
                                style="width: 95px" />
                            <asp:Button ID="Button1" runat="server" Text="debit order export" />
                    </td>
                            <td style="width: 166px; height: 21px;">
                                </td>
                                <td style="height: 21px">
                                    </td>
                                    <td style="width: 248px; height: 21px;">
                                        </td>
                </tr>                
            </table>
            <table>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        <asp:GridView ID="grdData1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="DealNo" HeaderText="DealNo" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                <asp:BoundField DataField="Company" HeaderText="Company" />
                                <asp:BoundField DataField="Account" HeaderText="Account" />
                                <asp:BoundField DataField="Branch_Code" HeaderText="Branch_Code" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        </td>
                    <td style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center" style="width: 192px">
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 192px">
                        </td>
                </tr>
            </table>
            <table>
            <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        &nbsp;</td>                
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


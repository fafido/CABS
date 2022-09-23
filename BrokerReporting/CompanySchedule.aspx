<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CompanySchedule.aspx.vb" Inherits="Reporting_CompanySchedule" title="Company Schedule" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    &nbsp;</td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top" style="height: 24px">
                        &nbsp;</td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Company" width="144px"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbCompany" runat="server" autopostback="True" 
                            width="192px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" font-names="Verdana" font-size="Small" 
                            Text="Date" width="144px"></asp:Label>
                    </td>
                    <td>
                        <BDP:BasicDatePicker ID="txtTargetDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1" style="text-align:center; height: 26px;">
                        <asp:RadioButton ID="rdAll" runat="server" font-names="Verdana" 
                            font-size="Small" GroupName="Classifiction" Text="All" Checked="True" 
                            Visible="False" />
                        <asp:Button ID="btnSelect" runat="server" Text="Print Report" />
                    </td>
                </tr>
                <tr>
                  <td colspan ="2" style ="text-align:center;">
                      &nbsp;</td>
                    
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


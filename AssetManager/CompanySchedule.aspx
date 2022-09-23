<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CompanySchedule.aspx.vb" Inherits="Reporting_CompanySchedule" title="Company Schedule" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trustee Services&gt;&gt;Company Schedule" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

    <asp:Panel id="Panel1"  runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Full Company Schedule">
    
<table >
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
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
                        <BDP:BasicDatePicker ID="txtTargetDate" runat="server" MaximumDate="" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Show Locked Securities" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1" style="text-align:center; height: 26px;">
                        <asp:RadioButton ID="rdAll" runat="server" font-names="Verdana" 
                            font-size="Small" GroupName="Classifiction" Text="All" Checked="True" 
                            Visible="False" />
                        <asp:Button ID="btnSelect" runat="server" Text="Print Report" style="height: 29px" />
                    </td>
                </tr>
                <tr>
                  <td colspan ="2" style ="text-align:center;">
                      &nbsp;</td>
                    
                </tr>
            </table>
            <table>
            <tr>
                    <td style="width: 850px" align="center">
                        &nbsp;</td>                
                </tr>
                <tr>
                    <td style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>


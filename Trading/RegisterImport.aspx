<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="RegisterImport.aspx.vb" Inherits="Trading_RegisterImport" title="Batch Receipting" %>

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
                <td style="width: 870px" align="center" colspan="2">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Company Register Import" width="824px" Height="16px"></asp:Label></td>
            </tr>
        </table>
        <table >
              <tr>
                <td colspan = "1" style="height: 18px" align ="left">&nbsp;</td>
                <td colspan = "1" style="height: 18px" align ="left">
                    &nbsp;</td>
                <td align ="left"></td>
                <td align ="left"></td>
                <td colspan ="1" style="height: 18px" align ="left">
                    &nbsp;</td>
                <td colspan ="1" style="height: 18px" align ="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan ="1">
                    <asp:Label ID="Label3" runat="server" font-names="Verdana" font-size="Small" 
                        Text="Company"></asp:Label>
                </td>
                <td colspan ="1">
                    <asp:DropDownList ID="cmbParaCompany" runat="server" width="175px">
                    </asp:DropDownList>
                </td>
                <td></td>
                <td></td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan ="1">
                    <asp:Label ID="Label6" runat="server" font-names="Verdana" font-size="Small" Text="Security Type"></asp:Label>
                </td>
                <td colspan ="1">
                    <asp:DropDownList ID="cmbParaCompany0" runat="server" width="175px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
            </tr>
              <tr>
                  <td colspan="1">
                      <asp:Label ID="Label7" runat="server" font-names="Verdana" font-size="Small" Text="File"></asp:Label>
                  </td>
                  <td colspan="1" style="text-align:center;">
                      <asp:FileUpload ID="FileUpload1" runat="server" />
                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td colspan="1">&nbsp;</td>
                  <td colspan="1">&nbsp;</td>
              </tr>
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1" style="text-align:center;">
                    <asp:Button ID="BtnDataImport" runat="server" text="Data Import" />
                </td>
                <td></td>
                <td></td>
                <td colspan ="1">&nbsp;</td>
                <td colspan ="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan ="1" align="left">&nbsp;</td>
                <td colspan ="1" align="left">
                    &nbsp;</td>
                <td align="left"></td>
                <td align="left"></td>
                <td colspan ="1" align="left">
                    </td>
                <td colspan ="1" align="left"></td>
            </tr>
            <tr>
                <td colspan ="1" style="height: 18px"></td>
                <td colspan ="1" style="height: 18px">&nbsp;</td>
                <td style="height: 18px"></td>
                <td style="height: 18px"></td>
                <td colspan ="1" style="height: 18px">&nbsp;</td>
                <td colspan ="1" style="height: 18px"></td>
            </tr>            
              <tr>
                  <td colspan="1"></td>
                  <td colspan="1"></td>
                  <td></td>
                  <td></td>
                  <td colspan="1"></td>
                  <td colspan="1"></td>
              </tr>
        </table>     
        </td>
    </tr>
</table>
        </asp:Panel>
</div>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="RiskManagementDashBoard.aspx.vb" Inherits="Parameters_RiskManagementDashBoard" title="Risk Management" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Risk Management" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

    <asp:panel id="Panel2" runat="server" GroupingText="System Access" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="SecuritiesType" Text="Attempted Failed Logins" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SecuritiesType" Text="Locked Accounts" />
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="SecuritiesType" Text="Active Accounts" />
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="SecuritiesType" Text="All Accounts" />
                </td>

            </tr>
            <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="From" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="To" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan =" 4 ">
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="_________________________" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4"></td>

            </tr>
            <tr>
                    <td colspan ="8" align="center"><dx:ASPxButton ID="ASPxButton3" runat="server" Text="Print Report"></dx:ASPxButton></td>

            </tr>
         </table>
    </asp:panel>
    <asp:panel id="Panel5" runat="server" GroupingText="Participants Credit Limit" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="SecuritiesType" Text="Exceeded Credit Limit" />
                    <asp:RadioButton ID="RadioButton6" runat="server" GroupName="SecuritiesType" Text="Failed Trades" />
                    <asp:RadioButton ID="RadioButton7" runat="server" GroupName="SecuritiesType" Text="Accounts Status" />
                </td>

            </tr>
              <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="From" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit3" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="To" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit4" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan =" 4 ">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="_________________________" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4"></td>

            </tr>
            <tr>
                    <td colspan ="8" align="center"><dx:ASPxButton ID="ASPxButton4" runat="server" Text="Print Report"></dx:ASPxButton></td>

            </tr>
         </table>
    </asp:panel>
    <asp:panel id="Panel6" runat="server" GroupingText="System Performance Watch" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:RadioButton ID="RadioButton8" runat="server" GroupName="SecuritiesType" Text="Settlement Engine Performance" />
                    <asp:RadioButton ID="RadioButton9" runat="server" GroupName="SecuritiesType" Text="Data Interfacing Engine" />
                    <asp:RadioButton ID="RadioButton10" runat="server" GroupName="SecuritiesType" Text="Efficient real-time processing" />
                    
                </td>

            </tr>
            <tr>
                    <td colspan ="8" align ="center">
                        <asp:RadioButton ID="RadioButton11" runat="server" GroupName="SecuritiesType" Text="Real-time positioning and allocation" />
                    </td>

            </tr>
              <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="From" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit5" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="To" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit6" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan =" 4 ">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="_________________________" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4"></td>

            </tr>
            <tr>
                    <td colspan ="8" align="center"><dx:ASPxButton ID="ASPxButton5" runat="server" Text="Print Report"></dx:ASPxButton></td>

            </tr>
         </table>
    </asp:panel>
    <asp:panel id="Panel7" runat="server" GroupingText="Market Watch" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:RadioButton ID="RadioButton12" runat="server" GroupName="SecuritiesType" Text="Trading Prices" />
                    <asp:RadioButton ID="RadioButton13" runat="server" GroupName="SecuritiesType" Text="Portfolio Analysis" />
                    
                    
                </td>

            </tr>
                     <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="From" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit7" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="To" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit8" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan =" 4 ">
                    <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="_________________________" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4"></td>

            </tr>
            <tr>
                    <td colspan ="8" align="center"><dx:ASPxButton ID="ASPxButton6" runat="server" Text="Print Report"></dx:ASPxButton></td>

            </tr>
         </table>
    </asp:panel>
   <asp:panel id="Panel9" runat="server" GroupingText="System Network Watch" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:RadioButton ID="RadioButton14" runat="server" GroupName="SecuritiesType" Text="Incoming Connections" />
                    <asp:RadioButton ID="RadioButton15" runat="server" GroupName="SecuritiesType" Text="Outgoing Communication" />
                    <asp:RadioButton ID="RadioButton16" runat="server" GroupName="SecuritiesType" Text="IP Ranges with valid connections" />
                    
                    
                </td>

            </tr>
                     <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="From" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit9" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan ="4" align ="right">
                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="To" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="left">
                    <dx:ASPxDateEdit ID="ASPxDateEdit10" runat="server" Theme="Aqua">
                    </dx:ASPxDateEdit>
                </td>

            </tr>
            <tr>
                <td colspan =" 4 ">
                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text="_________________________" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4"></td>

            </tr>
            <tr>
                    <td colspan ="8" align="center"><dx:ASPxButton ID="ASPxButton7" runat="server" Text="Print Report"></dx:ASPxButton></td>

            </tr>
         </table>
    </asp:panel>
     </asp:Panel>
  
</div>
</asp:Content>


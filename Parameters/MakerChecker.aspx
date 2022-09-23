<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="MakerChecker.aspx.vb" Inherits="Parameters_MakerChecker" title="System Access Times" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Transactions Authorizations" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Accounts Maintenance Maker Checker" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center" style="height: 18px">
                    </td>

            </tr>
             <tr>
                
                <td colspan ="8"align="center" >
                    <dx:ASPxRadioButton ID="rdChkOn" runat="server"   Text="Turn On" Theme="Office2003Blue" GroupName="Account Maintanance">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                <td colspan ="8" align ="center" >
                    <dx:ASPxRadioButton ID="rdChkOff" runat="server"   Text="Turn Off" Theme="Metropolis" GroupName="Account Maintanance">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>

        <asp:panel id="Panel3" runat="server" GroupingText="Batch Transactions Maker Checker" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    &nbsp;</td>

            </tr>
             <tr>
                
                <td colspan ="8"align="center" >
                    <dx:ASPxRadioButton ID="rdbatchon" runat="server"   Text="Turn On" Theme="Office2003Blue" GroupName="Batches">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                <td colspan ="8" align ="center" >
                    <dx:ASPxRadioButton ID="rdbatchoff" runat="server"   Text="Turn Off" Theme="Metropolis" GroupName="Batches">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>

        <asp:panel id="Panel4" runat="server" GroupingText="OTC Transactions Maker Checker" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    &nbsp;</td>

            </tr>
             <tr>
                
                <td colspan ="8"align="center" >
                    <dx:ASPxRadioButton ID="rdotcon" runat="server"   Text="Turn On" Theme="Office2003Blue" GroupName="OTC">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                <td colspan ="8" align ="center" >
                    <dx:ASPxRadioButton ID="rdotcoff" runat="server"   Text="Turn Off" Theme="Metropolis" GroupName="OTC">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>

        <asp:panel id="Panel5" runat="server" GroupingText="Pledge Transactions Maker Checker" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    &nbsp;</td>

            </tr>
             <tr>
                
                <td colspan ="8"align="center" >
                    <dx:ASPxRadioButton ID="rdpledgeon" runat="server"   Text="Turn On" Theme="Office2003Blue" GroupName="Pledge">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                <td colspan ="8" align ="center" >
                    <dx:ASPxRadioButton ID="rdpledgeoff" runat="server"   Text="Turn Off" Theme="Metropolis" GroupName="Pledge">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>

        <asp:panel id="Panel6" runat="server" GroupingText="Lending &amp; Borrowing Transactions Maker Checker" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    &nbsp;</td>

            </tr>
             <tr>
                
                <td colspan ="8"align="center" >
                    <dx:ASPxRadioButton ID="rdlendon" runat="server"   Text="Turn On" Theme="Office2003Blue" GroupName="Lending">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                <td colspan ="8" align ="center" >
                    <dx:ASPxRadioButton ID="rdlendoff" runat="server"   Text="Turn Off" Theme="Metropolis" GroupName="Lending">
                    </dx:ASPxRadioButton>
                 </td>
                

            </tr>
            <tr>
                
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
          
</asp:Panel>
  
</div>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="true" CodeFile="SystemAccessTimes.aspx.vb" Inherits="Parameter_SystemAccessTimes" title="System Access Times" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="System Access&gt;&gt;System Access Times" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Access Times" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    &nbsp;</td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="System Opening Time" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTimeEdit ID="ASPxTimeEdit1" runat="server" Theme="PlasticBlue">
                    </dx:ASPxTimeEdit>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="System Closing Time" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTimeEdit ID="ASPxTimeEdit2" runat="server" Theme="RedWine">
                    </dx:ASPxTimeEdit>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">&nbsp;</td>
                <td width="301">
                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="save" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

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
  
        <!--Settlement-->
       
                <asp:Panel runat="server" ID="Panel9" Font-Names="Cambria" GroupingText="System Run Time Sessions" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Glass" Width="800px">
        </dx:ASPxGridView>
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel10" Font-Names="Cambria" GroupingText="_" Font-Size="Medium" Visible="False">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        
        <dx:ASPxButton ID="ASPxButton8" runat="server" Text="save" Theme="BlackGlass">
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton9" runat="server" BackColor="#FF3300" Text="delete" Theme="RedWine">
        </dx:ASPxButton>
        
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        
</asp:Panel>
  
</div>
</asp:Content>


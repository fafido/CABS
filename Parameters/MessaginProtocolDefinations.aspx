<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="MessaginProtocolDefinations.aspx.vb" Inherits="Parameters_MessaginProtocolDefinations" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Messaging Protocols" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Messaging Protocols" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="SecuritiesType" Text="SWIFT" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SecuritiesType" Text="POSTILLION" />
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="SecuritiesType" Text="WEB SERVICES" />
                </td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    &nbsp;</td>
                <td colspan ="1" width="301">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
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
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Format Defination">

                <table width="810px">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Format Class" Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientNo" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Format Code" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientNo0" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1"></td>
    <td colspan ="1"></td>

</tr>
                    
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transaction Type" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtClientNo2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtClientNo3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
        </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Protocol Definations" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        <dx:ASPxGridView ID="ASPxGridView3" runat="server" Theme="BlackGlass" Width="800px">
        </dx:ASPxGridView>
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel8" Font-Names="Cambria" GroupingText="_" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass">
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton2" runat="server" BackColor="#FF3300" Text="delete" Theme="RedWine">
        </dx:ASPxButton>
        
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
      
        
</asp:Panel>
  
</div>
</asp:Content>


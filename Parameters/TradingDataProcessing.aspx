<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="TradingDataProcessing.aspx.vb" Inherits="Parameters_TradingDataProcessing" title="Trading Data Processing" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Trading Data Processing" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Orders Verification" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="SecuritiesType" Text="REAL TIME" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SecuritiesType" Text="INTRA DAY" />
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="SecuritiesType" Text="BATCHING" />
                </td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Start Time" Theme="Glass">
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
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="End Time" Theme="Glass">
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
                <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Orders Verification Sessions" Font-Size="Medium">

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
      

        <!--Clearing Processing-->
        <asp:panel id="Panel3" runat="server" GroupingText="Clearing Processing" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="SecuritiesType" Text="REAL TIME" />
                    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="SecuritiesType" Text="INTRA DAY" />
                    <asp:RadioButton ID="RadioButton6" runat="server" GroupName="SecuritiesType" Text="BATCHING" />
                </td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Start Time" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTimeEdit ID="ASPxTimeEdit3" runat="server" Theme="PlasticBlue">
                    </dx:ASPxTimeEdit>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="End Time" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTimeEdit ID="ASPxTimeEdit4" runat="server" Theme="RedWine">
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
                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="save" Theme="BlackGlass">
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
                <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Clearing Process Sessions" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="BlackGlass" Width="800px">
        </dx:ASPxGridView>
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel6" Font-Names="Cambria" GroupingText="_" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        
        <dx:ASPxButton ID="ASPxButton5" runat="server" Text="save" Theme="BlackGlass">
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton6" runat="server" BackColor="#FF3300" Text="delete" Theme="RedWine">
        </dx:ASPxButton>
        
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <!--Settlement-->
        <asp:panel id="Panel7" runat="server" GroupingText="Settlement Process" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="5" align ="center">
                    <asp:RadioButton ID="RadioButton7" runat="server" GroupName="SecuritiesType" Text="REAL TIME" />
                    <asp:RadioButton ID="RadioButton8" runat="server" GroupName="SecuritiesType" Text="INTRA DAY" />
                    <asp:RadioButton ID="RadioButton9" runat="server" GroupName="SecuritiesType" Text="BATCHING" />
                </td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Start Time" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTimeEdit ID="ASPxTimeEdit5" runat="server" Theme="PlasticBlue">
                    </dx:ASPxTimeEdit>
                 </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="End Time" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTimeEdit ID="ASPxTimeEdit6" runat="server" Theme="RedWine">
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
                    <dx:ASPxButton ID="ASPxButton7" runat="server" Text="save" Theme="BlackGlass">
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
                <asp:Panel runat="server" ID="Panel9" Font-Names="Cambria" GroupingText="Settlement Process Sessions" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="BlackGlass" Width="800px">
        </dx:ASPxGridView>
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel10" Font-Names="Cambria" GroupingText="_" Font-Size="Medium">

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


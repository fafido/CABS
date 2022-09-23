<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CreditRatingForm.aspx.vb" Inherits="Parameters_CreditRatingForm" title="Cash Accounts Viewer" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Lending &amp; Borrowing &gt;&gt; Credit Rating" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
         <asp:panel id="Panel4" runat="server" GroupingText="Client Details" Font-Names="Cambria">
        <table width="810px">
           
            <tr>
                <td colspan="1" align="center">
                    <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="Participant" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4" align ="center">
                    <asp:DropDownList ID="cmbParticipants" runat="server" AutoPostBack="True" Width="250px">
                    </asp:DropDownList>
                </td>
                <td colspan ="1" align ="left">
                    &nbsp;</td>
                <td colspan ="3">

                    
                   
                </td>

            </tr>
          </table>

    </asp:panel>
        <asp:panel id="Panel3" runat="server" GroupingText="Character " Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Total Score for Section" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="5">
                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>

                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="Question" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Text="Score" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Individual Weight" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="Weighted Individual" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>

            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Question." Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                
                <td colspan ="4">
                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="450px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox20" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
             <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="5" align="center">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="next &gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                 </td>
                
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="8" align="center">
                    <dx:ASPxGridView ID="grdCharacterQuestions" runat="server" Theme="BlackGlass" Width="700px">
                    </dx:ASPxGridView>
                </td>

            </tr>
         

        </table>

    </asp:panel>
        <asp:panel id="Panel5" runat="server" GroupingText="People" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Total Score for Section" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="5">
                    <dx:ASPxTextBox ID="ASPxTextBox11" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>

                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text="Question" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Text="Score" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel21" runat="server" Text="Individual Weight" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel22" runat="server" Text="Weighted Individual" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>

            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Text="Question." Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="4">
                    <dx:ASPxTextBox ID="ASPxTextBox12" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="450px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox21" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
                
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox13" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox14" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
             <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="5" align="center">
                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="next &gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                 </td>
                
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="8" align="center">
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="BlackGlass" Width="700px">
                    </dx:ASPxGridView>
                </td>

            </tr>
         

        </table>

    </asp:panel>
            <asp:panel id="Panel6" runat="server" GroupingText="Ratio Analysis" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel24" runat="server" Text="Total Score for Section" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="5">
                    <dx:ASPxTextBox ID="ASPxTextBox15" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>

                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="Question" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel32" runat="server" Text="Score" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel29" runat="server" Text="Variance" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="Individual Weight" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel27" runat="server" Text="Weighted Individual" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>

            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Text="Question." Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="3">
                    <dx:ASPxTextBox ID="ASPxTextBox16" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="450px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox22" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox19" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox17" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="ASPxTextBox18" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="45px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
             <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="5" align="center">
                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="next &gt;&gt;" Theme="BlackGlass">
                    </dx:ASPxButton>
                 </td>
                
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="8" align="center">
                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="BlackGlass" Width="700px">
                    </dx:ASPxGridView>
                </td>

            </tr>
         

        </table>

    </asp:panel>
    <asp:panel id="Panel2" runat="server" GroupingText="Assets And Liabilities" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="5">
                    <asp:RadioButton ID="rdAsset" runat="server" AutoPostBack="True" GroupName="AssetsandLiabilities" Text="Assets" />
                    <asp:RadioButton ID="rdAsset0" runat="server" AutoPostBack="True" GroupName="AssetsandLiabilities" Text="Liabilities" />
                </td>
                
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Asset/Liability" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="5">
                    <dx:ASPxTextBox ID="txtClientNo0" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="550px">
                    </dx:ASPxTextBox>
                </td>
                
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
            </tr>
             <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Value" Theme="DevEx">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="5">
                    <dx:ASPxTextBox ID="txtClientNo3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="550px">
                    </dx:ASPxTextBox>
                 </td>
                
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
            </tr>
           
        
            <tr>
                <td colspan ="1"></td>
                <td width="301">
                    <dx:ASPxButton ID="ASPxButton6" runat="server" Text="Add" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>

</asp:Panel>
  
</div>
</asp:Content>


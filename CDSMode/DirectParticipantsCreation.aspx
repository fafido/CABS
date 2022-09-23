<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="DirectParticipantsCreation.aspx.vb" Inherits="CDSMode_DirectParticipantsCreation" title="Instruments Setup" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>

        <asp:panel runat="server" ScrollBars="Auto" Font-Names="Cambria" Font-Size="Medium" GroupingText="Parameters&gt;&gt;Direct Participants Creation" BackColor="White">
        <asp:Panel runat="server" ID="panel2" Font-Names="Cambria" GroupingText="Basic Details">

            <table>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participants Name" Theme="BlackGlass">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox30" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Code" Theme="BlackGlass">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox31" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                     <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Contact Person" Theme="BlackGlass">
                            </dx:ASPxLabel>
                         </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox32" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                         </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Contact Email" Theme="BlackGlass">
                        </dx:ASPxLabel>
                         </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox33" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                         </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                     <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Contact No." Theme="BlackGlass">
                            </dx:ASPxLabel>
                         </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox34" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                         </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Cellphone" Theme="BlackGlass">
                        </dx:ASPxLabel>
                         </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox35" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                         </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                     <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="BlackGlass">
                            </dx:ASPxLabel>
                         </td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="ASPxTextBox36" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="500px">
                        </dx:ASPxTextBox>
                         </td>
                    
                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="ASPxTextBox37" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="500px">
                        </dx:ASPxTextBox>
                        </td>
                    
                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="ASPxTextBox38" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="500px">
                        </dx:ASPxTextBox>
                        </td>
                    
                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="ASPxTextBox39" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="500px">
                        </dx:ASPxTextBox>
                        </td>
                    
                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="7"></td>
                    
                </tr>
             
            </table>
        </asp:Panel>

            <asp:Panel runat="server" ID="panel1" Font-Names="Cambria" GroupingText="Banking Details">

            <table>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="BlackGlass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit6" runat="server" Theme="BlackGlass" Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch Name" Theme="BlackGlass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit10" runat="server" Theme="BlackGlass" Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Account" Theme="BlackGlass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox19" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
             </table>
        </asp:Panel>
            <asp:Panel runat="server" ID="panel3" Font-Names="Cambria" GroupingText="Cash Accounts">

            <table>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="BlackGlass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" Theme="BlackGlass" Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch Name" Theme="BlackGlass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" Theme="BlackGlass" Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Account" Theme="BlackGlass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
             </table>
        </asp:Panel>

                
<asp:Panel runat="server" ID="panel5" Font-Names="Cambria" GroupingText="__" HorizontalAlign="Center">

            <table>
               
                 <tr>
                    <td colspan ="8" align="center">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass">
                        </dx:ASPxButton>
                     </td>
                   

                </tr>
                 <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel43" runat="server" Text="__________________________">
                        </dx:ASPxLabel>
                     </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel44" runat="server" Text="__________________________">
                        </dx:ASPxLabel>
                     </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel45" runat="server" Text="__________________________">
                        </dx:ASPxLabel>
                     </td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel47" runat="server" Text="__________________________">
                        </dx:ASPxLabel>
                     </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
         
 
            </table>
        </asp:Panel>

        
    </asp:panel>
    </div>
    <meta http-equiv="Refresh" content="10" />  
    
</asp:Content>


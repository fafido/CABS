<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UpdateTransactionCharges.aspx.vb" Inherits="Enquiries_Cash_Deposits" title="Cash Deposits" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Deliverables&gt;&gt;Charges Update" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientNameSearch" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td colspan ="2"><dx:ASPxListBox ID="lstNamesSearch" AutoPostBack="true" runat="server" ValueType="System.String" Height="126px" Theme="BlackGlass" Width="519px"></dx:ASPxListBox></td>
                
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
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Trade Basic Details">

                <table width="810px">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientNo" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Commodity." Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtIDno" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Receipt" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtTitle" runat="server" Theme="BlackGlass" Width="100px" BackColor="#E4E4E4">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1"></td>
    <td colspan ="1"></td>

</tr>
                    
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtForenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Price" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                     <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Issued" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtReason" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="7" style="text-align: center">
                            <dx:ASPxLabel ID="lblCashBal0" Visible="false" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Current Balance" Theme="Glass">
                            </dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblCashBal" Visible="false" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
        </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Charges" Font-Size="Medium">

                <table width="810px">
                    <tr>
    <td colspan="1" style="height: 18px">
            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
            </dx:ASPxLabel>
            </td>
    <td colspan="1" style="height: 18px">
        <dx:ASPxTextBox ID="txtDescription" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
        </dx:ASPxTextBox>
    </td>
    <td colspan="1" style="height: 18px"></td>
    
     </tr>
                     <tr> <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    
     </tr>

                   <tr>
    <td colspan="1" style="height: 18px">
            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transaction Charge" Theme="Glass">
            </dx:ASPxLabel>
            </td>
    <td colspan="1" style="height: 18px">
        <dx:ASPxTextBox ID="txtAmount" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
        </dx:ASPxTextBox>
    </td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
     </tr>
                    <tr> <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
    <td colspan="1" style="height: 18px"></td>
     </tr>
                  
                    <tr>
                       
   
   
    
        <td colspan ="8" align ="center">
        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Save" Theme="BlackGlass" Width="50px">
        </dx:ASPxButton>
             <dx:ASPxButton ID="ASPxButton4" Visible="false" OnClick="ASPxButton4_Click" runat="server" Text="Unlock" Theme="BlackGlass" Width="50px">
        </dx:ASPxButton>
       
                        </td>
   
     
   
    
   
     </tr>
                 
        </table>
        </asp:Panel>
         
</asp:Panel>
  
</div>
</asp:Content>


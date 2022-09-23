<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Cash_Deposits_broker.aspx.vb" Inherits="Enquiries_Cash_Deposits_broker" title="Cash Deposits" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Cash Deposits" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Broker Code" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientNoSe" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Broker Name" Theme="Glass">
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
                <td colspan ="5">
                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Aqua" Width="780px">
                    </dx:ASPxGridView>
                </td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Broker Basic Details">

                <table width="810px">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Broker Code" Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientNo" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtTitle" runat="server" Theme="BlackGlass" Width="100px" BackColor="#E4E4E4" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1"></td>
    <td colspan ="1"></td>

</tr>
                    
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Broker Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtSurname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                &nbsp;</td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtForenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Visible="False" Width="710px">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="7" style="text-align: center">
                            <dx:ASPxTextBox ID="txtIDno" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Visible="False" Width="250px">
                            </dx:ASPxTextBox>
                            <dx:ASPxLabel ID="lblCashBal0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Current Balance" Theme="Glass">
                            </dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblCashBal" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
        </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Cleared Funds For Broker" Font-Size="Medium" Visible="False">

                <table width="810px">
<tr>
    <td style="height: 18px">
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Aqua" Width="780px">
            </dx:ASPxGridView>
            </td>
     </tr>
                 
        </table>
        </asp:Panel>
         
        <asp:Panel ID="Panel4" runat="server" Font-Names="Cambria" Font-Size="Medium" GroupingText="Deposit Details">
            <table width="810px">
                <tr>
                    <td colspan="1" style="height: 18px">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Deposit Amount" Theme="Glass">
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
                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <asp:CheckBox ID="chkCounter" runat="server" AutoPostBack="True" Text="Tick if deposit is specific to a counter or leave blank for global" Visible="False" />
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbCounter" runat="server" Theme="BlackGlass" ValueType="System.String" Visible="False" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1"></td>
                    <td colspan="1">
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Save" Theme="BlackGlass" Width="50px">
                        </dx:ASPxButton>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
            </table>
        </asp:Panel>
         
</asp:Panel>
  
</div>
</asp:Content>


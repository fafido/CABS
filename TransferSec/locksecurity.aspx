<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="locksecurity.aspx.vb" Inherits="Enquiries_locksecurity" title="Lock Security" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Enquiries&gt;&gt;Lock Security" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDS No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientNoSe" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass" style="height: 23px">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name/ID No/Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px">
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
                <td colspan ="4">
                    <dx:ASPxListBox ID="lstNames" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="485px">
                    </dx:ASPxListBox>
                    </td>

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
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Holder Basic Details">

                <table width="810px">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CDS No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientID" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Identification No." Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td>
        <dx:ASPxTextBox ID="txtIdNo" runat="server" Theme="BlackGlass" Width="287px" BackColor="#E4E4E4" Height="19px" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>

</tr>
                    
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="3">
                            <dx:ASPxTextBox ID="txtSurnames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="3">
                            <dx:ASPxTextBox ID="txtForenames" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="710px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="3">
                            <dx:ASPxTextBox ID="txtmobile" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="287px" ReadOnly="True">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel7" Font-Names="Cambria" GroupingText="Select Company" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td align="Left">
        <table class="auto-style1">
            <tr>
                <td style="width: 79px">&nbsp;</td>
                <td>
                    <dx:ASPxComboBox ID="cmbSecurities" runat="server" Height="22px" ValueType="System.String" Visible="False" Width="250px">
                    </dx:ASPxComboBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 79px">
                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbCompanySelect" runat="server" AutoPostBack="True" Height="22px" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 79px">&nbsp;</td>
                <td>
                    <dx:ASPxButton ID="btnView0" runat="server" Text="Lock Security" Theme="BlackGlass" Visible="False">
                    </dx:ASPxButton>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        </td>
   

</tr>
                 
                   
                 
        </table>
        </asp:Panel>

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Securities Category" Font-Size="Medium" Visible="False">

                <table width="810px">
<tr>
        
    <td align="center">
        &nbsp;</td>
   

</tr>
                 
                    <tr>
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                 
        </table>
        </asp:Panel>
         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Portfolio Details" Font-Size="Medium" Visible="False">

                <table width="810px">
                    <tr>
                            
                        <td colspan ="8" align="center">
                            <dx:ASPxButton ID="btnView" runat="server" Text="View" Theme="BlackGlass">
                            </dx:ASPxButton>
                            <dx:ASPxGridView ID="grdPortfolios" Width ="650px" runat="server" Theme="Aqua">
                            </dx:ASPxGridView>
                            <br />
                            <dx:ASPxGridView ID="grdunsettled" runat="server" Caption="PENDING TRADES" Theme="Aqua" Visible="False" Width="650px">
                            </dx:ASPxGridView>
                            <br />
                            <br />
                            <br />
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" Caption="Bonds" Theme="Glass" Visible="False" Width="640px">
                                <SettingsPager Visible="False">
                                </SettingsPager>
                            </dx:ASPxGridView>
                            </td>

                    </tr>
                
<tr>
        
    <td colspan ="8" align="center">
        <dx:ASPxLabel ID="lblCashBal" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass" Visible="False">
        </dx:ASPxLabel>
        <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Clear Screen" Theme="BlackGlass">
        </dx:ASPxButton>
    </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel6" Font-Names="Cambria" GroupingText="Movement Summaries" Font-Size="Medium" Visible="False">

                <table width="810px">
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="________________" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7"></td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDateEdit ID="txtBatchDate" runat="server" Theme="Aqua" Width="150px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDateEdit ID="txtBatchDate0" runat="server" Theme="Aqua" Width="150px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                           <td colspan ="8" align ="center">
                               <dx:ASPxButton ID="ASPxButton3" runat="server" Text="View" Theme="BlackGlass"></dx:ASPxButton>

                           </td>
                    </tr>
                    <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxGridView ID="rdMovements" runat="server" Theme="Aqua" Width="800px">
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Print Statement" Theme="BlackGlass" style="height: 23px"></dx:ASPxButton>
                            
                        </td>

                    </tr>
                   
                 
        </table>
        </asp:Panel>
        
</asp:Panel>
  
</div>
</asp:Content>


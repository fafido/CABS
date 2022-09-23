<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="transfershares.aspx.vb" Inherits="TransferSec_transfershares" title="Withdrawal" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Batching&gt;&gt;Withdrawal" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria" Visible="False">
        <table width="810px">
            <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch No." Theme="Glass">
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
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name." Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass" Visible="False">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td width="301">
                    <dx:ASPxComboBox ID="cmbBatchType" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" Visible="False">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td width="301">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Batch Details" Visible="False">

                <table width="810px">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxComboBox ID="cmbparaCompany" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
        </dx:ASPxComboBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Shares" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtBatchShares" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                                <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Share Price" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtShareprice" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Value" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtBatchValue" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 23px">
                                <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Date" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxDateEdit ID="txtBatchDate" runat="server" Theme="Aqua" Width="250px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lodger" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxTextBox ID="txtClientNo2" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>

                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 23px">
                                <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch No" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxTextBox ID="txtClientNo" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxComboBox ID="cmbBroker" runat="server" Theme="BlackGlass" ValueType="System.String" Visible="False" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>

                    </tr>
                    
                    <tr>
                            <td colspan ="1">
                                &nbsp;</td>
                        <td colspan ="7">
                            &nbsp;</td>

                    </tr>
               
                    
        </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Batching Options" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="SecuritiesType" Text="Process Batch" Checked="True" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SecuritiesType" Text="Post Batch For Processing" />
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel8" Font-Names="Cambria" GroupingText="" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        
        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="save" Theme="BlackGlass">
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton5" runat="server" Text="receipt" Theme="BlackGlass">
        </dx:ASPxButton>
        
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Primary Batch Details" Font-Size="Medium" Enabled="False">

                <table width="810px">
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="________________" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="6"></td>

                    </tr>
                             <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client ID No." Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtclientnumber" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxButton ID="ASPxButton10" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                            </dx:ASPxButton>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                    </tr>
                       <tr>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="2">
                               <asp:ListBox ID="ListBox1" runat="server" Width="447px" AutoPostBack="True"></asp:ListBox>
                           </td>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="1">&nbsp;</td>
                    </tr>
                       <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Shares Available" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtavailableshares" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Shares to withdraw" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtshares" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">
                            <dx:ASPxButton ID="ASPxButton11" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Visible="False">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                    </tr>
                    <tr>

                            <td colspan ="1">
                                &nbsp;</td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtcertno" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px" Visible="False">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxButton ID="ASPxButton6" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Visible="False">
                            </dx:ASPxButton>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                    </tr>
                
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">
                            <dx:ASPxButton ID="ASPxButton12" runat="server" Text="Add" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                
                    <tr>
                            <td colspan ="7">
                                <asp:GridView ID="grdTranShareholder" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="Black" GridLines="Vertical" Height="16px" Width="99%">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                    <AlternatingRowStyle CssClass="altrowstyle" />
                                    <Columns>
                                         <asp:BoundField DataField="name" HeaderText="Name" />
                                         <asp:BoundField DataField="cds_number" HeaderText="CDS Number" />
                                        <asp:BoundField DataField="Batch_no" HeaderText="Batch No" />
                                       
                                        <asp:BoundField DataField="Shares" HeaderText="Shares" />                                       
                                        <asp:CommandField SelectText="Edit Entry" ShowSelectButton="true" />
                                    </Columns>
                                    <HeaderStyle CssClass="headerstyle" />
                                    <RowStyle CssClass="rowstyle" />
                                </asp:GridView>
                            </td>

                    </tr>
                   
<tr>
        
    <td colspan ="7" align="center">
        &nbsp;</td>
   

</tr>
                 
        </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel9" runat="server" Enabled="False" Font-Names="Cambria" Font-Size="Medium" GroupingText="Finish">
            <table width="810px">
                <tr>
                    <td align="center" colspan="8">
                        <dx:ASPxButton ID="ASPxButton13" runat="server" Text="Save Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;
                        <dx:ASPxButton ID="ASPxButton14" runat="server" Text="Delete Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>


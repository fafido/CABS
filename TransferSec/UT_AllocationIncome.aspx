<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UT_AllocationIncome.aspx.vb" Inherits="TransferSec_UT_AllocationIncome" title="Fund Income Allocation" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trustee Services&gt;&gt;Unit Trust Fund Income Allocation" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Fund Income Allocation" Font-Names="Cambria" Visible="False">
        <table width="100%">
            <tr>
                <td colspan ="1" align="right" style="height: 23px">
                    </td>
                <td colspan ="1" width="301" style="height: 23px">
                    <dx:ASPxTextBox ID="txtClientNoSe" runat="server" Theme="Glass" Width="300px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1" style="height: 23px">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass" Visible="False">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1" style="height: 23px"></td>
                <td colspan ="1" style="height: 23px"></td>

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
        <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" GroupingText="Batch Details" Visible="False">
            <table width="810px">
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bond" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbparaCompany" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Units" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtBatchShares" runat="server"   Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Price Per Unit" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxTextBox ID="txtShareprice" runat="server"   Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Value" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxTextBox ID="txtBatchValue" runat="server"   ReadOnly="True" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxDateEdit ID="txtBatchDate" runat="server" Theme="Aqua" Width="250px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lodger" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxTextBox ID="txtClientNo2" runat="server"   Height="19px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security " Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxComboBox ID="cmbparaCompany0" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Ticker" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxTextBox ID="txtisin" runat="server"   Height="19px" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxTextBox ID="txtClientNo" runat="server"   ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 23px">&nbsp;</td>
                    <td colspan="1" style="height: 23px">&nbsp;</td>
                    <td colspan="1" style="height: 23px">&nbsp;</td>
                    <td colspan="1" style="height: 23px">&nbsp;</td>
                    <td colspan="1" style="height: 23px">&nbsp;</td>
                    <td colspan="1" style="height: 23px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="7" style="margin-left: 40px">
                        <dx:ASPxComboBox ID="cmbBroker" runat="server" Theme="BlackGlass" ValueType="System.String" Visible="False" Width="250px">
                        </dx:ASPxComboBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Batching Options" Font-Size="Medium" Visible="False">

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
        
        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="save" Theme="BlackGlass" Visible="False">
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton5" runat="server" Text="receipt" Theme="BlackGlass" Visible="False">
        </dx:ASPxButton>
        
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Fund Income Allocation" Font-Size="Medium">

                <table width="100%">
                    <tr>
                            <td colspan ="1" style="width: 205px">
                                &nbsp;</td>
                        <td colspan ="6"></td>

                    </tr>
                       <tr>

                            <td colspan ="1" style="width: 205px">
                                <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Fund" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="width: 193px">
                            <dx:ASPxComboBox ID="cmbparaCompany1" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 205px">
                            <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issued Units" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 193px">
                            <dx:ASPxTextBox ID="txtshares" runat="server" DisplayFormatString="n"   Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 205px">
                            <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount Received" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 193px">
                            <dx:ASPxTextBox ID="txtamountreceived" runat="server" AutoPostBack="True" DisplayFormatString="n" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 205px">
                            <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Current Price" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 193px">
                            <dx:ASPxTextBox ID="txtcurrentprice" runat="server"  Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 27px; width: 205px;">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Details" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 193px; height: 27px;">
                            <dx:ASPxTextBox ID="txtdescription"  runat="server"   Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 27px">
                            <dx:ASPxButton ID="ASPxButton11" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Visible="False">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1" style="height: 27px">
                            <asp:Label ID="lblid" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                        <td colspan="1" style="height: 27px"></td>
                        <td colspan="1" style="height: 27px"></td>
                        <td colspan="1" style="height: 27px"></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 27px; width: 205px;">
                            <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Cut-Off Date" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 193px; height: 27px;">
                            <dx:ASPxDateEdit ID="txtcutoff" runat="server" Theme="Aqua" Width="250px">
                            </dx:ASPxDateEdit>
                        </td>
                        <td colspan="1" style="height: 27px">&nbsp;</td>
                        <td colspan="1" style="height: 27px">&nbsp;</td>
                        <td colspan="1" style="height: 27px">&nbsp;</td>
                        <td colspan="1" style="height: 27px">&nbsp;</td>
                        <td colspan="1" style="height: 27px">&nbsp;</td>
                    </tr>
                    <tr>

                            <td colspan ="1" style="width: 205px">
                                &nbsp;</td>
                        <td colspan ="1" style="width: 193px">
                            <dx:ASPxTextBox ID="txtcertno" runat="server"   Height="19px" Theme="BlackGlass" Width="250px" Visible="False">
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
                        <td colspan="1" style="width: 205px">&nbsp;</td>
                        <td colspan="2">
                            <dx:ASPxButton ID="ASPxButton12" runat="server" Text="Allocate" Theme="BlackGlass">
                            </dx:ASPxButton>
                            &nbsp;
                            <dx:ASPxButton ID="ASPxButton15" runat="server" Text="Archive" Theme="BlackGlass" Visible="False">
                            </dx:ASPxButton>
                            &nbsp;<dx:ASPxButton ID="ASPxButton16" CausesValidation="true" runat="server" Text="Refresh" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                
                    <tr>
                            <td colspan ="7">
                                <asp:GridView ID="grdTranShareholder" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="id" EmptyDataText="No Relevant Data Found" ForeColor="#333333" GridLines="Vertical" Height="16px" Width="99%" Font-Size="Small">
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                    <AlternatingRowStyle CssClass="altrowstyle" />
                                    <Columns>
                                         <asp:BoundField DataField="id" HeaderText="Reference" />
                                         <asp:BoundField DataField="Fund" HeaderText="Fund" />
                                         <asp:BoundField DataField="Amount"  dataformatstring="{0:N}"  HeaderText="Distribution Amount" />
                                         <asp:BoundField DataField="IssuedUnits"  dataformatstring="{0:N}"  HeaderText="Issued Units" />
                                          <asp:BoundField DataField="CutOffDate" HeaderText="Cut Off" />
                                         <asp:BoundField DataField="Price"   HeaderText="Price" />  
                                          <asp:BoundField DataField="Status"  HeaderText="Staus" />  
                                                                                  <asp:BoundField DataField="CreatedBy"   HeaderText="CreatedBy" />  
                                         <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" />                                          
                                        <asp:CommandField SelectText="Edit Entry" ShowSelectButton="true" />
                                    </Columns>
                                     <EditRowStyle BackColor="White" />
                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#B7D8DC" ForeColor="Black" HorizontalAlign="left" />
                        <PagerStyle BackColor="White" ForeColor="#B7D8DC" HorizontalAlign="left" />
                        <RowStyle CssClass="rowstyle" BackColor="White" />
                        <SelectedRowStyle BackColor="#D1DDF1"  ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>

                    </tr>
                   
<tr>
        
    <td colspan ="7" align="center" style="height: 18px">
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
               
        <asp:Panel ID="Panel9" runat="server" Enabled="False" Font-Names="Cambria" Font-Size="Medium" GroupingText="Finish" Visible="False">
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


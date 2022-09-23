<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BatchAuthorizations.aspx.vb" Inherits="TransferSec_BatchAuthorizations" title="Batch Processing" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorizations&gt;&gt;Batch Authorizations" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1" align="right" style="width: 175px">
                    &nbsp;</td>
                <td colspan ="1" width="301">
                    &nbsp;</td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right" style="width: 175px">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Processed Batches" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxComboBox ID="cmbSavedBatches" runat="server" Theme="BlackGlass" ValueType="System.String" Width="300px" AutoPostBack="True" TextFormatString="{0}">
                        <Columns>
                           <dx:ListBoxColumn FieldName="Batch No" />
                            <dx:ListBoxColumn FieldName="Company" />
                            <dx:ListBoxColumn FieldName="Batch Shares" />
                            <dx:ListBoxColumn FieldName="Lodger" />
                            <dx:ListBoxColumn FieldName="Broker" />
                         
                 </Columns>
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 175px"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1" style="width: 175px"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Batch Details">

                <table width="810px">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtbatchno" runat="server" Theme="BlackGlass" Width="250px" BackColor="#E4E4E4" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Type" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtbatchtype" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
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
                                <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Shares" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtBatchShares" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Date" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtbatchdate" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtcompany" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Broker" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" ID="txtbroker">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Type" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtsecuritytype" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lodger" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtClientNo2" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Value" Theme="Glass" Visible="False">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtBatchValue" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px" Visible="False">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Share Price" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtshareprice" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Visible="False">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    
                    <tr>
                            <td colspan ="1">
                                &nbsp;</td>
                        <td colspan ="7">
                            &nbsp;</td>

                    </tr>
               
                    
        </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Primary Batch Details" Font-Size="Medium">

                <table width="810px">
                    <tr>
                            <td colspan ="1" style="height: 18px; width: 81px">
                            </td>
                        <td colspan ="7" style="height: 18px"></td>

                    </tr>
                    <tr>

                            <td colspan ="1" style="width: 81px">
                                &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                    </tr>
                
                    <tr>
                            <td colspan ="1" style="width: 81px">
                                &nbsp;</td>
                        <td colspan ="7">
                            <dx:ASPxGridView ID="grdBatchedRecords" runat="server" Theme="RedWine" Width="600px">
                            </dx:ASPxGridView>
                            </td>

                    </tr>
                   
<tr>
        
    <td colspan ="8" align="center">
        <br />
        <dx:ASPxButton ID="ASPxButton2" runat="server" Height="20px" Text="Approve" Theme="BlackGlass" Width="85px">
        </dx:ASPxButton>
        &nbsp;
        <dx:ASPxButton ID="ASPxButton3" runat="server" Height="20px" Text="Reject" Theme="BlackGlass" Width="85px">
        </dx:ASPxButton>
        <br />
    </td>
   

</tr>
                 
        </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>


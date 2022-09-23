<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Cash_Deposits.aspx.vb" Inherits="Enquiries_Cash_Deposits" title="Cash Deposits" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRibbon" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Trading&gt;&gt;Cash Transactions" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria" Visible="False">
        <table width="100%">
            <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
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
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name." Theme="Glass">
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
                <td colspan ="2"><dx:ASPxListBox ID="lstNamesSearch" AutoPostBack="true" runat="server" ValueType="System.String" Height="126px" Width="519px"></dx:ASPxListBox></td>
                
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
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Account Details" Visible="False">

                <table width="100%">
<tr>
        <td colspan ="1">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientNo" runat="server" Width="250px" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC No." Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtIDno" runat="server" Width="250px" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Title" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtTitle" runat="server" Width="100px" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1"></td>
    <td colspan ="1"></td>

</tr>
                    
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Forenames" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtForenames" runat="server" Width="710px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7">
                            <dx:ASPxTextBox ID="txtSurname" runat="server" Width="710px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="7" style="text-align: center">
                            <dx:ASPxLabel ID="lblCashBal0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Current Balance" Theme="Glass">
                            </dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblCashBal" runat="server" Font-Names="Cambria" Font-Size="Small" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
        </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Payment Details" Font-Size="Medium">

                <table width="100%">
<tr>
    <td colspan="1" style="height: 18px; width: 221px;">
            <dx:ASPxLabel ID="lblewr" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Choose Account" Theme="Glass">
            </dx:ASPxLabel>
            </td>
    <td colspan="1" style="height: 18px; width: 414px;">
        <dx:ASPxComboBox ID="cmbassetmanagerbank" 
             runat="server" DropDownWidth="550"
        DropDownStyle="DropDownList"  ValueField="acc"
        ValueType="System.String" TextFormatString="{0}"  EnableCallbackMode="true" AutoPostBack="true" IncrementalFilteringMode="StartsWith"
        CallbackPageSize="1000" Width="250px" Theme="Glass">
            <Columns>
                <dx:ListBoxColumn FieldName="acc" Name="acc" />
                <dx:ListBoxColumn Caption="AssetManagerCode"   FieldName="AssetManagerCode" Name="AssetManagerCode" />
                <dx:ListBoxColumn FieldName="AssetMana" Name="AssetMana"  />
                <dx:ListBoxColumn FieldName="AccountNo" Name="AccountNo"  />
                <dx:ListBoxColumn FieldName="Bank"  Name="Bank" />
                <dx:ListBoxColumn Caption="Branch" FieldName="Branch" Name="Branch" />
                <dx:ListBoxColumn Caption="AccountName"  FieldName="AccountName" />
              
            </Columns>
        </dx:ASPxComboBox>
    </td>
    <td colspan="1" style="height: 18px">
        <dx:ASPxLabel ID="EWR0" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Balance" Theme="Glass" Visible="False">
        </dx:ASPxLabel>
    </td>
    <td colspan="1" style="height: 18px">
        <dx:ASPxTextBox ID="txtcharges" runat="server" ReadOnly="True" Width="250px" Visible="False">
        </dx:ASPxTextBox>
    </td>
    <td colspan="1" style="height: 18px">&nbsp;</td>
    <td colspan="1" style="height: 18px">&nbsp;</td>
    <td colspan="1" style="height: 18px">&nbsp;</td>
     </tr>
                    <tr>
                        <td colspan="1" style="height: 18px; width: 221px;">
                            <dx:ASPxLabel ID="EWR1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transaction Type" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px; width: 414px;">
                            <dx:ASPxComboBox ID="cmbtransactiontype" runat="server" AutoPostBack="True"  Width="250px">
                               
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtAmount" runat="server" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px; width: 221px;">
                            <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Dr/Cr" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px; width: 414px;">
                            <dx:ASPxComboBox ID="cmbdeb" runat="server" Width="250px">
                                <Items>
                                    <dx:ListEditItem Text="Debit" Value="Debit" />
                                    <dx:ListEditItem Text="Credit" Value="Credit" />
                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan="1" style="height: 18px">
                            &nbsp;</td>
                        <td colspan="1" style="height: 18px">
                            &nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px; width: 221px;">
                            <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px; width: 414px;">
                            <dx:ASPxComboBox ID="cmbbank" runat="server" AutoPostBack="False" Width="250px">
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtbranch" runat="server" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px; width: 221px;">
                            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px; width: 414px;">
                            <dx:ASPxTextBox ID="txtaccountno" runat="server" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Recipient Account Name" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtrecipientname" runat="server" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                        <td colspan="1" style="height: 18px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 18px; width: 221px;">
                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Notes" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px; width: 414px;">
                            <dx:ASPxTextBox ID="txtdesc" runat="server" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxLabel ID="lblrejectionreason" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Rejection Reason" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtrejectionreason" runat="server" Visible="False" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 18px"></td>
                        <td colspan="1" style="height: 18px"></td>
                        <td colspan="1" style="height: 18px"></td>
                    </tr>
                    <tr>
                        <td colspan="7" align="center" style="height: 28px">
                            <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                            <dx:ASPxButton ID="ASPxButton3" runat="server" style="height: 23px" Text="Save" Width="70px">
                            </dx:ASPxButton>
                            &nbsp;<dx:ASPxButton ID="ASPxButton4" runat="server" style="height: 23px" Text="Refresh" Width="70px">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
    <td colspan="7">
            <dx:ASPxGridView ID="ASPxGridView3" runat="server" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%" KeyFieldName="ID">
               <Columns>
                    <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="DeleteID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit"  Text="Edit">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Description">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Description") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                       <dx:GridViewDataColumn Caption="Trans Type">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("TransType") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                       <dx:GridViewDataColumn Caption="Amount">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Amount") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                       <dx:GridViewDataColumn Caption="Date Created">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("DateCreated") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                       <dx:GridViewDataColumn Caption="Beneficiary">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Beneficiary") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                       <dx:GridViewDataColumn Caption="Bank">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Bank") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                       <dx:GridViewDataColumn Caption="Branch">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Branch") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                          <dx:GridViewDataColumn Caption="Captured By">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("CapturedBy") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                          <dx:GridViewDataColumn Caption="Status">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Status") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
               </Columns>
          </dx:ASPxGridView>
                        </td>
     </tr>
                    <tr>
    <td colspan="7">
                <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Industry Types" Modal="true" ShowCollapseButton="False" ShowMaximizeButton="False" ShowPageScrollbarWhenModal="True" ShowPinButton="False" ShowRefreshButton="False" Theme="Glass">
            <contentcollection>
          <dx:popupcontrolcontentcontrol runat="server" SupportsDisabledAttribute="True">
         
            <dx:ASPxRoundPanel ID="ASPxRoundPanel7" runat="server" ShowHeader="False" Theme="Glass" Width="40%"><panelcollection>
<dx:panelcontent runat="server" SupportsDisabledAttribute="True">
                                    <table class="dxflInternalEditorTable_Moderno" style="width: 100%">
                                        <tr>
                                            <td style="width:76px">
                                                <dx:aspxlabel ID="ASPxLabel63" runat="server" Text="Transaction Code" Theme="Glass"></dx:aspxlabel>

                                            </td>
                                            <td style="width:212px">
                                                <dx:aspxtextbox ID="txtcode" runat="server" Theme="Glass" Width="250px"></dx:aspxtextbox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:76px; height: 36px;">
                                                <dx:aspxlabel ID="ASPxLabel64" runat="server" Text="Transaction Description" Theme="Glass"></dx:aspxlabel>

                                            </td>
                                            <td style="width:212px; height: 36px;">
                                                <dx:aspxtextbox ID="txtdescription" runat="server" Theme="Glass" Width="250px"></dx:aspxtextbox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:76px; height: 36px;">
                                                <dx:ASPxLabel ID="ASPxLabel65" runat="server" Text="DR/CR" Theme="Glass">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td style="width:212px; height: 36px;">
                                                <dx:ASPxComboBox ID="cmbdrcr" runat="server" Width="250px">
                                                    <Items>
                                                        <dx:ListEditItem Text="Debit" Value="Debit" />
                                                        <dx:ListEditItem Text="Credit" Value="Credit" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:76px">&#160;</td>
                                            <td style="width:212px">
                                                <dx:aspxbutton ID="btnSaveCompany" runat="server" CausesValidation="False" Text="Add"></dx:aspxbutton>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <dx:aspxgridview ID="grdactivecharges" runat="server" AutoGenerateColumns="False" KeyFieldName="id" Theme="Glass" Width="100%"><Columns>
<dx:gridviewdatacolumn ShowInCustomizationForm="True" VisibleIndex="0"><dataitemtemplate>
                                                                <asp:LinkButton ID="SelectID1" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" Text="Delete">

                                        </asp:LinkButton>
                                                            
</dataitemtemplate>
</dx:gridviewdatacolumn>
<dx:gridviewdatacolumn Caption="Transaction Code" ShowInCustomizationForm="True" VisibleIndex="1"><dataitemtemplate>
                                                                <dx:aspxlabel runat="server" Text='<%# Eval("Category") %>'>
                                                                </dx:aspxlabel>
                                                            
</dataitemtemplate>

<HeaderStyle Font-Bold="True"></HeaderStyle>
</dx:gridviewdatacolumn>
<dx:gridviewdatacolumn Caption="Description" ShowInCustomizationForm="True" VisibleIndex="2"><dataitemtemplate>
                                                                <dx:aspxlabel runat="server" Text='<%# Eval("TransactionType") %>'>
                                                                </dx:aspxlabel>
                                                            
</dataitemtemplate>

<HeaderStyle Font-Bold="True"></HeaderStyle>
</dx:gridviewdatacolumn>

                                                    <dx:gridviewdatacolumn Caption="Debit/Credit" ShowInCustomizationForm="True" VisibleIndex="2"><dataitemtemplate>
                                                                <dx:aspxlabel runat="server" Text='<%# Eval("Action") %>'>
                                                                </dx:aspxlabel>
                                                            
</dataitemtemplate>

<HeaderStyle Font-Bold="True"></HeaderStyle>
</dx:gridviewdatacolumn>
</Columns>

<settingspager mode="ShowAllRecords" visible="False"></settingspager>
</dx:aspxgridview>

                                            </td>
                                        </tr>
                                    </table>
                                </dx:panelcontent>
</panelcollection>
</dx:ASPxRoundPanel>
                </dx:popupcontrolcontentcontrol>
            </contentcollection>
                </dx:ASPxPopupControl>
                        </td>
     </tr>
                    <tr>
                        <td colspan="1" style="width: 221px">
                            </td>
                        <td colspan="1" style="width: 414px">
                            &nbsp;</td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                    </tr>
                    <tr>
    <td colspan="1" style="width: 221px">
            </td>
    <td colspan="1" style="width: 414px">
                        </td>
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


<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="UTSetup_Approval.aspx.vb" Inherits="CDSMode_UserAccountsApproval" title="Unit Trust Fund Approval" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Approve Unit Trust Fund" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="Panel8" Font-Names="Cambria" GroupingText="Unit Trust Funds">
    <table width="100%">
            <tr>
                <td colspan ="8">
                    <asp:Panel ID="Panel12" runat="server" Font-Names="Cambria" GroupingText="Pending Unit Trust Funds">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="8">
                                    <dx:ASPxGridView ID="grdvCharges" runat="server" AutoGenerateColumns="true" OnRowCommand="grdvCharges_RowCommand" KeyFieldName="ID" Theme="Glass" Width="840px">
                                        <Columns>
                                            
                                            <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                                <DataItemTemplate>
                                                    <asp:LinkButton ID="SelectID" Text="View Details " CommandName="Select" CommandArgument='<%# Eval("ID") %>' runat="server">
                                                              </asp:LinkButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Issuer">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("issuer") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Fund Code">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Funding_Code") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Fund Name">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Funding_Name") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                             <dx:GridViewDataColumn Caption="Units">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Units") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Description">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("description") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Status">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("status") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                           
                                           
                                        </Columns>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        <tr>
                <td colspan ="1" style="width:211px; height: 27px;"></td>
                <td colspan ="1" style="width:35px; height: 27px;"><td colspan="1" style="height: 27px">&nbsp;</td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                    <td colspan="1" style="height: 27px"></td>
                </td>
            </tr>

            <tr>
                <td colspan="8">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td colspan="1" style="width:211px">
                    
                   
                    <dx:ASPxLabel ID="ASPxLabel78" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fund Code" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="width:35px">
                    <dx:ASPxTextBox ID="txtFunding_Code" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    </t>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width:211px">
                    <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fund Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="width:35px">
                    <dx:ASPxTextBox ID="txtFunding_Name" runat="server" ReadOnly="true" Theme="BlackGlass" Width="250px">
                        <ValidationSettings SetFocusOnError="true">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                   
                    <td colspan="1">
                        <asp:TextBox ID="txtDescription" runat="server" Height="21px" Width="255px"></asp:TextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width:211px">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issuer" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan="1" style="width:35px">
                    <asp:TextBox ID="txtIssuer" runat="server" Width="239px"></asp:TextBox>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Units" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtunits" runat="server" Height="21px" Width="255px"></asp:TextBox>
                    </td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width:211px">
                    <table class="dxflInternalEditorTable_Aqua">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td colspan="1" style="width:35px">
                    &nbsp;<td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </td>
            </tr>

    </table>
</asp:Panel>
        <asp:panel id="Panel2" runat="server" GroupingText="Options" Font-Names="Cambria">
        <table width="100%">
      
           
           
            <tr>
               
                <td colspan ="8" align="center">
                    <br />
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Accept" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;<dx:ASPxButton ID="btnReject" runat="server" CausesValidation="False" Text="Reject" Theme="BlackGlass">
                    </dx:ASPxButton>
                    <br />
                </td>
                

            </tr>
           
          
        </table>
    </asp:panel>
    
        <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" GroupingText="Accepted Unit Trust Funds">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="8">
                                    <dx:ASPxGridView ID="grdvCharges1" runat="server" AutoGenerateColumns="true"  KeyFieldName="ID" Theme="Glass" Width="840px">
                                        <Columns>
                                            
                                          
                                            <dx:GridViewDataColumn Caption="Issuer">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("issuer") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Fund Code">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Funding_Code") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Fund Name">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("Funding_Name") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Description">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("description") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Status">
                                                <DataItemTemplate>
                                                    <dx:ASPxLabel runat="server" Text='<%# Eval("status") %>'>
                                                    </dx:ASPxLabel>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                           
                                           
                                        </Columns>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                 
        <br />
        <br />
                 
</asp:Panel>
  
</div>
</asp:Content>


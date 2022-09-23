<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="transferapproval_UT.aspx.vb" Inherits="transferapproval_UT" title="Transfer Approval" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorization&gt;&gt;Unit Trust Transfer" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="panelSearch" Font-Names="Cambria" GroupingText="Search">
    <table style="width:100%">
                 <tr>
                    <td align ="left" >
                        <dx:ASPxGridView ID="grddocuments" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSizeItemSettings-ShowAllItem="true" Visible="True">
                            </SettingsPager>
                            <SettingsPopup>
                                <EditForm AllowResize="True" Modal="True" />
                            </SettingsPopup>
                            <SettingsCommandButton>
                                <SelectButton Text="Select">
                                </SelectButton>
                            </SettingsCommandButton>
                            <Columns>
                                <dx:GridViewDataColumn Caption="Select" FieldName="Selec" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:ASPxCheckBox ID="chk1" runat="server">
                                        </dx:ASPxCheckBox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="DeleteID0" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Approve Transaction" OnClientClick="if ( !confirm('Are you sure you want to post this Transaction? ')) return false;" Text="Approve Transaction">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="DeleteID1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Decline Transaction" OnClientClick="if ( !confirm('Are you sure you want to decline this Transaction? ')) return false;" Text="Decline Transaction">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Transferor">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Transferor") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Transferor Name">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("FromName") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Transferee">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("Transferee") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Transferee Name">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("ToName") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Fund">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("company") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataTextColumn Caption="Amount" FieldName="amount_to_transfer" Name="Amount" PropertiesTextEdit-DisplayFormatString="n">
                                </dx:GridViewDataTextColumn>
                         
                                <dx:GridViewDataColumn Caption="Date Captured">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("CaptureDate") %>'>
                                        </dx:ASPxLabel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                      <dx:GridViewDataColumn Caption="Transaction Date">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel runat="server" Text='<%# Eval("date") %>'>
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
                            <%-- W.EWR_Holder as [Account No], W.Company as [Details], W.ReceiptID AS [EWR No.], 
                                case when W.approvedby is NULL then 'Pending' else 'Approved' end as  [Status],  W.[Date],
                                 W.amount_to_withdraw ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] --%>
                        </dx:ASPxGridView>
                     </td>

            </tr>

            <tr>
                <td align="center">
                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Approve Selected" Theme="Glass">
                    </dx:ASPxButton>
                    &nbsp;&nbsp;
                    <dx:ASPxButton ID="ASPxButton6" runat="server" Text="Reject Selected" Theme="Glass">
                    </dx:ASPxButton>
                </td>
            </tr>

    </table>

</asp:Panel>
        <asp:panel id="Panel8" runat="server" GroupingText="Transferor Details" Font-Names="Cambria" Visible="False">
        <table width="100%">
            <tr>
                <td colspan ="1" style="width:205px">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1">
                    <dx:ASPxTextBox ID="txttransferorid" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                

            </tr>
           <tr>
               <td colspan ="1" style="height: 23px; width: 205px;">
                   <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                   </dx:ASPxLabel>
               </td>
               <td colspan ="7" style="height: 23px">
                   <dx:ASPxTextBox ID="txttransferorname" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="500px">
                   </dx:ASPxTextBox>
               </td>

           </tr>
            <tr>
                    <td colspan ="1" style="width: 205px"></td>
                <td colspan ="7" align="center"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel ID="Panel12" runat="server" Font-Names="Cambria" GroupingText="Transferee Details" Visible="False">
            <table width="810px">
                <tr>
                    <td colspan="1" style="width: 206px">
                        <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txttransfereeid" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 23px; width: 206px;">
                        <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7" style="height: 23px">
                        <dx:ASPxTextBox ID="txttransfereename" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="500px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 206px"></td>
                    <td align="center" colspan="7"></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel11" runat="server" GroupingText="Transfer Details" Font-Names="Cambria" Visible="False">
        <table width="810px">
            <tr>
                    <td colspan ="2" align="center">
                        &nbsp;</td>

            </tr>
         
           <tr>
               <td colspan ="1" style="width: 205px">
                   &nbsp;</td>
               <td>
                   &nbsp;</td>

           </tr>
               
            <tr>
                <td colspan="1" style="width: 205px; height: 32px;">
                    <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Units to transfer" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 32px">
                    <dx:ASPxTextBox ID="txtshares" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 205px">
                    <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bond Series" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtcomp" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
               
        </table>

    </asp:panel>

        <asp:Panel runat="server" ID="panelsaving" GroupingText="." Visible="False">
            <table style="width:100%">
                    <tr>
                            <td colspan ="8" align="center">
                                &nbsp;</td>


                    </tr>
                <tr>
                        <td colspan ="8" align ="center">
                            &nbsp;</td>

                </tr>

            </table>
        </asp:Panel>  
                 
</asp:Panel>
  
</div>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="banktransferapproval.aspx.vb" Inherits="Parameters_banktransferapproval" title="Bank Transfer Approval" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Authorizations>>Bank Transfer Approval" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Bank Transfer">

                <table width="100%">
                    <tr>
                        <td colspan="1">
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Font-Size="X-Small" Text="Select All" />
                        </td>
                        <td colspan="1">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 18px">
                            <dx:ASPxGridView ID="ASPxGridView2"  runat="server" Theme="Glass" Width="100%" KeyFieldName="ID" SettingsPager-Mode="ShowAllRecords" >
                                <Settings ShowFilterRow="true" />
                            <Columns>
                                 <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:aspxcheckbox ID="chk1" runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="Approve" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Approve" Text="Approve">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                      <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="Decline" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Decline" Text="Decline">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="ID">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                             <dx:GridViewDataTextColumn Caption="DebitAccountNumber" FieldName="DebitAccountNumber" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                
                                <dx:GridViewDataTextColumn Caption="CreditAccountNumber" FieldName="CreditAccountNumber" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn Caption="Currency" FieldName="Currency" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn Caption="Amount" FieldName="Amount" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="DrCDSNumber" FieldName="DrCDSNumber" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn Caption="CrCDSNumber" FieldName="CrCDSNumber" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Caption="BankFrom" FieldName="BankFrom" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn Caption="BankTo" FieldName="BankTo" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Description" FieldName="Description" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                  

                          
                                                               
                            </Columns>
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                 
                    <tr>
                        <td align="center" style="height: 18px">
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Approve Selected" Theme="Glass">
                            </dx:ASPxButton>
                            &nbsp;
                            <dx:ASPxButton ID="ASPxButton6" runat="server" Text="Reject Selected" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>


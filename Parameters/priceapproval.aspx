<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="priceapproval.aspx.vb" Inherits="Parameters_priceapproval" title="Price Approval" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters>>Share Prices Approval" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Prices">

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
                            <dx:ASPxGridView ID="ASPxGridView2"  runat="server" Theme="Glass" Width="100%" KeyFieldName="id" SettingsPager-Mode="ShowAllRecords" >
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
                                        <asp:LinkButton ID="Approve" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Approve" Text="Approve">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                      <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="Decline" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Decline" Text="Decline">
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="ID">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("id") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                             <dx:GridViewDataTextColumn Caption="Company" FieldName="Ticker" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                
                                <dx:GridViewDataTextColumn Caption="Price" FieldName="Current_price" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                  

                                <dx:GridViewDataDateColumn Caption="Price Date" FieldName="Date" PropertiesDateEdit-DisplayFormatString="{0:dd/MM/yyyy}" Settings-AutoFilterCondition="Equals" > </dx:GridViewDataDateColumn>
                                     
                                 <dx:GridViewDataColumn Caption="Capture Date">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%#   Convert.ToDateTime(Eval("CaptureDate")).ToString("dd/MM/yyyy hh:mm") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                          <dx:GridViewDataTextColumn Caption="CapturedBy" FieldName="CapturedBy" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                               
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


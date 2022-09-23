<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="uploadinstruction.aspx.vb" Title="Upload Instructions" Inherits="uploadinstruction" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" GroupingText="Depositor>>Upload Instructions" BackColor="White">
        <table>
            <tr id="Tr1" runat="server">
              <td colspan="5" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
           
 
            <tr id="panelSave2" runat="server" > 
                 <td style="width:208px">
                     <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Category" Theme="Glass">
                     </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                  </td>
                 <td style="width:212px">
                     <dx:ASPxComboBox ID="txtdocumentname" runat="server" ValidationSettings-ValidationGroup="upload11" AnimationType="Slide" AutoPostBack="true" CallbackPageSize="15" DropDownStyle="DropDownList" EnableCallbackMode="True" IncrementalFilteringMode="Contains" Theme="BlackGlass" ValueType="System.String" Width="250px">
                         <Items>
                             <dx:ListEditItem Text="" Value="" />
                             <dx:ListEditItem Text="Proof of residence(within 3 months)" Value="Proof of residence(within 3 months)" />
                             <dx:ListEditItem Text="Certified ID Copy" Value="Certified ID Copy" />
                             <dx:ListEditItem Text="Certified passport copy(if foreign)" Value="Certified passport copy(if foreign)" />
                             <dx:ListEditItem Text="Other" Value="Other" />
                         </Items>
                     </dx:ASPxComboBox>
                    <dx:ASPxTextBox ID="txtotherdoc" runat="server" BackColor="White" Theme="BlackGlass" Width="250px" Visible="False">
                    </dx:ASPxTextBox>
                  </td>
             </tr>
          <tr id="panelSave3" runat="server" >  
                 <td style="width:208px">
                     <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Document" Theme="Glass">
                     </dx:ASPxLabel>
                  </td>
                 <td style="width:212px">
                     <asp:FileUpload ID="FileUpload1" runat="server" />
                  </td>
             </tr>
            <tr id="panelSave4" runat="server" >
                    <td style="width:208px"></td>
                    <td style="width:212px">
                        <dx:ASPxButton ID="ASPxButton10" runat="server" ValidationGroup="upload11" Text="Upload" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
             </tr>
            
             
           

               
          
            <tr id="panelSave5" runat="server" >
                    <td style="width:208px"></td>
                        <td colspan="3">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="ID" Theme="Glass" Width="470px">
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Delete"  OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn VisibleIndex="1">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID1" Text="View" CommandName="view" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="ID">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Name">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("name") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Content Type">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("contenttype") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                            </dx:ASPxGridView>
                        </td>
                </tr> 
                  <tr>
                      <td colspan="1"></td>
                  </tr>
                  <tr>
                      <td colspan="1"></td>
                  </tr>
                  <tr>
                      <td colspan="1"></td>
                  </tr>
        </table>
    </asp:Panel>
</asp:Content>

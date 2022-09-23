<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="graddingComponets.aspx.vb" Inherits="Parameters_graddingComponets" title=" Grading Componets" %>



<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt; Grading Parameters" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Add Parameters">

                <table width="100%">
                    <tr>
                            <td colspan ="7" align ="center">
                                &nbsp;</td>

                    </tr>
                    <tr>
                            <td colspan ="1" style="width: 147px">
                                <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Commodity" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" class="auto-style10" style="width: 253px">
                            <asp:DropDownList ID="cmbType" runat="server"  AutoPostBack="True" Height="22px" Width="251px">
                            </asp:DropDownList>
                            </td>
                        <td colspan ="1" style="width: 192px">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Parameter" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="width: 292px">
                            <dx:ASPxTextBox ID="txtComponent" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>


                    </tr>
                    <tr>
                        <td colspan="1" style="width: 147px">&nbsp;</td>
                        <td class="auto-style10" colspan="1" style="width: 253px">
                            <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            &nbsp;<dx:ASPxButton ID="ASPxButton8" runat="server" Text="Clear" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1" style="width: 192px">&nbsp;</td>
                        <td colspan="1" style="width: 292px">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px; width: 147px;">
                            </td>
                        <td colspan ="6" style="height: 18px">
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" KeyFieldName="id" Theme="Glass" Width="640px" SettingsPager-Mode="ShowAllRecords" >
                            <Columns>
                                <dx:GridViewDataColumn VisibleIndex="0" Caption="">
                                                         <DataItemTemplate>
                                                              <asp:LinkButton ID="SelectID" Text="Edit"  CommandName="Edit" CommandArgument='<%# Eval("ID") %>' runat="server">
                                                              </asp:LinkButton>
                                                         </DataItemTemplate>
                                                                                       </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn VisibleIndex="0" Caption="">
                                                                                           <DataItemTemplate>
                                                              <asp:LinkButton ID="DeleteID" Text="Delete" CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandArgument='<%# Eval("ID") %>' runat="server">
                                                              </asp:LinkButton>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                               
                                  <dx:GridViewDataColumn Caption="Commodity">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Commodity") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                      <dx:GridViewDataColumn Caption="Parameter">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Component") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>


                            </Columns>
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1" style="width: 147px"></td>
                        <td colspan ="6" align="center">
                            <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="1" style="width: 147px">
                            &nbsp;</td>
                        <td colspan ="6">
                            &nbsp;</td>

                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>


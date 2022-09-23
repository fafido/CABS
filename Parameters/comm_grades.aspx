<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="comm_grades.aspx.vb" Inherits="Parameters_comm_grades" title="Commodity Grades" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;Commodity Grades" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Add Grades">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                &nbsp;</td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Commodity" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <asp:DropDownList ID="cmbType" AppendDataBoundItems="True" runat="server" Height="22px" Width="251px" AutoPostBack="True">
                                <asp:ListItem Text="-Select-"></asp:ListItem>

                            </asp:DropDownList>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>


                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Grade" Theme="Glass">
                          
                                  </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtCategory" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                          <ValidationSettings>
                                    <RequiredField IsRequired="True"  />
                                </ValidationSettings>
                                   </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Measurement" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <asp:DropDownList ID="cmbmeasurement" runat="server" Height="22px" Width="251px" Enabled="False">
                        
                                    </asp:DropDownList>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Variety" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtDesc" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                           <ValidationSettings>
                                    <RequiredField IsRequired="True"  />
                                </ValidationSettings>
                                  </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">
                            <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            &nbsp;<dx:ASPxButton ID="ASPxButton8" runat="server" Text="Refresh" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">
                            <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px">
                            </td>
                        <td colspan ="7" style="height: 18px">
                            <dx:ASPxGridView ID="ASPxGridView2"  runat="server" Theme="Glass" Width="640px" KeyFieldName="ID" SettingsPager-Mode="ShowAllRecords" >
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
                                        <dx:GridViewDataColumn Caption="ID">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("id") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                  <dx:GridViewDataColumn Caption="Grade">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("grade") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                
                                  <dx:GridViewDataColumn Caption="Variety">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Variety") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                 <dx:GridViewDataColumn Caption="Measurement">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("measurement") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>


                            </Columns>
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            &nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            &nbsp;</td>
                        <td colspan ="7">
                            &nbsp;</td>

                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>


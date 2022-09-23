<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="commodityComponents.aspx.vb" Inherits="Parameters_commodityComponents" title="Commodity Components" %>



<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;Grading Parameter" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Grading Parameter">

                <table width="100%">
                    <tr>
                            <td colspan ="8" align ="center">
                                &nbsp;</td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Commodity" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="width: 263px">
                            <asp:DropDownList ID="cmbType"  AutoPostBack="True" runat="server" Height="22px" Width="251px">
                                
                            </asp:DropDownList>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Grade" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <asp:DropDownList ID="cmbGrade" runat="server" Height="22px" Width="251px">
                            </asp:DropDownList>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Parameter" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <asp:DropDownList ID="cmbComponent" runat="server" AutoPostBack="True" Height="22px" Width="251px">

                            </asp:DropDownList>
                            </td>
                        <td colspan ="1">&nbsp;</td>


                    </tr>
                    <tr>
                        <td colspan="1" style="height: 29px">
                            <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Min/Max" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 29px; width: 263px;">
                             <dx:ASPxComboBox ID="minmax" runat="server" Height="23px" Width="250px" SelectedIndex="0">
                                 <Items>
                                     <dx:ListEditItem Text="" Value="" />
                                     <dx:ListEditItem Text="Min" Value="Min" />
                                     <dx:ListEditItem Text="Max" Value="Max" />
                                     <dx:ListEditItem Text="Absolute" Value="Absolute" />
                                 </Items>
                                    <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                             </dx:ASPxComboBox>
                        </td>
                        <td colspan="1" style="height: 29px">
                            <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Value" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 29px">
                            <dx:ASPxTextBox ID="txtValue" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                                   <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="height: 29px">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Measure" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="height: 29px">
                             <asp:Dropdownlist ID="cmbMeasure" runat="server" Height="23px" Width="250px" AppendDataBoundItems="true">
                                     <asp:ListItem Text="" Value="" />
                                
                             </asp:Dropdownlist>
                        </td>
               <td style="width: 100px">
                    <dx:ASPxButton ID="btnAddChargeType" ValidationGroup="addMeasure" runat="server" Visible="true" Text="Add" Theme="Glass">
                    </dx:ASPxButton>
               </td>
                        <%--<td colspan="1" style="height: 29px"></td>--%>
                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1" style="width: 263px">
                            <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            &nbsp;<dx:ASPxButton ID="ASPxButton8" CausesValidation="False" runat="server" Text="Refresh" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1">
                            <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                        </td>
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
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Glass" AutoGenerateColumns="True" Width="640px" KeyFieldName="ID" SettingsPager-Mode="ShowAllRecords" >
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

                                       <dx:GridViewDataColumn Caption="Grade">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Grade") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                       <dx:GridViewDataColumn Caption="Component">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Component") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                
                                       <dx:GridViewDataColumn Caption="Min/Max">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Min/Max") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                

                                     <dx:GridViewDataColumn Caption="Value">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Value") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                
                                     <dx:GridViewDataColumn Caption="Measure">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Measure") %>' runat="server"></dx:ASPxLabel>
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
        <tr>
                <td align="right" align="center" colspan="4">
                <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" Modal="true" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Add New Measure" ShowCollapseButton="False" ShowMaximizeButton="False" ShowPageScrollbarWhenModal="True" ShowPinButton="False" ShowRefreshButton="False" Theme="Glass">
            <contentcollection>
          <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
            <dx:ASPxRoundPanel ID="ASPxRoundPanel6" runat="server" ShowHeader="False" Theme="Glass" Width="100%">
                <panelcollection>
                    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                        <table class="dxflInternalEditorTable_Moderno" style="width: 100%">
                            <tr>
                                <td style="width:208px">
                                 <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="Measure" Theme="Glass"></dx:ASPxLabel>
                                </td>
                                <td style="width:212px">
                                    <dx:ASPxTextBox ID="txtAddMeasure" runat="server" Theme="Glass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                    <tr>
                         <td style="width:208px"></td>
                        <td style="width:212px">
                            <dx:ASPxButton ID="btnCommitNewMeasure" ValidationGroup="addMeasure1" runat="server" Text="Save" Theme="iOS">
                                </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
                        </dx:PanelContent>
                    </panelcollection>
                </dx:ASPxRoundPanel>
                        </dx:PopupControlContentControl>
            </contentcollection>
                </dx:ASPxPopupControl>
                </td>
            </tr>
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>



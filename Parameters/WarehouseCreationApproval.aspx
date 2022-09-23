<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="WarehouseCreationApproval.aspx.vb" Inherits="Custodian_WarehouseCreation"  title="Warehouse Creation Approval"  %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx1" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRibbon" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel  runat="server" Font-Names="Cambria"   GroupingText="Warehouse Approval" Font-Bold="true" style="width: 100%">
            <table>
            <tr  runat="server" visible="false"  id="Panel10">
                <td style="width: 137px">
                <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name" Theme="Glass">
                </dx:ASPxLabel>
                </td>
                <td colspan="7" style="height: 23px">
                <dx:ASPxTextBox ID="txtPName" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr  runat="server"  visible="false"  id="Tr6">
                <td style="width: 137px">
                <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Designation" Theme="Glass">
                </dx:ASPxLabel>
                </td>
                <td>
                <dx:ASPxTextBox ID="txtpersonnelDesignation" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr  runat="server"  visible="false"  id="Panel11">
                <td style="width: 137px">
                <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Cell no" Theme="Glass">
                </dx:ASPxLabel>
                </td>
                <td>
                <dx:ASPxTextBox ID="txtCellNo" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr  runat="server" visible="false"  id="Panel12">
                <td style="width: 137px">
                <dx:ASPxLabel ID="ASPxLabel45" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC no" Theme="Glass">
                </dx:ASPxLabel>
                </td>
                <td>
                <dx:ASPxTextBox ID="txtCNICno" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr  runat="server"  visible="false"  id="Panel13"> 
                <td style="width: 137px">
                <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email ID" Theme="Glass">
                </dx:ASPxLabel>
                </td>
                <td>
                <dx:ASPxTextBox ID="txtPEmail" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr runat="server" visible="false"  id="Panel14">
                <td style="width: 137px; height: 18px;"></td>
                <td style="height: 18px"></td>
                <td style="height: 18px"></td>
                <td style="height: 18px"></td>
                <td style="height: 18px"></td>
            </tr>
            <tr runat="server"  visible="false"  id="Panel15">
                <td style="height: 18px; width: 118px;"></td>
                <td colspan="3" style="height: 18px"  align="center">
                    <dx:ASPxGridView ID="grdPersonnel" runat="server" Caption="Personnel Details" Theme="Glass" Width="300px">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </td>
            </tr>
            <tr runat="server" visible="false"  id="Panel16">
                <td style="width: 118px">&nbsp;</td>
                <td colspan="4" align="center">
                    <dx:ASPxButton ID="btnPersonel" runat="server" Text="Add Personnel" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td style="width: 118px">&nbsp;</td>
                <td colspan="4" align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 18px; width: 118px;"></td>
                <td colspan="4" style="height: 18px">
                    <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="true" OnRowCommand="ASPxGridView3_RowCommand" KeyFieldName="ID" Theme="Glass" Width="100%">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Select" CommandName="Select" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Warehouse Name">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("WarehouseName") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           <%-- <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="WarehouseCode">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("WarehouseCode") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Warehouse Address">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("WarehouseAddresses") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Accreditation Number">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Accreditation Number") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Representative">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Representative") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <%--<dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Insurance">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Coverage") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Phone">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Phone") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr>                
            <%-- <tr>
             <td colspan="5" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Work in progress " Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
            <tr>
                <td style="height: 18px;"></td>
                <td colspan="4" style="height: 18px">
                    <dx:ASPxGridView ID="grdWIP" runat="server" AutoGenerateColumns="true" OnRowCommand="grdWIP_RowCommand" KeyFieldName="ID" Theme="Glass" Width="390px">
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Edit" CommandName="Select" CommandArgument='<%# Eval("ID") %>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Warehouse Name">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("WarehouseName") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           <%-- <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="WarehouseCode">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("WarehouseCode") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Warehouse Address">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("WarehouseAddresses") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Accreditation Number">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Accreditation Number") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Representative">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Representative") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <%--<dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Insurance">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Coverage") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Phone">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Phone") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </td>
            </tr> --%>
            <tr runat="server">
                <td style="width: 137px; height: 18px;"></td>
                <td style="height: 18px"></td>
                <td style="height: 18px"></td>
                <td style="height: 18px"></td>
                <td style="height: 18px"></td>
            </tr>
          </table>
        </asp:Panel>
    <asp:Panel runat="server" ID="Panel9" Font-Names="Cambria" GroupingText="Warehouse Creation Approval" Width="100%">
            <table>
                <tr>
                    <td style="width: 208px; height: 18px;">
                        <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Operator" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="height: 18px; width: 212px;">
                        <%--<asp:DropDownList ID="cmboperator" runat="server" AutoPostBack="True" visible="True" Width="250px" AppendDataBoundItems="true">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                        </asp:DropDownList>--%>
                         <dx:ASPxTextBox ID="txtoperator" runat="server"   Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox> 
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                        </dx:ASPxLabel>
                         <dx:ASPxLabel ID="ASPxLabel71" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                       <%-- <dx:ASPxComboBox ID="cmbCountry" AutoPostBack="true" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        </dx:ASPxComboBox>--%>
                         <dx:ASPxTextBox ID="txtCountry" runat="server"   Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox> 
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel66" runat="server" Font-Names="Cambria" Font-Size="Small" Text="City" Theme="Glass">
                        </dx:ASPxLabel>
                         <dx:ASPxLabel ID="ASPxLabel72" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                       <%-- <dx:ASPxComboBox ID="cmbCity" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        </dx:ASPxComboBox>--%>
                        <dx:ASPxTextBox ID="txtCity" runat="server"   Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox> 
                    </td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse Name" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel20" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td  style="width: 212px">
                        <dx:ASPxTextBox ID="txtWarehouseName" runat="server"   Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox> 
                    </td>             
                    <td  style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Accreditation Number" Theme="Glass">
                        </dx:ASPxLabel>
                         <dx:ASPxLabel ID="ASPxLabel21" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td  style="width: 212px">
                        <dx:ASPxTextBox ID="txtWarehouseCode" Enabled ="false" runat="server"  Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Phone" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="right">
                                    <dx:ASPxTextBox ID="txtcode2" BackColor="#E4E4E4" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtPhone" runat="server"  Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                    </td>
                    <td>
                        <table width="100%">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="right">
                                    <dx:ASPxTextBox ID="txtcode1" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 61px">
                        <dx:ASPxTextBox ID="txtMobile" runat="server" Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Google location" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtgooglelocation" runat="server"  Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                    </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtEmail" runat="server"  Height="19px" Theme="BlackGlass" ReadOnly="true" BackColor="#E4E4E4" Width="250px">
                                <ValidationSettings ErrorText="Invalid Email" SetFocusOnError="True">
                                <RegularExpression ErrorText="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Commodity to be stored " Theme="Glass">
                            </dx:ASPxLabel>
                    </td>
                                        <td>
                        <table class="auto-style1">
                            <tr>
                                <td>
                                    <asp:GridView ID="grdCommodityToBeStored" runat="server" ReadOnly="true" BackColor="#E4E4E4" AutoGenerateColumns="False" ShowFooter="true">
                                        <Columns>
                                            <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkDelete" runat="server" CommandArgument="<%# Bind('ID') %>" OnClick="LinkCTBSDelete_Click" OnClientClick="return isDelete();">remove</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <%# Eval("Commodity") %>
                                                </ItemTemplate>
                                                <%--<FooterTemplate>
                                                    <asp:DropDownList ID="cmbCommodityToBeStored" AutoPostBack="false" ReadOnly="true" BackColor="#E4E4E4" runat="server">
                                                    </asp:DropDownList>
                                                </FooterTemplate>--%>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button ID="btnAddCTBS" runat="server" CommandName="Footer" OnClick="AddCTBS" Text="Add" />
                                                </FooterTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <tr>
                                                <th scope="col"></th>
                                                <th scope="col"></th>
                                                <th scope="col"></th>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td><%--<asp:TextBox ID="txtStorageFacility" runat="server" />--%>
                                                    <asp:DropDownList ID="cmbCommodityToBeStored" AutoPostBack="false" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAddCTBS" runat="server" CommandName="EmptyDataTemplate" OnClick="AddCTBS" Text="Add" />
                                                </td>
                                            </tr>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <%--<td>
                        <asp:DropDownList ID="cmbcommodity" runat="server" visible="True" Width="250px" AppendDataBoundItems="true">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>--%>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Storage Facility" Theme="Glass">
                        </dx:ASPxLabel>
                         <dx:ASPxLabel ID="ASPxLabel26" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <table class="auto-style1">
                            <tr>
                                <td>
                                    <asp:GridView ID="grdLoanBreakDown" runat="server" AutoGenerateColumns="False" ReadOnly="true" BackColor="#E4E4E4" ShowFooter="true">
                                        <Columns>
                                           <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkDelete" runat="server" CommandArgument="<%# Bind('ID') %>" OnClick="LinkDelete_Click" OnClientClick="return isDelete();">remove</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <%# Eval("StorageFacility") %>
                                                </ItemTemplate>
                                               <%-- <FooterTemplate>
                                                    <asp:DropDownList ID="cmbStorageFacility" OnSelectedIndexChanged="cmbStorageFacility_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtStorageFacilityOther" Visible="false" runat="server" />
                                                </FooterTemplate>--%>
                                            </asp:TemplateField>
                                           <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button ID="btnAdd" runat="server" CommandName="Footer" OnClick="Add" Text="Add" />
                                                </FooterTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <tr>
                                                <th scope="col"></th>
                                                <th scope="col"></th>
                                                <th scope="col"></th>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td><%--<asp:TextBox ID="txtStorageFacility" runat="server" />--%>
                                                    <asp:DropDownList ID="cmbStorageFacility" OnSelectedIndexChanged="cmbStorageFacility_SelectedIndexChanged" ReadOnly="true" BackColor="#E4E4E4" AutoPostBack="true" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtStorageFacilityOther" Visible="false" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAdd" runat="server" CommandName="EmptyDataTemplate" OnClick="Add" Text="Add" />
                                                </td>
                                            </tr>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                    <tr>
                        <td colspan="5" style="height: 18px;">
                            <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Warehouse Details" Theme="Glass">
                            </dx:ASPxLabel>
                            <hr/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 208px; height: 18px;">
                            <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Individual capacity per unit (metric tons)" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td style="width: 212px">
                            <dx:ASPxTextBox ID="txtindivcapacity" runat="server" Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 208px">
                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Contact person name" Theme="Glass">
                            </dx:ASPxLabel>
                             <dx:ASPxLabel ID="ASPxLabel23" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                        </td>
                        <td style="width: 212px">
                            <dx:ASPxTextBox ID="txtRepresentative" runat="server" Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td style="height: 18px"></td>
                    </tr>
                    <tr>
                        <td style="width: 208px">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Designation" Theme="Glass">
                            </dx:ASPxLabel>
                             <dx:ASPxLabel ID="ASPxLabel24" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                        </td>
                        <td style="width: 212px">
                            <dx:ASPxTextBox ID="txtDesignation" runat="server" Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 208px">
                            <dx:ASPxLabel ID="ASPxLabel63" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Agreement Date" Theme="Glass">
                            </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel64" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                        </td>
                        <td style="width: 212px">
                            <%--<dx:ASPxDateEdit ID="txtAgreementDate" runat="server" EditFormatString="dd MMM yyyy" Height="21px" ReadOnly="true" BackColor="#E4E4E4" Width="250px">
                            </dx:ASPxDateEdit>--%>

                            <dx:ASPxTextBox ID="txtAgreementDate" runat="server" Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 118px">
                                        <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Phone no" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="right">
                                        <dx:ASPxTextBox ID="txtcode4" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 212px">
                            <dx:ASPxTextBox ID="txtcontactpersonPhoneno" runat="server" Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 118px">
                                        <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile no" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td align="right">
                                        <dx:ASPxTextBox ID="txtcode5" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 118px">
                            <dx:ASPxTextBox ID="txtcontactpersonMobileno" runat="server" Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                            <td style="width: 208px">
                                <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="No of storage unit(s) [sheds/silos]" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtNoStorageunits" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 208px">
                                <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Dimensions of the godown(s)/storage unit(s) (feet) " Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtdeminsionsunits" runat="server" Height="19px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    <tr>
                            <td style="width: 208px">
                                <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse Addresses" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxMemo ID="txtAddresses" runat="server" Height="40px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxMemo>
                            </td>
                            <td style="width: 208px">
                                <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of jurisdictional police station" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtpolice" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    <tr>
                            <td style="width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Is the storage facility owned" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px;">
                                <table class="dxflInternalEditorTable_Aqua" style="width: 38%">
                                    <tr>
                                        <td>
                                            <dx:ASPxCheckBox ID="owned" runat="server" AutoPostBack="True" Text="Yes" Theme="Aqua">
                                            </dx:ASPxCheckBox>
                                        </td>
                                        <td>
                                            <dx:ASPxCheckBox ID="leased" runat="server" AutoPostBack="True" Text="No" Theme="Aqua">
                                            </dx:ASPxCheckBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel35" Visible="false" runat="server" Font-Names="Cambria" Font-Size="Small" Text="duration of lease" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtDurationoflease" Visible="false" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    <tr>
                            <td style="width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Is a weighbridge available " Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px;">
                                <table class="dxflInternalEditorTable_Aqua" style="width: 38%">
                                    <tr>
                                        <td>
                                            <dx:ASPxCheckBox ID="ckweighbridgeyes" runat="server" AutoPostBack="True" Text="Yes" Theme="Aqua">
                                            </dx:ASPxCheckBox>
                                        </td>
                                        <td>
                                            <dx:ASPxCheckBox ID="ckweighbridgeNo" runat="server" AutoPostBack="True" Text="No" Theme="Aqua">
                                            </dx:ASPxCheckBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    <tr id="Tr4" runat="server">
                            <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Visible="false" Font-Size="Small" Text="Name of the owner " Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtOnwername" runat="server" Height="23px" Visible="false" ReadOnly="true" BackColor="#E4E4E4" Theme="Glass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel55" Visible="false" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address of the nearby weighbridge" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtweighbridgeaddress" Visible="false" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="Glass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    <tr id="Tr5" runat="server">
                            <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel56" Visible="false" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Distance from the storage facility " Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtdistance" Visible="false" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="width: 208px">
                                <dx:ASPxLabel ID="ASPxLabel57" Visible="false" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date of calibration " Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                               <%-- <dx:ASPxDateEdit ID="txtdatecalibration" Visible="false" runat="server" EditFormatString="dd MMM yyyy" Height="21px" Width="250px">
                                </dx:ASPxDateEdit>--%>
                                <dx:ASPxTextBox ID="txtdatecalibration" Visible="false" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>

                            </td>
                        </tr>
                    <tr id="Tr1" runat="server">
                            <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Weighbridge Capacity" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtwegcapacity" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Calibration Status" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                 <%--<asp:DropDownList ID="cmbwegcalibration" runat="server" Width="250px">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                     <asp:ListItem Text="Calibrated" Value="Calibrated"></asp:ListItem>
                                     <asp:ListItem Text="Not Calibrated" Value="Not Calibrated"></asp:ListItem>
                        </asp:DropDownList>--%>
                                 <dx:ASPxTextBox ID="txtwegcalibration" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    <tr id="Tr3" runat="server">
                            <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel52" Visible="false" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Due date of calibration" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                               <%-- <dx:ASPxDateEdit ID="txtduedate" Visible="false" EditFormatString="dd MMM yyyy" runat="server" Height="21px" Width="250px">
                                </dx:ASPxDateEdit>--%>
                                 <dx:ASPxTextBox ID="txtduedate" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel51" Visible="false" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date of installation " Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                               <%-- <dx:ASPxDateEdit ID="txtdateInst" Visible="false" runat="server" Height="21px" EditFormatString="dd MMM yyyy" Width="250px">
                                </dx:ASPxDateEdit>--%>
                                 <dx:ASPxTextBox ID="txtdateInst" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    <tr id="Tr2" runat="server">
                            <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Make/model" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtmake_model" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style=" width: 208px;">
                                <dx:ASPxLabel ID="ASPxLabel50w" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Total Capacity (Metric Tons)" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td style="width: 212px">
                                <dx:ASPxTextBox ID="txtTotalCapacityMetricTons" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    <tr>
                        <td colspan="5" style="height: 18px;">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Security Details" Theme="Glass">
                            </dx:ASPxLabel>
                            <hr/>
                        </td>
                    </tr>
                            <tr>
                                <td style=" width: 208px;">
                                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="No of entry points" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtentry" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td style="width: 208px">
                                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="No of Exit points" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtExit" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style=" width: 208px;">
                                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Details of the security arrangements" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtsecurityguards" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td style="width: 208px">
                                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Is storage facility bound by a compound wall " Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtbountwithfance" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                                        <tr>
                                <td style=" width: 208px;">
                                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Past Regulatory Actions" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtpastRegulatory" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td style="width: 208px">
                                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="No of storage facilities for which accreditation is applied" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtNomberofStorage" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                     <%--<tr>
                        <td colspan="5" style="height: 18px;">
                            <dx:ASPxLabel ID="ASPxLabel43" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Fidelity Insurance Details" Theme="Glass">
                            </dx:ASPxLabel>
                            <hr/>
                        </td>
                    </tr>--%>
  
                           <%-- <tr>
                                <td style=" width: 208px;">
                                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Insurance Company" Theme="Glass">
                                    </dx:ASPxLabel>
                                     <dx:ASPxLabel ID="ASPxLabel27" runat="server" ForeColor="Red" Text="*">
                                </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtinsurance" runat="server" Height="23px" ReadOnly="False" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td style="width: 208px">
                                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Insurance Policy No. &amp; Coverage" Theme="Glass">
                                    </dx:ASPxLabel>
                                     <dx:ASPxLabel ID="ASPxLabel28" runat="server" ForeColor="Red" Text="*">
                                </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtinsurancePolicyNo" runat="server" Height="23px" ReadOnly="False" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>--%>
                            <%--<tr>
                                <td style=" width: 208px;">
                                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Sum Insured for each category" Theme="Glass">
                                    </dx:ASPxLabel>
                                     <dx:ASPxLabel ID="ASPxLabel29" runat="server" ForeColor="Red" Text="*">
                                </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxTextBox ID="txtsumInsured" runat="server" Height="23px" ReadOnly="False" Theme="BlackGlass" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td style="width: 208px">
                                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry date of Insuarnce Policy" Theme="Glass">
                                    </dx:ASPxLabel>
                                     <dx:ASPxLabel ID="ASPxLabel33" runat="server" ForeColor="Red" Text="*">
                                </dx:ASPxLabel>
                                </td>
                                <td style="width: 212px">
                                    <dx:ASPxDateEdit ID="txtpolicyexpirydate" runat="server" EditFormat="Custom" EditFormatString="dd MMM yyyy" Height="21px" Width="250px">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>--%>
                     <%--<tr>
                        <td colspan="5" style="height: 18px;">
                            <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Allied Insurance Details" Theme="Glass">
                            </dx:ASPxLabel>
                            <hr/>
                        </td>
                    </tr>--%>
 <%--<tr>
	<td style=" width: 208px;">
		<dx:ASPxLabel ID="ASPxLabel11q" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Insurance Company" Theme="Glass">
		</dx:ASPxLabel>
		 <dx:ASPxLabel ID="ASPxLabel27q" runat="server" ForeColor="Red" Text="*">
	</dx:ASPxLabel>
	</td>
	<td style="width: 212px">
		<dx:ASPxTextBox ID="txtinsuranceA" runat="server" Height="23px" ReadOnly="False" Theme="BlackGlass" Width="250px">
		</dx:ASPxTextBox>
	</td>
	<td style="width: 208px">
		<dx:ASPxLabel ID="ASPxLabel12q" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Insurance Policy No. &amp; Coverage" Theme="Glass">
		</dx:ASPxLabel>
		 <dx:ASPxLabel ID="ASPxLabel28q" runat="server" ForeColor="Red" Text="*">
	</dx:ASPxLabel>
	</td>
	<td style="width: 212px">
		<dx:ASPxTextBox ID="txtinsurancePolicyNoA" runat="server" Height="23px" ReadOnly="False" Theme="BlackGlass" Width="250px">
		</dx:ASPxTextBox>
	</td>
</tr>--%>
<%--<tr>
	<td style=" width: 208px;">
		<dx:ASPxLabel ID="ASPxLabel13q" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Sum Insured for each category" Theme="Glass">
		</dx:ASPxLabel>
		 <dx:ASPxLabel ID="ASPxLabel29q" runat="server" ForeColor="Red" Text="*">
	</dx:ASPxLabel>
	</td>
	<td style="width: 212px">
		<dx:ASPxTextBox ID="txtsumInsuredA" runat="server" Height="23px" ReadOnly="False" Theme="BlackGlass" Width="250px">
		</dx:ASPxTextBox>
	</td>
	<td style="width: 208px">
		<dx:ASPxLabel ID="ASPxLabel14a" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry date of Insuarnce Policy" Theme="Glass">
		</dx:ASPxLabel>
		 <dx:ASPxLabel ID="ASPxLabel33a" runat="server" ForeColor="Red" Text="*">
	</dx:ASPxLabel>
	</td>
	<td style="width: 212px">
		<dx:ASPxDateEdit ID="txtpolicyexpirydateA" runat="server" EditFormat="Custom" EditFormatString="dd MMM yyyy" Height="21px" Width="250px">
		</dx:ASPxDateEdit>
	</td>
</tr>--%>
    
                <tr>
                        <td colspan="5" style="height: 18px;">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Documents" Theme="Glass">
                            </dx:ASPxLabel>
                            <hr/>
                        </td>
                    </tr>
                              <%--  <tr>
                                    <td style=" width: 208px;">
                                        <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Document Type" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td style="width: 212px">
                                        <asp:DropDownList ID="cmbDocument" runat="server" AutoPostBack="true" ValidationGroup="upload" visible="True" Width="250px">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>photocopies of the insurance policies</asp:ListItem>
                                            <asp:ListItem>Standard Operating Procedures implemented in the warehouse</asp:ListItem>
                                            <asp:ListItem>Proof document of Ownership </asp:ListItem>
                                            <asp:ListItem>lease document</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="otherHide1" runat="server" visible="false">
                                    <td style=" width: 208px;">
		                                <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Enter Description" Theme="Glass">
		                                </dx:ASPxLabel>
	                                </td>
	                                <td style="width: 212px">
		                                <dx:ASPxTextBox ID="txtDocDescription" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
		                                </dx:ASPxTextBox>
	                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 208px">
                                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select File" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td style="width: 212px">
                                        <asp:FileUpload ID="FileUpload4" runat="server" Width="248px" />
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td style="width: 208px;"></td>
                                    <td style="width: 212px;">
                                        <dx:ASPxButton ID="btnUpload" runat="server" Text="Add Document" Theme="BlackGlass" ValidationGroup="upload">
                                        </dx:ASPxButton>
                                    </td>
                                </tr>--%>
                                <tr runat="server">
                                    <td align="center" colspan="4" style="height: 18px;">
                                        <asp:GridView ID="grdDocuments" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" HorizontalAlign="Center" Width="486px">
                                            <AlternatingRowStyle CssClass="altrowstyle" />
                                            <Columns>
                                                <%--<asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="LinkButton1" runat="server" AlternateText="Delete" CausesValidation="False" CommandName="Delete" Height="40px" ImageAlign="Middle" ImageUrl="~/img/recycle.jpg" OnClientClick="return isDelete();" ToolTip="Delete" Width="40px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Download">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="LinkButton2" runat="server" AlternateText="View" CausesValidation="False" CommandArgument='<%#Eval("ID")%>' CommandName="Select" Height="40px" ImageAlign="Middle" ImageUrl="~/img/view3.jpg" ToolTip="Download" Width="40px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("doctype") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="File Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("filename") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ContentType") %>'></asp:Label>
                                                        <asp:TextBox ID="txtDocId" runat="server" CssClass="col-xs-12 form-control input-sm" Text='<%#Eval("ID")%>' Visible="False"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                            <RowStyle CssClass="rowstyle" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                <tr>
                        <td colspan="5" style="height: 18px;">
                            <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="Weighing scales present in the storage facility" Theme="Glass">
                            </dx:ASPxLabel>
                            <hr/>
                        </td>
                    </tr>
                                    <tr>
                                        <td style=" width: 208px; height: 27px;">
                                            <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="width: 212px;">
                                            <dx:ASPxTextBox ID="txtscalename" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px;">
                                            <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="width: 212px">
                                            <dx:ASPxTextBox ID="txtscaleDescription" runat="server" Height="23px" ReadOnly="true" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px;"></td>
                                        <td style="width: 212px;">
                                           <%-- <dx:ASPxButton ID="btnsavesacle" runat="server" Text="Add Scale" Theme="BlackGlass">
                                            </dx:ASPxButton>--%>
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="true">
                                        <td align="center" colspan="4" style="height: 18px; ">
                                            <dx:ASPxGridView ID="grdscale" runat="server" Caption="Scales" Theme="Glass" Width="300px">
                                                <SettingsPager Visible="False">
                                                </SettingsPager>
                                            </dx:ASPxGridView>
                                        </td>
                                    </tr>
                <tr runat="server" visible="true">
                     <td style="width: 208px;">
                                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Your Comment" Theme="Glass">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="width: 212px">
                                            <dx:ASPxTextBox ID="txtcomment" runat="server" Height="23px"  BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" ValidationSettings-ErrorImage-Height="150px">
                                             </dx:ASPxTextBox>
                                        </td>
                </tr>
                <%--<tr  runat="server" visible="true">
                    <td style=" width: 212px; height: 27px;">
                        <br />
                        <br />
                    </td>
                    <td style=" width: 208px; height: 27px;">
                        <dx:ASPxButton ID="btnsave" runat="server" Text="Approve" Theme="BlackGlass" style="margin-bottom: 0px">
                            <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Confirm this is the warehouse you want to approve');}" />
                        </dx:ASPxButton>
                    </td>
                    <td style=" width: 212px; height: 27px;">
                        <dx:ASPxButton ID="btnReject" runat="server" Text="Reject" Theme="BlackGlass" style="margin-bottom: 0px">
                        </dx:ASPxButton>

                    </td>
                </tr>--%>
            </table>
        </asp:Panel>
    <asp:Panel  id="Panel2" runat="server" Font-Names="Cambria"   GroupingText="Action" Font-Bold="true" style="width: 100%">
        <table class="auto-style1">
            <tr  runat="server" visible="true">
                    <td style=" width: 212px; height: 27px;">
                        <br />
                        <br />
                    </td>
                    <td style=" width: 208px; height: 27px;">
                        <dx:ASPxButton ID="btnsave" runat="server" Text="Approve" Theme="BlackGlass" style="margin-bottom: 0px">
                            <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Confirm this is the warehouse you want to approve');}" />
                        </dx:ASPxButton>
                    </td>
                    <td style=" width: 212px; height: 27px;">
                        <dx:ASPxButton ID="btnReject" runat="server" Text="Reject" Theme="BlackGlass" style="margin-bottom: 0px">
                        </dx:ASPxButton>

                    </td>
                 <td style=" width: 212px; height: 27px;">

                     <br />
                        <br />
                       <br />
                        <br />
                 </td>
            
                </tr>
        </table>
        </asp:Panel>
</asp:Content>




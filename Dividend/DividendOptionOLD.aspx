<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="DividendOptionOLD.aspx.vb" Inherits="Corp_DivOption" title="Dividend Option" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="90%" Font-Names="Cambria" BackColor="White" GroupingText="Dividend Option">
       <table>
           <tr id="Tr1" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="Panel13a" runat="server">
                <td style="width: 208px">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                    <td style="width: 212px">
                       <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                   <td style="width: 212px"></td>
                   <td style="width: 212px"></td>
                    <td style="width: 212px"></td>
                    <td style="width: 212px"></td>
           </tr>
           <tr id="Tr5" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel72d" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Dividend No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxComboBox ID="cmbDivNo" runat="server" Theme="Glass" Width="250px"  CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide" AutoPostBack="False">
                            <Items>
                                <dx:ListEditItem Text="" Value="" /> 
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                  </tr>
           <tr id="Tr2" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Enter Name/Holder No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxTextBox ID="txtShareholder" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 212px">
                        <dx:ASPxButton ID="btnSearch" runat="server" Text=">>" Theme="Glass">
                            </dx:ASPxButton>
                    </td>
                  </tr>
           <tr id="Tr3" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                    <dx:ASPxListBox ID="lstNAME" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                    </dx:ASPxListBox>
                    </td>
                  </tr>
           <tr id="Tr4" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Holder No." Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtCDSNo" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Names" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtNames" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                  </tr>
           <tr id="Tr6" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel6a" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Asset Manager" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtAssetManager" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Shares Held" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtSharesheld" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                  </tr>
           <tr id="Tr8" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Div. Rate" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtDivRate" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Scrip Price" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtScripPrice" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                  </tr>
           <tr id="Tr9" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Gross" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtGross" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtTax" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                  </tr>
           <tr id="Tr10" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Net/Offered Cash" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtNetOffered" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Offered Shares" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtOfferedShares" ReadOnly="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                  </tr>
           <tr id="Tr7" runat="server">
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Accepted Cash" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtAcceptedCash" ReadOnly="false" AutoPostBack="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td style="width: 208px">
                        <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Accepted Shares" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 212px">
                     <dx:ASPxTextBox ID="txtAcceptedShares" ReadOnly="false" AutoPostBack="true" runat="server" BackColor="White" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                  </tr>
           <tr id="Tr11" runat="server">
                <td colspan="6">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                   <hr/>
                </td>
            </tr>
           <tr id="PanelSAVE" runat="server" visible="true">
                        <td style="width:208px"></td>
                        <td style="width:212px">
                            &nbsp;<dx:ASPxButton ID="btnUpdate" runat="server" Text="Update" Theme="Glass">
                            </dx:ASPxButton>
                        </td>
                </tr>
        </table> 
      </asp:Panel>
</asp:Content>


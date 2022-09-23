<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CurrencySetup.aspx.vb" Inherits="Parameters_CurrencySetup" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    <asp:Panel id="Panel1" runat="server" GroupingText="Currencies">
    <table width="100%">
    <tr>
        <td  align="left" style="height: 18px;" colspan="3">
            <dx1:ASPxLabel ID="ASPxLabel8" runat="server" Font-Size="Small" Text="Parameters&gt;&gt;Currency Setup" Theme="PlasticBlue"></dx1:ASPxLabel>
        </td>
    </tr>
    <tr>
        <td style="width: 163px">
            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Currency Code">
            </dx:ASPxLabel>
        </td>
        <td>
            <dx:ASPxTextBox ID="txtCCode" runat="server" Width="170px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 509px">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 163px">
            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Currency Name">
            </dx:ASPxLabel>
        </td>
        <td>
            <dx:ASPxTextBox ID="txtCName" runat="server" Width="170px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 509px">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 163px">
            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Currency Symbol">
            </dx:ASPxLabel>
        </td>
        <td>
            <dx:ASPxTextBox ID="txtCSymbol" runat="server" Width="170px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 509px">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 163px">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="International Standard">
            </dx:ASPxLabel>
        </td>
        <td>
            <dx:ASPxTextBox ID="txtIntStd" runat="server" Width="170px">
            </dx:ASPxTextBox>
        </td>
        <td style="width: 509px">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 163px; height: 16px">
            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="System Status">
            </dx:ASPxLabel>
        </td>
        <td style="height: 16px">
            <asp:DropDownList ID="ddSStatus" runat="server" Height="21px" Width="171px">
            </asp:DropDownList>
        </td>
        <td style="width: 509px; height: 16px"></td>
    </tr>
    <tr>
        <td style="width: 163px; height: 16px">
            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Country">
            </dx:ASPxLabel>
        </td>
        <td>
        <dx:ASPxComboBox ID="cmbCountry" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Width="170px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
        </dx:ASPxComboBox>
        </td>
        <td style="width: 509px; height: 16px"></td>
    </tr>
    <tr>
        <td style="width: 163px">&nbsp;</td>
        <td>&nbsp;</td>
        <td style="width: 509px">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 163px; height: 18px;"></td>
        <td style="height: 18px;">
            <dx:ASPxButton ID="btnSave" runat="server" Height="20px" Text="Save Currency" Width="161px">
            </dx:ASPxButton>
            <dx1:ASPxButton ID="btnDelete" runat="server" Height="20px" Text="Delete Currency" Visible="False" Width="110px">
            </dx1:ASPxButton>
            <dx1:ASPxButton ID="btnClear" runat="server" Height="20px" Text="Clear" Visible="False" Width="110px">
            </dx1:ASPxButton>
          </td>
        <td style="width: 509px; height: 18px;">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 163px; height: 107px;"></td>
        <td style="height: 107px;" colspan="2">
            <asp:GridView ID="grdvCurrencies" runat="server" AutoGenerateSelectButton="False" CellPadding="4" ForeColor="#333333" Width="782px" Font-Size="Small">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle CssClass="headerstyle" BackColor="#B7D8DC" ForeColor="Black" HorizontalAlign="left" />
                <PagerStyle BackColor="white" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="white" />
                <SelectedRowStyle BackColor="white" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="Edit" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    <tr>
        <td style="width: 163px; ">
        </td>
        <td>
        </td>
        <td style="width: 509px; ">
        </td>
    </tr>
    <tr>
        <td style="width: 163px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td style="width: 509px">
            &nbsp;</td>
    </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
</table>
        </asp:Panel>
   
</asp:Content>




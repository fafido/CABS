<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/CDSUser.master" CodeFile="pmexrpt.aspx.vb" Inherits="Reporting_ewr_newrpt" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;PMEX Report" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                    <dx:ASPxDateEdit ID="txtDateFrom" runat="server" Theme="BlackGlass" Width="250px"> 
                    </dx:ASPxDateEdit>
                </td>
            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                    <dx:ASPxDateEdit ID="txtDateTo" runat="server" Theme="BlackGlass" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
            </tr>
             <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="EWR No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                    <dx:ASPxComboBox ID="cmbEWRs" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        <Items>
                            <dx:ListEditItem Text="All" Value="All" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
             <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Code" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                    <dx:ASPxComboBox ID="cmbParticipantCode" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        <Items>
                            <dx:ListEditItem Text="All" Value="All" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Status" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                    <dx:ASPxComboBox ID="cmdStatus" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        <Items>
                            <dx:ListEditItem Text="All" Value="All" />
                            <dx:ListEditItem Text="Open" Value="Open" />
                            <dx:ListEditItem Text="Traded" Value="Traded" />
                            <dx:ListEditItem Text="Pending PMEX Fetch" Value="Pending PMEX Fetch" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                
            </tr>

             <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Produce" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                    <dx:ASPxComboBox ID="cmdProduce" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        <Items>
                            <dx:ListEditItem Text="All" Value="All" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="1"></td>
                <td colspan ="1">
                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                   
                </td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>
<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SellProcceedPayments.aspx.vb" Inherits="Custodian_SellProcceedPayments" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table runat="server">
            <tr>
                <td>From</td>
                <td>
                    <BDP:BasicDatePicker ID="ddateFrom" runat="server" ReadOnly="True">
                    </BDP:BasicDatePicker>
                </td>
                <td>To</td>
                <td style="width: 237px">
                    <BDP:BasicDatePicker ID="ddto" runat="server" ReadOnly="True">
                    </BDP:BasicDatePicker>
                </td>
                <td>
                    &nbsp;</td>
                 <td>
                     &nbsp;</td>
                
                 <td>
                     <asp:CheckBox ID="chkText" runat="server" Text="Paynet" Checked="True" Enabled="False" />
                </td>

                <td>
                    <asp:button id="Button1" runat="server" text="Load" />
                </td>
            </tr>
        </table>
    </div>

    <div>
    </div>
</asp:Content>


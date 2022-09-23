<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="LendingAndBorrowing.aspx.vb" Inherits="Pledges_LendingAndBorrowing" title="Landing And Borrowing" %>
<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>

    <tr>

        <td>

                <table>
                        <tr>

                            <td colspan ="2">
                                <asp:Label ID="Label1" runat="server" Text="Holder No."></asp:Label></td>
                            <td colspan ="4">
                                <asp:TextBox ID="txtHolderNoSearch" runat="server" Width="300px"></asp:TextBox></td>

                        </tr>
                    <tr>
                        <td colspan ="2">
                            <asp:Label ID="Label2" runat="server" Text="Holder Name Search"></asp:Label></td>
                        <td colspan ="4">
                            <asp:TextBox ID="txtHolderNameSearch" runat="server" Width="300px" 
                                AutoPostBack="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan ="2"></td>
                        <td colspan ="4">
                            <asp:ListBox ID="lstNameSearch" AutoPostBack ="true"  runat="server" Width="300px"></asp:ListBox></td>

                    </tr>
                    <tr>
                        <td colspan ="2"></td>
                        <td colspan ="4"><asp:Label id="lblSelectedAccNo" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan ="2"></td>
                        <td colspan ="4"><asp:Label id="lblSelectedName" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan ="2"></td>
                        <td colspan ="4"><asp:Label id="lblSelectedAddress" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>

                            <td colspan ="2">
                                <asp:Label ID="Label3" runat="server" Text="Companies"></asp:Label></td>
                        <td colspan ="4">
                            <asp:ListBox ID="LstCompanies" AutoPostBack ="true"  runat="server" Width="300px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                            <td colspan ="2">
                                <asp:Label ID="Label4" runat="server" Text="Holding Shares"></asp:Label></td>
                        <td colspan ="4">
                            <asp:Label ID="lblHoldingShares" runat="server" Text=""></asp:Label></td>

                    </tr>
                    <tr>
                            <td colspan ="2">
                                <asp:Label ID="Label5" runat="server" Text="Borrowed Shares"></asp:Label></td>
                        <td colspan ="4">
                            <asp:Label ID="lblBorrowedShares" runat="server" Text=""></asp:Label></td>

                    </tr>
                    <tr>
                            <td colspan ="2">
                                <asp:Label ID="Label6" runat="server" Text="Borrowed Outstanding"></asp:Label></td>
                        <td colspan ="4">
                            <asp:Label ID="lblBorrowedOutstanding" runat="server" Text=""></asp:Label></td>

                    </tr>
                    <tr>
                            <td colspan ="2"></td>
                        <td colspan ="4" style ="text-align:center;">
                            <asp:RadioButton ID="rdLend" Text ="Lend Shares" AutoPostBack="true"  GroupName ="Sharemovement" runat="server" />
                            <asp:RadioButton ID="rdBorrow" Text ="Borrow Shares" AutoPostBack="true"  GroupName ="Sharemovement" runat="server" />
                            <asp:RadioButton ID="rdReturnBorrow" Text ="Return Borrowing" AutoPostBack="true"  GroupName ="Sharemovement" runat="server" /></td>

                    </tr>
                    <tr>
                            <td colspan ="2">
                                <asp:Label ID="Label7" runat="server" Text="Shares"></asp:Label></td>
                        <td colspan ="4">
                            <asp:TextBox ID="txtShares" runat="server" Width="300px"></asp:TextBox></td>

                    </tr>
                    <tr>
                            <td colspan ="2">
                                <asp:Label ID="Label8" runat="server" Text="Return Date"></asp:Label></td>
                        <td colspan ="4">
                            <BDP:BasicDatePicker ID="BasicDatePicker1" runat="server" Width="175px">
                            </BDP:BasicDatePicker>
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="2"></td>
                        <td colspan ="4" style ="text-align:center;">
                            <asp:Button ID="btnSave" runat="server" Text="Save" />
                            </td>

                    </tr>

                </table>

        </td>

    </tr>

</table>
    
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>


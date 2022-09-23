<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BorrowingRequestApproval.aspx.vb" Inherits="BrokerMode_BorrowingRequestApproval" title="Broker Home" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>


<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial" width="848px"></asp:Label></td>
            </tr>
                               
            </table>
            <table>
            
                <tr>

                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Pending Accounts" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="7">
                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Theme="Glass" ValueType="System.String" Width="500px">
                        </dx:ASPxComboBox>
                    </td>
                    
                </tr>
                <tr>

                    <td colspan ="1"></td>
                    <td colspan ="3">
                        &nbsp;</td>
                    
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
           
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="3">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>


                </tr>
                <tr>

                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Client Type" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbClientType" runat="server" AutoPostBack="True" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Client Code" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtClientCode" runat="server" Theme="Glass" Width="155px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Client Name" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="Net Value" Theme="Office2010Blue">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtNetValue" runat="server" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="Credit Limit" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtClientCode0" runat="server" Theme="Glass" Width="155px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="2" align="right">
                            &nbsp;</td>
                    <td colspan ="4" style="align-items:center;">
                        &nbsp;</td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel23" runat="server" Text="Company" Theme="Office2010Blue">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="cmbCompany" runat="server" DataSourceID="getCompany" Theme="Glass" Width="250px" AutoPostBack="True" TextField="company" ValueField="company">
                        </dx:ASPxComboBox>
                        <asp:SqlDataSource ID="getCompany" runat="server" ConnectionString="<%$ ConnectionStrings:CDSConnectionString %>" SelectCommand="select distinct (company) from para_company"></asp:SqlDataSource>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel24" runat="server" Text="Security Type" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="cmbSecurityType" runat="server" AutoPostBack="True" DataSourceID="borrowingSecurityType" EnableTheming="True" TextField="Security" Theme="Glass" ValueField="Security" Width="170px">
                        </dx:ASPxComboBox>
                        <asp:SqlDataSource ID="borrowingSecurityType" runat="server" ConnectionString="<%$ ConnectionStrings:CDSConnectionString %>" SelectCommand="select distinct Security from para_lendingRules"></asp:SqlDataSource>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="Current Unit Price" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtCurrentPrice" runat="server" Theme="Glass" Width="155px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="Credit Applied" Theme="Office2010Blue">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtCreditAplied" runat="server" AutoPostBack="True" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="Possible Units" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtPossibleUnits" runat="server" Theme="Glass" Width="170px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="Return Date" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="txtreturnDate" runat="server" Theme="Office2003Blue">
                        </dx:ASPxDateEdit>
                        </td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text="Interest Rate" Theme="Office2010Blue">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtInterestRate" runat="server" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel21" runat="server" Text="Repayment Amount" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtRepaymentAmount" runat="server" Theme="Glass" Width="170px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel22" runat="server" Text="Monthly Repayment" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtMonthlyRepayment" runat="server" Theme="Glass" Width="155px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    

                </tr>
                <tr>
                        <td colspan ="8" align ="center">
                            <asp:RadioButton ID="rdApprove" runat="server" AutoPostBack="True" GroupName="Approval" Text="Approve" />
                            <asp:RadioButton ID="rdApprove0" runat="server" AutoPostBack="True" GroupName="Approval" Text="Reject" />
                        </td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Text="Rejection Reason" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="7">
                        <dx:ASPxTextBox ID="txtInterestRate0" runat="server" Theme="Glass" Width="710px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                   <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Borrow" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                    

                </tr>
                   <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1">
                            &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="3">
                        &nbsp;</td>
                    
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>

                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                        <td colspan ="1">
                            &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="8" style="text-align:center;">
                            &nbsp;</td>

                </tr>
                <tr>
                        <td colspan ="8" style=" align-items :center;">&nbsp;</td>

                </tr>
                <tr>

                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>


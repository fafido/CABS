<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsManagement.aspx.vb" Inherits="Parameters_AccountsManagement" title="Accounts Management" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Client Accounts Management" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Dormancy Period">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:CheckBox ID="chkMonths" runat="server" AutoPostBack="True" Text="Dormancy Period in Months" />
                                <asp:CheckBox ID="chkMonths0" runat="server" AutoPostBack="True" Text="Dormancy Period in Years" />
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Flag Account after " Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo10" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <asp:Label ID="lblPeriod1" runat="server"></asp:Label>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Unclaimed Dividend(s)" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px">
                                <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Flag Account after " Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="height: 18px">
                            <dx:ASPxTextBox ID="txtClientNo11" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1" style="height: 18px">
                            <asp:Label ID="lblPeriod2" runat="server"></asp:Label>
                            </td>
                        <td colspan ="1" style="height: 18px">
                            <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Returned Mail(s)" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="height: 18px"></td>
                        <td colspan ="1" style="height: 18px"></td>
                        <td colspan ="1" style="height: 18px"></td>
                        <td colspan ="1" style="height: 18px"></td>


                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px">
                            </td>
                        <td colspan ="7" style="height: 18px">
                            &nbsp;</td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            <dx:ASPxButton ID="ASPxButton6" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            &nbsp;</td>
                        <td colspan ="7">
                            &nbsp;</td>

                    </tr>
                 
        </table>
        </asp:Panel>
        <%--<asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Client Accounts Updates">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" GroupName="ClientVerifications" Text="Enable Client Verification on Account Transactions" />
                                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="ClientVerifications" Text="Enable Client Verification on Account Transactions" />
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:RadioButton ID="RadioButton5" runat="server" AutoPostBack="True" GroupName="Correspondence" Text="Verify By Email" />
                                <asp:RadioButton ID="RadioButton6" runat="server" AutoPostBack="True" GroupName="Correspondence" Text="Verify By Sms" />
                                <asp:RadioButton ID="RadioButton7" runat="server" AutoPostBack="True" GroupName="Correspondence" Text="Verify By Email and Sms" />
                            </td>

                    </tr>
                    <tr>
                        <td colspan ="8" align ="center">
                            <dx:ASPxButton ID="ASPxButton9" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>

                    </tr>
                 
                 
        </table>
        </asp:Panel>--%>
                       
</asp:Panel>
  
</div>
</asp:Content>


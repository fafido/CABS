<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AddNewBankersAcceptance.aspx.vb" Inherits="AddNewDerivContractt" title="Bankers Acceptance" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Bankers Acceptance&gt;Add B.As" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Bankers Acceptance" Width="854px">

                <table width="810px">
                    <tr>
                            <td colspan ="5" align ="center">
                                &nbsp;</td>

                    </tr>
                    <tr>
                            <td colspan ="1" style="width: 504px">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="B.A No." Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtBANo" runat="server" Theme="Glass" Width="250px" ReadOnly="False">
                            </dx:ASPxTextBox>
                            </td>
                       
                        <td colspan ="1" style="width: 652px">
                            &nbsp;</td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search Company" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td style="width: 63px">
                            <dx:ASPxTextBox ID="txtSearchName" runat="server" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 63px">
                            <dx:ASPxButton ID="btnSearchName" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="38px">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1" style="width: 652px">&nbsp;</td>
                        <td colspan ="1" style="width: 311px"></td>
                        

                    </tr>
                    <tr>
                            <td colspan ="1" style="width: 504px">
                                &nbsp;</td>
                        <td colspan ="2" style="width: 63px">
                            <dx:ASPxListBox ID="lstNames" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="293px" Visible="False">
                            </dx:ASPxListBox>
                            </td>
                        <td colspan ="1" style="width: 652px">
                            &nbsp;</td>
                        <td colspan ="1" style="width: 311px">
                            &nbsp;</td>
                       


                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company Fullname" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtfullname" runat="server" Theme="Glass" Width="250px" ReadOnly="False" Height="23px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company Email" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxTextBox ID="txtemail" runat="server" ReadOnly="False" Theme="Glass" Width="250px" Height="23px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Holder Phone" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtphone" runat="server" Theme="Glass" Width="250px" ReadOnly="False" Height="23px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Holder Code" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxTextBox ID="txtcode" runat="server" ReadOnly="False" Theme="Glass" Width="250px" Height="23px">
                            </dx:ASPxTextBox>
                        </td>
                       
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address 1" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtadd1" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address 2" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxTextBox ID="txtadd2" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                       
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address 3" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtadd3" runat="server" Theme="Glass" Width="250px" Height="23px" ReadOnly="False">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address 4" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxTextBox ID="txtadd4" runat="server" Theme="Glass" Width="250px" Height="23px" ReadOnly="False">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issue Date" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxDateEdit ID="txtIssueDate" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                            </dx:ASPxDateEdit>
                        </td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenor" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxTextBox ID="txtTenor" runat="server" Height="23px" Theme="Glass" Width="250px" AutoPostBack="True">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Status" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxComboBox ID="cmbStatus" runat="server" Height="23px" Width="250px">
                                <Items>
                                    <dx:ListEditItem Text="Active" Value="Active" />
                                    <dx:ListEditItem Text="InActive" Value="InActive" />
                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issuer" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxComboBox ID="cmbIssuer" runat="server" Height="23px" Width="250px">
                                <Items>
                                    <dx:ListEditItem Text="Base metals" Value="Base metals" />
                                    <dx:ListEditItem Text="Precious Metals" Value="Precious Metals" />
                                    <dx:ListEditItem Text="Agricultural" Value="Agricultural" />
                                    <dx:ListEditItem Text="Commodity Actuals" Value="Commodity Actuals" />
                                    <dx:ListEditItem Text="Stock Options" Value="Stock Options" />
                                    <dx:ListEditItem Text="Commodity Options" Value="Commodity Options" />
                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Face Value" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtFaceValue" runat="server" AutoPostBack="True" Height="23px" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxDateEdit ID="txtMaturityDate" runat="server" AutoPostBack="True" Height="23px" Width="250px">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Discount %" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtDiscountPerc" runat="server" AutoPostBack="True" Height="23px" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issue Price" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxTextBox ID="txtDiscountedAmt" runat="server" Height="23px" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Broker" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxTextBox ID="txtBroker" runat="server" Height="23px" ReadOnly="False" Theme="Glass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Guarantee" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxComboBox ID="cmbbankGuarantee" runat="server" Height="23px" Width="250px">
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            &nbsp;</td>
                        <td colspan="2" style="width: 63px">
                            &nbsp;</td>
                        <td colspan="1" style="width: 652px">
                            <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Accept Participant" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1" style="width: 311px">
                            <dx:ASPxTextBox ID="txtAcceptParticipant" runat="server" Height="23px" Theme="Glass" Visible="False" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Purpose" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxMemo ID="txtPurpose" runat="server" Height="71px" Width="320px">
                            </dx:ASPxMemo>
                        </td>
                        <td colspan="1" style="width: 652px">&nbsp;</td>
                        <td colspan="1" style="width: 311px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">&nbsp;</td>
                        <td colspan="2" style="width: 63px">
                            <dx:ASPxButton ID="btnSaveContract" runat="server" Text="Post B.A" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1" style="width: 652px">&nbsp;</td>
                        <td colspan="1" style="width: 311px">&nbsp;</td>
                       
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">&nbsp;</td>
                        <td colspan="2" style="width: 63px">&nbsp;</td>
                        <td colspan="1" style="width: 652px">
                            <asp:Label ID="Label2" runat="server" Text="List of Posted B.As" Visible="False"></asp:Label>
                        </td>
                        <td colspan="1" style="width: 311px">&nbsp;</td>
                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px; width: 504px;">
                            </td>
                        <td colspan ="4" style="height: 18px">
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Glass" Width="640px" Caption ="List of Posted B.As">
                                <SettingsPager Visible="False">
                                </SettingsPager>
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1" style="width: 504px"></td>
                        <td colspan ="4" align="center">
                            &nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="1" style="width: 504px">
                            &nbsp;</td>
                        <td colspan ="4">
                            &nbsp;</td>

                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>


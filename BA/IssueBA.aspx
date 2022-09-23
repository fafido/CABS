<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="IssueBA.aspx.vb" Inherits="BA_IssueBA" title="Issue BA" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Bankers Acceptance&gt;&gt;Issue BA" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel2" runat="server" GroupingText="Principal Borrower Details" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan ="1" style="width: 185px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of Company" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtcompany_name" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                

            </tr>
            <tr>
                <td colspan="1" style="height: 18px; width: 185px;">
                    <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company Code" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 18px">
                    <dx:ASPxTextBox ID="txtcompany" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1" style="height: 18px"></td>
                <td colspan="1" style="height: 18px"></td>
                <td colspan="1" style="height: 18px"></td>
                <td colspan="1" style="height: 18px"></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 185px">
                    <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtemail" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 185px">
                    <dx:ASPxLabel ID="ASPxLabel81" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Phone" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtphone" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 185px">
                    <dx:ASPxLabel ID="ASPxLabel92" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reference Number" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtloanref" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 185px">
                    <dx:ASPxLabel ID="ASPxLabel93" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Purpose" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtpurpose" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 185px">
                    <dx:ASPxLabel ID="ASPxLabel82" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtaddress" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="550px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 185px">&nbsp;</td>
                <td>
                    <dx:ASPxTextBox ID="txtadd2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="550px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 185px">&nbsp;</td>
                <td>
                    <dx:ASPxTextBox ID="txtadd3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="550px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 185px">&nbsp;</td>
                <td>
                    <dx:ASPxTextBox ID="txtadd4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="550px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
                <td colspan="1">&nbsp;</td>
            </tr>
            <tr>
                    <td colspan ="6" align="center">
                        &nbsp;</td>


            </tr>
      </table>

    </asp:panel>
                 
        <asp:Panel ID="Panel3" runat="server" Font-Names="Cambria" GroupingText="Bankers Acceptance Details">
            <table width="810px">
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel91" runat="server" Font-Names="Cambria" Font-Size="Small" Text="BA Number" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtbanumber" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel83" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Face Value" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtfacevalue" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 18px">
                        <dx:ASPxLabel ID="ASPxLabel84" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenor" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="height: 18px">
                        <dx:ASPxTextBox ID="txttenor" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" AutoPostBack="True">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                    <td colspan="1" style="height: 18px"></td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel85" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtmaturity" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel94" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Discount Option" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <table class="auto-style1">
                            <tr>
                                <td style="width: 4px">
                                    <dx:ASPxCheckBox ID="ASPxCheckBox4" runat="server" Text="Percentage" AutoPostBack="True">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td>
                                    <dx:ASPxCheckBox ID="ASPxCheckBox5" runat="server" Text="Amount" AutoPostBack="True">
                                    </dx:ASPxCheckBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel89" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Discount(%)" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtdiscount" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="40px" Enabled="False">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel95" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Discount(Amount[$])" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtdiscountamount" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="100px" Enabled="False">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td><table class="dxflInternalEditorTable">
                        <tr>
                            <td style="width: 107px">
                                <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Text="Compounding">
                                </dx:ASPxCheckBox>
                            </td>
                            <td style="width: 114px">
                                <dx:ASPxCheckBox ID="ASPxCheckBox2" runat="server" Text="Simple Interest">
                                </dx:ASPxCheckBox>
                            </td>
                            <td>
                                <dx:ASPxCheckBox ID="ASPxCheckBox3" runat="server" Text="Forward Rate">
                                </dx:ASPxCheckBox>
                            </td>
                        </tr>
                        </table>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel90" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Participants" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <asp:GridView ID="AspxGridView1" runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                            <Columns>
                                <asp:TemplateField HeaderText="Participants" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRow" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#424242" Font-Size="Small" ForeColor="White" />
                        </asp:GridView>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" valign="top">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" valign="top">&nbsp;</td>
                    <td>
                        <dx:ASPxCheckBox ID="chkbroadcast" runat="server" CheckState="Unchecked" Text="Issue BA and Broadcast">
                        </dx:ASPxCheckBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">&nbsp;</td>
                    <td align="center" colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Height="20px" Text="Create BA" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="6">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
                 
</asp:Panel>
  
</div>
</asp:Content>


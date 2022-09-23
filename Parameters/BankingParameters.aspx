<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BankingParameters.aspx.vb" Inherits="Parameters_BankingParameters" title="Account Details Enquiry" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Banks &amp; Branches" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Banks">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:RadioButton ID="rdCreateNew" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Create New" />
                                <asp:RadioButton ID="rdCreateNew0" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Update Exisiting" />
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDropDownEdit ID="ASPxDropDownEdit4" runat="server" Theme="Glass" Width="250px">
                            </dx:ASPxDropDownEdit>
                            </td>
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
                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo10" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Code" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo11" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                            <td colspan ="8" align="center"><asp:CheckBox runat="server" ID="chkSwift" Text="Enable Swift"></asp:CheckBox>
                                <asp:CheckBox ID="chkSwift0" runat="server" Text="Enable Postillion" />
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px">
                            </td>
                        <td colspan ="7" style="height: 18px">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Glass" Width="640px">
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            <dx:ASPxButton ID="ASPxButton6" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="ASPxButton5" runat="server" BackColor="#FF3300" Text="delete" Theme="RedWine">
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
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Branches">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Create New" />
                                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Update Exisiting" />
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDropDownEdit ID="ASPxDropDownEdit5" runat="server" Theme="Glass" Width="250px">
                            </dx:ASPxDropDownEdit>
                            </td>
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
                            <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxDropDownEdit ID="ASPxDropDownEdit7" runat="server" Theme="Glass" Width="250px">
                            </dx:ASPxDropDownEdit>
                        </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch Code" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px">
                            </td>
                        <td colspan ="7" style="height: 18px">
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Glass" Width="640px">
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            <dx:ASPxButton ID="ASPxButton7" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="ASPxButton8" runat="server" BackColor="#FF3300" Text="delete" Theme="RedWine">
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
        <asp:Panel runat="server" ID="Panel6" Font-Names="Cambria" GroupingText="Nationality">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Create New" />
                                <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Update Exisiting" />
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDropDownEdit ID="ASPxDropDownEdit6" runat="server" Theme="Glass" Width="250px">
                            </dx:ASPxDropDownEdit>
                            </td>
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
                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nationality Code" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px">
                            </td>
                        <td colspan ="7" style="height: 18px">
                            <dx:ASPxGridView ID="ASPxGridView3" runat="server" Theme="Glass" Width="640px">
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            <dx:ASPxButton ID="ASPxButton9" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="ASPxButton10" runat="server" BackColor="#FF3300" Text="delete" Theme="RedWine">
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
                       
</asp:Panel>
  
</div>
</asp:Content>


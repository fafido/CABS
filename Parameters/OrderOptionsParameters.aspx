<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="OrderOptionsParameters.aspx.vb" Inherits="Parameters_OrderOptionsParameters" title="Order Options" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Market Orders Options" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Market Board">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:RadioButton ID="rdCreateNew" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Create New" />
                                <asp:RadioButton ID="rdCreateNew0" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Update Exisiting" />
                            </td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
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
                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtClientNo10" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type Code" Theme="Glass">
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
                            <td colspan ="8" align="center">&nbsp;</td>

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
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Order Qualifiers">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Create New" />
                                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Update Exisiting" />
                            </td>

                    </tr>
                 
                    <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
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
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type Code" Theme="Glass">
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
         <asp:Panel runat="server" ID="Panel2" Font-Names="Cambria" GroupingText="Order Preference">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:RadioButton ID="RadioButton5" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Create New" />
                                <asp:RadioButton ID="RadioButton6" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Update Exisiting" />
                            </td>

                    </tr>
                 
                    <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxDropDownEdit ID="ASPxDropDownEdit1" runat="server" Theme="Glass" Width="250px">
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
                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type Code" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                            <dx:ASPxGridView ID="ASPxGridView4" runat="server" Theme="Glass" Width="640px">
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="ASPxButton2" runat="server" BackColor="#FF3300" Text="delete" Theme="RedWine">
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
         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Time in force">

                <table width="810px">
                    <tr>
                            <td colspan ="8" align ="center">
                                <asp:RadioButton ID="RadioButton7" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Create New" />
                                <asp:RadioButton ID="RadioButton8" runat="server" AutoPostBack="True" GroupName="CountryOptions" Text="Update Exisiting" />
                            </td>

                    </tr>
                 
                    <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxDropDownEdit ID="ASPxDropDownEdit2" runat="server" Theme="Glass" Width="250px">
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
                                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type Code" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
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
                            <dx:ASPxGridView ID="ASPxGridView5" runat="server" Theme="Glass" Width="640px">
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            <dx:ASPxButton ID="ASPxButton3" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="ASPxButton4" runat="server" BackColor="#FF3300" Text="delete" Theme="RedWine">
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


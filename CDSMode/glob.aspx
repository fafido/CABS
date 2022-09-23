<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="glob.aspx.vb" Inherits="CDSMode_glob" title="Global Securities Registration" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:panel runat="server" scrollbars="Auto" font-names="Cambria" font-size="Medium" groupingtext="Parameters&gt;&gt;Global Issuer Setup" backcolor="White">
        <asp:Panel runat="server" ID="panel2" Font-Names="Cambria" GroupingText="Global Issuer">

            <table>
                <tr>
                    <td colspan ="6" align ="center">
                        <asp:RadioButtonList runat="server" id="rdbType" repeatdirection="horizontal" autopostback="true" Visible="False">
                            <asp:listitem value="New" text="Company Issuer"></asp:listitem>
                            <asp:listitem value="Update" text="Individual"></asp:listitem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel runat="server" ID="lblSearchSecName" Font-Names="Cambria" Font-Size="Small" Text="Security Name"  Visible="False"></dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="display:inline;">
                        <dx:ASPxTextBox ID="txtSearchSecName" runat="server"   Width="200px" Visible="False">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnSearchSecName" runat="server" Text=">>"  CausesValidation="False"></dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issuer Name" >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtSecName" runat="server"   Width="200px">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel59" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issuer Code" >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtissuercode" runat="server"   Width="200px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel61" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issued Shares" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtissuedshares" runat="server"   Width="200px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Incorporation" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxDateEdit ID="dtYear" runat="server"  Width="200px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 32px">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Industry Type" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 32px">
                        <dx:ASPxComboBox ID="cmbIndexType" runat="server"  ValueType="System.String" Width="200px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 32px">
                        <dx:ASPxLabel ID="ASPxLabel60" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Custodian" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 32px">
                        <dx:ASPxTextBox ID="txtissuercode0" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 32px">&nbsp;</td>
                    <td colspan="1" style="height: 32px">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbCountryListed" runat="server"  ValueType="System.String" Width="200px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Units">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtissuercode1" runat="server" Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                        <td colspan ="1" style="height: 24px">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Registered Office" >

                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="5" style="height: 24px">
                            <dx:ASPxTextBox ID="txtRegdOffice1" runat="server"  Width="630px"  Height="20px">
                                <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                </tr>
                <tr>
                    <td colspan ="1"></td>
                    <td colspan ="5">
                        <dx:ASPxTextBox ID="txtRegdOffice2" runat="server" Width="630px"   >
                        </dx:ASPxTextBox>
                    </td>

                </tr>
                <tr>
                    <td colspan ="1"></td>
                    <td colspan ="5">
                        <dx:ASPxTextBox ID="txtRegdOffice3" runat="server" Width="630px"   >
                        </dx:ASPxTextBox>
                    </td>

                </tr>
                <tr>
                    <td colspan ="1" style="height: 23px"></td>
                    <td colspan ="5" style="height: 23px">
                        <dx:ASPxTextBox ID="txtRegdOffice4" runat="server" Width="630px"  >
                        </dx:ASPxTextBox>
                    </td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transfer Secretary" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="5">
                        <dx:ASPxComboBox ID="txtcompsecretary" runat="server"  ValueType="System.String" Width="200px">
                            <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Phone No." >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtPhoneNo" runat="server"   Width="200px">
                                <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fax No." >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtFaxNo" runat="server"   Width="200px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>



                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtEmail" runat="server"   Width="200px">
                                <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Website" >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtWebsite" runat="server"   Width="200px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>



                </tr>
                 <tr>
                        <td colspan ="1" style="height: 23px">
                            &nbsp;</td>
                        <td colspan ="1" style="height: 23px">
                            &nbsp;</td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxTextBox ID="txtISIN" runat="server"   Visible="False" Width="200px">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1" style="height: 23px">
                            </td>
                        <td colspan ="1" style="height: 23px">
                            </td>



                </tr>
                <tr>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>



                </tr>
                <tr>
                        <td align="center" colspan ="6">
                            <dx:ASPxButton ID="btnSaveCompany" runat="server" Text="Save Company">
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



                </tr>

            </table>
        </asp:Panel>
            <asp:Panel runat="server" ID="panel6" Font-Names="Cambria" GroupingText="Shareholding" Visible="False" Width="903px">

            <table>
              
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Locals" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox30" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="%" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Foreigners" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox31" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="%" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1"></td>

                </tr>
             
            </table>
        </asp:Panel>
            <asp:Panel runat="server" ID="panel1" Font-Names="Cambria" GroupingText="Bond Register Details" Visible="False">

            <table>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Type" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit6" runat="server"  Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Ticker" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtTicker" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Board" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtBoard" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbcurrency" runat="server"  ValueType="System.String" Width="200px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax On Bonds" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox19" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel21" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issue Price" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox21" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tranche No." >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox20" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tranche Date" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server"  Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenure" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox18" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="ASPxComboBox5" runat="server"  Width="80px">
                            <Items>
                                <dx:ListEditItem Text="Days" Value="Days" />
                                <dx:ListEditItem Text="Months" Value="Months" />
                                <dx:ListEditItem Text="Years" Value="Years" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit3" runat="server"  Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Interest Payment Intervals" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox22" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="ASPxComboBox6" runat="server"  Width="80px">
                            <Items>
                                <dx:ListEditItem Text="Days" Value="Days" />
                                <dx:ListEditItem Text="Months" Value="Months" />
                                <dx:ListEditItem Text="Years" Value="Years" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Interest Type" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="ASPxComboBox7" runat="server"  ValueType="System.String" Width="200px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                  <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Redemption" >
                        </dx:ASPxLabel>
                      </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox24" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                      </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Interest Rate" >
                        </dx:ASPxLabel>
                      </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox23" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                      </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
         
 
            </table>
        </asp:Panel>

            <asp:Panel runat="server" ID="panel3" Font-Names="Cambria" GroupingText="Tresuary Bills Register Details" Visible="False">

            <table>
                <tr>

                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Type" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit7" runat="server"  Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                    <td colspan ="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel17" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tax On Bonds" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1" style="height: 23px">
                        <dx:ASPxTextBox ID="ASPxTextBox16" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1" style="height: 23px"></td>
                    <td colspan ="1" style="height: 23px"></td>
                    <td colspan ="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issue Price" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1" style="height: 23px">
                        <dx:ASPxTextBox ID="ASPxTextBox17" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1" style="height: 23px"></td>
                    <td colspan ="1" style="height: 23px"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tranche No." >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox25" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tranche Date" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit4" runat="server"  Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Tenure" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox26" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="ASPxComboBox4" runat="server"  Width="80px">
                            <Items>
                                <dx:ListEditItem Text="Days" Value="Days" />
                                <dx:ListEditItem Text="Months" Value="Months" />
                                <dx:ListEditItem Text="Years" Value="Years" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maturity Date" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit5" runat="server"  Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Interest Payment Intervals" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox27" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="ASPxComboBox8" runat="server"  Width="80px">
                            <Items>
                                <dx:ListEditItem Text="Days" Value="Days" />
                                <dx:ListEditItem Text="Months" Value="Months" />
                                <dx:ListEditItem Text="Years" Value="Years" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Interest Type" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxComboBox ID="ASPxComboBox9" runat="server"  ValueType="System.String" Width="200px">
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                  <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Redemption" >
                        </dx:ASPxLabel>
                      </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox28" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                      </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Implied Interest" >
                        </dx:ASPxLabel>
                      </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="ASPxTextBox29" runat="server"   Width="200px">
                        </dx:ASPxTextBox>
                      </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Announcement Date" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit8" runat="server"  Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Auction Date" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxDateEdit ID="ASPxDateEdit9" runat="server"  Width="200px">
                        </dx:ASPxDateEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Opening Time" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTimeEdit ID="ASPxTimeEdit1" runat="server" Theme="Office2003Olive" Width="200px">
                        </dx:ASPxTimeEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Closing Time" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTimeEdit ID="ASPxTimeEdit2" runat="server" Theme="RedWine" Width="200px">
                        </dx:ASPxTimeEdit>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                 <tr>
                    <td colspan ="8">
                        <asp:Panel ID="Panel7" runat="server" Enabled="False">
                            <asp:Panel ID="Panel8" runat="server" Height="319px">
                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issued Capital (Units)" >
                                </dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txtIssuedCapital" runat="server"   Width="200px">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                                <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nominal Value" >
                                </dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txtNominalValue" runat="server"   Width="200px">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                                <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Status" >
                                </dx:ASPxLabel>
                                <dx:ASPxComboBox ID="cmbIndexType0" runat="server"  Width="200px">
                                    <Items>
                                        <dx:ListEditItem Text="Dealing Allowed" Value="Security Status" />
                                        <dx:ListEditItem Text="Dealings Suspended" Value="Dealings Suspended" />
                                        <dx:ListEditItem Text="CDS Suspended" Value="CDS Suspended" />
                                        <dx:ListEditItem Text="Trade Suspended" Value="Trade Suspended" />
                                        <dx:ListEditItem Text="Trading Halted" Value="Trading " />
                                        <dx:ListEditItem Text="Tripped" Value="Tripped" />
                                        <dx:ListEditItem Text="Expired" Value="Expired" />
                                    </Items>
                                    <ValidationSettings>
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Term" >
                                </dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txtNominalValue0" runat="server"   Width="200px">
                                </dx:ASPxTextBox>
                                <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Days to Maturity" >
                                </dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txtNominalValue1" runat="server"   Width="200px">
                                </dx:ASPxTextBox>
                                <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Foreign Holding Limit" >
                                </dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txtNominalValue2" runat="server"   Width="200px">
                                </dx:ASPxTextBox>
                                <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Coupon Rate" >
                                </dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txtNominalValue3" runat="server"   Width="200px">
                                </dx:ASPxTextBox>
                                <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Coupon Period(Years)" >
                                </dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txtNominalValue4" runat="server"   Width="200px">
                                </dx:ASPxTextBox>
                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Type" >
                                </dx:ASPxLabel>
                                <br />
                                <dx:ASPxComboBox ID="cmbSecType" runat="server"  ValueType="System.String" Width="200px">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <br />
                            </asp:Panel>
                        </asp:Panel>
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
         
 
            </table>
        </asp:Panel>

            <asp:Panel runat="server" ID="panel4" Font-Names="Cambria" GroupingText="Derivetives" Visible="False">

            <table>
               
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
        </asp:Panel>
<asp:Panel runat="server" ID="panel5" Font-Names="Cambria" GroupingText="__" HorizontalAlign="Center" Visible="False">

            <table>
               
                 <tr>
                    <td colspan ="8" align="center">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="save" >
                        </dx:ASPxButton>
                     </td>
                   

                </tr>
                 <tr>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel43" runat="server" Text="__________________________">
                        </dx:ASPxLabel>
                     </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel44" runat="server" Text="__________________________">
                        </dx:ASPxLabel>
                     </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel45" runat="server" Text="__________________________">
                        </dx:ASPxLabel>
                     </td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel47" runat="server" Text="__________________________">
                        </dx:ASPxLabel>
                     </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
         
 
            </table>
        </asp:Panel>

        
    </asp:panel>
    </div>
</asp:Content>

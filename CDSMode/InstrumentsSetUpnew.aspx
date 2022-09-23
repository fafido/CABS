<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="InstrumentsSetUpnew.aspx.vb" Inherits="CDSMode_InstrumentsSetUpnew" title="Instruments Setup" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register namespace="BasicFrame.WebControls" tagprefix="WebControls" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:panel runat="server" scrollbars="Auto" font-names="Cambria" font-size="Medium" groupingtext="Parameters>>Securities Setup" backcolor="White">
        <asp:Panel runat="server" ID="panel2" Font-Names="Cambria" GroupingText="Basic Details">

            <table>
                <tr>
                    <td colspan ="6" align ="center" style="height: 30px">
                        <asp:RadioButtonList runat="server" id="rdbType" repeatdirection="horizontal" autopostback="true" Visible="False">
                            <asp:listitem value="New" text="Create New"></asp:listitem>
                            <asp:listitem value="Update" text="Update Existing"></asp:listitem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel runat="server" ID="lblSearchSecName" Font-Names="Cambria" Font-Size="Small" Text="Issuer Name" ></dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="display:inline;">
                        <dx:ASPxComboBox ID="txtsearchsecname" runat="server" AutoPostBack="True"  ValueType="System.String" Width="200px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnSearchSecName" runat="server" Text=">>"  CausesValidation="False"></dx:ASPxButton>
                    </td>
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
                </tr>
                <tr>
                        <td colspan ="1" style="height: 32px">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Security Name" >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1" style="height: 32px">
                            <dx:ASPxTextBox ID="txtSecName" runat="server"   Width="200px">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1" style="height: 32px">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Ticker" >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1" style="height: 32px">
                            <dx:ASPxTextBox ID="txtTicker" runat="server"  Width="200px" AutoPostBack="True" >
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1" style="height: 32px">
                            </td>
                        <td colspan ="1" style="height: 32px">
                            </td>



                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Year Listed" >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxDateEdit ID="dtYear" runat="server"  Width="200px">
                                <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Board" >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="txtboard" runat="server" Width="200px">
                                <Items>
                                    <dx:ListEditItem Text="Equities Board" Value="Equities Board" />
                                </Items>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>



                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ISIN" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtISIN" runat="server"   Width="200px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country Listed" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxComboBox ID="cmbCountryListed" runat="server"  ValueType="System.String" Width="200px">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel58" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Segment">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtBoard0" runat="server" Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Registered Office" >

                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="5">
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
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company Secretary" >
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
                            <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" >
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxComboBox ID="cmbcurrency" runat="server"  ValueType="System.String" Width="200px">
                            </dx:ASPxComboBox>
                        </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxLabel ID="ASPxLabel57" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Initial Price">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxTextBox ID="txtprice" runat="server" Width="200px">
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
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Issued Capital (Units)" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtIssuedCapital" runat="server"   Width="200px" AutoPostBack="True">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Nominal Value" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtNominalValue" runat="server"   Width="200px" ReadOnly="True">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Status" >
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxComboBox ID="cmbIndexType0" runat="server"  Width="200px">
                            <Items>
                                <dx:ListEditItem Text="Dealing Allowed" Value="Security Status" />
                                <dx:ListEditItem Text="Dealing Suspended" Value="Dealings Suspended" />
                                <dx:ListEditItem Text="Trade Halted" Value="Trade Halted" />
                                                          </Items>
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxLabel ID="ASPxLabel56" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Foreign Limit(%)">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxTextBox ID="txtNominalValue2" runat="server" Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                </tr>
                <tr>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="1">
                        <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Term" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtNominalValue0" runat="server" Width="200px" Visible="False">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                </tr>
                <tr>
                        <td align="center" colspan ="6">
                            <dx:ASPxButton ID="btnSaveCompany" runat="server" Text="Save Equity">
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
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

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


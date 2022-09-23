<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="ClientCompanySetupAccept.aspx.vb" Inherits="Parameters_ClientCompanySetupAccept" title="Participant Approval" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table >
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="System User Accounts&gt;&gt;Participant Approval" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        <asp:Panel runat="server" ID="Panel2"  Font-Names="Cambria" GroupingText="Form Options" >

                <table style="width:100%">
                    <tr>
                            <td style="width:70px">
                                <dx:ASPxLabel ID="ASPxLabel87" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>

                            <td>
                                <table class="auto-style1">
                                    <tr>
                                        <td style="width: 89px">
                                            <dx:ASPxTextBox ID="txtsearchtext" runat="server" Theme="BlackGlass" Width="200px">
                                              
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="ASPxButton6" runat="server" CausesValidation="False" Height="22px" Text="Search" Theme="BlackGlass" validationgroup="test" Width="94px">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>

                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <dx:ASPxListBox ID="ASPxListBox2" runat="server" ValueType="System.String" Width="500px" AutoPostBack="True">
                            </dx:ASPxListBox>
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search" Theme="Glass" Visible="False">
                            </dx:ASPxLabel>
                            <asp:DropDownList ID="cmbParticipants" runat="server" AppendDataBoundItems="true" AutoPostBack="True" Visible="False" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" Font-Names="Cambria"  GroupingText="Participant Details" >
            <table>
                <tr>
                    <td colspan="1" style="width:300px; height: 29px;">
                        <dx:ASPxLabel ID="ASPxLabel88" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Update Type" Theme="Glass">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan="1" style="width: 200px; height: 29px;">
                        <asp:RadioButton ID="rdCreateNew" runat="server" AutoPostBack="True" GroupName="NewUpdate" Text="New" Enabled="False" />
                        <asp:RadioButton ID="rdUpdate" runat="server" AutoPostBack="True" GroupName="NewUpdate" Text="Update" Enabled="False" />
                    </td>
                    <td colspan="1" style="height: 29px">
                        <dx:ASPxLabel ID="ASPxLabel21" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Type" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 29px">
                        <dx:ASPxTextBox ID="txttype" runat="server" ReadOnly="true" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                        <asp:DropDownList ID="cmbType" runat="server" AppendDataBoundItems="true" Enabled="false" AutoPostBack="True" Width="200px" ReadOnly="true" Visible="False">
                        </asp:DropDownList>
                    </td>
                    <td style="height: 29px">
                        <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Code" Theme="Glass">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" ForeColor="Red" Text="*">
                        </dx:ASPxLabel>
                    </td>
                    <td style="height: 29px">
                        <dx:ASPxTextBox ID="txtCode" runat="server" ReadOnly="True" Theme="BlackGlass" Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="">
                        <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxTextBox ID="txtCompanyName" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="">
                        <dx:ASPxLabel ID="lblsecp" runat="server" Font-Names="Cambria" Font-Size="Small" Text="SECP CUI No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="">
                        <dx:ASPxTextBox ID="txtNTN" runat="server" ReadOnly="true" Theme="BlackGlass" Visible="False" Width="200px">
                        </dx:ASPxTextBox>
                        <dx:ASPxTextBox ID="txtsecp" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true" Visible="False">
                        </dx:ASPxTextBox>
                    </td>
                    <td style=" ">
                        &nbsp;</td>
                    <td style=" ">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" >
                        &nbsp;</td>
                    <td colspan="1" style="width: 200px">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Enabled="false" RepeatDirection="Horizontal" Visible="False">
                            <asp:ListItem>Individual</asp:ListItem>
                            <asp:ListItem>Company</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="1" >
                        &nbsp;</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 27px" >
                        </td>
                    <td colspan="1" style="height: 27px; width: 200px;">
                        </td>
                    <td colspan="1" style="height: 27px"  >
                        </td>
                    <td colspan="1" style="height: 27px">
                        </td>
                    <td colspan="2" style="height: 27px"></td>
                </tr>
                <tr>
                    <td colspan="1"  >
                        <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxTextBox ID="txtAdd1" runat="server" style="margin-top: 0px" ReadOnly="true" Theme="BlackGlass" Width="200px">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Country" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <asp:DropDownList ID="cmbCountry" AppendDataBoundItems="true" ReadOnly="true" Enabled="false" runat="server" Width="200px" AutoPostBack="True">
                              <%--<asp:ListItem Selected="True"  Value="--Select--"></asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <table style="width:100%" >
                            <tr>
                                <td >
                                    <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="right" >
                                    <dx:ASPxTextBox ID="txtcode7" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtTel" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                           <%-- <MaskSettings ErrorText="10 digits expected" Mask="0000000000" />--%>
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" ></td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxTextBox ID="txtAdd2" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" width: 117px;">
                        <dx:ASPxLabel ID="ASPxLabel74" runat="server" Font-Names="Cambria" Font-Size="Small" Text="City" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" >
                        <asp:DropDownList ID="cmbCity" runat="server"   AppendDataBoundItems="true" Width="200px" ReadOnly="true" Enabled="False">
                        </asp:DropDownList>
                    </td>
                    <td >
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Website" Theme="Glass">
                       
                             </dx:ASPxLabel>
                    </td>
                    <td >
                        <dx:ASPxTextBox ID="txtwebsite" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxTextBox ID="txtAdd3" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="ASPxLabel75" runat="server" Font-Names="Cambria" Font-Size="Small" Text="State" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <asp:DropDownList ID="cmbstate" AppendDataBoundItems="true" runat="server" Width="200px" ReadOnly="true" Enabled="False">
                             </asp:DropDownList>
                    </td>
                    <td style="">
                        <table style="width:100%" >
                            <tr>
                                <td style="height: 24px" >
                                    <dx:ASPxLabel ID="ASPxLabel79" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile No" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="right" style="height: 24px" >
                                    <dx:ASPxTextBox ID="txtcode6" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px" >
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtMobile" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                      <%-- <MaskSettings ErrorText="10 digits expected" Mask="0000000000" />--%>
                             </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxTextBox ID="txtEmail" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                            <ValidationSettings ErrorText="Invalid Email" SetFocusOnError="True">
                                <RegularExpression ErrorText="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        
                        <table style="width:100%" >
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel83" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Fax" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="right" >
                                    <dx:ASPxTextBox ID="txtcode9" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                        
                    </td>
                    <%--<td style="width: 10px">
                        <dx:ASPxTextBox ID="txtcodeFx" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px">
                        </dx:ASPxTextBox>
                    </td>--%>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtfax" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                    <%--        <MaskSettings ErrorText="10 digits expected" Mask="0000000000" />--%>
                        </dx:ASPxTextBox>
                    </td>
                    <td >
                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Contact Person" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td >
                        <dx:ASPxTextBox ID="txtContact" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Max Users" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxTextBox ID="txtmaxusers" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" >&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" >&nbsp;</td>
                    <td colspan="1" style="width: 200px">&nbsp;</td>
                    <td colspan="1" >&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <dx:ASPxLabel ID="ASPxLabel84" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Participant Representatives" Theme="Glass">
                        </dx:ASPxLabel>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxTextBox ID="txtContactName" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true" >
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1">
                        <table >
                            <tr>
                                <td >
                                    <dx:ASPxLabel ID="ASPxLabel82" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Telephone" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="right" >
                                    <dx:ASPxTextBox ID="txtcode8" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px" >
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtphoneNo"  ValidationSettings-ValidationGroup="test" ReadOnly="true" runat="server" Theme="BlackGlass" Width="200px">
                             <MaskSettings ErrorText="10 digits expected" Mask="0000000000" />
                           
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        <table >
                            <tr>
                                <td >
                                    <dx:ASPxLabel ID="ASPxLabel85" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile No" Theme="Glass">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="right"  >
                                    <dx:ASPxTextBox ID="txtcode10" runat="server" ReadOnly="True" Theme="BlackGlass" Width="40px" >
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtmobileno" runat="server" ValidationSettings-ValidationGroup="test" Theme="BlackGlass" ReadOnly="true" Width="200px">
                             <MaskSettings ErrorText="10 digits expected" Mask="0000000000" />
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Designation" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxTextBox ID="txtdesignation" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtpersonalemail" runat="server" ValidationSettings-ValidationGroup="test" ReadOnly="true" Theme="BlackGlass" Width="200px">
                               <ValidationSettings ErrorText="Invalid Email" SetFocusOnError="True">
                                <RegularExpression ErrorText="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtother" runat="server" Theme="BlackGlass" Width="200px" ReadOnly="true">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" ></td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxButton ID="ASPxButton5" runat="server" validationgroup="test" Height="22px" Text="Add Representative" Theme="BlackGlass" Width="155px" Visible="False">
                        </dx:ASPxButton>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1" ></td>
                    <td ></td>
                    <td ></td>
                </tr>
                <tr>
                    <td colspan="6" >
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" CellPadding="4" DataKeyNames="Entry ID" ForeColor="#333333" GridLines="None" Width="100%" Enabled="False">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <sortedascendingcellstyle backcolor="#F5F7FB" />
                            <sortedascendingheaderstyle backcolor="#6D95E1" />
                            <sorteddescendingcellstyle backcolor="#E9EBEF" />
                            <sorteddescendingheaderstyle backcolor="#4870BE" />
                           
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" >&nbsp;</td>
                    <td colspan="1" style="width: 200px">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <dx:ASPxLabel ID="ASPxLabel86" runat="server" Font-Names="Cambria" Font-Size="Medium" Text="Participant Banking Details" Theme="Glass">
                        </dx:ASPxLabel>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Bank Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxTextBox ID="txtmainbankname" runat="server" ReadOnly="True" Theme="BlackGlass" Width="200px">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Branch" Theme="Glass"  ReadOnly="True">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtmainbranch" runat="server" ReadOnly="True" Theme="BlackGlass" Width="200px">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 51px">
                        <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 200px; height: 51px;">
                        <dx:ASPxTextBox ID="txtmainaccount" runat="server" Theme="BlackGlass" Width="200px"  ReadOnly="True">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 51px">
                        <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account Name" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 51px">
                        <dx:ASPxTextBox ID="txtmainaccountname" runat="server" Theme="BlackGlass" Width="200px"  ReadOnly="True">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td style="height: 51px">
                        <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currency" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td style="height: 51px">
                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String" Width="200px" ReadOnly="True" Enabled="False">
                        </dx:ASPxComboBox>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Height="22px" Text="Add Currency" Theme="BlackGlass" Width="103px" Visible="False">
                        </dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="1"  valign="top">
                        <dx:ASPxLabel ID="ASPxLabel77" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Currencies" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="width: 200px">
                        <dx:ASPxListBox ID="ASPxListBox1" runat="server" ValueType="System.String" Width="200px"  ReadOnly="True">
                        </dx:ASPxListBox>
                    </td>
                    <td colspan="1" >&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6" style="height: 28px">
                        <asp:RadioButton ID="rdActive" runat="server" AutoPostBack="True" Checked="True" GroupName="Activation" Text="Activate" Visible="False" />
                        <asp:RadioButton ID="rdActive0" runat="server" AutoPostBack="True" GroupName="Activation" Text="Deactivate" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="6" style="height: 29px">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Approve" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;<dx:ASPxButton ID="ASPxButton4" runat="server" Text="Reject" Theme="BlackGlass" Visible="False">
                        </dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" >
                        <dx:ASPxLabel ID="lblrejectreason" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reject Reason" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="4">
                        <dx:ASPxTextBox ID="txtrejectreason" runat="server"  Theme="BlackGlass" Width="400px" Height="46px" Visible="False">
                            <ValidationSettings SetFocusOnError="true">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="4">
                        <dx:ASPxButton ID="btnreject" runat="server" Text="Reject" Theme="BlackGlass" Visible="False">
                        </dx:ASPxButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1" style="width: 200px">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1" style="width: 200px">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td colspan="1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
                    
</asp:Panel>
  

</asp:Content>


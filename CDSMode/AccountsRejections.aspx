<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountsRejections.aspx.vb" Inherits="CDSMode_AccountsRejections" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;" 
            __designer:mapid="21f">
        <tr align="center" __designer:mapid="220">
            <td style="width: 100%; height: 226px" valign="top" __designer:mapid="221">
                <table __designer:mapid="222">
                    <tr __designer:mapid="223">
                        <td style="width: 100%" align="left" __designer:mapid="224">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="System User Accounts&gt;&gt;Accounts Rejections" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                        </td>
                    </tr>
                </table>
               <%-- <table __designer:mapid="226" style="width: 291px">
                    <tr __designer:mapid="227">
                        <td align="left" __designer:mapid="228" style="width: 225px">
                            <asp:Label id="Label1" runat="server" Text="Bank Code" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="22a">
                            <asp:TextBox id="txtCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="22c">
                        <td align="left" __designer:mapid="22d" style="width: 225px">
                            <asp:Label id="Label2" runat="server" Text="Short Name" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="22f" style="text-align: left">
                            <asp:TextBox id="txtFname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" __designer:mapid="22d" style="width: 225px">
                            <asp:Label id="Label11" runat="server" Text="Bank" font-names="Arial" 
                            font-size="Small"></asp:Label>
                        </td>
                        <td __designer:mapid="22f" style="text-align: left">
                            <asp:TextBox id="txtName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr __designer:mapid="22c">
                        <td align="left" __designer:mapid="22d" style="width: 225px">
                            &nbsp;</td>
                        <td __designer:mapid="22f" style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr __designer:mapid="231">
                        <td align="left" __designer:mapid="232" colspan="2" style="text-align: center">
                            <asp:Button id="btnSave" runat="server" Text="Save" width="64px" 
                                style="height: 26px; text-align: center" />
                        </td>
                    </tr>
                </table>--%>
              <%--  <table __designer:mapid="249">
                    <tr __designer:mapid="24a">
                        <td colspan="3" align="center" bgcolor="#8080ff" style="height: 13px" 
                        __designer:mapid="24b">
                            <asp:Label id="Label10" runat="server" 
                            Text="..................................................................................................................................................................................................." 
                            width="848px"></asp:Label>
                        </td>
                    </tr>
                    <tr __designer:mapid="24d">
                        <td colspan ="1" style="width: 147px" __designer:mapid="24e">
                        </td>
                        <td __designer:mapid="24f">
                            <asp:GridView id="GridView1" runat="server" backcolor="White" 
                                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                GridLines="Horizontal" width="386px">
                                <RowStyle backcolor="#E7E7FF" forecolor="#4A3C8C" />
                                <FooterStyle backcolor="#B5C7DE" forecolor="#4A3C8C" />
                                <PagerStyle backcolor="#E7E7FF" forecolor="#4A3C8C" HorizontalAlign="Right" />
                                <SelectedRowStyle backcolor="#738A9C" font-bold="True" forecolor="#F7F7F7" />
                                <HeaderStyle backcolor="#4A3C8C" font-bold="True" forecolor="#F7F7F7" />
                                <AlternatingRowStyle backcolor="#F7F7F7" />
                            </asp:GridView>
                        </td>
                        <td colspan ="1" style="width: 424px" __designer:mapid="252">
                        </td>
                    </tr>
                </table>--%>

                <table style="width: 100%">
                  <tr>
                      <td align="left" style="height: 170px;width:100%" >
                          <asp:GridView ID="grdvCharges" runat="server" AutoGenerateSelectButton="False" OnPageIndexChanging="OnPageIndexChanging"  CellPadding="4" ForeColor="#333333" allowpaging="true" GridLines="None" Height="72px" Width="100%">
                              <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
                              
                              <EditRowStyle BackColor="#999999" />
                              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                              <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                              <SortedAscendingCellStyle BackColor="#E9E7E2" />
                              <SortedAscendingHeaderStyle BackColor="#506C8C" />
                              <SortedDescendingCellStyle BackColor="#FFFDF8" />
                              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                          </asp:GridView>
                      </td>
                  </tr>
                  <tr>
                      <td colspan="1"></td>
                  </tr>
                  <tr>
                      <td colspan="1"></td>
                  </tr>
                  <tr>
                      <td colspan="1"></td>
                  </tr>
              </table>


                <table __designer:mapid="253">
                    <tr __designer:mapid="254">
                        <td style="width: 850px" align="center" __designer:mapid="255">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>



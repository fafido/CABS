<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BillingPara.aspx.vb" Inherits="Parameters_BillingPara" title="Charges" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Billing" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="System Charges" Font-Names="Cambria">
        <table style="width: 826px">
            <tr>
                <td align ="center" style="width: 356px; height: 18px;">
                    </td>

                <td align="center" colspan="5" style="height: 18px">
                    &nbsp;</td>

            </tr>
             <tr>
                 <td align="center" style="width: 356px">&nbsp;</td>
                 <td align="center" colspan="5">&nbsp;</td>
            </tr>
             <tr>
                <td align="left" style="height: 14px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Security Type" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                 <td align="left" colspan="1" style="height: 14px; width: 264px;">
                     <dx:ASPxComboBox ID="cmbsecuritytype" runat="server" AutoPostBack="True" Theme="BlackGlass" Width="250px">
                         <Items>
                             <dx:ListEditItem Text="Commodity" Value="Commodity" />
                         </Items>
                     </dx:ASPxComboBox>
                 </td>
                <td colspan ="1" style="height: 14px; width: 73px;">
                    &nbsp;</td>
                <td colspan ="1" style="height: 14px">
                    &nbsp;</td>
                <td colspan ="1" style="height: 14px; width: 367px;">
                    &nbsp;</td>
                <td colspan ="1" style="height: 14px">&nbsp;</td>

            </tr>
            <tr>
                <td align="left" style="height: 14px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel18" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Charge Stage" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="1" style="height: 14px; width: 264px;">
                    <dx:ASPxComboBox ID="cmbchargestage" runat="server" AutoPostBack="True" Theme="BlackGlass" Width="250px">
                        <Items>
                            <dx:ListEditItem Text="Trading" Value="Trading" />
                            <dx:ListEditItem Text="Withdrawal" Value="Withdrawal" />
                            <dx:ListEditItem Text="Borrowing" Value="Borrowing" />
                            <dx:ListEditItem Text="Storage" Value="Storage" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td colspan="1" style="height: 14px; width: 73px;">&nbsp;</td>
                <td colspan="1" style="height: 14px">&nbsp;</td>
                <td colspan="1" style="height: 14px; width: 367px;">&nbsp;</td>
                <td colspan="1" style="height: 14px">&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="height: 14px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Code" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="1" style="height: 14px; width: 264px;">
                    <dx:ASPxTextBox ID="txtChargeCode" runat="server" BackColor="#E4E4E4" Height="18px" Theme="BlackGlass" Width="249px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1" style="height: 14px; width: 73px;"></td>
                <td colspan="1" style="height: 14px"></td>
                <td colspan="1" style="height: 14px; width: 367px;"></td>
                <td colspan="1" style="height: 14px"></td>
            </tr>
            <tr>
                <td align="left" style="height: 2px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Description" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="1" style="height: 2px; width: 264px;">
                    <dx:ASPxTextBox ID="txtChargeName" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="249px" Height="19px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1" style="height: 2px; width: 73px;">
                    </td>
                <td colspan="1" style="height: 2px">
                    </td>
                <td colspan="1" style="height: 2px; width: 367px;">
                    </td>
                <td colspan="1" style="height: 2px"></td>
            </tr>
            <tr>
                <td align="left" style="height: 2px; width: 356px;">
                    &nbsp;</td>
                <td colspan="4" align="left" style="height: 2px; ">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Percentage</asp:ListItem>
                        <asp:ListItem>Flat Value</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td colspan="1" style="height: 2px">&nbsp;</td>
            </tr>

            <tr>
                <td align="left" style="height: 2px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Value" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="4" style="height: 2px; ">
                    <dx:ASPxTextBox ID="txtPercent" runat="server" BackColor="#E4E4E4" Height="16px" Theme="BlackGlass" Width="249px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1" style="height: 2px">&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="height: 2px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Charge to" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="4" style="height: 2px; ">
                    <dx:ASPxComboBox ID="cmbchargeto" runat="server" AutoPostBack="True" Theme="BlackGlass" Width="250px">
                        <Items>
                            <dx:ListEditItem Text="Holder" Value="Holder" />
                            <dx:ListEditItem Text="Trader" Value="Trader" />
                            <dx:ListEditItem Text="Participant" Value="Participant" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td colspan="1" style="height: 2px">&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="height: 2px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel21" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Pay to Account" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="4" style="height: 2px; ">
                    <dx:ASPxTextBox ID="txtaccount" runat="server" BackColor="#E4E4E4" Height="16px" Theme="BlackGlass" Width="249px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1" style="height: 2px">&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="height: 2px; width: 356px;">&nbsp;</td>
                <td align="left" colspan="4" style="height: 2px; ">
                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Add" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan="1" style="height: 2px">&nbsp;</td>
            </tr>

        </table>

              <table style="width: 826px">
                  <tr>
                      <td align="left" colspan="6" style="height: 170px;width:100%" >
                          <asp:GridView ID="grdvCharges" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="72px" Width="712px">
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
                  <tr>
                      <td style="width: 206px">&nbsp;</td>
                      <td colspan="1" style="width: 264px">&nbsp;</td>
                      <td style="width: 73px">&nbsp;</td>
                      <td colspan="1"></td>
                      <td colspan="1" style="width: 367px"></td>
                      <td colspan="1"></td>
                  </tr>
                  <tr>
                      <td style="width: 206px">&nbsp;</td>
                      <td colspan="1" style="width: 264px"></td>
                      <td style="width: 73px"></td>
                      <td colspan="1"></td>
                      <td colspan="1" style="width: 367px"></td>
                      <td colspan="1"></td>
                  </tr>
              </table>

    </asp:panel>
  
        <!--Settlement-->
       
        <asp:Panel runat="server" ID="Panel10" Font-Names="Cambria" GroupingText="_" Font-Size="Medium">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        
        &nbsp;</td>
   

</tr>
                 
        </table>
        </asp:Panel>
        
</asp:Panel>
  
</div>
</asp:Content>


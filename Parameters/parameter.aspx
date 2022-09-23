<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="parameter.aspx.vb" Inherits="Parameters_parameter" %>

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

          <asp:panel id="Panel2" runat="server" GroupingText="Additional Charges" Font-Names="Cambria">
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
                <td align="left" style="height: 2px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Charge Name" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="4" style="height: 2px; ">
                    <dx:ASPxTextBox ID="txtCharge" runat="server" Height="16px" Theme="BlackGlass" Width="249px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan="1" style="height: 2px">&nbsp;</td>
            </tr>
             <tr>
                <td align="left" style="height: 2px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Charge Description" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="1" style="height: 2px; width: 264px;">
                    <dx:ASPxTextBox ID="txtdep" runat="server" Theme="BlackGlass" Width="249px" Height="19px">
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
                <td align="left" style="height: 14px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Charge Type" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                 <td align="left" colspan="1" style="height: 14px; width: 264px;">
                      <asp:DropDownList ID="cmdtype" runat="server" AutoPostBack="false" Height="20px" Theme="BlackGlass" Width="249px">
                    </asp:DropDownList>
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
                <td align="left" style="height: 2px; width: 356px;">
                    &nbsp;</td>
                <td colspan="4" align="left" style="height: 2px; ">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                         <asp:ListItem Text="Percentage" Value="Percentage"></asp:ListItem>
                        <asp:ListItem Text="Flat Value" Value="Flat Value"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td colspan="1" style="height: 2px">&nbsp;</td>
            </tr>
             <tr>
                <td align="left" style="height: 2px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Value/Percentage" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="1" style="height: 2px; width: 264px;">
                    <dx:ASPxTextBox ID="txtAmt" runat="server"  Theme="BlackGlass" Width="249px" Height="19px">
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
                    <dx:ASPxLabel ID="lbllimit" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Maximum" Theme="Glass" Visible="false">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="4" style="height: 2px; ">
                    <dx:ASPxTextBox ID="txtlimit" runat="server"  Height="16px" Theme="BlackGlass" Width="249px" Visible="false">
                    </dx:ASPxTextBox>
                </td>
               
                <td colspan="1" style="height: 2px">&nbsp;</td>

            </tr>
            <tr>
                <td align="left" style="height: 2px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Apply To" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td align="left" colspan="1" style="height: 2px; width: 264px;">
                    <asp:DropDownList ID="txtapp" runat="server" AutoPostBack="True" Height="20px" Theme="BlackGlass" Width="249px">
                    </asp:DropDownList>
                </td>
                <td colspan="1" style="height: 2px; width: 73px;">
                    </td>
                <td colspan="1" style="height: 2px">
                    </td>
                <td colspan="1" style="height: 2px; width: 367px;">
                    </td>
                <td colspan="1" style="height: 2px"></td>
            </tr>
             <tr runat ="server" id="tc" visible="false">
                <td align="left" style="height: 14px; width: 356px;">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small"  Text="Participant Type" Theme="Glass">
                    </dx:ASPxLabel>
                 </td>
                 <td align="left" colspan="1" style="height: 14px; width: 264px;">
                      <asp:DropDownList ID="cmdtypes" runat="server" AutoPostBack="True" Height="20px" Theme="BlackGlass" Width="249px">
                    </asp:DropDownList>
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
                <td align="left" style="height: 2px; width: 356px;">&nbsp;</td>
                <td align="left" colspan="4" style="height: 2px; ">
                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Add" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan="1" style="height: 2px">&nbsp;</td>
            </tr>
            <tr>
                    <td align="center" colspan="5">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Visible="false" Text="Update" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;<dx:ASPxButton ID="ASPxButton2"  runat="server" Visible="false" Text="Delete" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
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
       
        <asp:Panel runat="server" ID="Panel10" Font-Names="Cambria" GroupingText="_" Font-Size="Medium" Visible="false">

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

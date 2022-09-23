<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BatchReceipting.aspx.vb" Inherits="TsecMode_BatchReceipting" title="CDS Capture" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" width="871px">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 634px; height: 226px" valign="top">
            <table>
            <tr>
                <td>
                    <asp:Label id="lblsitemap" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="Batching" width="850px" Height="19px"></asp:Label></td>
            </tr>
           </table>

             <table>
          <tr>
                <td class ="LayoutFormat">
                    <table>     
            <tr>
                    <td colspan ="6"></td>

            </tr>
                        <tr>
                                <td colspan ="1"></td>
                                <td colspan ="1"></td>
                                <td colspan ="1"></td>
                                <td colspan ="1"></td>
                                <td colspan ="1">
                <asp:Label ID="Label31" runat="server" Text="Batch Search"></asp:Label></td>
                                <td colspan ="1">
                                    <asp:TextBox ID="txtBatchSearch" runat="server" AutoPostBack="True" 
                                        Width="121px"></asp:TextBox>
                                    <asp:Button ID="btnBatchSearch" runat="server" Text="&gt;&gt;" />
                                </td>
                        </tr>
        <tr>
            <td colspan ="1">
                <asp:Label ID="Label15" runat="server" Text="Company"></asp:Label></td>
            <td colspan ="1">
         <asp:DropDownList ID="cmbCOmpany" runat="server" Width="150px" TabIndex="2"  > </asp:DropDownList>
            </td>
            <td colspan ="1"></td>
            <td colspan ="1"></td>
            <td colspan ="1">
                <asp:Label ID="Label22" runat="server" Text="Date"></asp:Label></td>
            <td colspan ="1">
                <BDP:BasicDatePicker ID="txtdate" runat="server" Width="160px" />
                </td>
        </tr>
                        <tr>
                            <td colspan ="1">
                <asp:Label ID="Label23" runat="server" Text="Batch Type"></asp:Label></td>
                            <td colspan ="1">
         <asp:DropDownList ID="cmbBatchType" runat="server"
                            AutoPostBack="True" Width="150px" TabIndex="7" >
                        </asp:DropDownList>
                            </td>
                            <td colspan ="1">
                        <asp:TextBox ID="txtBatchType" runat="server"  Font-Bold="True" Width="67px" TabIndex="8" Visible="False"></asp:TextBox>
                            </td>
                            <td colspan ="1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbBatchType"
                        ErrorMessage="Select Batch type" InitialValue="-Select-" ValidationGroup="addgrp" ></asp:RequiredFieldValidator>
                            </td>
                            <td colspan ="1">
                <asp:Label ID="Label24" runat="server" Text="Batch Ref"></asp:Label></td>
                            <td colspan ="1">
        <asp:TextBox ID="txtBatchRef" runat="server" Font-Bold="True"  Enabled="False" Width="150px" TabIndex="1" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan ="1">
                <asp:Label ID="Label25" runat="server" Text="Batch Shares"></asp:Label></td>
                            <td colspan ="1">
          <asp:TextBox ID="txtShares" runat="server" Width="145px" TabIndex="10" ></asp:TextBox>
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1">
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShares"
                        ErrorMessage="Enter Shares ?" ValidationGroup="addgrp" ></asp:RequiredFieldValidator>
                            </td>
                            <td colspan ="1">
                <asp:Label ID="Label26" runat="server" Text="Batch Value" Visible = "false"></asp:Label></td>
                            <td colspan ="1">
         <asp:TextBox ID="txtBatchValue" Visible ="false" runat="server" Width="150px" TabIndex="11" >0.00</asp:TextBox>
         
                            </td>
                        </tr>
                        <tr>
                            <td colspan ="1">
                <asp:Label ID="Label27" runat="server" Text="Broker"></asp:Label></td>
                            <td colspan ="1">
        <asp:DropDownList ID="cmbBroker1" runat="server" AutoPostBack="True" Width="150px" TabIndex="12">
                    </asp:DropDownList></td>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="1"></td>
                            <td colspan ="1">
                                <asp:CheckBox ID="chkLodger" runat="server" AutoPostBack="True" Text="Add lodger" />
                            </td>
                            <td colspan ="1">
         <asp:TextBox ID="txtLodger" runat="server" Width="150px" TabIndex="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>    
                            <td colspan ="6" style="text-align:center;">
            <asp:Label ID="cmbbroker" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan ="1">
                <asp:Label ID="Label38" runat="server" Text="Comments"></asp:Label></td>
                            <td colspan ="5">
                                <asp:TextBox ID="txtComments" runat="server" Height="81px" TextMode="MultiLine" 
                                    Width="590px"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan ="1">
                <asp:Label ID="Label35" runat="server" Text="Certificate"></asp:Label></td>
                            <td colspan ="1">
          <asp:TextBox ID="txtsubcert" runat="server" Width="145px" TabIndex="10" AutoPostBack="True" ></asp:TextBox>
                            </td>
                            <td colspan ="1"></td>
                            <td colspan ="1"></td>
                            <td colspan ="1">&nbsp;</td>
                            <td colspan ="1">
                <asp:Label ID="Label36" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan ="1"></td>
                            <td colspan ="1">
                                <asp:RadioButton ID="rdEnterNow" runat="server" AutoPostBack="True" GroupName="BatchDetails" Text="ProcessBatch" />
                            </td>
                            <td colspan ="1">&nbsp;</td>
                            <td colspan ="1"></td>
                            <td colspan ="1">
                                <asp:RadioButton ID="rdPost" runat="server" AutoPostBack="True" GroupName="BatchDetails" Text="Post Batch" Width="87px" />
                            </td>
                            <td colspan ="1"></td>
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
                                <td colspan ="6" style="text-align:center;"><asp:Button ID="btnValidate" runat="server"  BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid"  Text="Validate" Width="72px" Height="25px" CausesValidation="False" TabIndex="19" Visible="False" />
                    <asp:Button ID="btnAdd" runat="server"  Text="Add" BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" CausesValidation="False" Width="72px" UseSubmitBehavior="False" Height="25px" ValidationGroup="addgrp" TabIndex="20" />
       <asp:Button ID="btnUpdate" runat="server"  BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid"  
                                        Text="Update" Width="72px" Height="25px" CausesValidation="False" TabIndex="19" 
                                        Visible="False" />
        <asp:Button ID="Button1" runat="server"  Text="Print" BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" CausesValidation="False" Width="72px" UseSubmitBehavior="False" Height="25px" TabIndex="21" />
                    <asp:Button ID="Button2" runat="server" BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" CausesValidation="False" Width="72px" UseSubmitBehavior="False" Height="25px" TabIndex="21"   Text="Document Scan" Visible="False" />
       <asp:Button ID="btnNew" runat="server"  BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid"  
                                        Text="New Batch" Width="86px" Height="25px" CausesValidation="False" 
                                        TabIndex="19" />
                                </td>
                        </tr>
                        <tr>

                            <td colspan ="1">
                <asp:Label ID="Label33" runat="server" Text="Certificate" Visible="False"></asp:Label></td>
                            <td colspan ="2">
                                <asp:TextBox ID="txtCertSearch" runat="server" Width="101px" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="txtCd" runat="server" Visible="False" Width="40px"></asp:TextBox>
                                <asp:Button ID="btnCertSearch" runat="server" Text="&gt;&gt;" Visible="False" />
                                <asp:Button ID="btnHolderSearch" runat="server" Text="&gt;&gt;" Visible="False" />
                            </td>
                            <td colspan ="2">
                <asp:Label ID="Label28" runat="server" Text="Name" Visible="False"></asp:Label>
                                <asp:TextBox ID="txtNameSearch" runat="server" Width="153px" Visible="False"></asp:TextBox>
                                </td>
                            <td colspan ="1">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan ="1">
                                <asp:Label ID="Label30" runat="server"></asp:Label>
                            </td>
                            <td colspan ="3">
                                <asp:ListBox ID="lstNamesSelect" runat="server" AutoPostBack="True" Height="152px" Width="328px" Visible="False"></asp:ListBox>
                            </td>
                            <td colspan ="2">
                                <asp:Panel ID="Panel2" runat="server">
                                    <asp:GridView ID="grdAddedCertificate0" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SELECT">
                                                <ItemTemplate >
                                                    <asp:CheckBox ID="checkbox2" runat ="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ImageField NullImageUrl="~/images/01.png">
                                            </asp:ImageField>
                                        </Columns>
                                        <RowStyle BackColor="#EFF3FB" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                                <td colspan ="1">
                <asp:Label ID="Label29" runat="server" Text="Shares" Visible="False"></asp:Label></td>
                                <td colspan ="1">
                                    <asp:TextBox ID="txtToBatchShares" runat="server" Width="150px" Visible="False"></asp:TextBox>
                                </td>
                                <td colspan ="1">
                                <asp:Button ID="btnToBatchShares" runat="server" Text="&gt;&gt;" Visible="False" />
                                </td>
                                <td colspan ="1"></td>
                                <td colspan ="1"></td>
                                <td colspan ="1"></td>
                        </tr>
                        <tr style="text-align:center;">
                                <td colspan ="6" style="text-align:center;">
                    <asp:GridView ID="grdAddedCertificate" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="671px" Visible="False">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate >
                            
                            <%--<asp:CheckBox ID="checkbox1" runat ="server" />--%>
                            <asp:LinkButton ID="linkAuthorize" runat="server" CommandArgument="<%# Bind('Certificate') %>"
                                        OnClick="linkAuthorize_Click">Remove</asp:LinkButton>
                            
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                                </td>

                        </tr>
                        <tr>
                                
                            <td colspan ="6" style="text-align:center;">
                                <asp:Button ID="Button4" runat="server" Text="Remove Cert(s)" Visible="False" />
                            </td>

                        </tr>

                        <tr>

                            <td colspan ="6" style="text-align:center">
                                <asp:Label ID="Label32" runat="server" Text="transferee section" Visible="False"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                            <td colspan ="3">
                                <asp:RadioButton ID="rdCDs" runat="server" AutoPostBack="True" GroupName="MultipleCds" Text="Create CDs" Visible="False" />
                                <asp:RadioButton ID="rdBalance" runat="server" AutoPostBack="True" GroupName="MultipleCds" Text="Create Balance Certs" Visible="False" />
                            </td>
                            
                           
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan ="1">
                <asp:Label ID="Label37" runat="server" Text="Shareholder No" Visible="False"></asp:Label></td>
                            <td colspan ="2">
                                <asp:TextBox ID="txtTransfereeHolderSearch" runat="server" Width="153px" 
                                    Visible="False"></asp:TextBox>
                                <asp:Button ID="btnTranssearch0" runat="server" Text="&gt;&gt;" 
                                    Visible="False" />
                            </td>
                            <td colspan ="2"></td>
                            <td colspan ="1"></td>
                        </tr>
                         <tr>

                            <td colspan ="1">
                <asp:Label ID="Label16" runat="server" Text="Name" Visible="False"></asp:Label></td>
                            <td colspan ="2">
                                <asp:TextBox ID="txtTransfereeSearch" runat="server" Width="153px" 
                                    Visible="False"></asp:TextBox>
                                <asp:Button ID="btnTranssearch" runat="server" Text="&gt;&gt;" Visible="False" />
                            </td>
                            <td colspan ="2">
                                <asp:Label ID="Label17" runat="server" ForeColor="Red"></asp:Label>
                             </td>
                            <td colspan ="1">
                                <asp:Label ID="Label34" runat="server"></asp:Label>
                             </td>
                        </tr>
                        <tr>
                            <td colspan ="1">
                                &nbsp;</td>
                            <td colspan ="6">
                                <asp:ListBox ID="lstTransferee" runat="server" AutoPostBack="True" Height="152px" Width="609px" Visible="False"></asp:ListBox>
                            </td>
                            
                        </tr>
                        <tr>
                                <td colspan ="1">
                <asp:Label ID="Label18" runat="server" Text="Shares" Visible="False"></asp:Label></td>
                                <td colspan ="1">
                                    <asp:TextBox ID="txtTransfereeBatchShares" runat="server" Width="150px" Visible="False"></asp:TextBox>
                                </td>
                                <td colspan ="1">
                                <asp:Button ID="btnBatchTransshares" runat="server" Text="&gt;&gt;" Visible="False" />
                                </td>
                                <td colspan ="1">
                                <asp:Button ID="btnBalance" runat="server" Text="Create Balance" Visible="False" />
                                </td>
                                <td colspan ="1"></td>
                                <td colspan ="1"></td>
                        </tr>
                        <tr style="text-align:center;">
                                <td colspan ="6" style="text-align:center;">
                    <asp:GridView ID="grdTransshares" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="671px" Visible="False">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate >
                            
                            <%--<asp:CheckBox ID="checkbox1" runat ="server" />--%>
                            <asp:LinkButton ID="linkAuthorizeReceive" runat="server" CommandArgument="<%# Bind('Shareholder') %>"
                                        OnClick="linkAuthorizeReceive_Click">Remove</asp:LinkButton>
                            
                            </ItemTemplate>
                            
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                                </td>

                        </tr>
                        <tr>

                            <td colspan ="6" style="text-align:center;">
                                <asp:Button ID="Button5" runat="server" Text="Remove Cert(s)" Visible="False" />
                            </td>

                        </tr>
                    </table>

                </td>

          </tr>

    </table>
         </td>
    </tr>
    <tr>
            <td>
                

            </td>

    </tr>
</table>
         
</asp:Panel>
</div>
</asp:Content>


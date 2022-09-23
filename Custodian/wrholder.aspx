<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="wrholder.aspx.vb" Inherits="wrholder" title="Warehouse Receipt" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRibbon" tagprefix="dx1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Securities&gt;&gt;Warehouse Receipt" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table >
            <tr>
                <td colspan ="1" align="right"  style="width: 198px">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientNoSe" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass" style="height: 23px">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name/CNIC No/Mobile" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                    <td colspan ="1"></td>
                <td colspan ="4">
                    <dx:ASPxListBox ID="lstNames" runat="server" AutoPostBack="True" Theme="Glass" ValueType="System.String" Width="485px">
                    </dx:ASPxListBox>
                    </td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1"></td>
                <td width="301"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Account Details">

                <table style="width:100%" >
<tr>
        <td colspan ="1" >
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Account No." Theme="Glass">
            </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtClientID" runat="server" Theme="BlackGlass" Width="250px"  ReadOnly="True">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="CNIC No/ UIN No" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td>
        <dx:ASPxTextBox ID="txtIdNo" runat="server" Theme="BlackGlass" Width="250px"  Height="19px" ReadOnly="True">
        </dx:ASPxTextBox>
        </td>

</tr>
                    
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel50" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Surname" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtSurnames" runat="server"  ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Name" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtForenames" runat="server"  ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    
                    <tr>
                            <td colspan="1">
                                <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Mobile" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtmobile" runat="server"  Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>

                            <td colspan="1">
                                <dx:ASPxLabel ID="ASPxLabel49" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Address" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtaddress" runat="server"  ReadOnly="True" Theme="BlackGlass" Width="250px">
                                </dx:ASPxTextBox>
                            </td>

                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel7" Font-Names="Cambria" GroupingText="Warehouse Receipt Details" Font-Size="Medium">

                <table >
<tr>
        
    <td>
        <dx:ASPxComboBox ID="cmbSecurities" runat="server" Height="22px" style="margin-bottom: 0px" ValueType="System.String" Visible="False" Width="250px">
        </dx:ASPxComboBox>
        <br />
        <table style="width:100%">
            <tr>
                <td style="width: 198px">
                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Deposits" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxComboBox ID="cmbCompanySelect" runat="server" Height="22px" ValueType="System.String" Width="250px" AutoPostBack="True">
                    </dx:ASPxComboBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Product" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtproduct" runat="server" AutoPostBack="True" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px; height: 27px;">
                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px; width: 344px;">
                    <dx:ASPxTextBox ID="txtreceiptquantity" runat="server" ReadOnly="True" AutoPostBack="True" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 27px">
                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse Accreditation No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px">
                    <dx:ASPxTextBox ID="txtwarehouse" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 27px"></td>
            </tr>
            
             <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Unit Measure" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxComboBox ID="ASPxComboBox1" ReadOnly="true" runat="server" AutoPostBack="True" Height="22px" ValueType="System.String" Width="250px">
                      
                    </dx:ASPxComboBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lot No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtLotNumber" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr >
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Quantity" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="ASPxTextBox1" ReadOnly="true" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                       
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Shed/Silo" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbshedsilo" ReadOnly="true" runat="server" AutoPostBack="True" Height="22px" Width="250px">
                      
                    </dx:ASPxComboBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtexp" runat="server" Height="19px" ReadOnly="true" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Silo No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtsiloNo" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                       
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel44" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Declared Market Value" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtmarketvalue" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                     
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel43" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Marks" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtmarks" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
         <%--   <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Harvest Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxDateEdit ID="txtharvestdate" runat="server" Theme="Glass" Width="250px">
                    </dx:ASPxDateEdit>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
            <tr>
                <td style="width: 167px; height: 27px;">
                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Packaging" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px; width: 344px;">
                    <dx:ASPxComboBox ID="txtpackaging" ReadOnly="true" runat="server" AutoPostBack="True" Height="22px" Width="250px">
                        <Items>
                            <dx:ListEditItem Text="Bulk" Value="Bulk" />
                            <dx:ListEditItem Text="Bags" Value="Bags" />
                        </Items>
                      
                    </dx:ASPxComboBox>
                </td>
                <td style="height: 27px">
                    <dx:ASPxLabel ID="ASPxLabel52" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Weight Per Unit" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="height: 27px">
                    <dx:ASPxTextBox ID="txtweight" ReadOnly="true" runat="server" AutoPostBack="True" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 27px"></td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Packages" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtpackages" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel53"  runat="server" Font-Names="Cambria" Font-Size="Small" Text="Storage Charge (PKR/Day/MT)" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtcharge" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                      
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Wastage" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtwastage" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                     
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Other Charge" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtother" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                       
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px">
                    <dx:ASPxLabel ID="ASPxLabel51" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Deposit Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtdepositdate" runat="server" Height="19px" ReadOnly="true" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel45" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Harvest Date" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtharvestdate" runat="server" Height="19px" ReadOnly="true" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 167px; height: 27px;">
                    <dx:ASPxLabel ID="ASPxLabel54" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Remarks" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px; height: 27px;">
                    <dx:ASPxTextBox ID="txtremarks" ReadOnly="true" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 27px">
                    </td>
                <td style="height: 27px">
                    </td>
                <td style="height: 27px"></td>
            </tr>
            
            
            <tr>
                <td style="width: 198px">
                    <dx:ASPxLabel ID="ASPxLabel33" runat="server" Visible="False" Font-Names="Cambria" Font-Size="Small" Text="Expiry" Theme="Glass">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Insurance Expiry" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Visible="False" Font-Size="Small" Text="Insurance Company" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtinsuranceexpiry" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
                    </dx:ASPxTextBox>
                    <dx:ASPxTextBox ID="txtinsrancecompany" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
                    </dx:ASPxTextBox>
                    <dx:ASPxDateEdit ID="txtexpiry" runat="server" Theme="Glass" Width="250px" Visible="False" ReadOnly="True">
                    </dx:ASPxDateEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse Operator" Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                    <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Visible="False" Text="Insurance Policy Ref" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtwarehouseoperator" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
                    </dx:ASPxTextBox>
                    <dx:ASPxTextBox ID="txtpolicy" runat="server" Height="19px" ReadOnly="True" Visible="False" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="height: auto;" colspan="2">
                    <asp:GridView ID="grdgrading" runat="server" AutoGenerateColumns="False" EmptyDataText="" GridLines="None" style="height:auto" Visible="true">
                        <Columns>
                            <asp:TemplateField ControlStyle-Width="200px" HeaderText="" Visible="True">
                                <ItemTemplate>
                                    <dx:ASPxLabel ID="lblcomponent" runat="server" Font-Names="Cambria" Font-Size="Small" Text='<%#DataBinder.Eval(Container.DataItem, "Component")%>' Theme="Glass">
                                    </dx:ASPxLabel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grading Values" Visible="true">
                                <ItemTemplate>
                                    <dx:ASPxTextBox ID="txtvalue" runat="server" Height="19px" ReadOnly="False" Theme="BlackGlass" Visible="True" Width="250px">
                                    </dx:ASPxTextBox>
                                    <%--      <asp:DropDownList ID="ddvalue" Visible="false" Height="19px" Width="250px" runat="server">
                    </asp:DropDownList>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="grdabsolute" runat="server" AutoGenerateColumns="False" EmptyDataText="" GridLines="None" style="height:auto" Visible="true">
                        <Columns>
                            <asp:TemplateField ControlStyle-Width="200px" HeaderText="" Visible="True">
                                <ItemTemplate>
                                    <dx:ASPxLabel ID="lblabsolutecomponent" runat="server" Font-Names="Cambria" Font-Size="Small" Text='<%#DataBinder.Eval(Container.DataItem, "Component")%>' Theme="Glass">
                                    </dx:ASPxLabel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="true">
                                <ItemTemplate>
                              
                                          <asp:DropDownList ID="ddabsolutevalue" Visible="True" Height="19px" Width="250px" runat="server">
                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px; height: 27px;"></td>
                <td style="height: 27px; width: 344px;">
                    <dx:ASPxButton ID="btnView0" runat="server" Text="Calculate Grade" Theme="BlackGlass" style="height: 23px" Visible="False">
                    </dx:ASPxButton>
                </td>
                <td style="height: 27px"></td>
                <td style="height: 27px"></td>
                <td style="height: 27px"></td>
            </tr>
            <tr>
                <td style="width: 198px">
                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Grade" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxComboBox ID="txtgrade" runat="server" AutoPostBack="True" Height="22px" ReadOnly="True" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Unit Measure" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="txtmeasurement" runat="server" AutoPostBack="True" Enabled="False" Height="22px" ValueType="System.String" Width="250px">
                    </dx:ASPxComboBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px">
                    <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Indicative Price" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 344px">
                    <dx:ASPxTextBox ID="txtcurrentprice" runat="server" Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 198px">&nbsp;</td>
                <td style="width: 344px">
                    <dx:ASPxButton ID="btnView" runat="server" Text="Save" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;<asp:Label ID="lblid" runat="server"></asp:Label>
                    <asp:Label ID="lbldeliveryid" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="5">&nbsp;</td>
            </tr>
        </table>
        </td>
   

</tr>
                 
                   
                 
        </table>
        </asp:Panel>

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Created Warehouse Receipts" Font-Size="Medium">

                <table style="width:100%" >
<tr>
        
    <td align="left">
        <table>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel55" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtsearch" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxButton ID="btnsearch" runat="server" Text="Search" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </td>
   

</tr>
                 
                    <tr>
                        <td align="center">
                            <dx:ASPxGridView ID="ASPxGridView3" runat="server" KeyFieldName="ID" Settings-ShowTitlePanel="true" SettingsText-Title="Receipts" Theme="Glass" Width="100%">
                                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                <SettingsPager Visible="True">
                                </SettingsPager>
                                <Settings ShowTitlePanel="True" />
                                <SettingsText Title="Receipts" />
                                <SettingsPopup>
                                    <EditForm AllowResize="True" Modal="True" />
                                </SettingsPopup>
                                <SettingsCommandButton>
                                    <SelectButton Text="Select">
                                    </SelectButton>
                                </SettingsCommandButton>
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                 
                    <tr>
                        <td align="center">
                             <dx:ASPxCheckBox ID="chkPrintInfoCopy" runat="server" Text="Print Information Copy" Theme="Aqua">
                            </dx:ASPxCheckBox>
                            <dx:ASPxButton ID="btnSaveContract0" runat="server" Text="view" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                 
                    <tr>
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                 
        </table>
        </asp:Panel>
         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Pending Warehouse Receipts" Font-Size="Medium">

                <table style="width:100%" >
                    <tr>
                            
                        <td colspan ="8" align="left">
                            <dx:ASPxGridView ID="ASPxGridView4" runat="server" KeyFieldName="id" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
                                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                <SettingsPager PageSizeItemSettings-ShowAllItem="true" Visible="True">
                                </SettingsPager>
                                <SettingsPopup>
                                    <EditForm AllowResize="True" Modal="True" />
                                </SettingsPopup>
                                <SettingsCommandButton>
                                    <SelectButton Text="Select">
                                    </SelectButton>
                                </SettingsCommandButton>
                                <Columns>
                                    <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="otpenabled" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" Text="Edit">
                                                              </asp:LinkButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="DeleteID" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" Text="Cancel Transaction">
                                                              </asp:LinkButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Account No.">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Account No") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Receipt No">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("EWRNo") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Transaction Status">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Status") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Commodity">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Commodity") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataTextColumn Caption="Quantity">
                                        <PropertiesTextEdit DisplayFormatString="#,###">
                                        </PropertiesTextEdit>
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Quantity") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataColumn Caption="Unit of Measure">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("UnitMeasure") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Grade">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Grade") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Warehouse">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("Warehouse") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="EWR Status">
                                        <DataItemTemplate>
                                            <dx:ASPxLabel runat="server" Text='<%# Eval("wrstatus") %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <%-- W.EWR_Holder as [Account No], W.Company as [Details], W.ReceiptID AS [EWR No.], 
                                case when W.approvedby is NULL then 'Pending' else 'Approved' end as  [Status],  W.[Date],
                                 W.amount_to_withdraw ,wr.Commodity, wr.Grade, wr.WarehousePhysical, wr.Date_Issued, wr.[Status] --%>
                            </dx:ASPxGridView>
                            </td>

                    </tr>
                
<tr>
        
    <td colspan ="8" align="center">
        <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Clear Screen" Theme="BlackGlass">
        </dx:ASPxButton>
        <br />
        <br />
    </td>
   

</tr>
                 
        </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel6" Font-Names="Cambria" GroupingText="Movement Summaries" Font-Size="Medium" Visible="False">

                <table >
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="________________" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="7"></td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="cmbCompany" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDateEdit ID="txtBatchDate" runat="server" Theme="Aqua" Width="150px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxDateEdit ID="txtBatchDate0" runat="server" Theme="Aqua" Width="150px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                           <td colspan ="8" align ="center">
                               <dx:ASPxButton ID="ASPxButton3" runat="server" Text="View" Theme="BlackGlass"></dx:ASPxButton>

                           </td>
                    </tr>
                    <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxGridView ID="rdMovements" runat="server" Theme="Aqua" Width="800px">
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="8" align="center">
                            <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Print Statement" Theme="BlackGlass" style="height: 23px"></dx:ASPxButton>
                            
                        </td>

                    </tr>
                   
                 
        </table>
        </asp:Panel>
        
</asp:Panel>
  
</div>
</asp:Content>


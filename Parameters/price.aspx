<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="price.aspx.vb" Inherits="Parameters_price" title="Price" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters>>Share Prices" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Prices">

                <table width="810px">
                    <tr>
                        <td colspan="1">
                            &nbsp;</td>
                        <td colspan="1">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Company" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxComboBox ID="cmbparaCompany" runat="server" AutoPostBack="True" Theme="Glass" ValidationSettings-RequiredField-IsRequired="true" Width="250px">
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Price" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtprice" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                           <ValidationSettings>
                                    <RequiredField IsRequired="True"  />
                                </ValidationSettings>
                                  </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Price Date" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxDateEdit ID="dtdate" runat="server" Width="250px">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">
                            <dx:ASPxButton ID="ASPxButton7" runat="server" Text="Save" Theme="BlackGlass">
                            </dx:ASPxButton>
                            &nbsp;
                            <dx:ASPxButton ID="ASPxButton8" CausesValidation="False" runat="server" Text="Upload" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">
                            <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 18px">
                            </td>
                        <td style="height: 18px">
                            <dx:ASPxGridView ID="ASPxGridView2"  runat="server" Theme="Glass" Width="640px" KeyFieldName="ID" SettingsPager-Mode="ShowAllRecords" >
                                <Settings ShowFilterRow="true" />
                            <Columns>
                                 
                                        <dx:GridViewDataColumn Caption="ID">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("id") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                             <dx:GridViewDataTextColumn Caption="Company" FieldName="Ticker" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                
                                <dx:GridViewDataTextColumn Caption="Price" FieldName="Current_price" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                  

                                <dx:GridViewDataDateColumn Caption="Price Date" FieldName="Date" PropertiesDateEdit-DisplayFormatString="{0:dd/MM/yyyy}" Settings-AutoFilterCondition="Equals" > </dx:GridViewDataDateColumn>
                                     
                                 <dx:GridViewDataColumn Caption="Capture Date">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%#   Convert.ToDateTime(Eval("CaptureDate")).ToString("dd/MM/yyyy hh:mm") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                               
                            </Columns>
                            </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>


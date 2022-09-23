<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BankUpload.aspx.vb" Inherits="Parameters_BankUpload" title="Bank Upload" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Cash Maintenance>>Bank Upload" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Bank Upload">

                <table width="100%">
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Upload" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">
                            &nbsp;
                            <dx:ASPxButton ID="ASPxButton8" runat="server" Text="Upload" Theme="BlackGlass">
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
                            <td colspan ="2" style="height: 18px">
                                <dx:ASPxGridView ID="ASPxGridView3" runat="server" KeyFieldName="ID" Settings-ShowTitlePanel="true" Theme="Glass" Width="100%">
                                 <Settings  ShowFilterRow="true" />

                                       <Columns>
                                    
                                     <dx:GridViewDataTextColumn Name="AssetManager" FieldName="AssetManager" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                                                          <dx:GridViewDataTextColumn Name="BankAccount" FieldName="BankAccount" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                                             <dx:GridViewDataTextColumn Name="BankName" FieldName="BankName" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                                             <dx:GridViewDataTextColumn Name="Amount" FieldName="Amount" Settings-AutoFilterCondition="Equals">    </dx:GridViewDataTextColumn>

                                                                             <dx:GridViewDataTextColumn Name="Reference" FieldName="Reference" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                                             <dx:GridViewDataTextColumn Name="Description" FieldName="Other_Details" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                                             <dx:GridViewDataDateColumn  Name="Record Date" FieldName="DateCreated" Settings-AutoFilterCondition="Equals">    </dx:GridViewDataDateColumn>

                                                                             <dx:GridViewDataTextColumn Name="Status" FieldName="Allocated" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Name="Currency" FieldName="Currency" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                                                               <dx:GridViewDataTextColumn Name="FileName" FieldName="FileName" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn Name="UploadBy" FieldName="UploadBy" Settings-AutoFilterCondition="Contains">    </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn Name="UploadDate" FieldName="UploadDate" Settings-AutoFilterCondition="Equals">    </dx:GridViewDataDateColumn>

                                        
                                    </Columns>
                                </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>


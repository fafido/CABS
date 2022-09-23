<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="BankStatement.vb" Inherits="TransferSec_withdrawal" title="Bank Balanace" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Aspxdateedit" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFormLayout" tagprefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="&gt;&gt;Bank Balance" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        
      
        
               
        <asp:Panel ID="Panel9" runat="server" Enabled="True" Font-Names="Cambria" Font-Size="Medium" GroupingText="Balance Statement">
            <table width="100%">
                    
                

                 <tr>

                <td align="center">


                        <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="100%">
                      
                        <Columns >

                            
                                               
                           <%--  <dx:GridViewDataColumn  >
                                    <DataItemTemplate>
                                                    <dx:ASPxCheckBox ID="cbStatus"  Value='<%# Eval("id") %>'   runat="server" AutoPostBack ="true"  ClientInstanceName="chkbox"  
                                                 OnCheckedChanged="ASPxCheckBox1_CheckedChanged1">    

                                            </dx:ASPxCheckBox>

                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>--%>
                        

<%--                             <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="" CellStyle-HorizontalAlign="Right" Width="8PX" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                       <dx:ASPxButton Height="18px" ID="btnAction" Value='<%# Eval("id") %>'  runat="server" AutoPostBack="False" ClientInstanceName="btnAction" Text="Approve" OnClick="btn_accept" >
                        </dx:ASPxButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           --%>
                         <%--   <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="" CellStyle-HorizontalAlign="Right" Width="8PX" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                       <dx:ASPxButton Height="18px"   ID="btnAction" runat="server" AutoPostBack="False"  ClientInstanceName="btnAction" Text="Reject" OnClick="btn_reject"  >
                                            <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Do you really want to Reject?');}" />  
                        </dx:ASPxButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                           
                          <%--  <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="S.No">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="AccountNumber" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("AccountNumber") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="AccountName">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("AccountName") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Category" CellStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Category") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                         
                           
                        
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Status") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>

                               <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="ClientType" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ClientType") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                             <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Branch" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Branch") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>

                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Balance" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Balance") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>

                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Currency" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Currency") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>





 
                    </td>
                </tr>
        
                    <tr>
                      
                        
                        
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>

              

                </table>
                         </asp:Panel>

    
               
</asp:Panel>
  
</div>
</asp:Content>


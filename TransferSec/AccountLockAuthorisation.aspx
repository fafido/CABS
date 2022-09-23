<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="AccountLockAuthorisation.aspx.vb" Inherits="Orders" title="Bonds Buy" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
   
    
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial" width="848px"></asp:Label></td>
            </tr>
                               
            </table>
             <asp:Panel runat="server" ID="panel4" GroupingText="Account Lock&gt;&gt;Account Lock Authorisation">
                 
                 <table >
                      <tr>
                <td colspan="8">
                    <dx:ASPxLabel ID="lbltitle" runat="server"  Font-Size="Medium"  Text="Account Lock Authorisation">
                    </dx:ASPxLabel>
                    <dx:ASPxtextbox ID="txtpricetoday"  Visible="false" runat="server"  Font-Size="Medium"  Text="Prices Authorisation">
                    </dx:ASPxtextbox>
                     <dx:ASPxtextbox ID="txtbidprice" Visible="false"  runat="server"  Font-Size="Medium"  Text="Prices Authorisation">
                    </dx:ASPxtextbox>
                     <dx:ASPxtextbox ID="txtrequest" visible="false" runat="server"  Font-Size="Medium"  Text="Prices Authorisation">
                    </dx:ASPxtextbox>
                     <dx:ASPxtextbox ID="txtcdsnumber" visible="false" runat="server"  Font-Size="Medium"  Text="Prices Authorisation">
                    </dx:ASPxtextbox>
                    <dx:ASPxtextbox ID="txtdate" visible="false" runat="server"  Font-Size="Medium"  Text="Prices Authorisation">
                    </dx:ASPxtextbox>
                </td>
            </tr>
                <tr>
                        <td colspan ="8" align="center">
                            <asp:GridView ID="grdRules" runat="server" AllowPaging="True" CellPadding="4" CssClass="table table-bordered table-striped tablestyle success" EmptyDataRowStyle-CssClass="text-warning text-center" EmptyDataText="No  Pending Authorisation!" ForeColor="#333333" GridLines="None" HorizontalAlign="Left">
                <AlternatingRowStyle BackColor="White" CssClass="altrowstyle" />
                <EditRowStyle BackColor="#2461BF" />
                <EmptyDataRowStyle CssClass="text-warning text-center" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" CssClass="header info" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" CssClass="rowstyle" />
                <PagerStyle BackColor="#2461BF" CssClass="pagination-ys" ForeColor="White" HorizontalAlign="Center" />
                <Columns>
                   
              
                   <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton OnClientClick="if (!confirm('Are you sure you want approve?')) return false;" ID="lnkDiscard" runat="server" CommandArgument="<%# Bind('id') %>" OnClick="authorise">Approve</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkdelete" OnClientClick="if (!confirm('Are you sure you want deny?')) return false;" runat="server"  CommandArgument="<%# Bind('id') %>" OnClick="linkDiscard"     CommandName="Delete" >Reject</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
                            <br />
                            <br />
                            
                        </td>

                </tr>
                
                 </table>

             </asp:Panel>
            
            <table>
                <tr>
                    <td style="width: 850px" align="center">
                        </td>                
                </tr>
            </table>
        </td>
    </tr>

   
</table>
</asp:Panel>
</div>
</asp:Content>


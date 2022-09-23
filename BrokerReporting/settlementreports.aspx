<%@ Page Title="" Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="settlementreports.aspx.vb" Inherits="Reporting_settlementreports" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;Settlement Reports" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Settlement Reports" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 46px">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" BackColor="#6699FF" Text="Settlement and Delivery" Theme="iOS" Visible="False" Width="322px">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton2" runat="server" BackColor="#6699FF" Text="Settlement Report" Theme="iOS" Width="322px" Visible="False">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton9" runat="server" BackColor="#6699FF" Text="Consolidated Summary By Broker" Theme="iOS" Visible="False" Width="322px">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton4" runat="server" BackColor="#6699FF" Text="Settlement By Broker" Theme="iOS" Visible="False" Width="322px">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton10" runat="server" BackColor="#6699FF" Text="Purchases and Sales" Theme="iOS" Visible="False" Width="322px">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton3" runat="server" BackColor="#6699FF" Text="Settlement Report" Theme="iOS" Visible="False" Width="322px">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="ASPxButton8" runat="server" BackColor="#6699FF" Text="Delivery Report" Theme="iOS" Visible="False" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 58px">
                    <dx:ASPxButton ID="ASPxButton13" runat="server" BackColor="#6699FF" Text="Settlement Report" Theme="iOS" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 58px">
                    <dx:ASPxButton ID="ASPxButton14" runat="server" BackColor="#6699FF" Text="Failed Trades" Theme="iOS" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 58px">
                    <dx:ASPxButton ID="ASPxButton15" runat="server" BackColor="#6699FF" Text="Order Register" Theme="iOS" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 58px">
                    <dx:ASPxButton ID="ASPxButton16" runat="server" BackColor="#6699FF" Text="Pending Settlement" Theme="iOS" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 58px">
                    <dx:ASPxButton ID="ASPxButton17" runat="server" BackColor="#6699FF" Text="Settled Trades" Theme="iOS" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 58px">
                    <dx:ASPxButton ID="ASPxButton18" runat="server" BackColor="#6699FF" Text="Settlement Master" Theme="iOS" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 58px">
                    <dx:ASPxButton ID="ASPxButton19" runat="server" BackColor="#6699FF" Text="Deal Settlement" Theme="iOS" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 58px">
                    <dx:ASPxButton ID="ASPxButton21" runat="server" BackColor="#6699FF" Text="Charges" Theme="iOS" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" class="dxcpCurrentColor_PlasticBlue" style="height: 30px">
                    <dx:ASPxButton ID="ASPxButton11" runat="server" BackColor="#6699FF" Text="Settlement Reports Mailing List" Theme="iOS" Width="322px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="right" valign="bottom"   class="dxcpCurrentColor_PlasticBlue" style="height: 46px">
                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Comment" Font-Size="X-Small" Height="24px" Theme="Moderno" Width="98px">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Panel ID="Panel6" runat="server" Visible="False">
                        <table class="auto-style1">
                            <tr>
                                <td style="width: 231px; height: 18px;"></td>
                                <td style="height: 18px">
                                    <asp:Label ID="Label2" runat="server" Text="Affix Comment"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" style="width: 231px; height: 80px;">
                                    <asp:Label ID="Label3" runat="server" Text="Comment"></asp:Label>
                                </td>
                                <td style="height: 80px">
                                    <dx:ASPxMemo ID="ASPxMemo1" runat="server" Height="71px" Theme="iOS" Width="397px">
                                    </dx:ASPxMemo>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 231px" valign="top">&nbsp;</td>
                                <td>
                                    <dx:ASPxButton ID="ASPxButton6" runat="server" Font-Size="X-Small" Height="24px" Text="Save" Theme="Moderno" Width="98px">
                                    </dx:ASPxButton>
                                    &nbsp;
                                    <dx:ASPxButton ID="ASPxButton7" runat="server" Font-Size="X-Small" Height="24px" Text="Cancel" Theme="Moderno" Width="98px">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>


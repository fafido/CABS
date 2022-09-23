<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Approvesuper.aspx.vb" Inherits="CDSMode_Approvesuper" title="Approve" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;&gt;Administrator Accounts Creation" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
<asp:Panel runat="server" ID="Companie" Font-Names="Cambria" GroupingText="Company Details">
    <table>
            <tr>
                <td colspan ="1" style="width: 163px">
                    <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Approve Category" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" style="width: 250px">
                    <dx:ASPxComboBox ID="cmbparticipants" runat="server" AutoPostBack="True" Height="18px" ValueType="System.String" Width="248px">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1" style="width: 10px"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1" style="width: 10px"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>
        <tr>
                <td colspan ="1" valign="top" style="width: 163px">
                    <dx:ASPxLabel ID="ASPxLabel71" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Select Approve Item" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" style="width: 250px">
                    <asp:ListBox ID="ListBox1" autopostback="true" runat="server" Height="88px" Width="251px" BackColor="#E4E4E4"></asp:ListBox>
                </td>
                <td colspan ="1" style="width: 10px"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1" style="width: 10px"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
            </tr>

    </table>
</asp:Panel>
        <asp:Panel ID="Panel8" runat="server" Font-Names="Cambria" GroupingText="Personal Details">
            <table width="810px">
                <tr>
                    <td colspan="1" style="height: 23px; width: 164px;">
                        <dx:ASPxLabel ID="ASPxLabel70" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Approve ID" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1" style="height: 23px">
                        <dx:ASPxTextBox ID="txtapproveid" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" ReadOnly="True">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                    <td colspan="1" style="height: 23px"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 164px">
                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Status" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="1">
                        <dx:ASPxTextBox ID="txtstatus" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 164px">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Initiator" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxTextBox ID="txtinitiator" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                        <dx:ASPxTextBox ID="txtemail" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Visible="False">
                        </dx:ASPxTextBox>
                        <dx:ASPxTextBox ID="txtsubject" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Visible="False">
                        </dx:ASPxTextBox>
                        <dx:ASPxTextBox ID="txtbody" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px" Visible="False">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 23px; width: 164px;">
                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date Captured" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7" style="height: 23px">
                        <dx:ASPxTextBox ID="txtdate" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" valign="top" style="width: 164px">
                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Full Description" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7">
                        <dx:ASPxMemo ID="txtdescription" BackColor="#E4E4E4" runat="server" Height="71px" Theme="BlackGlass" Width="638px">
                        </dx:ASPxMemo>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" valign="top" style="width: 164px; height: 80px;">
                        <dx:ASPxLabel ID="ASPxLabel72" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Your Comment" Theme="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7" style="height: 80px">
                        <dx:ASPxMemo ID="txtcomment" BackColor="#E4E4E4" runat="server" Height="71px" Theme="BlackGlass" Width="638px">
                        </dx:ASPxMemo>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 18px; width: 164px;" valign="top">
                        <dx:ASPxLabel ID="ASPxLabel73" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Script" Theme="Glass" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan="7" style="height: 18px">
                        <dx:ASPxMemo ID="txtscript" runat="server" BackColor="#E4E4E4" Height="71px" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="638px">
                        </dx:ASPxMemo>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:panel id="Panel2" runat="server" GroupingText="Action" Font-Names="Cambria">
        <table width="810px">
      
           
           
            <tr>
               
                <td colspan ="8" align="center">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Execute/Approve" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;<dx:ASPxButton ID="ASPxButton2" runat="server" Text="Decline" Theme="BlackGlass">
                    </dx:ASPxButton>
                    &nbsp;</td>
                

            </tr>
           
          
        </table>
    </asp:panel>
    
</asp:Panel>
  
</div>
</asp:Content>


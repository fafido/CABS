<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="transaction.aspx.vb" Inherits="Reporting_transaction" %>


<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Reporting&gt;&gt;Transaction status Report" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:panel id="Panel5" runat="server" GroupingText="Search Options" Font-Names="Cambria">
        <table width="810px">
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date From" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                    <dx:ASPxDateEdit ID="txtDateFrom" runat="server" Theme="BlackGlass">
                    </dx:ASPxDateEdit>
                </td>
                
            </tr>
            <tr>
                <td colspan ="1">
                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Date To" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                    <dx:ASPxDateEdit ID="txtDateTo" runat="server" Theme="BlackGlass">
                    </dx:ASPxDateEdit>
                </td>
                

            </tr>
            
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Activity performed" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                   <%-- <asp:DropDownList ID="cmbactivity" runat="server" Height="21px" Width="156px">
                              <asp:ListItem Text="All" Value="ALL"></asp:ListItem>
                          <asp:ListItem Text="WITHDRAWAL" Value="WITHDRAWAL"></asp:ListItem>
                          <asp:ListItem Text="TRANSFER" Value="TRANSFER"></asp:ListItem>
                         <asp:ListItem Text="SPLIT" Value="SPLIT"></asp:ListItem>
                        <asp:ListItem Text="FINANCING" Value="FINANCING"></asp:ListItem>
                    </asp:DropDownList>--%>

                     <dx:ASPxComboBox ID="cmbactivity" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Height="21px" Width="156px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        <Items>
                            <dx:ListEditItem Text="All" Value="All" />
 <dx:ListEditItem Text="WITHDRAWAL" Value="WITHDRAWAL" />
  <dx:ListEditItem Text="TRANSFER" Value="TRANSFER" />
 <dx:ListEditItem Text="SPLIT" Value="SPLIT" />
                             <dx:ListEditItem Text="FINANCING" Value="FINANCING" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                
            </tr>


            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="status" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
              <td >
                   <%-- <asp:DropDownList ID="cmdparticipants" runat="server" Height="21px" Width="156px">
                     <asp:ListItem Text="All" Value="All"></asp:ListItem>
                    </asp:DropDownList>--%>
           

                <dx:ASPxComboBox ID="cmdparticipants" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Height="21px" Width="156px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        <Items>
                            <dx:ListEditItem Text="All" Value="All" />
                        </Items>
                    </dx:ASPxComboBox>
                     </td>
            </tr>
             
          <%--  <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Holder" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                    <asp:DropDownList ID="cmdhold" runat="server" Height="21px" Width="156px">
                          
                    </asp:DropDownList>
                </td>
                
            </tr>--%>
             
            <tr>
                <td colspan="1">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Produce" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td >
                  <%--  <asp:DropDownList ID="cmdpart" runat="server" Height="21px" Width="156px">
                                          <asp:ListItem Text="All" Value="All"></asp:ListItem> 
                    </asp:DropDownList>--%>
                

                <dx:ASPxComboBox ID="cmdpart" AutoPostBack="false" runat="server" Theme="BlackGlass" ValueType="System.String" Height="21px" Width="156px" CallbackPageSize="15" EnableCallbackMode="True" DropDownStyle="DropDownList"  IncrementalFilteringMode="Contains"  AnimationType="Slide">
                        <Items>
                            <dx:ListEditItem Text="All" Value="All" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            
            
            <tr>
                <td colspan="1"></td>
                <td colspan ="1">
                    <dx:ASPxButton ID="btnPrint" runat="server" Text="Print" Theme="BlackGlass" Width="150px">
                    </dx:ASPxButton>
                   
                </td>
            </tr>

        </table>

    </asp:panel>
         
</asp:Panel>
  
</div>
</asp:Content>
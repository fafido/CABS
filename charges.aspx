<%@ Page Language="VB"  MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="charges.aspx.vb" Title="Charges" Inherits="Depositor_charges" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" GroupingText="Depositor>>Charges" BackColor="White">
        <table>
            <tr id="Tr1" runat="server">
              <td colspan="5" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="" Theme="Glass">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
           
 
           <tr>
                 <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Description" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px;">
                    <dx:ASPxTextBox ID="txtDescription" runat="server" Height="16px" Theme="Glass" Width="250px" ReadOnly="true">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr>
                 <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel41" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Reference" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px;">
                    <dx:ASPxTextBox ID="txtReference" runat="server" Height="16px" Theme="Glass" Width="249px" ReadOnly="true">
                    </dx:ASPxTextBox>
                </td>
            </tr>
           <tr>
                 <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel412" runat="server" Font-Names="Cambria" Font-Size="Small" Text="ChargeCode" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px;">
                    <dx:ASPxTextBox ID="txtChargeCode" runat="server" Height="16px" Theme="Glass" Width="250px" ReadOnly="true">
                    </dx:ASPxTextBox>
                </td>
            </tr>
             <tr>
                 <td style="width: 208px;">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Amount to be Paid" Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 212px;">
                    <dx:ASPxTextBox ID="txtAmount" runat="server" Height="16px" Theme="Glass" Width="250px">
                    </dx:ASPxTextBox>
                </td>
            </tr>

             <tr>
                                    <td style="width: 208px">
                                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Upload payment proof" Theme="Glass">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td style="width: 212px">
                                        <asp:FileUpload ID="FileUpload4" runat="server" Width="248px" />
                                    </td>
                                </tr>
            <tr>
               <td style="width: 208px;"></td>
                <td style="width: 212px;">
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Submit" Theme="Glass">
                    </dx:ASPxButton>
                </td>
            </tr>
          
            <tr id="panel00002" runat="server">
              <td colspan="5" style="height: 18px;">
                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Font-Bold="true" Text="List of all due charges" Theme="Glass" Width="800px">
                    </dx:ASPxLabel>
                    <hr/>
                </td>
              </tr>
                <tr>
                 
                    <td colspan="8">
                     <dx:ASPxGridView ID="grdvCharges" runat="server" AutoGenerateColumns="true" OnRowCommand="grdvCharges_RowCommand" KeyFieldName="chargecode" Theme="Glass" Width="100%">
                      
                        <Columns >
                            <dx:GridViewDataColumn VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="SelectID" Text="Select" CommandName="Select" CommandArgument='<%# Eval("chargecode").ToString()%>' runat="server">
                                        </asp:LinkButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           
                          <%--  <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="S.No">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ID") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>--%>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Width="250px" Caption="EWR" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Reference") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true"  Width="500px" Caption="Description">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Description") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="ChargeCode"  Width="150px" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ChargeCode") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Amount" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Amount") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           
                        
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status"  Width="100px" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("STATUS") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>
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
        </table>
    </asp:Panel>
</asp:Content>

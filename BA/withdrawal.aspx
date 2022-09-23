<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Withdrawal.aspx.vb" Inherits="TransferSec_withdrawal" title="Withdrawal" %>

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
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Batching&gt;&gt;Withdrawal" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria"  GroupingText="EWR Holder Details" Font-Size="Medium">

                <table width="100%" >
                       <tr   runat="server" visible ="false">
                           <td colspan="1">
                               <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Search EWR Holder" Theme="Glass">
                               </dx:ASPxLabel>
                           </td>
                           <td colspan="1">
                               <dx:ASPxTextBox ID="txtclientnumber0" runat="server"  Height="19px" Theme="BlackGlass" Width="250px">
                               </dx:ASPxTextBox>
                           </td>
                           <td colspan="1">
                               <dx:ASPxButton ID="ASPxButton4" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                               </dx:ASPxButton>
                           </td>
                           <td colspan="1"></td>
                           <td colspan="1"></td>
                           <td colspan="1"></td>
                           <td colspan="1"></td>
                    </tr>
                       <tr runat="server" visible ="false">
                           <td colspan="1">&nbsp;</td>
                           <td colspan="2">
                               <asp:ListBox ID="ListBox1" runat="server" Width="447px" AutoPostBack="True"></asp:ListBox>
                           </td>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="1">&nbsp;</td>
                    </tr>

                     <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtparticipantname" runat="server"  enabled="false"  Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>


                    <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Account No" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtAccountNo" runat="server"  enabled="false"  Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>

                    <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Name of EWR holder" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtewrholder" runat="server"  enabled="false"  Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>


                    <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="Cambria" Font-Size="Small" Text="EWR holder Account No" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtewraccountno" runat="server"  Height="19px"  enabled="false"  Theme="BlackGlass" Width="250px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>






                       <tr>
                           <td colspan="1">
                               <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Warehouse Receipts Available" Theme="Glass">
                               </dx:ASPxLabel>
                           </td>
                           <td colspan="2">
                               <dx:ASPxComboBox ID="cmbparaCompany" runat="server" AutoPostBack="true" Theme="BlackGlass" ValueType="System.String" Width="250px">
                               </dx:ASPxComboBox>
                           </td>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="1">&nbsp;</td>
                           <td colspan="1">&nbsp;</td>
                    </tr>
                     <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Charge" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="2">
                            <dx:ASPxTextBox ID="txtcharge" runat="server" enabled="false"  Height="19px" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>
                       <tr>

                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Available Units" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtavailableshares" runat="server" enabled="false"  Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                    </tr>
                         <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Units to withdraw" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtshares" runat="server"  Enabled="false" Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
                            </dx:ASPxTextBox>
                        </td>
                        
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>

                   
<tr>
        
    <td colspan ="7" align="center">
        &nbsp;</td>
   

</tr>
                    
                <tr>
                      <td colspan="1">&nbsp;</td>
                    <td align="left">
                        <dx:ASPxButton ID="ASPxButton13" runat="server" Text="Withdraw" Theme="BlackGlass">
                             <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Are you sure you want to Withdraw ?');}" />  
                        </dx:ASPxButton>
                        &nbsp;
                        <%--<dx:ASPxButton ID="ASPxButton14" runat="server" Text="Delete Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>--%>
                    </td>
                </tr>
                 
        </table>
        </asp:Panel>
        


        
        
               
        <asp:Panel ID="Panel9" runat="server" Enabled="True" Font-Names="Cambria" Font-Size="Medium" GroupingText="Pending">
            <table width="100%">
                    
                

                 <tr>

                <td align="center">


                        <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="100%">
                      
                        <Columns >

                            
                                               <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="otpenabled" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Re-Send"  Text='<%# Eval("Resend OTP") %>'>
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                             <dx:GridViewDataColumn Caption="" VisibleIndex="0">
                                    <DataItemTemplate>
                                        <asp:LinkButton ID="otpenabled" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="OTP"  Text='<%# Eval("otp") %>'>
                                                              </asp:LinkButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                             <dx:GridViewDataColumn VisibleIndex="0" Caption="">
                                                                                           <DataItemTemplate>
                                                              <asp:LinkButton ID="DeleteID" Text="Cancel Transaction" CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandArgument='<%# Eval("id") %>' runat="server">
                                                              </asp:LinkButton>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
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
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="S.No" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("id") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="EWR No.">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ReceiptID") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Amount" CellStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("amount_to_withdraw") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                         
                           
                        
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Commodity" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Commodity") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>

                               <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Grade" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Grade") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                             <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Status") %>' runat="server"></dx:ASPxLabel>
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

         <asp:Panel ID="Panel2" runat="server" Enabled="True" Font-Names="Cambria" Font-Size="Medium" GroupingText="Approved">
            <table width="100%">
                 <tr>
                <td align="center">

                      
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="100%">
                      
                        <Columns >

                        

                           
                           
                       
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="S.No" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("id") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="EWR No.">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("ReceiptID") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Amount" CellStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("amount_to_withdraw") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                         
                           
                        
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Commodity" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Commodity") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>

                               <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Grade" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Grade") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                             <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Status" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Status") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                    </dx:ASPxGridView>





 
                    </td>
                </tr>

                 <tr>
                    <td align="center">
                        <dx:ASPxPopupControl ID="ASPxPopupControl1"  runat="server" BackColor="#DDECFE" CloseAction="CloseButton"  PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" EnableCallbackAnimation="True" HeaderText="Enter OTP to Submit" ShowCollapseButton="True" ShowPageScrollbarWhenModal="True" ShowPinButton="True" Theme="Glass" Width="400px">
        <contentcollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    <dx:ASPxRoundPanel ID="ASPxRoundPanel6" BackColor="White" runat="server" ShowHeader="False"  Width="100%">
        <panelcollection>
            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                <table  style="width: 100%">
                    <tr>
                        <td align="right" style="height: 57px">
                            <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="OTP" Theme="iOS">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left" style="height: 57px">
                            <dx:ASPxTextBox ID="txtotp" runat="server"  Theme="iOS" >
                            <MaskSettings ErrorText="Invalid OTP" Mask="0000" />
                            </dx:ASPxTextBox>
                             <asp:Label ID="lbltransid" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" ></td>
                        <td align="left">
                            <dx:ASPxButton ID="btnotp" runat="server" CausesValidation="False" Text="Submit" Theme="Glass">

                            </dx:ASPxButton>
                        </td>
                        <td align="left">
                            <dx:ASPxButton ID="btnreject" runat="server" CausesValidation="False" Text="Reject" Theme="Glass">
                                <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Do you really want to Reject?');}" />  
                            </dx:ASPxButton>
                        </td>
                    </tr>
                  
                  
                </table>
            </dx:PanelContent>
        </panelcollection>
    </dx:ASPxRoundPanel>
            </dx:PopupControlContentControl>
</contentcollection>
    </dx:ASPxPopupControl></td>
                </tr>
                
                     
            </table>
             <table width="810px">
                    


               <tr  runat="server" id="l" visible="false" > 
                        <td  align="right"  runat="server"  >
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Please enter OTP here" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <%--<td >
                            <dx:ASPxTextBox ID="txtotp" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>--%>
                      
                     
                    </tr>
                 
                   <tr  runat="server" id="g" visible="false">
                       <td colspan="1">  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;</td>
                      

                        <td align="LEFT" >
                            <dx:ASPxButton ID="btnotp1" runat="server" Text="Confirm" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                    </tr>
                     
            </table>
        </asp:Panel>
               
</asp:Panel>
  
</div>
</asp:Content>


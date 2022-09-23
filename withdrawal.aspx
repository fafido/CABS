<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="Withdrawal.aspx.vb" Inherits="TransferSec_withdrawal" title="Withdrawal" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Batching&gt;&gt;Withdrawal" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

        
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria"  GroupingText="EWR Holder Details" Font-Size="Medium">

                <table width="810px" >
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
                            <dx:ASPxTextBox ID="txtshares" runat="server"  Enabled="false" Height="19px" Theme="BlackGlass" Width="250px">
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
                        </dx:ASPxButton>
                        &nbsp;
                        <%--<dx:ASPxButton ID="ASPxButton14" runat="server" Text="Delete Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>--%>
                    </td>
                </tr>
                 
        </table>
        </asp:Panel>
        


        
        
               
        <asp:Panel ID="Panel9" runat="server" Enabled="true" Font-Names="Cambria" Font-Size="Medium" GroupingText="Finish">
            <table width="810px">
                    
                

                 <tr>

                <td align="center">


                        <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="740px">
                      
                        <Columns >

                        

                             <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="" CellStyle-HorizontalAlign="Right" Width="8PX" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                       <dx:ASPxButton Height="18px" ID="btnAction" Value='<%# Eval("id") %>'  runat="server" AutoPostBack="False" ClientInstanceName="btnAction" Text="Approve" OnClick="btn_accept" >
                        </dx:ASPxButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="" CellStyle-HorizontalAlign="Right" Width="8PX" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                       <dx:ASPxButton Height="18px"   ID="btnAction" runat="server" AutoPostBack="False"  ClientInstanceName="btnAction" Text="Reject" OnClick="btn_reject"  >
                                            <ClientSideEvents Click="function(s,e){ e.processOnServer = confirm('Do you really want to Reject?');}" />  
                        </dx:ASPxButton>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                           
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
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Amount">
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

                 <tr>

                <td align="center">


                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="740px">
                      
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
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Amount">
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
                
                     
            </table>
             <table width="810px">
                    


               <tr  runat="server" id="otptable" visible="false" > 
                        <td  align="right"  runat="server"  >
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Please enter OTP here" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td >
                            <dx:ASPxTextBox ID="txtotp" runat="server" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                      
                     
                    </tr>
                 
                   <tr  runat="server" id="otptable2" visible="false">
                       <td colspan="1">  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;</td>
                      

                        <td align="LEFT" >
                            <dx:ASPxButton ID="btnotp" runat="server" Text="Confirm" Theme="BlackGlass">
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


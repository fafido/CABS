<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="transfershares.aspx.vb" Inherits="TransferSec_transfershares" title="Transfer" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="840px" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="810px">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Batching&gt;&gt;Transfer" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>

          <asp:panel id="Panel2" runat="server" GroupingText="Search Options" Font-Names="Cambria" Visible="False">
        <table width="810px">
            <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch No." Theme="Glass">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientNoSe" runat="server" Theme="Glass" Width="300px">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
             <tr>
                <td colspan ="1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Client Name." Theme="Glass" Visible="False">
                    </dx:ASPxLabel>
                </td>
                <td colspan ="1" width="301">
                    <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="300px" Visible="False">
                    </dx:ASPxTextBox>
                </td>
                <td colspan ="1">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="&gt;&gt;" Width="38px" Theme="BlackGlass" Visible="False">
                    </dx:ASPxButton>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td width="301">
                    <dx:ASPxComboBox ID="cmbBatchType" runat="server" Theme="BlackGlass" ValueType="System.String" Width="250px" Visible="False">
                    </dx:ASPxComboBox>
                </td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>
            <tr>
                <td colspan ="1">
                    &nbsp;</td>
                <td width="301">
                    &nbsp;</td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>
                <td colspan ="1"></td>

            </tr>

        </table>

    </asp:panel>
        <asp:Panel runat="server" ID="Panel3" Font-Names="Cambria" GroupingText="Batch Details" Visible="False">

                <table width="810px">
<tr>
        <td colspan ="1">
            &nbsp;</td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1">
        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Shares" Theme="Glass">
        </dx:ASPxLabel>
        </td>
    <td colspan ="1">
        <dx:ASPxTextBox ID="txtBatchShares" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
        </dx:ASPxTextBox>
        </td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1">
        &nbsp;</td>
    <td colspan ="1"></td>
    <td colspan ="1"></td>

</tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Share Price" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtShareprice" runat="server" BackColor="#E4E4E4" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Value" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtBatchValue" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>

                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 23px">
                                <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch Date" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxDateEdit ID="txtBatchDate" runat="server" Theme="Aqua" Width="250px">
                            </dx:ASPxDateEdit>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Lodger" Theme="Glass">
                            </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxTextBox ID="txtClientNo2" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>

                    </tr>
                    <tr>
                            <td colspan ="1" style="height: 23px">
                                <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Batch No" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxTextBox ID="txtClientNo" runat="server" BackColor="#E4E4E4" ReadOnly="True" Theme="BlackGlass" Visible="False" Width="250px">
                            </dx:ASPxTextBox>
                            </td>
                        <td colspan ="1" style="height: 23px">
                            </td>
                        <td colspan ="1" style="height: 23px">
                            <dx:ASPxComboBox ID="cmbBroker" runat="server" Theme="BlackGlass" ValueType="System.String" Visible="False" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>
                        <td colspan ="1" style="height: 23px"></td>

                    </tr>
                    
                    <tr>
                            <td colspan ="1">
                                &nbsp;</td>
                        <td colspan ="7">
                            &nbsp;</td>

                    </tr>
               
                    
        </table>
        </asp:Panel>
        

         <asp:Panel runat="server" ID="Panel4" Font-Names="Cambria" GroupingText="Batching Options" Font-Size="Medium" Visible="False">

                <table width="810px">
<tr>
        
    <td colspan ="8" align="center">
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="SecuritiesType" Text="Process Batch" Checked="True" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SecuritiesType" Text="Post Batch For Processing" />
        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="save" Theme="BlackGlass">
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton5" runat="server" Text="receipt" Theme="BlackGlass">
        </dx:ASPxButton>
        </td>
   

</tr>
                 
        </table>
        </asp:Panel>
         <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Transferor Information" Font-Size="Medium">

                <table width="810px"  >
                       <tr runat ="server" visible="false">
                           <td colspan="1">
                               <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transferor Name" Theme="Glass">
                               </dx:ASPxLabel>
                           </td>
                           <td colspan="1">
                               <dx:ASPxTextBox ID="txtclientnumber" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                               </dx:ASPxTextBox>
                           </td>
                           <td colspan="1">
                               <dx:ASPxButton ID="ASPxButton10" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                               </dx:ASPxButton>
                           </td>
                           <td colspan="1"></td>
                           <td colspan="1"></td>
                           <td colspan="1"></td>
                           <td colspan="1"></td>
                    </tr>
                       <tr runat ="server" visible="false">
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
                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Name" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtparticipantname" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
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
                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant Account No" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtAccountNo" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
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
                            <dx:ASPxTextBox ID="txtewrholder" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
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
                            <dx:ASPxTextBox ID="txtewraccountno" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
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
                                <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Available Units" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxTextBox ID="txtavailableshares" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px" ReadOnly="True">
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
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Units to transfer" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtshares" runat="server" BackColor="#E4E4E4" Height="19px" ReadOnly="true" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">
                            &nbsp;</td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                    </tr>
                   
<tr>
        
    <td colspan ="7" align="center">
        &nbsp;</td>
   

</tr>
                 
        </table>
        </asp:Panel>
               
        <asp:panel id="Panel6" runat="server" GroupingText="Transferee Information" Font-Names="Cambria" Visible="True">
        <table width="810px">
           
               <tr>
                        <td colspan="1" style="width:208px">
                            <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Transferee Account No" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtclientnumber0" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">
                            <dx:ASPxButton ID="ASPxButton15" runat="server" Text="&gt;&gt;" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>

            <tr>
                        <td colspan="1">&nbsp;</td>
                        
                        <td colspan="1">
                            <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True" Width="447px"></asp:ListBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
             <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
            <tr>
                <td colspan="1">&nbsp;</td>
                        
                        
                        <td align="center">
                            <dx:ASPxButton ID="ASPxButton12" runat="server" Text="Transfer" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                    </tr>

                
                
        </table>

    </asp:panel>

        <asp:Panel ID="Panel9" runat="server" Enabled="True" Font-Names="Cambria" Font-Size="Medium" GroupingText="Finish">
            <table width="760px">


                
                <%--<tr>
                    <td align="center" colspan="8">
                        <dx:ASPxButton ID="ASPxButton13" runat="server" Text="Save Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>
                        &nbsp;
                        <dx:ASPxButton ID="ASPxButton14" runat="server" Text="Delete Batch Details" Theme="BlackGlass">
                        </dx:ASPxButton>
                    </td>
                </tr>--%>
                <tr>
                    <td align="center">


                        <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="760px">
                      
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
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Transferor">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Transferor") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Transferee" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Transferee") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Quantity">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Amount_to_transfer") %>' runat="server"></dx:ASPxLabel>
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
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                 <tr>
                         <td align="center">


                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="true"  KeyFieldName="id" Theme="Glass" Width="760px">
                      
                        <Columns >


                           
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
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Transferor">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Transferor") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                                
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Transferee" CellStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Transferee") %>' runat="server"></dx:ASPxLabel>
                                    </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn HeaderStyle-Font-Bold="true" Caption="Quantity">
                                    <DataItemTemplate>
                                        <dx:ASPxLabel Text='<%# Eval("Amount_to_transfer") %>' runat="server"></dx:ASPxLabel>
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



<%--                         <asp:GridView ID="ASPxGridView3" runat="server" BackColor="White"  Settings-ShowTitlePanel="true" SettingsText-Title="Transfers"
                        BorderColor="#eafaf1" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CssClass="tablestyle" 
                        Style="position: relative; top: 0px; left: 0px; width: 99%;" 
                         DataKeyNames="id" AutoGenerateColumns="False" Font-Size="Small" >
                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                              <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle CssClass="headerstyle" BackColor="#eafaf1" Font-Bold="True" ForeColor="#000" />
                              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle CssClass="rowstyle" ForeColor="#000" />
                        <Columns>
                                <asp:BoundField DataField="id" Visible="false" HeaderText="ID" />
                                <asp:BoundField DataField="S.No" HeaderText="S.No" />
                                <asp:BoundField DataField="Transferor" HeaderText="Transferor" />
                              <asp:BoundField DataField="Transferee" HeaderText="Transferee" />
                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                              <asp:BoundField DataField="Commodity" HeaderText="Commodity" />
                               <asp:BoundField DataField="Grade" HeaderText="Grade" />
                            <asp:BoundField DataField="EWR No." HeaderText="EWR No." />

                             <asp:BoundField DataField="Status" HeaderText="Status" />
                              <asp:BoundField DataField="Trns. Date" HeaderText="Trns. Date" />
                              
                           
                           
                                                                                                                         <asp:TemplateField Visible="false"  HeaderText="id">
<ItemTemplate>
<asp:Label ID="id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                       


                     
                            
                               <asp:CommandField ShowSelectButton="true" SelectText="Approve"  ControlStyle-Font-Bold="true"  />

                            
                            

                           
                                                    <asp:TemplateField >
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="LinkButton2" ToolTip="Reject" Font-Bold="True" AlternateText="Reject" CommandName="REJECT" runat="server" CommandArgument='<%#Eval("id")%>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                            </Columns>
                             
                    </asp:GridView>--%>


 
                    </td>
                </tr>
                
                 
            </table>
            <table  width="810px">
                 <tr runat="server" id="otptable" visible="false"> 
                        <td align="RIGHT" >
                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Please enter OTP here" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtotp" runat="server" BackColor="#E4E4E4" Height="19px" Theme="BlackGlass" Width="250px">
                            </dx:ASPxTextBox>
                        </td>
                     
                     
                    </tr>

                   <tr  runat="server" id="otptable2" visible="false">
                       <td colspan="1">  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; </td>
                       

                        <td align="left" >
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


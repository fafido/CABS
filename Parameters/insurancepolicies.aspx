<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="insurancepolicies.aspx.vb" Inherits="Parameters_InsurancePolicies" title="Insurance Policy Uploads" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Panel id="Panel1" runat="server" Width="100%" Font-Names="Arial" Font-Size="Medium" BackColor="White">
    
        <table width ="100%">
            <tr>
                   <td style ="text-align :left;" align="left">
                       <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Parameters&gt;Insurance Policies" Font-Names="Cambria" Font-Size="Small" Theme="PlasticBlue"></dx:ASPxLabel>

                   </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="Panel5" Font-Names="Cambria" GroupingText="Insurance Policies">

                <table width="100%">
                    <tr>
                            <td colspan ="8" align ="center">
                                &nbsp;</td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Participant" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <dx:ASPxComboBox ID="cmbparticipant" runat="server" AutoPostBack="True" Theme="BlackGlass" ValueType="System.String" Width="250px">
                            </dx:ASPxComboBox>
                            </td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">
                            &nbsp;</td>
                        <td colspan ="1">&nbsp;</td>
                        <td colspan ="1">&nbsp;</td>


                    </tr>
                    <tr>
                        <td colspan="7">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="Cambria" Font-Size="Medium" Font-Underline="True" Text="Fidelity Insurance " Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="2">
                            <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="Cambria" Font-Size="Medium" Font-Underline="True" Text="Fire &amp; Allied Insurance" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Insurance Company" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtinsurancecompany" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Insurance Company" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtinsurancecompany0" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Policy Number" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                          
                              <dx:ASPxTextBox ID="txtpolicynumber" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                              </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Policy Number" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtpolicynumber0" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                         <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                                   </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1"></td>
                        <td colspan="1"></td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel23" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxDateEdit ID="txtexpiry" runat="server" EditFormat="Custom" EditFormatString="dd-MMM-yyyy" Theme="BlackGlass" Width="250px">
                           <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                                 </dx:ASPxDateEdit>
                        </td>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Expiry" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxDateEdit ID="txtexpiry1" runat="server" EditFormat="Custom" EditFormatString="dd-MMM-yyyy" Theme="BlackGlass" Width="250px">
                          <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                                  </dx:ASPxDateEdit>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel24" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Cover Amount" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtamount" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">
                            <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Cover Amount" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan="1">
                            <dx:ASPxTextBox ID="txtamount0" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                          <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                                  </dx:ASPxTextBox>
                        </td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan ="1" style="height: 27px">
                            <dx:ASPxLabel ID="ASPxLabel22" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Notes" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1" style="height: 27px">
                            <dx:ASPxTextBox ID="txtnotes" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                          <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                                  </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1" style="height: 27px">
                            <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Notes" Theme="Glass">
                            </dx:ASPxLabel>
                        </td>
                        <td colspan ="1" style="height: 27px">
                            <dx:ASPxTextBox ID="txtnotes0" runat="server" style="margin-top: 0px" Theme="Glass" Width="250px">
                            <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td colspan ="1" style="height: 27px"></td>
                        <td colspan ="1" style="height: 27px"></td>
                        <td colspan ="1" style="height: 27px"></td>

                    </tr>
                    <tr>
                            <td colspan ="1">
                                <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Cover Note" Theme="Glass">
                                </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="248px" />
                            </td>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Cover Note" Theme="Glass">
                          
                                  </dx:ASPxLabel>
                            </td>
                        <td colspan ="1">
                            <asp:FileUpload ID="FileUpload2" runat="server" Width="248px" />
                            </td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>
                        <td colspan ="1"></td>


                    </tr>
                    <tr>
                        <td colspan="1">&nbsp;</td>
                        <td colspan="1">
                            <dx:ASPxButton ID="ASPxButton7" runat="server" Text="save" Theme="BlackGlass">
                            </dx:ASPxButton>
                        </td>
                        <td colspan="1">
                            <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
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
                        <td colspan="1">&nbsp;</td>
                    </tr>
                    <tr>
                            <td colspan ="8" style="height: 18px">
                                <dx:ASPxGridView ID="ASPxGridView2" KeyFieldName="id" runat="server" Theme="Glass"  Width="100%">
                                    <SettingsPager Visible="True">
                                    </SettingsPager>
                                    <Columns>
                                        <dx:GridViewDataColumn VisibleIndex="0" Caption="">
                                                         <DataItemTemplate>
                                                              <asp:LinkButton ID="SelectID" Text="Edit"  CommandName="Edit" CommandArgument='<%# Eval("ID") %>' runat="server">
                                                              </asp:LinkButton>
                                                         </DataItemTemplate>
                                                                                       </dx:GridViewDataColumn>
                               <%--     <dx:GridViewDataColumn VisibleIndex="0" Caption="">
                                                                                           <DataItemTemplate>
                                                              <asp:LinkButton ID="DeleteID" Text="Delete" CommandName="Delete" OnClientClick="if ( !confirm('Are you sure you want to delete ? ')) return false;" CommandArgument='<%# Eval("ID") %>' runat="server">
                                                              </asp:LinkButton>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>--%>
                               
                                  
                                        <dx:GridViewDataColumn Caption="Fidelity Insurance Company">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("InsuranceCompany") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                               <dx:GridViewDataColumn Caption="Fidelity Policy No.">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("PolicyNumber") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                               <dx:GridViewDataColumn Caption="Fidelity Insurance Expiry">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Expiry") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                        
                                               <dx:GridViewDataColumn Caption="Fidelity Amount">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Amount") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                           <dx:GridViewDataColumn Caption="Allied Insurance Company">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("A_InsuranceCompany") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                               <dx:GridViewDataColumn Caption="Allied Policy No.">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("A_policyNumber") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                               <dx:GridViewDataColumn Caption="Allied Insurance Expiry">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("A_Expiry") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                        
                                               <dx:GridViewDataColumn Caption="Allied Amount">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("A_Amount") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                        
                                               <dx:GridViewDataColumn Caption="Warehouse">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("Participant") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                                     <dx:GridViewDataColumn Caption="Date Upload">
                                                         <DataItemTemplate>
                                                              <dx:ASPxLabel Text='<%# Eval("DateUploaded") %>' runat="server"></dx:ASPxLabel>
                                                         </DataItemTemplate>
                                                    </dx:GridViewDataColumn>

                                  


                                  



                                    </Columns>
                                </dx:ASPxGridView>
                            </td>
                        


                    </tr>
                    <tr>
                        <td colspan ="1"></td>
                        <td colspan ="7" align="center">
                            &nbsp;</td>

                    </tr>
                    <tr>
                        <td colspan="1">
                            &nbsp;</td>
                        <td colspan ="7">
                            &nbsp;</td>

                    </tr>
                 
        </table>
        </asp:Panel>
                       
</asp:Panel>
  
</div>
</asp:Content>


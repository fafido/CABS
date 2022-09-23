<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="CDSHome.aspx.vb" Inherits="CDSMode_CDSHome" title="Home" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Aspxdateedit" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFormLayout" tagprefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRibbon" tagprefix="dx" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
     <asp:Panel runat="server" ID="panelview" Visible="false">    <div class="main-section">
		<div class="dashbord email-content">
			<div class="title-section">
				<p runat="server" id="onebyone_title">SENT EMAILS</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-envelope-o" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="onebyone_value">200</h1>
					<span runat="server" id="onebyone_pending">+7% email list penetration</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server"  id="onebyone_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>
		<div class="dashbord download-content">
			<div class="title-section">
				<p runat="server" id="onebytwo_title">CLOUD DOWNLOAD</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-download" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="onebytwo_value">8.25 <small>k</small></h1>
					<span runat="server" id="onebytwo_pending">12% have started download</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="onebytwo_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>
		<div class="dashbord product-content">
			<div class="title-section">
				<p runat="server" id="onebythree_title">SALES FROM YOUR CREDIT-CARD</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-credit-card" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="onebythree_value">360 <small>$</small></h1>
					<span runat="server" id="onebythree_pending">$ 272 credit in your account</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="onebythree_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>

		<div class="dashbord email-content">
			<div class="title-section">
				<p runat="server" id="twobyone_title">SENT EMAILS</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-envelope-o" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="twobyone_value">200</h1>
					<span runat="server" id="twobyone_pending">+7% email list penetration</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="twobyone_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>
		<div class="dashbord download-content">
			<div class="title-section">
				<p runat="server" id="twobytwo_title">CLOUD DOWNLOAD</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section" >
					<i class="fa fa-download" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="twobytwo_value">8.25 <small>k</small></h1>
					<span runat="server" id="twobytwo_pending">121% have started download</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="twobytwo_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>
		<div class="dashbord product-content">
			<div class="title-section">
				<p runat="server" id="twobythree_title">SALES FROM YOUR CREDIT-CARD</p>
			</div>
			<div class="icon-text-section">
				<div  class="icon-section">
					<i class="fa fa-credit-card" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="twobythree_value">360 <small>$</small></h1>
					<span runat="server" id="twobythree_pending">$ 272 credit in your account</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="twobythree_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>
        	<div class="dashbord email-content">
			<div class="title-section">
				<p runat="server" id="threebyone_title">SENT EMAILS2</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-envelope-o" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="threebyone_value">200</h1>
					<span runat="server" id="threebyone_pending">+7% email list penetration</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="threebyone_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>
		<div class="dashbord download-content">
			<div class="title-section">
				<p runat="server" id="threebytwo_title">CLOUD DOWNLOAD</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-download" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="threebytwo_value">8.25 <small>k</small></h1>
					<span  runat="server" id="threebytwo_pending">12% have started download</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a  runat="server" id="threebytwo_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>
		<div class="dashbord product-content">
			<div class="title-section">
				<p  runat="server" id="threebythree_title">SALES FROM YOUR CREDIT-CARD</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-credit-card" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="threebythree_value">360 <small>$</small></h1>
					<span runat="server" id="threebythree_pending">$ 272 credit in your account</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="threebythree_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>



           	<div class="dashbord email-content">
			<div class="title-section">
				<p runat="server" id="fourby1_title">SENT EMAILS2</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-envelope-o" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="fourby1_value">200</h1>
					<span runat="server" id="fourby1_pending">+7% email list penetration</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="fourby1_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>

          	<div class="dashbord download-content">
			<div class="title-section">
				<p runat="server" id="fourby2_title">SENT EMAILS2</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-envelope-o" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="fourby2_value">200</h1>
					<span runat="server" id="fourby2_pending">+7% email list penetration</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="fourby2_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>


          	<div class="dashbord product-content">
			<div class="title-section">
				<p runat="server" id="fourby3_title">SENT EMAILS2</p>
			</div>
			<div class="icon-text-section">
				<div class="icon-section">
					<i class="fa fa-envelope-o" aria-hidden="true"></i>
				</div>
				<div class="text-section">
					<h1 runat="server" id="fourby3_value">200</h1>
					<span runat="server" id="fourby3_pending">+7% email list penetration</span>
				</div>
				<div style="clear:both;"></div>
			</div>
			<div class="detail-section">
				<a runat="server" id="fourby3_link">
					<p>View Detail</p>
					<i class="fa fa-arrow-right" aria-hidden="true"></i>
				</a>
			</div>
		</div>
	

	</div>
        </asp:Panel>
     <table style="width: 249px">
        <tr>
            <td style="width: 32px; height: 41px">
            </td>
            <td style="height: 41px">
                                <dx:ASPxButton ID="btnSaveContract3" runat="server" CausesValidation="False" Text="Dashboard Preferences" Theme="Glass" Height="22px" Width="164px" Visible="False">
                                </dx:ASPxButton>
                            </td>
        </tr>
    </table>

     <br />
                        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" BackColor="#DDECFE" CloseAction="CloseButton" EnableCallbackAnimation="True" HeaderText="Dashboard Preference" Modal="true" ShowCollapseButton="False" ShowMaximizeButton="False" ShowPageScrollbarWhenModal="True" ShowPinButton="False" ShowRefreshButton="False" Theme="Glass">
                            <contentcollection>
                                <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                    <dx:aspxroundpanel ID="ASPxRoundPanel9" runat="server" ShowHeader="False" Theme="Glass" Width="100%">
                            <panelcollection>
                                <dx:panelcontent runat="server" SupportsDisabledAttribute="True">
                                    <table class="dxflInternalEditorTable_Moderno" style="width: 100%">
                                        <tr>
                                            <td>
                                                <dx:ASPxGridView ID="grdcols" runat="server" AutoGenerateColumns="False" KeyFieldName="title" Theme="Glass" Width="100%">
                                                    <Columns>
                                                         <dx:GridViewDataColumn Caption="Select" FieldName="Selec"  VisibleIndex="0">
                                    <DataItemTemplate>
                                        <dx:aspxcheckbox ID="chk1" Checked='<%# Eval("chk") %>' runat="server" >
                                                              </dx:aspxcheckbox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                                        
                                                                                                         <dx:GridViewDataColumn Caption="Title" ShowInCustomizationForm="True" VisibleIndex="2">
                                                            <DataItemTemplate>
                                                                <dx:ASPxLabel runat="server" Text='<%# Eval("title") %>'>
                                                                </dx:ASPxLabel>
                                                            </DataItemTemplate>
                                                            <HeaderStyle Font-Bold="True" />
                                                        </dx:GridViewDataColumn>
                                                    </Columns>
                                                    <SettingsPager Mode="ShowAllRecords" Visible="False">
                                                    </SettingsPager>
                                                </dx:ASPxGridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxButton ID="btnSaveContract5" runat="server" CausesValidation="False" Text="Save Change" Theme="Glass">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:panelcontent>
                            </panelcollection>
              </dx:aspxroundpanel>
                                </dx:PopupControlContentControl>
                            </contentcollection>
                        </dx:ASPxPopupControl>
                    
</asp:Content>


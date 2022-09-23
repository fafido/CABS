<%@ Page Language="VB" MasterPageFile="~/CDSUser.master" AutoEventWireup="false" CodeFile="SecuritiesBorrowingValuation.aspx.vb" Inherits="BrokerMode_SecuritiesBorrowingValuation" title="Broker Home" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>


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
            <table>
            
                <tr>

                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Client Name" Theme="Office2010Blue" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtNameSearch" runat="server" Theme="Glass" Width="250px" Visible="False">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxButton ID="btnNameSearch" runat="server" Text="&gt;&gt;" Theme="Glass" Width="45px" Visible="False">
                        </dx:ASPxButton>
                    </td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                </tr>
                <tr>

                    <td colspan ="1"></td>
                    <td colspan ="3">
                        <asp:ListBox ID="lstNamesSearch" runat="server" AutoPostBack="True" Width="474px" Visible="False"></asp:ListBox>
                    </td>
                    
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                        
                    <td colspan ="8" align="center"><dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Documents Attchments" Theme="RedWine" BackColor="#CCCCFF" Width="600px"></dx:ASPxLabel></td>
                    

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    
                    <td colspan ="4">
                        <asp:RadioButton ID="rdApplicationForm" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Application Form" />
                        <asp:RadioButton ID="rdIdentity" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Identity Documents" />
                        <asp:RadioButton ID="rdOther" runat="server" AutoPostBack="True" GroupName="DocumentsType" Text="Other" />
                        </td>
                    
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtOther" runat="server" Theme="Glass" Visible="False" Width="170px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    

                </tr>
                <tr>

                    <td colspan ="8" align="center" >
                        <dx:ASPxUploadControl ID="Fileupload1" runat="server" ShowProgressPanel="True" Theme="Office2003Blue" UploadMode="Advanced" Visible="False" Width="211px">
                        </dx:ASPxUploadControl>
                        <dx:ASPxButton ID="btnUpload" runat="server" Text="Upload" Theme="Glass" Visible="False">
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnScan" runat="server" Text="Scan" Theme="Glass" Visible="False">
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnCam" runat="server" Text="Camera" Theme="Glass" Visible="False">
                        </dx:ASPxButton>
                    </td>

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="3">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>


                </tr>
                <tr>

                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Client Type" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <asp:DropDownList ID="cmbClientType" runat="server" AutoPostBack="True" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Client Code" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtClientCode" runat="server" Theme="Glass" Width="155px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Client Name" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                    </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtClientName" runat="server" Theme="Glass" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="Net Value" Theme="Office2010Blue">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtNetValue" runat="server" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="2" align="right">
                            <dx:ASPxRadioButton ID="rdAssets" runat="server" AutoPostBack="True" GroupName="Valuation" Text="Assets" Theme="PlasticBlue">
                            </dx:ASPxRadioButton>
                        </td>
                    <td colspan ="4" style="align-items:center;">
                        <dx:ASPxRadioButton ID="rdLiabilities" runat="server" AutoPostBack="True" GroupName="Valuation" Text="Liabilities" Theme="PlasticBlue">
                        </dx:ASPxRadioButton>
                        </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="Asset Name" Theme="Office2010Blue">
                            </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtAssetName" runat="server" Theme="Glass" Width="250px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Value" Theme="Office2010Blue">
                        </dx:ASPxLabel>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxTextBox ID="txtValue" runat="server" Theme="Glass" Width="155px">
                        </dx:ASPxTextBox>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxButton ID="btnAdditions" runat="server" Text="&gt;&gt;" Theme="BlackGlass" Width="83px">
                        </dx:ASPxButton>
                        </td>
                    <td colspan ="1">
                        <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Calculate Credit Limit" Theme="BlackGlass">
                        </dx:ASPxButton>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        
                    <td colspan ="8" align="center">
                        <dx:ASPxGridView ID="grdBorrowingValuation" runat="server" Theme="Office2003Blue" Width="462px">
                        </dx:ASPxGridView>
                        </td>
                    
                    

                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">&nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>

                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="8" style="text-align:center;">
                            &nbsp;</td>

                </tr>
                <tr>
                        <td colspan ="8" style=" align-items :center;">&nbsp;</td>

                </tr>
                <tr>

                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1">
                        &nbsp;</td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                </tr>
                
                <tr>
                        <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>

                </tr>
                <tr>
                        <td colspan ="1">
                            <dx:ASPxButton ID="ASPxButton5" runat="server" Text="previous" Theme="SoftOrange" Width="85px">
                            </dx:ASPxButton>
                        </td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1"></td>
                    <td colspan ="1">
                        <dx:ASPxButton ID="ASPxButton6" runat="server" Text="next" Theme="SoftOrange" Width="85px">
                        </dx:ASPxButton>
                        </td>

                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
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


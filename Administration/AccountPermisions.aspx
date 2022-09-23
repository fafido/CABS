<%@ Page Language="VB" MasterPageFile="~/BrokerAdministration.master" AutoEventWireup="false" CodeFile="AccountPermisions.aspx.vb" Inherits="Administration_AccountPermisions" title="Account Permissions" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>

<div>
    <asp:Panel id="Panel1" runat="server">
    
<table style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 832px; border-bottom: #000033 thin solid; background-color: #ffffff">
    <tr>
        <td style="width: 712px; height: 226px" valign="top">
            <table>
            <tr>
                <td style="width: 870px" align="center">
                    <asp:Label id="Label4" runat="server" backcolor="#8080FF" font-bold="True" font-names="Arial"
                        Text="User Permissions" width="848px"></asp:Label></td>
            </tr>
                <tr>
                    <td colspan ="4" valign="top">
                        <asp:Label id="Label1" runat="server" Text="Department:" width="144px" font-names="Verdana" font-size="Small" Visible="False"></asp:Label>
                        <asp:Label id="lblShareholder" runat="server" font-names="Verdana" font-size="Small" Visible="False"></asp:Label></td>
                </tr>
                
            </table>
            <table>
                <tr>
                    <td style="width: 143px">
                        </td>
                        <td>
                            </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                                    <td style="width: 141px">
                                        </td>
                </tr>
            </table>
            <table id="TABLE1" onclick="return TABLE1_onclick()">
            <tr>
                    <td colspan ="1" style="width: 140px">
                        <asp:Label id="Label9" runat="server" Text="User name Search" font-names="Verdana" font-size="Small" width="120px"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtSearchUser" runat="server" autopostback="True"></asp:TextBox>
                            <asp:Button id="BtnSearch" runat="server" Text=">>" /></td>
                            <td colspan ="1" style="width: 172px">
                                </td>
                                <td colspan ="1" style="width: 291px">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px"></td>
                    <td></td>
                    <td></td>
                    <td style="width: 291px"></td>
                </tr>
               
            <tr>
                    <td colspan ="1" style="width: 140px">
                        <asp:Label id="Label5" runat="server" Text="UserName" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtUsername" runat="server" autopostback="True" ReadOnly="True"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                                </td>
                                <td colspan ="1" style="width: 291px">
                                    </td>
                </tr>
                <tr>
                    <td colspan ="1" style="width: 140px">
                        <asp:Label id="Label2" runat="server" Text="Surname" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td colspan="1" style="width: 203px">
                            <asp:TextBox id="txtSurname" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <td colspan ="1" style="width: 172px">
                                <asp:Label id="Label3" runat="server" Text="Fornames" font-names="Verdana" font-size="Small"></asp:Label></td>
                                <td colspan ="1" style="width: 291px">
                                    <asp:TextBox id="txtforenames" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        <asp:Label id="Label6" runat="server" Text="Employee Code" font-names="Verdana" font-size="Small"></asp:Label></td>
                        <td>
                            <asp:TextBox id="txtID" runat="server" ReadOnly="True"></asp:TextBox></td>
                            <td>
                                <asp:Label id="Label10" runat="server" font-names="Verdana" font-size="Small" Text="Department"></asp:Label></td>
                            <td style="width: 291px">
                                <asp:TextBox id="tctDept" runat="server" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        <asp:Label id="Label11" runat="server" font-names="Verdana" font-size="Small" Text="Company"></asp:Label></td>
                    <td>
                        <asp:TextBox id="txtCompany" runat="server" font-bold="True" font-names="Times New Roman"
                            font-size="Small" ReadOnly="True"></asp:TextBox></td>
                    <td>
                        <asp:Label id="Label29" runat="server" Text="Select a department:" font-names="Verdana" font-size="Small" width="144px"></asp:Label></td>
                    <td style="width: 291px">
                        <asp:DropDownList id="cmbUserType" runat="server" width="160px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 140px; background-color: #8080ff; height: 7px;"></td>
                    <td style="width: 175px; height: 7px; background-color: #8080ff">
                        <asp:Label id="Label14" runat="server" font-bold="True" Text="SYSTEM/MEMBER ACCOUNTS MANAGEMENT"
                            width="368px"></asp:Label></td>
                    <td style="width: 175px; height: 7px; background-color: #8080ff"></td>
                    <td style="width: 291px; height: 7px; background-color: #8080ff"></td>
                </tr>
                
                <tr>
                    <td colspan ="1" style="width: 140px; height: 12px; background-color: #990000;">
                        </td>
                        <td colspan="1" style="width: 203px; height: 12px; background-color: #990000;">
                            <asp:CheckBox id="chkUserCreation" runat="server" font-bold="True" font-names="Verdana" font-size="Small" forecolor="White" Text="Create A System User" /></td>
                            <td colspan ="1" style="width: 203px; height: 12px; background-color: #990000;">
                                <asp:CheckBox id="chkUpdateSystemUser" runat="server" font-bold="True" font-names="Verdana" font-size="Small" forecolor="White" Text="Update User" /></td>
                                <td colspan ="1" style="width: 291px; height: 12px; background-color: #990000;">
                                    <asp:CheckBox id="chkPermissionAllot" runat="server" font-bold="True" font-names="Verdana" font-size="Small" forecolor="White" Text="Allot Permissions" /></td>
                </tr>
                
                <tr>
                    <td colspan ="1" style="width: 140px; height: 12px;">
                        </td>
                        <td colspan="1" style="width: 203px; height: 12px;">
                            <asp:CheckBox id="chkCreateMemberAcc" runat="server" Text="Create Member Accounts" font-names="Verdana" font-size="Small" /></td>
                            <td colspan ="1" style="width: 172px; height: 12px;">
                                <asp:CheckBox id="ChkUpdateMemberAcc" runat="server" Text="Update Member Accounts" width="192px" font-names="Verdana" font-size="Small" /></td>
                                <td colspan ="1" style="width: 291px; height: 12px;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            </td>
                            <td>
                                <asp:CheckBox id="CheckBox5" runat="server" font-names="Verdana" font-size="Small" /></td>
                            <td style="width: 291px">
                                </td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                    <td>
                        <asp:CheckBox id="CheckBox7" runat="server" font-names="Verdana" font-size="Small" /></td>
                    <td>
                        <asp:CheckBox id="CheckBox8" runat="server" font-names="Verdana" font-size="Small" /></td>
                    <td style="width: 291px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 140px; background-color: #8080ff; height: 21px;"></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff">
                        <asp:Label id="Label15" runat="server" font-bold="True" Text="ENQUIRIES"
                            width="280px"></asp:Label></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff"></td>
                    <td style="width: 291px; height: 21px; background-color: #8080ff"></td>
                </tr>
                <tr>
                    <td style="background-color: #990000; width: 140px;">
                        </td>
                        <td style="background-color: #990000">
                            <asp:CheckBox id="ChkEnqSystemAcc" runat="server" Text="System User Accounts" font-bold="True" font-names="Verdana" font-size="Small" forecolor="White" /></td>
                            <td style="background-color: #990000">
                                <asp:CheckBox id="ChkEqnSystemUserAudit" runat="server" Text="System Users Audits" font-bold="True" font-names="Verdana" font-size="Small" forecolor="White" /></td>
                            <td style="background-color: #990000;">
                                </td>
                </tr>
                <tr>
                    <td style="width: 140px"></td>
                    <td>
                        <asp:CheckBox id="ChkEnqMemberAccDetail" runat="server" Text="Member Accounts Details" font-names="Verdana" font-size="Small" /></td>
                        <td>
                            <asp:CheckBox id="ChkMemberAccPort" runat="server" Text="Member Accounts Portfolio" font-names="Verdana" font-size="Small" /></td>
                        <td style="width: 291px">
                            </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 21px;">
                        &nbsp;</td>
                        <td style="height: 21px">
                            <asp:CheckBox id="ChkEnqTransHist" runat="server" Text="Transaction History" font-names="Verdana" font-size="Small" /></td>
                            <td style="height: 21px">
                                <asp:CheckBox id="ChkEnqBatchHist" runat="server" Text="Batch History" font-names="Verdana" font-size="Small" /></td>
                                <td style="height: 21px; width: 291px;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            <asp:CheckBox id="chkEnqTradesSettlements" runat="server" Text="Trades Settelments" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="ChkEnqDivHist" runat="server" Text="Dividend History" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            <asp:CheckBox id="chkEnqRightsAllot" runat="server" Text="Rights Allocations" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="ChkEnqBonusAllot" runat="server" Text="Bonus Allotments" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; background-color: #8080ff; height: 21px;"></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff">
                        <asp:Label id="Label16" runat="server" font-bold="True" Text="TRANSACTION BATCHING"
                            width="280px"></asp:Label></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff"></td>
                    <td style="width: 291px; height: 21px; background-color: #8080ff"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                    <td>
                        <asp:CheckBox id="ChkTransBatchCre" runat="server" Text="Batch Creation" font-names="Verdana" font-size="Small" /></td>
                    <td>
                        <asp:CheckBox id="ChkTransBatchProc" runat="server" Text="Batch Processing " font-names="Verdana" font-size="Small" /></td>
                    <td style="width: 291px"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        &nbsp;</td>
                        <td>
                            <asp:CheckBox id="chkTransBatchUpdate" runat="server" Text="Batch Updating " font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="ChkTransBatchReve" runat="server" Text="Batch Reversal" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px">
                                    </td>
                </tr>
                 <tr>
                    <td style="width: 140px; background-color: #8080ff; height: 19px;"></td>
                    <td style="width: 175px; height: 19px; background-color: #8080ff">
                        <asp:Label id="Label17" runat="server" font-bold="True" Text="ORDER MAINTAINANCE"
                            width="280px"></asp:Label></td>
                    <td style="width: 175px; height: 19px; background-color: #8080ff"></td>
                    <td style="width: 291px; height: 19px; background-color: #8080ff"></td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 16px;">
                        </td>
                    <td style="height: 16px">
                        <asp:CheckBox id="chkOrdSalePos" runat="server" Text="Sale Order Posting" font-names="Verdana" font-size="Small" /></td>
                    <td style="height: 16px">
                        <asp:CheckBox id="chkOrdPurchasePos" runat="server" Text="Purchase Order Posting" font-names="Verdana" font-size="Small" /></td>
                    <td style="width: 291px; height: 16px;"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        &nbsp;</td>
                        <td>
                            <asp:CheckBox id="chkOrdUpdate" runat="server" Text="Orders Update" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="chkOrdRev" runat="server" Text="Orders Reversal" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px">
                                    </td>
                </tr>
                
                <tr>
                    <td style="width: 140px; background-color: #8080ff; height: 21px;"></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff">
                        <asp:Label id="Label19" runat="server" font-bold="True" Text="AUDIT TRAIL"
                            width="280px"></asp:Label></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff"></td>
                    <td style="width: 291px; height: 21px; background-color: #8080ff"></td>
                </tr>
                <tr>
                    <td style="background-color: #990000; width: 140px;">
                        </td>
                    <td style="background-color: #990000">
                        <asp:CheckBox id="chkAudSysUserCre" runat="server" Text="System Users Creation" font-bold="True" font-names="Verdana" font-size="Small" forecolor="White" /></td>
                    <td style="background-color: #990000">
                        <asp:CheckBox id="chkAuditSystemPerm" runat="server" Text="System Users Permissions Allocations"
                            width="312px" font-bold="True" font-names="Verdana" font-size="Small" forecolor="White" /></td>
                    <td style="background-color: #990000;"></td>
                </tr>
                <tr>
                    <td style="background-color: #990000; width: 140px;">
                        &nbsp;</td>
                        <td style="background-color: #990000">
                            <asp:CheckBox id="ChkAudSysUserAccessSchd" runat="server" Text="System Users Access Schedule" font-bold="True" font-names="Verdana" font-size="Small" forecolor="White" /></td>
                            <td style="background-color: #990000">
                                <asp:CheckBox id="chkAudSysUserProMan" runat="server" Text="System Users Profile Management" font-bold="True" font-names="Verdana" font-size="Small" forecolor="White" /></td>
                                <td style="background-color: #990000;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 22px;">
                        </td>
                        <td style="height: 22px">
                            <asp:CheckBox id="chkAudMemberAccCre" runat="server" Text="Member Acounts Creation " font-names="Verdana" font-size="Small" /></td>
                            <td style="height: 22px">
                                <asp:CheckBox id="chkMAudemberAccUp" runat="server" Text="Member Accounts Updates" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px; height: 22px;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px;"></td>
                    <td>
                        <asp:CheckBox id="chkAudBatchCre" runat="server" Text="Batch Creation" font-names="Verdana" font-size="Small" /></td>
                    <td>
                        <asp:CheckBox id="chkAudBatchProce" runat="server" Text="Batch Processing " font-names="Verdana" font-size="Small" /></td>
                    <td style="width: 291px"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            <asp:CheckBox id="chkAudOrderCre" runat="server" Text="Orders Creation" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="chkAudOrderUpdate" runat="server" Text="Orders Update" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px">
                                    </td>
                </tr>
                
                <tr>
                    <td style="width: 140px; background-color: #8080ff; height: 21px;"></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff">
                        <asp:Label id="Label27" runat="server" font-bold="True" Text="FILE DOWNLOADS AND UPLOADS"
                            width="280px"></asp:Label></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff"></td>
                    <td style="width: 291px; height: 21px; background-color: #8080ff"></td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 22px;">
                        </td>
                    <td style="height: 22px">
                        <asp:CheckBox id="chkFileOrderDownl" runat="server" Text="Orders Summary File Download" font-names="Verdana" font-size="Small" /></td>
                    <td style="height: 22px">
                        <asp:CheckBox id="chkFileATSUp" runat="server" Text="ATS Settlement File Upload" font-names="Verdana" font-size="Small" /></td>
                    <td style="width: 291px; height: 22px;"></td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 11px;">
                        &nbsp;</td>
                        <td style="height: 11px">
                            <asp:CheckBox id="chkFileSettleEftDown" runat="server" Text="Settlements Eft downloads" font-names="Verdana" font-size="Small" /></td>
                            <td style="height: 11px">
                                <asp:CheckBox id="chkFileEFTsettleUp" runat="server" Text="Settlements Eft Confirmations Upload" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px; height: 11px;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 22px;">
                        </td>
                        <td style="height: 22px">
                            <asp:CheckBox id="chkFileMemberAccUp" runat="server" Text="Member Accounts File Upload" font-names="Verdana" font-size="Small" /></td>
                            <td style="height: 22px">
                                <asp:CheckBox id="chkFileMemberAccdown" runat="server" Text="Member Accounts File download" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px; height: 22px;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px;"></td>
                    <td>
                        <asp:CheckBox id="chkFileEFTDivDown" runat="server" Text="Dividend EFT File download" font-names="Verdana" font-size="Small" /></td>
                    <td></td>
                    <td style="width: 291px;"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            </td>
                            <td>
                                </td>
                                <td style="width: 291px">
                                    </td>
                </tr>  
                <tr>
                    <td style="width: 140px; background-color: #8080ff; height: 21px;"></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff">
                        <asp:Label id="Label8" runat="server" font-bold="True" Text="CORPORATEACTIONS"
                            width="280px"></asp:Label></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff"></td>
                    <td style="width: 291px; height: 21px; background-color: #8080ff"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                    <td>
                        <asp:CheckBox id="chkCorpDivCrea" runat="server" Text="Dividend Creation" font-names="Verdana" font-size="Small" /></td>
                    <td>
                        <asp:CheckBox id="chkCorpDivProc" runat="server" Text="Dividend Processing" font-names="Verdana" font-size="Small" /></td>
                    <td style="width: 291px"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        &nbsp;</td>
                        <td>
                            <asp:CheckBox id="chkCorpCheqAlloc" runat="server" Text="Cheque Numbers Allocation" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="CheckchkCorpCheqsPrintBox53" runat="server" Text="Cheques Printing" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 22px;">
                        </td>
                        <td style="height: 22px">
                            <asp:CheckBox id="chkCorpDivRecon" runat="server" Text="Dividend Reconciliation" font-names="Verdana" font-size="Small" /></td>
                            <td style="height: 22px">
                                <asp:CheckBox id="chkCorpCheqRepl" runat="server" Text="Cheques Replacements" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px; height: 22px;">
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 31px;"></td>
                    <td style="height: 31px">
                        <asp:CheckBox id="chkCorpRightsCreat" runat="server" Text="Rights Creation" font-names="Verdana" font-size="Small" /></td>
                    <td style="height: 31px">
                        <asp:CheckBox id="chkcorprightsplit" runat="server" Text="Rights Splits Capturing" font-names="Verdana" font-size="Small" /></td>
                    <td style="height: 31px; width: 291px;"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            <asp:CheckBox id="chkCorpRightsAccpt" runat="server" Text="Rights Acceptence Capturing" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="chkCorpRightLa" runat="server" Text="Rights LA's printing " font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px">
                                    </td>
                </tr>  
                <tr>
                    <td style="width: 140px; height: 18px;">
                        </td>
                        <td style="height: 18px">
                            <asp:CheckBox id="chkCorpBonusCreat" runat="server" Text="Bonus Creation" font-names="Verdana" font-size="Small" /></td>
                            <td style="height: 18px">
                                <asp:CheckBox id="ChkCorpBonusProce" runat="server" Text="Bonus Processing" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px; height: 18px;">
                                    </td>
                </tr>  
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            <asp:CheckBox id="chkCorpBonusNotePrint" runat="server" Text="Bonus Notices Printing" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="chkCorpAnnualRep" runat="server" Text="Annual Reports Uploading" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px">
                                    </td>
                </tr>  
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            <asp:CheckBox id="ChkCorpAGMNote" runat="server" Text="AGM Notices Creation" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="ChkCorpOtherActions" runat="server" Text="Other Corporate Events Notices Creation" font-names="Verdana" font-size="Small" /></td>
                                <td style="width: 291px">
                                    </td>
                </tr>  
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            </td>
                            <td>
                                </td>
                                <td style="width: 291px">
                                    </td>
                </tr>  
                <tr>
                    <td style="width: 140px; background-color: #8080ff; height: 21px;"></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff">
                        <asp:Label id="Label7" runat="server" font-bold="True" Text="REPORTS "
                            width="280px"></asp:Label></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff"></td>
                    <td style="width: 175px; height: 21px; background-color: #8080ff"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                    <td>
                        <asp:CheckBox id="ChkRptMemberSchd" runat="server" Text="Member Accounts Schedule" font-names="Verdana" font-size="Small" /></td>
                    <td>
                        <asp:CheckBox id="chkRptCompnySch" runat="server" Text="Company Portfolio Schedule" font-names="Verdana" font-size="Small" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        &nbsp;</td>
                        <td>
                            <asp:CheckBox id="chkRptMemberAccsAudit" runat="server" Text="Member Accounts Audit Reports" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="chkRptTransBatchSummarySchd" runat="server" Text="Transaction Batch Summary Schedules" font-names="Verdana" font-size="Small" /></td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            <asp:CheckBox id="chkRptOrderSumry" runat="server" Text="Orders Summary Schedules" font-names="Verdana" font-size="Small" /></td>
                            <td>
                                <asp:CheckBox id="chkRptSattlementSummary" runat="server" Text="Sattelments Summary Schedules" font-names="Verdana" font-size="Small" /></td>
                                <td>
                                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 31px;"></td>
                    <td style="height: 31px">
                        <asp:CheckBox id="chkRptCorpSch" runat="server" Text="Corporate Actions Schedules" font-names="Verdana" font-size="Small" /></td>
                    <td style="height: 31px">
                        <asp:CheckBox id="chkRptMemberTrans" runat="server" Text="Member Transactions Movements Reports" font-names="Verdana" font-size="Small" /></td>
                    <td style="height: 31px"></td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        </td>
                        <td>
                            </td>
                            <td>
                                </td>
                                <td>
                                    </td>
                </tr>                              
            </table>
            <table>
                <tr>
                    <td colspan ="4" style="width: 850px" align="center">
                        <asp:Button id="btnSave" runat="server" Text="Update System Permissions" width="240px" /></td>                
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Panel>
</div>
</asp:Content>


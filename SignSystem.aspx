<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SignSystem.aspx.vb" Inherits="_SignSystem" %>
 <%@ Register Src="TimePickerControl.ascx" TagName="Time" TagPrefix="uc1" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    

<head id="Head1" runat="server">
    <title>Central Depository System Log in Panel</title>
    <style type="text/css">
        
        #form1
        {
            height: 432px;
        }
        .style1
        {
            width: 100%;
            height: 428px;
            
        }
        .style2
        {
            width: 78%;
            height: 275px;
            background-image: url('Images/CDS-System_login.png');
            
        }
        .style3
        {
            width: 894px;
        }
        .style4
        {
            width: 324px;
        }
        .style5
        {
            height: 40px;
        }
        .style6
        {
            width: 324px;
            height: 40px;
        }
        .style7
        {
            height: 99px;
        }
        .style8
        {
            width: 324px;
            height: 99px;
        }
        .style9
        {
            height: 134px;
        }
        .style10
        {
            width: 894px;
            height: 134px;
        }
        .Body 
        {
        background-color:Black ;        	         
        	}
        .Art
        {
        	font :Algerian;
        	font-size :small;
        	color:Blue;
        	}
       
         
    </style>
   <script language="JavaScript">
<!--

function startclock()
{
var thetime=new Date();

var nhours=thetime.getHours();
var nmins=thetime.getMinutes();
var nsecn=thetime.getSeconds();
var nday=thetime.getDay();
var nmonth=thetime.getMonth();
var ntoday=thetime.getDate();
var nyear=thetime.getYear();
var AorP=" ";

if (nhours>=12)
    AorP="P.M.";
else
    AorP="A.M.";

if (nhours>=13)
    nhours-=12;

if (nhours==0)
   nhours=12;

if (nsecn<10)
 nsecn="0"+nsecn;

if (nmins<10)
 nmins="0"+nmins;

if (nday==0)
  nday="Sunday";
if (nday==1)
  nday="Monday";
if (nday==2)
  nday="Tuesday";
if (nday==3)
  nday="Wednesday";
if (nday==4)
  nday="Thursday";
if (nday==5)
  nday="Friday";
if (nday==6)
  nday="Saturday";

nmonth+=1;

if (nyear<=99)
  nyear= "19"+nyear;

if ((nyear>99) && (nyear<2000))
 nyear+=1900;

document.clockform.clockspot.value=nhours+": "+nmins+": "+nsecn+" "+AorP+" "+nday+", "+nmonth+"/"+ntoday+"/"+nyear;

setTimeout('startclock()',1000);

} 

//-->
</script>
</head>
<body>

<FORM name="clockform">
<center>
<INPUT TYPE="text"  class ="Art" name="clockspot" size="40" readonly="readonly" 
        style="height: 31px; width: 241px">
</center>
</FORM>
<SCRIPT language="JavaScript">
<!--
startclock();
//-->
</SCRIPT>
<center>
<table>
 
<tr align="center"> 
    <td align ="center">
        <form id="form1" class="body" runat="server">
    <table class="style1">
        <tr>
            <td class="style9">
                </td>
            <td class="style10">
                </td>
            <td class="style9">
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td valign="middle" align="center" class="style3" >
                <table class="style2">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style7">
                            </td>
                        <td class="style8">
                            </td>
                        <td class="style7">
                            </td>
                        <td class="style7">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style4">
                            <asp:DropDownList id="cmbOrg" runat="server" Visible="False" width="152px">
                            </asp:DropDownList>
                        </td>
                        <td valign="top" align="left" colspan="2" rowspan="2">
                            <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" 
                                Text="Username"></asp:Label>
&nbsp;&nbsp;&nbsp;
                            <asp:TextBox id="txtUserId" runat="server" width="144px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label id="Label3" runat="server" font-names="Verdana" font-size="Small" 
                                Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox id="txtPassword" runat="server" TextMode="Password" width="144px"></asp:TextBox>
                            <br />
                            <asp:Label id="Label1" runat="server" font-names="Verdana" font-size="Small" 
                                Text="User name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox id="txtChangeUsername" runat="server" width="144px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label id="Label6" runat="server" font-names="Verdana" font-size="Small" 
                                Text="Old Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox id="txtoldPass" runat="server" TextMode="Password" width="144px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label id="Label7" runat="server" font-names="Verdana" font-size="Small" 
                                Text="New Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox id="txtNewPass" runat="server" TextMode="Password" width="144px"></asp:TextBox>
                            <br />
                            <asp:Button id="btnChange" runat="server" backcolor="White" 
                                BorderColor="#095482" BorderStyle="Solid" BorderWidth="4px" forecolor="#094C78" 
                                Text="Update" />
                            <br />
                            
                            
&nbsp;<asp:Label id="lblChances" runat="server" font-bold="False" font-names="Arial" font-size="Small" 
                                forecolor="Red"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button id="btnSignIn" runat="server" backcolor="White" 
                                BorderColor="#095482" BorderStyle="Solid" BorderWidth="4px" forecolor="#094C78" 
                                Text="Sign in" />
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            </td>
                        <td class="style6">
                            <asp:Label id="Label4" runat="server"></asp:Label>
                            </td>
                    </tr>
                    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style3">
<%--                <form name="clockform">
<input type="text" name="clockspot" size="40">
</form>
<script language="JavaScript">
<!--
startclock();
//-->
</script>
--%><asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
                            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td align="center">
                <asp:Label ID="lblEvent" runat="server" 
                    style="font-family: 'Cambria Math'; color: #FF0000"></asp:Label></td>
            <td></td>
        </tr>
    </table> 
        </form>    
    </td>
</tr>

</table>
 </center>
    </body>
</html>
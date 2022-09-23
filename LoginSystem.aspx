<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginSystem.aspx.vb" Inherits="_LoginSystem" %>
 <%@ Register Src="TimePickerControl.ascx" TagName="Time" TagPrefix="uc1" %> 
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    
    
<head id="Head1" runat="server">
    <title>C-Trade Custodial System</title>
        <script type="text/javascript"
      src="https://code.jquery.com/jquery-3.2.1.js"
      integrity="sha256-DZAnKJ/6XZ9si04Hgrsxu/8s717jcIzLy3oi35EouyE="
      crossorigin="anonymous">
        
      </script>

<script type = "text/javascript" >

    function preventBack() { window.history.forward(); }

    setTimeout("preventBack()", 0);

    window.onunload = function () { null };

</script>

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
            background-repeat:no-repeat;
        }
        .style3
        {
            width: 894px;
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
       
         
        .auto-style1 {
            height: 36px;
        }
       
         
        .auto-style11 {
            width: 223px;
        }
        .auto-style15 {
            height: 36px;
            width: 223px;
        }
        .auto-style16 {
            height: 112px;
            width: 223px;
        }
        .auto-style17 {
            height: 112px;
        }
        .auto-style18 {
            height: 112px;
            width: 116px;
        }
        .auto-style19 {
            width: 116px;
        }
        .auto-style20 {
            height: 36px;
            width: 116px;
        }
        .auto-style21 {
            width: 223px;
            height: 8px;
        }
        .auto-style22 {
            width: 116px;
            height: 8px;
        }
        .auto-style23 {
            height: 8px;
        }
       
         
    </style>
   <script language="JavaScript">
<!--

    function startclock() {
        var thetime = new Date();

        var nhours = thetime.getHours();
        var nmins = thetime.getMinutes();
        var nsecn = thetime.getSeconds();
        var nday = thetime.getDay();
        var nmonth = thetime.getMonth();
        var ntoday = thetime.getDate();
        var nyear = thetime.getYear();
        var AorP = " ";

        //if (nhours >= 12)
        //    AorP = "P.M.";
        //else
        //    AorP = "A.M.";

        //if (nhours >= 13)
        //    nhours -= 12;

        //if (nhours == 0)
        //    nhours = 12;

        if (nsecn < 10)
            nsecn = "0" + nsecn;

        if (nmins < 10)
            nmins = "0" + nmins;

        if (nday == 0)
            nday = "Sunday";
        if (nday == 1)
            nday = "Monday";
        if (nday == 2)
            nday = "Tuesday";
        if (nday == 3)
            nday = "Wednesday";
        if (nday == 4)
            nday = "Thursday";
        if (nday == 5)
            nday = "Friday";
        if (nday == 6)
            nday = "Saturday";

        nmonth += 1;

        if (nyear <= 99)
            nyear = "19" + nyear;

        if ((nyear > 99) && (nyear < 2000))
            nyear += 1900;

        document.clockform.clockspot.value = nhours + ": " + nmins + ": " + nsecn + " " + AorP + " " + nday + ", " + nmonth + "/" + ntoday + "/" + nyear;

        setTimeout('startclock()', 1000);

    }

    //-->
</script>
</head>
<body>

<FORM name="clockform" action="login.cgi" method="post" autocomplete="off" defaultbutton="btnSignIn">
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
<table >

<tr align="center"> 
    <td align ="center">
        <form id="form1" class="body" runat="server">
    <table class="style1" style ="top: 572px;">
        <tr>
            <td class="style9">
                </td>
            <td class="style10">
                         <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" HeaderText="Forgot Password" Theme="Moderno" Width="493px">
                             <HeaderStyle Font-Bold="True" />
                             <contentcollection>
                                 <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                     <table class="dxflInternalEditorTable_Moderno">
                                         <tr>
                                             <td align="right">
                                                 <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="Cambria" Font-Size="Small" Text="Email" Theme="iOS">
                                                 </dx:ASPxLabel>
                                             </td>
                                             <td align="left"> 
                                                 <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" THEME="iOS" Width="276px">
                                                 </dx:ASPxTextBox>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td>&nbsp;</td>
                                             <td>
                                                 <asp:Button ID="btnSignIn0" runat="server" BackColor="White" BorderColor="#095482" BorderStyle="Solid" BorderWidth="4px" ForeColor="#094C78" TabIndex="500" Text="Reset Password" Height="36px" />
                                             </td>
                                         </tr>
                                     </table>
                                 </dx:PopupControlContentControl>
                             </contentcollection>
                         </dx:ASPxPopupControl>
                         <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" HeaderText="Change Password" Theme="Moderno" Width="493px">
                             <HeaderStyle Font-Bold="True" />
                             <contentcollection>
                                 <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                     <table class="dxflInternalEditorTable_Moderno">
                                         <tr>
                                             <td align="right">
                                                 <asp:Label ID="Label6" runat="server" Font-Names="Verdana" Font-Size="Small" Text="Old Password"></asp:Label>
                                             </td>
                                             <td align="left"> 
                                                 <asp:TextBox ID="txtoldPass" runat="server" autocomplete="off" AutoCompleteType="Disabled" TextMode="Password" Width="144px"></asp:TextBox>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="right">
                                                 <asp:Label ID="Label7" runat="server" Font-Names="Verdana" Font-Size="Small" Text="New Password"></asp:Label>
                                             </td>
                                             <td align="left">
                                                 <asp:TextBox ID="txtNewPass" runat="server" autocomplete="off" AutoCompleteType="Disabled" TextMode="Password" Width="144px"></asp:TextBox>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="right">
                                                 <asp:Label ID="Label8" runat="server" Font-Names="Verdana" Font-Size="Small" Text="Confirm Password"></asp:Label>
                                             </td>
                                             <td align="left">
                                                 <asp:TextBox ID="txtconfirmpassword" runat="server" autocomplete="off" AutoCompleteType="Disabled" TextMode="Password" Width="144px"></asp:TextBox>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="right">&nbsp;</td>
                                             <td align="left">
                                                 <asp:Button ID="btnChange" runat="server" BackColor="White" BorderColor="#095482" BorderStyle="Solid" BorderWidth="4px" ForeColor="#094C78" Text="Update" />
                                                 <asp:RequiredFieldValidator ID="req_Pwd" runat="server" ControlToValidate="txtNewPass" Display="None" ErrorMessage="Password is required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="rev_Pwd" runat="server" ControlToValidate="txtNewPass" Display="None" ErrorMessage="Password must contain: Minimum 8 characters at least 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,}" ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword" Display="None" ErrorMessage="Confirm Password is required" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                 <asp:CompareValidator ID="cmpPassword" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPassword" Display="None" ErrorMessage="Password mismatch" ValidationGroup="Submit"></asp:CompareValidator>
                                             </td>
                                         </tr>
                                     </table>
                                 </dx:PopupControlContentControl>
                             </contentcollection>
                         </dx:ASPxPopupControl>
                         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Submit" />
<asp:Label id="lblChances" runat="server" font-bold="False" font-names="Arial" font-size="Small" 
                                forecolor="Red"></asp:Label>
                </td>
            <td class="style9">
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td valign="middle" align="center" class="style3" style=" position:inherit; top:572px;">
                <table class="style2">
                    <tr>
                        <td align="left" class="auto-style16">
                            </td>
                        <td align="left" class="auto-style18">
                            </td>
                        <td align="left" class="auto-style17">

                            </td>
                        <td align="left" class="auto-style17">

                            </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style11">
                            &nbsp;</td>
                        <td align="left" class="auto-style19">
                            <asp:Label ID="lblsess" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label id="Label2" runat="server" font-names="Verdana" font-size="Small" 
                                Text="Username"></asp:Label>

                            
                            </td>
                        <td align="left">

                            <asp:TextBox id="txtUserId" ReadOnly="true" runat="server" width="150px" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                            
                            </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style21">
                            </td>
                        <td align="left" class="auto-style22">
                            </td>
                        <td align="left" class="auto-style23">
                        <asp:Label id="Label3" runat="server" Visible="false" font-names="Verdana" font-size="Small" 
                                Text="Password"></asp:Label>

                            
                            </td>
                        <td align="left" class="auto-style23">
<asp:TextBox id="txtPassword" runat="server" TextMode="Password" Visible="false" width="144px" AutoCompleteType="Disabled" autocomplete="off" ></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style11">
                            </td>
                        <td align="left" class="auto-style19">
                            </td>
                        <td align="left">

                            &nbsp;</td>
                        <td align="left">


                            <asp:Button id="btnSignIn" runat="server" backcolor="White" 
                                BorderColor="#095482" BorderStyle="Solid" BorderWidth="4px" forecolor="#094C78" 
                                Text="Sign in" TabIndex="1" />
                                
                            </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style11">
                            </td>
                        <td align="left" class="auto-style19">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                                
                            <asp:DropDownList id="cmbOrg" runat="server" Visible="False" width="152px">
                            </asp:DropDownList>
                                
                            </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style11">
                            </td>
                        <td align="left" class="auto-style19">
                            </td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">


                            <asp:LinkButton Visible="false" ID="LinkButton1" runat="server">Forgot Password</asp:LinkButton>


                            </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style15">
                            </td>
                        <td align="left" class="auto-style20">
                            </td>
                        <td align="left" class="auto-style1">
                            </td>
                        <td align="left" class="auto-style1">
                        

                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="FileTest" Theme="BlackGlass" Visible="False">
                            </dx:ASPxButton>
                            </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style11">
                            </td>
                        <td align="left" class="auto-style19">
                            </td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                        

                            &nbsp;</td>
                    </tr>
                    
                    </table>
            </td>
            <td>
</td>
        </tr>
        <tr>
            <td>
</td>
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
    <script type="text/javascript">
            $(document).ready(function () {
                var wmi = GetObject("winmgmts:{impersonationLevel=Impersonate}\\\\.\\root\\cimv2");
                var query = "Select * From win32_computersystem";
                e = new Enumerator(wmi.ExecQuery(query));
                var data = e.item();
                alert("UserName is" + data.UserName);
                var username = data.UserName;
                document.foo.engineer.value = username;
                document.foo.engineerName.value = username;
                alert(document.foo.engineer.value);
            });
            </script>
    </body>
</html>
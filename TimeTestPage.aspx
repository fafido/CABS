﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TimeTestPage.aspx.vb" Inherits="TimeTestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD>
<SCRIPT language="JavaScript">
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
</SCRIPT>
</HEAD>

<BODY>

<FORM name="clockform">
Current Time: <INPUT TYPE="text" name="clockspot" size="40">
</FORM>
<SCRIPT language="JavaScript">
<!--
startclock();
//-->
</SCRIPT>

</BODY>
</html>

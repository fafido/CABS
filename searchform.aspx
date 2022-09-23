<%@ Page Language="VB" AutoEventWireup="false" CodeFile="searchform.aspx.vb" Inherits="Custodian_searchform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <style>
input[type=text], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
    border-radius: 25px;
  border: 2px solid #4CAF50;
}

input[type=submit] {
  width: 100%;
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}



div {
  border-radius: 5px;
  background-color: #fff;
  padding: 20px;
}
body {font-family: Arial, Helvetica, sans-serif;}
* {box-sizing: border-box;}

.form-inline {  
  display: flex;
  flex-flow: row wrap;
  align-items: center;
}

.form-inline label {
  margin: 5px 10px 5px 0;
}

.form-inline input {
  vertical-align: middle;
  margin: 5px 10px 5px 0;
  padding: 10px;
  background-color: #fff;
  border: 1px solid #ddd;
}

.form-inline button {
  padding: 10px 20px;
  background-color: dodgerblue;
  border: 1px solid #ddd;
  color: white;
  cursor: pointer;
  margin-top: 50px;
}

.form-inline button:hover {
  background-color: royalblue;
}

@media (max-width: 800px) {
  .form-inline input {
    margin: 10px 0;
  }
  
  .form-inline {
    flex-direction: column;
    align-items: stretch;
  }
}
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 91px;
        }
    </style>
<head runat="server">
    <title> Search  </title>

</head>
<body>
    <form id="form1" runat="server" class="form-inline">
     
        <div style="margin-top: 100px" class="auto-style1"> <center><img src="Images/MOALF.png" class="auto-style2" /></center></div> 
        <div style="margin-top: 100px" class="auto-style1">

        <asp:TextBox  ID="txtid" style="width: 55%; height:55px; margin-left: 367px; margin-right: 7px;" runat="server"  placeholder="Enter Name/Reference (Search for your warehouse receipt)" />
        <asp:Button type="button"  ID="btnView" runat="server"  style="background-color : dimgray; width: 90px;"
                                Text="Search" />
</div>

         
          <div   style="width: 100%; margin-top: 10px ; align-content:center ">
                <asp:GridView ID="grddetails" headerStyle-backcolor="#A9A9A9" style="margin-left: auto; margin-right: auto;" runat="server" HorizontalAlign="center" AutoGenerateColumns="True" EnableModelValidation="True"  Width="100%" >
                                                <AlternatingRowStyle CssClass="altrowstyle" />
                                           
                                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                                <RowStyle CssClass="rowstyle" />
                                            </asp:GridView>
     </div>
    </form>

</body>

</html>

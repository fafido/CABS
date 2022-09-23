<%@ Page Language="VB" AutoEventWireup="false" CodeFile="viewDocument.aspx.vb" Inherits="Credit_viewDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            // PAGE IS FULLY LOADED
            // FADE OUT YOUR OVERLAYING DIV
            $('#overlay').fadeOut();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="overlay">
            <img src="Images/Walking.gif" alt="Loading" />
            Loading...
        </div>
        <div>
        </div>
    </form>
</body>
</html>
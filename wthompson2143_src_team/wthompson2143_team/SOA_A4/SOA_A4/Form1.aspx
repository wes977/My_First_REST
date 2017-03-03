<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="SOA_A4.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crazy Melvin's Shopping Emporium</title>
</head>
<body style="margin-left:15cm;margin-right:15cm" >
    <img src="Resources/SOA_A4_Title.png" alt="title" style="" /><img src="Resources/melvin.png" alt="melvin" style="vertical-align:top" /></center>
    <br />
    <p style="text-align:center">Here at Crazy Melvin's we believe in selling things cheap !! That's why our User Interface is cheap !</p>
    <br />
    <br />
    <br />
    <p style="text-align:center">Use the buttons below to tell me what you'd like to do here at Crazy Melvin's ??</p>
    <br />
    <br />
    <br />
    <form runat="server">

        <asp:ImageButton runat="server" ImageUrl="~/Resources/btnSearch.png" id="btnSearch"   />
        <asp:ImageButton runat="server" ImageUrl="~/Resources/btnInsert.png" id="btnInsert"   />
        <asp:ImageButton runat="server" ImageUrl="~/Resources/btnUpdate.png" id="btnUpdate"   />
        <asp:ImageButton runat="server" ImageUrl="~/Resources/btnDelete.png" id="btnDelete"   />

    </form>
    <br />
    <br />
  
        <a  onclick="closeWin()">
            <img src="Resources/btnExit.png" alt="exit" />
        </a>

    <img src="Resources/loveMelvin.png" alt="loveMelvin" style="vertical-align:bottom;float:right"  />

</body>
</html>

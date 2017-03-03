<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form2.aspx.cs" Inherits="SOA_A4.Form2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body style="margin-left: 10cm; margin-right: 5cm">

    <img src="Resources/SOA_A4_Title.png" alt="title" style="" />
    <img src="Resources/melvin.png" alt="melvin" style="vertical-align: top" />
    <form runat="server" id="inputForm">
        <div runat="server" id="PObox">
        </div>
        <h2>Customer</h2>
        <p>
            custID&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="custIDtxt" type="text" />
            &nbsp;&nbsp;firstName&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="firstNametxt" type="text" />
            &nbsp;&nbsp;lastName&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="lastNametxt" type="text" />
            &nbsp;&nbsp;phoneNumber&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="phoneNumbertxt" type="text" />
            &nbsp;&nbsp;xxx-xxx-xxxx
        </p>
        <br />
        <h2>Product</h2>
        <p>
            prodID&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="prodIDtxt" type="text" />
            &nbsp;&nbsp;prodName&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="prodNametxt" type="text" />
            &nbsp;&nbsp;price&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="pricetxt" type="text" />
            &nbsp;&nbsp;productWeight&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="productWeighttxt" type="text" />
            &nbsp;&nbsp;kg. SOLD OUT&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="KGcb" type="checkbox" />
        </p>
        <br />
        <h2>Order</h2>
        <p>
            orderID&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="orderIDtxt" type="text" />
            &nbsp;&nbsp;custID&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="custIDtxtOrder" type="text" />
            &nbsp;&nbsp;poNumber&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="poNumbertxt" type="text" />
            &nbsp;&nbsp;orderDate&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="orderDatetxt" type="text" />
            &nbsp;&nbsp;MM-DD-YY
        </p>
        <br />
        <h2>Cart</h2>
        <p>
            prodID&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="orderIDtxtCart" type="text" />
            &nbsp;&nbsp;orderID&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="prodIDtxtCart" type="text" />
            &nbsp;&nbsp;quantity&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="quantity" type="text" />
            <label id="Temp">MEOW</label>
        </p>
        <br />
        <p>
            Please generate a Purchase Order (P.O.)&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="generatePO" type="checkbox" />
        </p>
        <div>
            <asp:Label runat="server" ID="errorlbl" ForeColor="Red"></asp:Label>
        </div>
        <asp:ImageButton runat="server" ImageUrl="~/Resources/btnGoBack.png" ID="goBackbtn" />
        <asp:ImageButton runat="server" ImageUrl="~/Resources/btnExecute.png" ID="submitbtn" />


    </form>


    <img src="Resources/btnExit.png" alt="exit" style="padding-right: 1cm" />
    <img src="Resources/loveMelvin.png" alt="loveMelvin" />


</body>
</html>

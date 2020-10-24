<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="PRIMEWeb.Landing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Home</title>
    <link href="/CSS/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        body {
            background-color: #e0e0e0;
            line-height: 1;
        }
        .breadcrumb {
            margin: 10px;
        }
        #frmLanding {
            text-align: center;
        }
        #wrapper {
            height: calc(100vh - 4rem - 20px);
        }
        h1, h4 {
            margin: 2rem 0;
        }
        #wrapper-inner {
            background-color: #fff;
            box-shadow: 2px 2px 10px 3px #a8a8a8;
            padding: 10vh 0;
        }
        .btn {
            margin: 2rem 15px;
            padding: 10px 0;
            width: 130px;
        }
        #btnLogout {
            margin: 0 15px;
        }
    </style>
</head>
<body>
    <form id="frmLanding" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light" aria-label="breadcrumb">
            <a class="navbar-brand">PRIME</a>
            <ol class="collapse navbar-collapse breadcrumb">
                <li class="breadcrumb-item active" aria-current="page">Home</li>
            </ol>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container">
            <div id="wrapper" class="row align-items-center justify-content-sm-center">
                <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                    <h1>Hello <asp:Label ID="lblUser" runat="server" Text="(Name)"></asp:Label></h1>
                    <h4>Let's get started</h4>
                    <asp:Button ID="btnCustomers" runat="server" Text="Customers" CssClass="btn btn-outline-primary rounded-pill" PostBackUrl="/Customers/" />
                    <asp:Button ID="btnSales" runat="server" Text="Sales" CssClass="btn btn-outline-primary rounded-pill" PostBackUrl="/Sales/" />
                    <asp:Button ID="btnInventory" runat="server" Text="Inventory" CssClass="btn btn-outline-primary rounded-pill" PostBackUrl="/Inventory/" />
                    <asp:Button ID="btnEquipment" runat="server" Text="Equipments" CssClass="btn btn-outline-primary rounded-pill" PostBackUrl="/Equipments/" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

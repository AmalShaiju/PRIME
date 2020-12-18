<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteItem.aspx.cs" Inherits="PRIMEWeb.Inventory.DeleteItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Delete Inventory Item</title>
    <link href="/CSS/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        body {
            background-color: #e0e0e0;
            line-height: 1;
        }
        .breadcrumb, #navbar {
            margin: 10px;
        }
        #btnLogout {
            margin: 0 15px;
            padding: 10px 0;
            width: 130px;
        }
        .container {
            background-color: #fff;
            box-shadow: 2px 2px 10px 3px #a8a8a8;
            margin: 15px auto;
            padding: 10px 55px;
        }
        h1 {
            text-align: center;
            padding: 10px 0 20px 0;
        }
        .alert {
            margin-bottom: 25px;
        }
        .tbl {
            padding: 0 15px;
        }
        .table {
            margin: 15px auto 20px auto;
        }
        .table td {
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="frmInvDelete" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light" aria-label="breadcrumb">
            <a class="navbar-brand" href="/Landing.aspx">PRIME</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavDropdown">
                <ul class="navbar-nav" id="navbar">
                    <li class="nav-item">
                        <a class="nav-link" href="/Customers/">Customers</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Sales/">Sales</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Repairs/">Repairs</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Inventory/">Inventory</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Orders/">Orders</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Orders/ArrivedOrderDefaultPage.aspx">Arriving Orders</a>
                    </li>
                </ul>
                <ol class="navbar-collapse breadcrumb">
                    <li class="breadcrumb-item"><a href="/Landing.aspx">Home</a></li>
                    <li class="breadcrumb-item"><a href="/Inventory/">Inventory</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Delete Item</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" OnClick="btnLogout_Click" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <h1>Delete Inventory Item</h1>
            <div class="col-lg-11 alert alert-danger" role="alert">
                <h4 class="alert-heading">Do you really want to delete this item?</h4>
                <hr />
                <p>If you're sure about this, click the "Delete" button.</p>
                <a href="/Inventory/" type="button" class="btn btn-secondary">Cancel</a>
                <asp:Button ID="btnDeleteConfirm" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDeleteConfirm_Click" />
            </div>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <h4>Inventory Item</h4>
            <table class="table">
                <tr>
                    <td class="col-sm-2">Name:</td>
                    <td class="col-sm-4">
                        <asp:Label ID="lblInvName" runat="server"></asp:Label>
                    </td>
                    <td class="col-sm-2">Quantity:</td>
                    <td class="col-sm-4">
                        <asp:Label ID="lblInvQty" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col-sm-2">Size:</td>
                    <td class="col-sm-4">
                        <asp:Label ID="lblInvSize" runat="server"></asp:Label>
                    </td>
                    <td class="col-sm-2">Brand:</td>
                    <td class="col-sm-4">
                        <asp:Label ID="lblInvBrand" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col-sm-2">Price:</td>
                    <td class="col-sm-4">
                        <asp:Label ID="lblInvPrice" runat="server"></asp:Label>
                    </td>
                    <td class="col-sm-2"></td>
                    <td class="col-sm-4"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

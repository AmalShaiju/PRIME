<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="PRIMEWeb.Sales.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Sales Report</title>
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
            padding: 15px;
        }
        h1 {
            text-align: center;
            padding-top: 10px;
        }
        h4 {
            padding-top: 50px;
        }
        .table {
            margin-top: 15px;
        }
        .table td, .table th {
            text-align: center;
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="frmReport" runat="server">
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
                </ul>
                <ol class="navbar-collapse breadcrumb">
                    <li class="breadcrumb-item"><a href="/Landing.aspx">Home</a></li>
                    <li class="breadcrumb-item"><a href="/Sales/">Sales</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Sales Report</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div class="col-lg-9">
                <h1>Weekly Sales Report</h1>
                <h4>Sales completed last week</h4>
                <asp:GridView ID="gvSales" runat="server" CssClass="table" CellPadding="0" GridLines="None" ></asp:GridView>
                <asp:Label ID="lblSales" runat="server"></asp:Label>
                <h4>Total sales broken down</h4>
                <asp:GridView ID="gvBreakDown" runat="server" CssClass="table" CellPadding="0" GridLines="None" ></asp:GridView>
                <h4>Inventory used & Parts Ordered</h4>
                <asp:GridView ID="gvOrdered" runat="server" CssClass="table" CellPadding="0" GridLines="None" ></asp:GridView>
                <asp:Label ID="lblOrdered" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

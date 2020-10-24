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
            padding: 10px 0 50px 0;
        }
        .table {
            margin: 15px auto 50px auto;
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
                        <a class="nav-link" href="/Inventory/">Inventory</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Equipments/">Equipments</a>
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
                <h4>Overall summary of the week's monetary events</h4>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Sale Number</th>
                            <th scope="col">Date</th>
                            <th scope="col">Customer</th>
                            <th scope="col">Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>123</td>
                            <td>2020-01-23</td>
                            <td>Mark Otto</td>
                            <td>Paid</td>
                        </tr>
                        <tr>
                            <td>456</td>
                            <td>2020-10-15</td>
                            <td>Jacob Thornton</td>
                            <td>Unpaid</td>
                        </tr>
                        <tr>
                            <td>789</td>
                            <td>2020-04-13</td>
                            <td>Larry Bird</td>
                            <td>Paid</td>
                        </tr>
                    </tbody>
                </table>
                <h4>Overall summary of the week's monetary events</h4>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Sale Number</th>
                            <th scope="col">Date</th>
                            <th scope="col">Customer</th>
                            <th scope="col">Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>123</td>
                            <td>2020-01-23</td>
                            <td>Mark Otto</td>
                            <td>Paid</td>
                        </tr>
                        <tr>
                            <td>456</td>
                            <td>2020-10-15</td>
                            <td>Jacob Thornton</td>
                            <td>Unpaid</td>
                        </tr>
                        <tr>
                            <td>789</td>
                            <td>2020-04-13</td>
                            <td>Larry Bird</td>
                            <td>Paid</td>
                        </tr>
                    </tbody>
                </table>
                <h4>Overall summary of the week's monetary events</h4>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Sale Number</th>
                            <th scope="col">Date</th>
                            <th scope="col">Customer</th>
                            <th scope="col">Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>123</td>
                            <td>2020-01-23</td>
                            <td>Mark Otto</td>
                            <td>Paid</td>
                        </tr>
                        <tr>
                            <td>456</td>
                            <td>2020-10-15</td>
                            <td>Jacob Thornton</td>
                            <td>Unpaid</td>
                        </tr>
                        <tr>
                            <td>789</td>
                            <td>2020-04-13</td>
                            <td>Larry Bird</td>
                            <td>Paid</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

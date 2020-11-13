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
                    <li class="nav-item">
                        <a class="nav-link" href="/Repairs/">Repairs</a>
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
                            <th scope="col">Order Number</th>
                            <th scope="col">Date</th>
                            <th scope="col">Payment ID</th>
                            <th scope="col">Customer</th>
                            <th scope="col">Employee</th>
                            <th scope="col">Total Amount</th>
                            <th scope="col">Emma's 2%</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>5643739</td>
                            <td>2020-10-20</td>
                            <td>56472</td>
                            <td>John Brown (423545)</td>
                            <td>Whilliam White</td>
                            <td>$150.00</td>
                            <td>$3.00</td>
                        </tr>
                        <tr>
                            <td>9365439</td>
                            <td>2020-10-19</td>
                            <td>56445</td>
                            <td>Weima Black (343667)</td>
                            <td>Jessica Johns</td>
                            <td>$230.00</td>
                            <td>$4.60</td>
                        </tr>
                        <tr>
                            <td>2956349</td>
                            <td>2020-10-20</td>
                            <td>56489</td>
                            <td>David Green (853145)</td>
                            <td>Jeremy Wolt</td>
                            <td>$241.00</td>
                            <td>$4.82</td>
                        </tr>
                    </tbody>
                </table>
                <h4>Total sales broken down</h4>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col"></th>
                            <th scope="col">Total</th>
                            <th scope="col">Amount</th>
                            <th scope="col">Emma's 2%</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Records</td>
                            <td>37</td>
                            <td>$3456.00</td>
                            <td>$69.12</td>
                        </tr>
                        <tr>
                            <td>Repair Records</td>
                            <td>13</td>
                            <td>$1602.00</td>
                            <td>$32.04</td>
                        </tr>
                        <tr>
                            <td>Sale Records</td>
                            <td>14</td>
                            <td>$1854.00</td>
                            <td>$37.08</td>
                        </tr>
                    </tbody>
                </table>
                <h4>Inventory used & Parts Ordered </h4>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Inventory ID</th>
                            <th scope="col">Product Name</th>
                            <th scope="col">Inventory Usage</th>
                            <th scope="col"># Ordered</th>
                            <th scope="col">Amount for Inventory</th>
                            <th scope="col">Amount for the Ordered</th>
                            <th scope="col">Total Amount</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>853457</td>
                            <td>Oil "G37s", 200ml</td>
                            <td>12</td>
                            <td>10</td>
                            <td>$120.00</td>
                            <td>$100.00</td>
                            <td>$220.00</td>
                        </tr>
                        <tr>
                            <td>457875</td>
                            <td>Wheel "Radius", 28 inches</td>
                            <td>4</td>
                            <td>0</td>
                            <td>$120.00</td>
                            <td>$0</td>
                            <td>$120.00</td>
                        </tr>
                        <tr>
                            <td>654321</td>
                            <td>Blade "RT", silver</td>
                            <td>0</td>
                            <td>2</td>
                            <td>$0</td>
                            <td>$170.00</td>
                            <td>$170.00</td>
                        </tr>
                    </tbody>
                </table>
                <h4>Orders (completed, shipping, receiving)</h4>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col"># Orders Placed</th>
                            <th scope="col"># Shipping Orders</th>
                            <th scope="col"># Orders Receiving</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>12</td>
                            <td>5</td>
                            <td>7</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

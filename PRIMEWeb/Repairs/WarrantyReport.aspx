<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarrantyReport.aspx.cs" Inherits="PRIMEWeb.Repairs.WarrantyReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Warranty Report</title>
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
            padding: 10px 0 30px 0;
        }
        h4 {
            padding-top: 30px;
        }
        .table {
            margin: 15px auto 20px auto;
        }
        .table td, .table th {
            text-align: center;
            vertical-align: middle;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
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
                    <li class="breadcrumb-item"><a href="/Repairs/">Repairs</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Warranty Report</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div class="col-lg-9">
                <h1>Warranty Report</h1>
                <button class="btn btn-secondary" type="button" data-toggle="collapse" data-target="#collapseFilter" aria-expanded="false" aria-controls="collapseFilter" aria-label="Filter Entries">
                    Filter Entries
                </button>
                <div class="collapse" id="collapseFilter">
                    <div class="card card-body bg-light">
                        <div class="form-row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">From Date:</label>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">To Date:</label>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Manufacturer:</label>
                                    <asp:DropDownList ID="ddlManufacturer" runat="server" CssClass="form-control">
                                        <asp:ListItem>Manufacturers...</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="divBtnSearch" class="col-md-6 form-group align-self-end">
                                <asp:Button ID="btnSearch" runat="server" aria-label="Apply Filter" CssClass="btn btn-outline-secondary" Text="Apply Filter" />
                                <input id="btnClear" type="reset" value="Clear Filter" class="btn btn-outline-secondary" aria-label="Clear Filter"/>
                            </div>
                        </div>
                    </div>
                </div>
                <h4>Detailed Report</h4>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Manufacturer</th>
                            <th scope="col">Type</th>
                            <th scope="col">Model</th>
                            <th scope="col">Serial</th>
                            <th scope="col">Issue</th>
                            <th scope="col">Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Honda</td>
                            <td>Lawn Mower</td>
                            <td>20in Cordless</td>
                            <td>545482135484</td>
                            <td>Gap spark plug and restring line.</td>
                            <td>$50.00</td>
                        </tr>
                        <tr>
                            <td>Honda</td>
                            <td>Weedeater</td>
                            <td>17-inch 2 stroke</td>
                            <td>5461548513</td>
                            <td>Change oil and sharpen blade.</td>
                            <td>$35.50</td>
                        </tr>
                        <tr>
                            <td>Hitachi</td>
                            <td>Lawn Mower</td>
                            <td>EU1000i</td>
                            <td>1584513215</td>
                            <td>Change oil and air filter.</td>
                            <td>$37.00</td>
                        </tr>
                        <tr>
                            <td>Craftsman</td>
                            <td>Chainsaw</td>
                            <td>DCCS690M1</td>
                            <td>654df5645df</td>
                            <td>Change oil and sharpen blade.</td>
                            <td>$55.50</td>
                        </tr>
                    </tbody>
                </table>
                <h4>Overall Report</h4>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Manufacturer</th>
                            <th scope="col"># Repaired</th>
                            <th scope="col">Total Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>All</td>
                            <td>4</td>
                            <td>$178.00</td>
                        </tr>
                        <tr>
                            <td>Honda</td>
                            <td>2</td>
                            <td>$85.50</td>
                        </tr>
                        <tr>
                            <td>Hitachi</td>
                            <td>1</td>
                            <td>$37.00</td>
                        </tr>
                        <tr>
                            <td>Craftsman</td>
                            <td>1</td>
                            <td>$55.50</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

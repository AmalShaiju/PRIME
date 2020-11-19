<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipments.aspx.cs" Inherits="PRIMEWeb.Customers.Equipments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Equipments</title>
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
            padding: 10px 0;
        }
        #divBtnSearch {
            text-align: right;
            margin-bottom: 1rem;
        }
        #btnClear {
            margin-left: 30px;
        }
        .table {
            margin: 30px auto 0 auto;
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
    <form id="frmSales" runat="server">
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
                    <li class="breadcrumb-item"><a href="/Customers/">Customers</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Equipments</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg">
            <div id="wrapper" class="row justify-content-sm-center">
                <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                    <h1>Equipments</h1>
                    <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-secondary" aria-label="Create New Equipment" Text="Create New Equipment" PostBackUrl="/Customers/NewEquipment.aspx" />
                    <button class="btn btn-secondary" type="button" data-toggle="collapse" data-target="#collapseFilter" aria-expanded="false" aria-controls="collapseFilter" aria-label="Filter Equipments">
                        Filter Equipments
                    </button>
                    <div class="collapse" id="collapseFilter">
                        <div class="card card-body bg-light">
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Model:</label>
                                        <asp:TextBox ID="txtModel" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Serial Number:</label>
                                        <asp:TextBox ID="txtSerialNum" runat="server" CssClass="form-control"></asp:TextBox>
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
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Type:</label>
                                        <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                                            <asp:ListItem>Types...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Customer:</label>
                                        <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control">
                                            <asp:ListItem>Customers...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="divBtnSearch" class="col-md-6 align-self-end">
                                    <asp:Button ID="btnSearch" runat="server" aria-label="Apply Filter" CssClass="btn btn-outline-secondary" Text="Apply Filter" />
                                    <input id="btnClear" type="reset" value="Clear Filter" class="btn btn-outline-secondary" aria-label="Clear Filter"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Model</th>
                                <th scope="col">Serial Number</th>
                                <th scope="col">Manufacturer</th>
                                <th scope="col">Type</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>20in Cordless</td>
                                <td>545482135484</td>
                                <td>Black and Decker</td>
                                <td>Lawn Mower</td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-outline-secondary" aria-label="Equipment Details" Text="Details" />
                                    <asp:Button runat="server" CssClass="btn btn-outline-warning" aria-label="Edit Equipment" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-outline-danger" aria-label="Delete Equipment" Text="Delete" />
                                </td>
                            </tr>
                            <tr>
                                <td>17-inch 2 stroke</td>
                                <td>5461548513</td>
                                <td>Husqvarna</td>
                                <td>Weedeater</td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-outline-secondary" aria-label="Equipment Details" Text="Details" />
                                    <asp:Button runat="server" CssClass="btn btn-outline-warning" aria-label="Edit Equipment" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-outline-danger" aria-label="Delete Equipment" Text="Delete" />
                                </td>
                            </tr>
                            <tr>
                                <td>EU1000i</td>
                                <td>1584513215</td>
                                <td>Honda</td>
                                <td>Generator</td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-outline-secondary" aria-label="Equipment Details" Text="Details" />
                                    <asp:Button runat="server" CssClass="btn btn-outline-warning" aria-label="Edit Equipment" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-outline-danger" aria-label="Delete Equipment" Text="Delete" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

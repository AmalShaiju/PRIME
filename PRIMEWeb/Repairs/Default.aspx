<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PRIMEWeb.Repairs.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Repairs</title>
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
        .form-check-inline {
            margin-right: 2rem;
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
        td .btn {
            width: 80px;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmRepairs" runat="server">
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
                    <li class="breadcrumb-item active" aria-current="page">Repairs</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg">
            <div id="wrapper" class="row justify-content-sm-center">
                <div id="wrapper-inner" class="rounded-lg">
                    <h1>Repairs</h1>
                    <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-secondary" aria-label="Create New Repair" Text="Create New Repair" PostBackUrl="/Repairs/NewRepair.aspx" />
                    <button class="btn btn-secondary" type="button" data-toggle="collapse" data-target="#collapseFilter" aria-expanded="false" aria-controls="collapseFilter" aria-label="Filter Repairs">
                        Filter Repairs
                    </button>
                    <asp:Button ID="btnServices" runat="server" CssClass="btn btn-secondary" aria-label="Services" Text="Services" PostBackUrl="/Repairs/Services.aspx" />
                    <asp:Button ID="btnReport" runat="server" CssClass="btn btn-secondary" aria-label="Warranty Report" Text="Warranty Report" PostBackUrl="/Repairs/WarrantyReport.aspx" />
                    <div class="collapse" id="collapseFilter">
                        <div class="card card-body bg-light">
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Date In:</label>
                                        <asp:TextBox ID="txtDateIn" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Date Out:</label>
                                        <asp:TextBox ID="txtDateOut" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Service:</label>
                                        <asp:DropDownList ID="ddlServices" runat="server" CssClass="form-control">
                                            <asp:ListItem>Services...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Equipment:</label>
                                        <asp:DropDownList ID="ddlEquipments" runat="server" CssClass="form-control">
                                            <asp:ListItem>Equipments...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Employee:</label>
                                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control">
                                            <asp:ListItem>Employees...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Customer:</label>
                                        <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control">
                                            <asp:ListItem>Customers...</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Warranty Status:</label>
                                        <div class="form-control">
                                            <div class="form-check form-check-inline">
                                                <asp:RadioButton ID="radInWarranty" runat="server" CssClass="form-check-input" value="true" GroupName="radStatus" />
                                                <label class="form-check-label" for="radInWarranty">In Warranty</label>
                                            </div>
                                            <div class="form-check form-check-inline">
                                                <asp:RadioButton ID="radNoWarranty" runat="server" CssClass="form-check-input" value="false" GroupName="radStatus" />
                                                <label class="form-check-label" for="radNoWarranty">Not In Warranty</label>
                                            </div>
                                        </div>
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
                                <th scope="col">Date In</th>
                                <th scope="col">Date Out</th>
                                <th scope="col">Issue</th>
                                <th scope="col">In Warranty</th>
                                <th scope="col">Equipment</th>
                                <th scope="col">Employee</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>2020-01-23</td>
                                <td>2020-01-24</td>
                                <td>Change Oil</td>
                                <td>Yes</td>
                                <td>Lawn Mower</td>
                                <td>Mark Otto</td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-info" aria-label="Repair Details" Text="Details" />
                                    <asp:Button runat="server" CssClass="btn btn-dark" aria-label="Edit Repair" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-danger" aria-label="Delete Repair" Text="Delete" />
                                </td>
                            </tr>
                            <tr>
                                <td>2020-10-13</td>
                                <td>2020-10-15</td>
                                <td>Restring line</td>
                                <td>No</td>
                                <td>Weedeater</td>
                                <td>Jacob Thornton</td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-info" aria-label="Repair Details" Text="Details" />
                                    <asp:Button runat="server" CssClass="btn btn-dark" aria-label="Edit Repair" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-danger" aria-label="Delete Repair" Text="Delete" />
                                </td>
                            </tr>
                            <tr>
                                <td>2020-04-13</td>
                                <td>2020-04-13</td>
                                <td>Grease auger</td>
                                <td>Yes</td>
                                <td>Snow Blower</td>
                                <td>Larry Bird</td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-info" aria-label="Repair Details" Text="Details" />
                                    <asp:Button runat="server" CssClass="btn btn-dark" aria-label="Edit Repair" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-danger" aria-label="Delete Repair" Text="Delete" />
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

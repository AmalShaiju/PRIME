<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewSale.aspx.cs" Inherits="PRIMEWeb.Sales.NewSale" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Create New Sale</title>
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
        #wrapper-inner {
            padding: 30px;
        }
        h1 {
            text-align: center;
            padding: 2rem 0;
        }
        .form-row [class*="col-"] {
            padding: 0 15px;
        }
        .form-group {
            margin-bottom: 2rem;
        }
        .form-control, .custom-select {
            border: none;
            border-bottom: 2px solid #6c757d;
            -webkit-box-shadow: none;
            box-shadow: none;
            border-radius: 0;
            height: 45px;
            padding: 0.375rem 0.75rem;
        }
        .form-check-label {
            margin-right: 10px;
        }
        #divBtnSales, #divBtnOrder {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }
        #divBtnSales input, #divBtnSales a, #divBtnOrder input, #divBtnOrder a {
            margin: 0 10px;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmNewSale" runat="server">
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
                        <a class="nav-link" href="/Equipment/">Equipment</a>
                    </li>
                </ul>
                <ol class="navbar-collapse breadcrumb">
                    <li class="breadcrumb-item"><a href="/Landing.aspx">Home</a></li>
                    <li class="breadcrumb-item"><a href="/Sales/">Sales</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Create New Sale</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9">
                <h1>Create New Sale</h1>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="custom-select">
                            <asp:ListItem>Select a Customer...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:DropDownList ID="ddlPayment" runat="server" CssClass="custom-select">
                            <asp:ListItem>Select a Payment method...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date" required="required"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="custom-select">
                            <asp:ListItem>Select an Employee...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <div class="form-control form-check form-check-inline">
                            <label class="form-check-label">Sale Status:</label>
                            <asp:RadioButton ID="radPaid" runat="server" CssClass="form-check-input" value="true" GroupName="radStatus" />
                            <label class="form-check-label" for="radPaid">Paid</label>
                            <asp:RadioButton ID="radUnpaid" runat="server" CssClass="form-check-input" value="false" GroupName="radStatus" required="required" />
                            <label class="form-check-label" for="radUnpaid">Unpaid</label>
                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <div id="divBtnSales" class="col-md-12">
                        <asp:Button ID="btnAddOrder" runat="server" aria-label="Add an Order" CssClass="btn btn-outline-primary" Text="Add an Order" data-toggle="collapse" data-target="#collapseOrder" aria-expanded="false" aria-controls="collapseOrder" />
                        <input type="reset" value="Clear Form" class="btn btn-outline-primary" aria-label="Clear Form"/>
                        <a class="btn btn-outline-primary" href="/Sales/" role="button" aria-label="Cancel Creating Sale">Cancel</a>
                    </div>
                </div>
            </div>
            <div class="collapse col-lg-9" id="collapseOrder">
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:DropDownList ID="ddlProduct" runat="server" CssClass="custom-select" AutoPostBack="True">
                            <asp:ListItem>Select a Product...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" TextMode="Number" placeholder="Quantity" required="required" AutoPostBack="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-12 form-group">
                        <asp:TextBox ID="txtNote" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Notes for this order..."></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Price" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="The number of selected product in stock..." ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div id="divBtnOrder" class="col-md-12">
                        <asp:Button ID="btnCreate" runat="server" aria-label="Create Sale" CssClass="btn btn-outline-primary" Text="Create Sale" PostBackUrl="/Sales/" />
                        <input type="reset" value="Clear Form" class="btn btn-outline-primary" aria-label="Clear Form"/>
                        <a class="btn btn-outline-primary" href="/Sales/" role="button" aria-label="Cancel Creating Sale">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

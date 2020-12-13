                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArrivedOrder.aspx.cs" Inherits="PRIMEWeb.Orders.ArrivedOrder" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>PRIME - Item arrived</title>
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
        #wrapper-inner, #pnlOrder {
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
        #pnlBtnItems{
            text-align: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }
        #pnlBtnItems input, #pnlBtnItems a{
            margin: 0 10px;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmNewItem" runat="server">
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
                    <li class="breadcrumb-item"><a href="/Orders/">Orders</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Order Arrived</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9">
                <h1>Form about arrived Item</h1>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <label class="control-label">Invoice Number:</label>
                        <asp:TextBox ID="txtInvoiceNum" runat="server" CssClass="form-control" TextMode="Number" required="required"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label class="control-label">Arrive Date:</label>
                        <asp:TextBox ID="txtArriveDate" runat="server" CssClass="form-control" TextMode="Date" required="required"></asp:TextBox>
                    </div>
                    <label class="control-label">Select Inventory Item</label>
                    <asp:DropDownList ID="ddlInventoryID" runat="server" CssClass="custom-select">
                                <asp:ListItem>Select an Item...</asp:ListItem>
                        </asp:DropDownList>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <label class="control-label">Number in Order:</label>
                        <asp:TextBox ID="txtNumInOrder" runat="server" CssClass="form-control" TextMode="Number" required="required"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label class="control-label">Price:</label>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                    </div>
                    <label class="control-label">Select Product Order</label>
                    <asp:DropDownList ID="ddlProdOrderID" runat="server" CssClass="custom-select">
                                <asp:ListItem>Select a product order...</asp:ListItem>
                        </asp:DropDownList>
                </div>
               
                <div class="form-row">
                    <asp:Panel ID="pnlBtnItems" CssClass="col-md-12" runat="server">
                        <asp:Button ID="btnAddItem" runat="server" aria-label="Add Info About Arrived Order" CssClass="btn btn-outline-primary" Text="Add the Item" />
                        <input type="reset" value="Clear Form" class="btn btn-outline-primary" aria-label="Clear Form" />
                        <a class="btn btn-outline-primary" href="/Inventory/" role="button" aria-label="Cancel Adding Inventory Item">Cancel</a>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailsArrivedOrder.aspx.cs" Inherits="PRIMEWeb.Orders.DetailsArrivedOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Orders</title>
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

        .flex-box {
            display: flex;
            justify-content: space-around;
            margin-bottom: 50px;
            border: 1px solid #e9e9e9;
        }

        .details {
            padding-left: 60px;
            padding-top: 25px;
        }


        .dark-detail {
            background: #f9fafa;
            width: 50%;
            padding: 45px 50px;
        }

        .light-detail {
            width: 50%;
            padding: 45px 50px;
            border-left: 1px solid #e9e9e9;
        }

        .detail-Items {
            margin-bottom: 85px;
        }

        .detail-Items-1 {
            margin-bottom: 60px;
        }


        input {
            background-color: transparent;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmOrders" runat="server">
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
                    <li class="breadcrumb-item active" aria-current="page">Orders</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg">
            <div id="wrapper" class="row justify-content-sm-center">
                <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                    <h1>
                        <asp:Label ID="lblTitle" runat="server">Order Details</asp:Label></h1>



                    <div class="flex-box">
                        <div class="dark-detail">

                            <div class="detail-Items">
                                <asp:Label runat="server">ID</asp:Label>

                            </div>
                            <div class="detail-Items">
                                <asp:Label runat="server">Invoice Number</asp:Label>

                            </div>
                            <div class="detail-Items">
                                <asp:Label runat="server">Arrive Date</asp:Label>


                            </div>
                            <div class="detail-Items">
                                <asp:Label runat="server">Number in Order</asp:Label>

                            </div>
                            <div class="detail-Items">
                                <asp:Label runat="server">Price</asp:Label>

                            </div>
                            <div class="detail-Items">
                                <asp:Label runat="server">Inventory ID</asp:Label>


                            </div>
                            <div class="detail-Items">
                                <asp:Label runat="server">Product Order ID</asp:Label>


                            </div>




                        </div>
                        <div class="light-detail">
                            <div class="detail-Items-1">

                                <asp:TextBox ID="txtID" runat="server" placeholder="ID" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                            </div>
                            <div class="detail-Items-1">
                                <asp:TextBox ID="txtInvoiceNum" runat="server" placeholder="Invoice Number" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                            </div>
                            <div class="detail-Items-1">
                                <asp:TextBox ID="txtArriveDate" runat="server" placeholder="Arrive Date" CssClass="form-control" ReadOnly="true"></asp:TextBox>


                            </div>
                            <div class="detail-Items-1">
                                <asp:TextBox ID="txtNumInOrder" runat="server" placeholder="Number in Order" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>


                            </div>
                            <div class="detail-Items-1">
                                <asp:TextBox ID="txtPrice" runat="server" placeholder="Price" CssClass="form-control" ReadOnly="true"></asp:TextBox>


                            </div>

                            <div class="detail-Items-1">

                                <asp:TextBox ID="txtInventoryID" runat="server" placeholder="InventoryID" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                            </div>

                            <div class="detail-Items-1">


                                <asp:TextBox ID="txtProdOrderID" runat="server" placeholder="Prouct Order ID" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                <div class="form-row">
                    <div class="col-md-12">
                        <asp:Button ID="btnEdit" runat="server" aria-label="Create Order" CssClass="btn btn-outline-primary" Text="Edit Order" OnClick="btnEdit_Click" />
                        <a class="btn btn-outline-primary" href="/Orders/ArrivedOrderDefaultPage.aspx" role="button" aria-label="Go back to Orders page">Back to Orders</a>
                    </div>
                </div>
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </div>

            </div>
        </div>

    </form>
</body>
</html>

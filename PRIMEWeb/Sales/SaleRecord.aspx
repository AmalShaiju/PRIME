<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleRecord.aspx.cs" Inherits="PRIMEWeb.Sales.SaleRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - <%=lblTitle.Text%></title>
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
    <form id="frmRecord" runat="server">
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
                    <li class="breadcrumb-item active" aria-current="page"><%=lblTitle.Text%></li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" OnClick="btnLogout_Click" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div class="col-lg-11">
                <h1><asp:Label ID="lblTitle" runat="server">Sale Details</asp:Label></h1>
                <asp:Panel ID="pnlDeleteConfirm" runat="server" CssClass="alert alert-danger" role="alert" Visible="False">
                    <h4 class="alert-heading">Do you really want to delete this sale?</h4>
                    <hr />
                    <p>Doing this will also delete all orders and repairs under this sale.</p>
                    <p>Please check out the orders and repairs before doing so.</p>
                    <p>If you're sure about this, click the "Delete" button.</p>
                    <hr />
                    <a href="/Sales/" type="button" class="btn btn-secondary">Cancel</a>
                    <asp:Button ID="btnDeleteConfirm" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDeleteConfirm_Click" />
                </asp:Panel>
                <asp:Panel ID="pnlInfo" runat="server">
                    <div class="form-row">
                        <div class="col-md-6 tbl">
                            <h4>Customer Information</h4>
                            <table class="table">
                                <tr>
                                    <td class="col-sm-4">Name:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblCustName" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">Phone Number:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblCustNo" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">Email:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblCustEmail" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">Address:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblCustAddress" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">City:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblCustCity" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">Postal Code:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblCustPostal" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-md-6 tbl">
                            <h4>Sale Information</h4>
                            <table class="table">
                                <tr>
                                    <td class="col-sm-4">Sale Number:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblSaleNo" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">Date:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblSaleDate" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">Amount Total:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblSaleAmount" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">Sale Status:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblSalePaid" runat="server" Text="N/A"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">Payment Method:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblSalePayment" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-4">Sales Rep:</td>
                                    <td class="col-sm-8">
                                        <asp:Label ID="lblSaleEmp" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="form-row">
                        <h4>
                            <asp:Label ID="lblOrder" runat="server" Text="Order"></asp:Label>
                        </h4>
                        <div class="col-md-12">
                            <asp:GridView ID="gvOrders" CssClass="table" CellPadding="0" GridLines="None" runat="server"></asp:GridView>
                        </div>
                    </div>
                    <div class="form-row">
                        <h4>
                            <asp:Label ID="lblRepairs" runat="server" Text="Repair"></asp:Label>
                        </h4>
                        <asp:GridView ID="gvRepairs" CssClass="table" CellPadding="0" GridLines="None" runat="server"></asp:GridView>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>

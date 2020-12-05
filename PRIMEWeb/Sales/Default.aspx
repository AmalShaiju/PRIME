<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PRIMEWeb.Sales.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Sales</title>
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
        #collapseFilter {
            margin: 5px auto;
        }
        #divBtnSearch {
            text-align: right;
            margin-bottom: 1rem;
        }
        #btnClear {
            margin-left: 30px;
        }
        #upnSales {
            padding-top: 20px;
        }
        .table {
            margin: 5px auto 0 auto;
        }
        .table td, .table th {
            text-align: center;
            vertical-align: middle;
        }
        td .btn {
            width: 70px;
            margin: 0 5px;
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
                    <li class="breadcrumb-item active" aria-current="page">Sales</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg">
            <div id="wrapper" class="row justify-content-sm-center">
                <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                    <h1>Sales</h1>
                    <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-secondary" aria-label="Create New Sale" Text="Create New Sale" PostBackUrl="/Sales/NewSale.aspx" />
                    <button class="btn btn-secondary" type="button" data-toggle="collapse" data-target="#collapseFilter" aria-expanded="false" aria-controls="collapseFilter" aria-label="Filter Sales">
                        Filter Sales
                    </button>
                    <asp:Button ID="btnReport" runat="server" CssClass="btn btn-secondary" aria-label="Sales Report" Text="Sales Report" PostBackUrl="/Sales/Report.aspx" />
                    <div class="collapse" id="collapseFilter">
                        <div class="card card-body bg-light">
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Sale Number:</label>
                                        <asp:TextBox ID="txtSaleNum" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Customer:</label>
                                        <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Date:</label>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Employee:</label>
                                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Sale Status:</label>
                                        <div class="form-control">
                                            <div class="form-check form-check-inline">
                                                <asp:RadioButton ID="radPaid" runat="server" CssClass="form-check-input" value="true" GroupName="radStatus" />
                                                <label class="form-check-label" for="radPaid">Paid</label>
                                            </div>
                                            <div class="form-check form-check-inline">
                                                <asp:RadioButton ID="radUnpaid" runat="server" CssClass="form-check-input" value="false" GroupName="radStatus" />
                                                <label class="form-check-label" for="radUnpaid">Unpaid</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divBtnSearch" class="col-md-6 align-self-end">
                                    <asp:Button ID="btnSearch" runat="server" aria-label="Apply Filter" CssClass="btn btn-outline-secondary" Text="Apply Filter" OnClick="btnSearch_Click" />
                                    <input id="btnClear" type="reset" value="Clear Filter" class="btn btn-outline-secondary" aria-label="Clear Filter"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:ScriptManager ID="smgSales" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upnSales" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblCount" runat="server"></asp:Label>
                            <asp:GridView ID="gvSales" runat="server" CssClass="table" CellPadding="0" GridLines="None" OnRowDataBound="gvSales_RowDataBound"></asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            <asp:PostBackTrigger ControlID="btnDeleteConfirm"/>
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="deleteModalLabel">Delete Sale</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <p>Do you really want to delete this sale?</p>
                                    <p>Doing this will also delete all orders and repairs under this sale.</p>
                                    <p>You can go back to details page to check out the orders and repairs.</p>
                                    <p>If you're sure about this, click the "Delete" button.</p>
                                    <asp:Label ID="lblReceiptID" runat="server" Visible="False"></asp:Label>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                                    <asp:Button ID="btnDeleteConfirm" runat="server" Text="Delete" CssClass="btn btn-danger" data-dismiss="modal" OnClick="btnDeleteConfirm_Click" UseSubmitBehavior="False" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

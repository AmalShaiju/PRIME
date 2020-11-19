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
        h1 {
            text-align: center;
            padding: 1rem 0;
        }
        h4 {
            padding-bottom: 0.5rem;
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
        #txtNote {
            height: 45px;
        }
        #txtPrice {
            margin-bottom: 2rem;
        }
        p {
            margin: 0.5rem 0;
        }
        #lsbOrders {
            height: 40%;
            width: 100%;
        }
        #divBtnOrder {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }
        #divBtnOrder input, #divBtnOrder a {
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
                        <a class="nav-link" href="/Equipments/">Equipments</a>
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
                    <li class="breadcrumb-item active" aria-current="page">Create New Sale</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <h1>Create New Sale</h1>
            <div class="col-lg-9">
                <h4>Sales Information</h4>
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
                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" required="required" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="custom-select">
                            <asp:ListItem>Select an Employee...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <!--div class="form-row">
                    <div class="col-md-6 form-group">
                        <label class="control-label">Sale Status:</label>
                        <div class="form-control form-check form-check-inline">
                            <asp:RadioButton ID="radPaid" runat="server" CssClass="form-check-input" value="true" GroupName="radStatus" />
                            <label class="form-check-label" for="radPaid">Paid</label>
                            <asp:RadioButton ID="radUnpaid" runat="server" CssClass="form-check-input" value="false" GroupName="radStatus" required="required" />
                            <label class="form-check-label" for="radUnpaid">Unpaid</label>
                        </div>
                    </div>
                </!div-->
            </div>
            <asp:ScriptManager ID="smgOrder" runat="server"></asp:ScriptManager>
            <asp:Panel ID="pnlOrder" CssClass="col-lg-9" runat="server">
                <h4>Order Information</h4>
                <div class="form-row">
                    <div class="col-md-6">
                        <asp:UpdatePanel ID="upnOrder" runat="server">
                            <ContentTemplate>
                                <div class="col-md-12 form-group">
                                    <asp:DropDownList ID="ddlProduct" runat="server" CssClass="custom-select" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                        <asp:ListItem>Select a Product...</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-12 form-group">
                                    <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" TextMode="Number" placeholder="Quantity" required="required"></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group">
                                    <asp:TextBox ID="txtNote" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Notes for this order..."></asp:TextBox>
                                </div>
                                <div class="col-md-12 form-group">
                                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Price" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="Number in Stock..." ReadOnly="True"></asp:TextBox>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlProduct" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="lsbOrders" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel ID="upnSavedOrders" class="col-md-6" runat="server">
                        <ContentTemplate>
                            <p>Saved Orders:</p>
                            <asp:ListBox ID="lsbOrders" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lsbOrders_SelectedIndexChanged"></asp:ListBox>
                            <p>Notes:</p>
                            <p>Fill the form and click the Save Order button to save the order and start the next order.</p>
                            <p>Select an saved order and view the details on the left.</p>
                            <p>Select an saved order and click the Delete Order button to delete an saved order.</p>
                            <p>Click the Clear Form button to clear everything in the form, including saved orders.</p>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSaveOrder" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnDeleteOrder" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="form-row">
                    <div id="divBtnOrder" class="col-md-12">
                        <asp:Button ID="btnCreate" runat="server" aria-label="Create Sale" CssClass="btn btn-outline-primary" Text="Create Sale" PostBackUrl="/Sales/" />
                        <asp:Button ID="btnSaveOrder" runat="server" aria-label="Save Order" CssClass="btn btn-outline-primary" Text="Save Order" OnClick="btnSaveOrder_Click" />
                        <asp:Button ID="btnDeleteOrder" runat="server" aria-label="Delete Order" CssClass="btn btn-outline-primary" Text="Delete Order" OnClick="btnDeleteOrder_Click" />
                        <a class="btn btn-outline-primary" href="/Sales/NewSale.aspx" role="button" aria-label="Clear Form">Clear Form</a>
                        <a class="btn btn-outline-primary" href="/Sales/" role="button" aria-label="Cancel Creating Sale">Cancel</a>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

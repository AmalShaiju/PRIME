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
        .lbl-help {
            display: inline-block;
            margin: 5px 0;
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
        p {
            margin: 0.5rem 0;
        }
        #lsbOrders {
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
        #pnlOrdersHelp {
            text-align: center;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
    <script type="text/javascript">
        function setHeight() {
            var divHeight = $("[id$=divProduct]").height() +
                $("[id$=divQty]").height() +
                $("[id$=divNote]").height() +
                $("[id$=divPrice]").height() +
                $("[id$=divStock]").innerHeight();
            var lblHeight = $("[id$=lblOrders]").height();
            var lsbHeight = divHeight - lblHeight;
            document.getElementById("<%=lsbOrders.ClientID%>").style.height = "calc(" + lsbHeight + "px + 7.5rem)";
        }
    </script>
</head>
<body onload="setHeight()">
    <form id="frmNewSale" runat="server" class="was-validated">
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
                    <li class="breadcrumb-item active" aria-current="page">Create New Sale</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <asp:ScriptManager ID="smgOrder" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upnOrder" class="container rounded-lg row justify-content-sm-center" runat="server">
            <ContentTemplate>
                <h1>Create New Sale</h1>
                <div class="col-lg-9">
                    <div class="form-group form-control form-check form-check-inline">
                        <asp:CheckBox ID="cboHelp" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="cboHelp_CheckedChanged" />
                        <label class="form-check-label" for="cboHelp">Check this checkbox to display detailed instruction on this form.</label>
                    </div>
                    <h4>Sales Information</h4>
                    <div class="form-row">
                        <div class="col-md-6 form-group">
                            <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="custom-select" required="required"></asp:DropDownList>
                            <div class="invalid-feedback">Please select the customer</div>
                            <asp:Label ID="lblCustomerHelp" runat="server" Text="Select the customer whom this receipt belongs to." CssClass="lbl-help" Visible="False"></asp:Label>

                        </div>
                        <div class="col-md-6 form-group">
                            <asp:DropDownList ID="ddlPayment" runat="server" CssClass="custom-select" required="required"></asp:DropDownList>
                            <div class="invalid-feedback">Please select the payment method</div>
                            <asp:Label ID="lblPaymentHelp" runat="server" Text="Select the payment used for this receipt." CssClass="lbl-help" Visible="False"></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col-md-6 form-group">
                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" required="required" TextMode="Date"></asp:TextBox>
                            <div class="invalid-feedback">Please select the date</div>
                            <asp:Label ID="lblDateHelp" runat="server" Text="Date of creation for this receipt.<br />Today's date has been automatically filled in." CssClass="lbl-help" Visible="False"></asp:Label>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="custom-select"></asp:DropDownList>
                            <asp:Label ID="lblEmployeeHelp" runat="server" Text="Select the employee who created this receipt." CssClass="lbl-help" Visible="False"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-lg-9">
                    <h4>Order Information</h4>
                    <div class="form-row">
                        <div class="col-md-6">
                            <div id="divProduct" class="form-group">
                                <asp:DropDownList ID="ddlProduct" runat="server" CssClass="custom-select" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" required="required"></asp:DropDownList>
                                <div class="invalid-feedback">Please select the product to order</div>
                                <asp:Label ID="lblProductHelp" runat="server" Text="Select the product to order.<br />After selection you will see the price and number in stock at two fields after. " CssClass="lbl-help" Visible="False"></asp:Label>
                            </div>
                            <div id="divQty" class="form-group">
                                <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" TextMode="Number" min="1" placeholder="Quantity" required="required"></asp:TextBox>
                                <div class="invalid-feedback">Please input a valid quantity</div>
                                <asp:Label ID="lblQtyHelp" runat="server" Text="Input needed quantity.<br />If more than the amount in stock is needed, the order will go to Orders department to fill the margin." CssClass="lbl-help" Visible="False"></asp:Label>
                            </div>
                            <div id="divNote" class="form-group">
                                <asp:TextBox ID="txtNote" runat="server" CssClass="form-control" placeholder="Notes for this order..."></asp:TextBox>
                                <asp:Label ID="lblNoteHelp" runat="server" Text="Input notes for this order." CssClass="lbl-help" Visible="False"></asp:Label>
                            </div>
                            <div id="divPrice" class="form-group">
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Price" ReadOnly="True"></asp:TextBox>
                                <asp:Label ID="lblPriceHelp" runat="server" Text="Price for the product selected.<br />Displayed after product selection." CssClass="lbl-help" Visible="False"></asp:Label>
                            </div>
                            <div id="divStock" class="form-group">
                                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="Number in Stock..." ReadOnly="True"></asp:TextBox>
                                <asp:Label ID="lblStockHelp" runat="server" Text="The amount of product selected in stock.<br />Displayed after product selection." CssClass="lbl-help" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label id="lblOrders" class="control-label">Saved Orders:</label>
                            <asp:ListBox ID="lsbOrders" runat="server"></asp:ListBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div id="divBtnOrder" class="col-md-12">
                            <asp:Button ID="btnCreate" runat="server" aria-label="Create Sale" CssClass="btn btn-outline-primary" Text="Create Sale" UseSubmitBehavior="False" OnClick="btnCreate_Click"/>
                            <asp:Button ID="btnAddOrder" runat="server" aria-label="Add Order" CssClass="btn btn-outline-primary" Text="Add Order" OnClick="btnAddOrder_Click" />
                            <asp:Button ID="btnDeleteOrder" runat="server" aria-label="Delete Order" CssClass="btn btn-outline-primary" Text="Delete Order" OnClick="btnDeleteOrder_Click" UseSubmitBehavior="False" />
                            <asp:Button ID="btnClearOrder" runat="server" aria-label="Clear Order Form" CssClass="btn btn-outline-primary" Text="Clear Order Form" UseSubmitBehavior="False" OnClick="btnClearOrder_Click" />
                            <a class="btn btn-outline-primary" href="/Sales/" role="button" aria-label="Cancel Creating Sale">Cancel</a>
                        </div>
                    </div>
                    <asp:Panel ID="pnlOrdersHelp" runat="server" Visible="False">
                        <p>Notes:</p>
                        <p>Fill the order form and click the Save Order button to save the order and start the next order.</p>
                        <p>Select an saved order and view the details in the order form.</p>
                        <p>Select an saved order and click the Delete Order button to delete an saved order.</p>
                        <p>Click the Clear Order Form button to clear the product selection and the quantity.</p>
                    </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cboHelp" EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlProduct" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnCreate" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAddOrder" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDeleteOrder" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClearOrder" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>

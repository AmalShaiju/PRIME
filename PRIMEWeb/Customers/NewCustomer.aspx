<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCustomer.aspx.cs" Inherits="PRIMEWeb.Customers.NewCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Create New Customer</title>
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
        .form-row .col-md-6 {
            padding: 0 15px;
        }
        .form-group {
            margin-bottom: 3rem;
        }
        .lbl-help {
            display: inline-block;
            margin: 5px 0;
        }
        .form-control {
            border: none;
            border-bottom: 2px solid #6c757d;
            -webkit-box-shadow: none;
            box-shadow: none;
            border-radius: 0;
            height: 45px;
        }
        .col-md-12 {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }
        .col-md-12 input, .col-md-12 a {
            margin: 0 10px;
        }
    </style>
</head>
<body>
    <form id="frmNewCust" runat="server" class="was-validated">
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
                    <li class="breadcrumb-item active" aria-current="page">Create New Customer</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center" style="height: 1086px">
            <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                <h1>Create New Customer</h1>
                <div class="form-group form-control form-check form-check-inline">
                    <asp:CheckBox ID="cboHelp" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="cboHelp_CheckedChanged" />
                    <label class="form-check-label" for="cboHelp">Check this to display detailed instruction on this form.</label>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">First</asp:Label>
                        <asp:TextBox ID="txtFName" runat="server" placeholder="Eg. John" CssClass="form-control" required="required"></asp:TextBox>
                        <%--<div class="invalid-feedback">Please input first name</div>--%>
                        <asp:Label ID="lblFirstlHelp" runat="server" Text="Input the customer's first name (Eg. John)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Last</asp:Label>
                        <asp:TextBox ID="txtLName" runat="server" placeholder="Eg. Smith" CssClass="form-control" required="required"></asp:TextBox>
                        <%--<div class="invalid-feedback">Please input last name</div>--%>
                        <asp:Label ID="lblLastHelp" runat="server" Text="Input the customer's last name (Eg. Smith)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Phone</asp:Label>
                        <asp:TextBox ID="txtPhone" runat="server" placeholder="Eg. 2897771414" CssClass="form-control" TextMode="Phone" required="required"></asp:TextBox>
                        <%--<div class="invalid-feedback">Please input phone number. 10 digits without +1 or spaces</div>--%>
                        <asp:Label ID="lblPhoneHelp" runat="server" Text="Input the customer's phone number. 10 digits without +1 or spaces (Eg. 2897771414)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Email</asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Eg. email@gmail.com" CssClass="form-control" required="required"></asp:TextBox>
                        <%--<div class="invalid-feedback">Please input email address</div>--%>
                        <asp:Label ID="lblEmailHelp" runat="server" Text="Input the customer's email address (Eg. email@gmail.com)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Address</asp:Label>
                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Eg. 123 Real Street" CssClass="form-control" required="required"></asp:TextBox>
                        <%--<div class="invalid-feedback">Please input address</div>--%>
                        <asp:Label ID="lblAddressHelp" runat="server" Text="Input the customer's address (Eg. 123 Real Street)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">City</asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" placeholder="Eg. Welland" CssClass="form-control" required="required"></asp:TextBox>
                        <%--<div class="invalid-feedback">Please input city</div>--%>
                        <asp:Label ID="lblCityHelp" runat="server" Text="Input the city customer lives in(Eg. Welland)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Postal</asp:Label>
                        <asp:TextBox ID="txtPCode" runat="server" placeholder="Eg. L3C7H2" CssClass="form-control" required="required"></asp:TextBox>
                        <%--<div class="invalid-feedback">Please input postal code. 6 characters, no spaces</div>--%>
                        <asp:Label ID="lblPostalHelp" runat="server" Text="Input the customer's postal code. 6 characters, no spaces (Eg. L3C7H2)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <br />  
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                <div class="form-row">
                    <div class="col-md-12">
                        <asp:Button ID="btnCreate" runat="server" aria-label="Create Customer" CssClass="btn btn-outline-primary" Text="Create Customer" OnClick="btnCreate_Click" />
                        <input type="reset" value="Clear Form" class="btn btn-outline-primary" aria-label="Clear Form"/>
                        <a class="btn btn-outline-primary" href="/Customers/" role="button" aria-label="Cancel Creating Customer">Cancel</a>
                    </div>
                </div>
                <asp:Panel ID="pnlCustomerHelp" runat="server" Visible="False">
                        <p>Notes:</p>
                        <p>Fill the customer form and click the "Create Customer" button to add the customer record to the database and start creating a new customer.</p>
                        <p>Click the "Clear Form" button to remove all the text from textboxes.</p>
                        <p>Click the "Cancel" button to cancel creating the customer and go to the Customer page.</p>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>

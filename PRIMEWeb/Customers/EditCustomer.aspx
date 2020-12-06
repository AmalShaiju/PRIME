<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="PRIMEWeb.Customers.EditCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Edit Customer</title>
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
            margin-bottom: 2rem;
        }
        .form-control {
            border: none;
            border-bottom: 2px solid #6c757d;
            -webkit-box-shadow: none;
            box-shadow: none;
            border-radius: 0;
            height: 45px;
            margin-top: 5px;
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
    <form id="frmEditCust" runat="server">
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
                    <li class="breadcrumb-item active" aria-current="page">Edit Customer</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                <h1>Edit Customer</h1>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">ID</asp:Label>
                        <asp:TextBox ID="txtID" runat="server" placeholder="ID" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">First</asp:Label>
                        <asp:TextBox ID="txtFName" runat="server" placeholder="Eg. John" CssClass="form-control" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Last</asp:Label>
                        <asp:TextBox ID="txtLName" runat="server" placeholder="Eg. Smith" CssClass="form-control" required="required"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Phone</asp:Label>
                        <asp:TextBox ID="txtPhone" runat="server" placeholder="Eg. 2897774433" CssClass="form-control" TextMode="Phone" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Email</asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Eg. email@gmail.com" CssClass="form-control" required="required"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Address</asp:Label>
                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Eg. 123 Real Street" CssClass="form-control" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">City</asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" placeholder="Eg. Welland" CssClass="form-control" required="required"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Postal</asp:Label>
                        <asp:TextBox ID="txtPCode" runat="server" placeholder="Eg. L3C7H2" CssClass="form-control" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-12">
                        <asp:Button ID="btnUpdate" runat="server" aria-label="Update Customer" CssClass="btn btn-outline-primary" Text="Update Customer" OnClick="btnUpdate_Click"/>
                        &nbsp;<a class="btn btn-outline-primary" href="/Customers/" role="button" aria-label="Cancel Editing Customer">Cancel</a>
                    </div>
                </div>
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

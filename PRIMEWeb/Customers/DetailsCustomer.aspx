<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailsCustomer.aspx.cs" Inherits="PRIMEWeb.Customers.DetailsCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Customer Details</title>
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
            margin-top:5px;
        }
        .col-md-12 {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }
        .col-md-12 input, .col-md-12 a {
            margin: 0 10px;
        }
        nav{
            border:solid 1px #000;
        }
    </style>
    <link href="/CSS/wcag.css" rel="stylesheet" />
    <script src="/Script/wcag.js"></script>
</head>
<body>
    <form id="frmDetailsCust" runat="server">
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
                    <li class="breadcrumb-item active" aria-current="page">Customer Details</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                <h1><asp:Label ID="lblTitle" runat="server">Sale Details</asp:Label></h1>
                <asp:Panel ID="pnlDeleteConfirm" runat="server" CssClass="alert alert-danger" role="alert" Visible="False">
                    <h4 class="alert-heading">Do you really want to delete this customer?</h4>
                    <hr />
                    <p>You will not be allowed to delete the customer if he has been assigned to the equipment.</p>
                    <p>Please check out the equipment page and delete the equipment record before doing so.</p>
                    <p>Click the "Delete" button.</p>
                    <hr />
                    <a href="/Customers/Default.aspx" type="button" class="btn btn-secondary">Cancel</a>
                    <asp:Button ID="btnDeleteConfirm" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDeleteConfirm_Click" />
                </asp:Panel>
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                <br />
                <div class="form-group form-control form-check form-check-inline">
                    &nbsp;
                    <input type="checkbox" onclick="SwitchCss(this)" class="form-check-input" id="chbSwitch" name="cnbSwitch" />
                    <label class="form-check-label" for="cnbSwitch">Check this to switch to high contrast design.</label>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label runat="server">ID</asp:Label>
                        <asp:TextBox ID="txtID" runat="server" placeholder="ID" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label runat="server">First</asp:Label>
                        <asp:TextBox ID="txtFName" runat="server" placeholder="First Name" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label runat="server">Last</asp:Label>
                        <asp:TextBox ID="txtLName" runat="server" placeholder="Last Name" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label runat="server">Phone</asp:Label>
                        <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone Number" CssClass="form-control" TextMode="Phone" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label runat="server">Email</asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label runat="server">Address</asp:Label>
                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label runat="server">City</asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" placeholder="City" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label runat="server">Postal</asp:Label>
                        <asp:TextBox ID="txtPCode" runat="server" placeholder="Postal Code" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-12">
                        <asp:Button ID="btnEdit" runat="server" aria-label="Create Customer" CssClass="btn btn-outline-primary" Text="Edit Customer" OnClick="btnEdit_Click" />
                        <a class="btn btn-outline-primary" href="/Customers/" role="button" aria-label="Go back to Customer page">Back to Customers</a>
                    </div>
                </div>
                
            </div>
        </div>
    </form>
</body>
</html>


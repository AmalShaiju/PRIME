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
        label {
            width: 100%;
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
        #btnLogout.btn-logout-high {
            color: #fff;
            background-color: #DC3545;
            border-color: #DC3545;
        }
        #btnLogout.btn-logout-high:hover {
            color: #fff;
            background-color: #C72334;
            border-color: #C72334;
        }
    </style>
    <link href="/CSS/wcag.css" rel="stylesheet" />
     <script>
         function SwitchCss(element) {
             var btnDangers = document.getElementsByClassName("btn-danger");
             var btnInfos = document.getElementsByClassName("btn-info");
             var btnInfos = document.getElementsByClassName("btn-info");
             var btnSearch = document.getElementById("btnSearch");
             var btnFilter = document.getElementById("btnFilter");
             var btnCreate = document.getElementById("btnCreate");
             var btnClear = document.getElementById("btnClear");
             var btnLogOut = document.getElementById("btnLogout");
             var btnDependents = document.getElementsByClassName("btn btn-secondary btn-dependent-page");
             var body = document.getElementsByTagName("body");
             var navigation = document.getElementsByTagName("nav");
             var ol = document.getElementsByTagName("ol");
             var container = document.getElementsByClassName("container");
             var table = document.getElementsByClassName("table");

             if (element.checked) {
                 btnLogOut.classList.add("btn-logout-high");
                 for (var i = 0; i < btnDangers.length; i++) {
                     btnDangers[i].classList.add("btn-danger-high");
                 }

                 for (var i = 0; i < btnInfos.length; i++) {
                     btnInfos[i].classList.add("btn-info-high");
                 }

                 for (var i = 0; i < btnDependents.length; i++) {
                     btnDependents[i].classList.add("btn-dependent-high");
                 }

                 for (var i = 0; i < body.length; i++) {
                     body[i].classList.add("body-high");
                 }

                 for (var i = 0; i < navigation.length; i++) {
                     navigation[i].classList.add("nav-high");
                 }

                 for (var i = 0; i < ol.length; i++) {
                     ol[i].classList.add("border-high");
                 }

                 for (var i = 0; i < container.length; i++) {
                     container[i].classList.add("border-high");
                 }

                 for (var i = 0; i < table.length; i++) {
                     table[i].classList.add("table-high");
                 }

                 btnSearch.classList.add("btn-search-high");
                 btnFilter.classList.add("btn-search-high");
                 btnCreate.classList.add("btn-create-high");
                 btnClear.classList.add("btn-clear-high");

             }
             else {
                 btnLogOut.classList.remove("btn-logout-high");
                 for (var i = 0; i < btnDangers.length; i++) {
                     btnDangers[i].classList.remove("btn-danger-high");
                 }

                 for (var i = 0; i < btnInfos.length; i++) {
                     btnInfos[i].classList.remove("btn-info-high");
                 }

                 for (var i = 0; i < btnDependents.length; i++) {
                     btnDependents[i].classList.remove("btn-dependent-high");
                 }

                 for (var i = 0; i < body.length; i++) {
                     body[i].classList.remove("body-high");
                 }

                 for (var i = 0; i < navigation.length; i++) {
                     navigation[i].classList.remove("nav-high");
                 }

                 for (var i = 0; i < ol.length; i++) {
                     ol[i].classList.remove("border-high");
                 }

                 for (var i = 0; i < container.length; i++) {
                     container[i].classList.remove("border-high");
                 }

                 for (var i = 0; i < table.length; i++) {
                     table[i].classList.remove("table-high");
                 }

                 btnSearch.classList.remove("btn-search-high");
                 btnFilter.classList.remove("btn-search-high");
                 btnCreate.classList.remove("btn-create-high");
                 btnClear.classList.remove("btn-clear-high");

             }
         }
     </script> 
    <%--<script src="/Script/wcag.js"></script>--%>
</head>
<body>
    <form id="frmEditCust" runat="server"  class="was-validated">
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
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" OnClick="btnLogout_Click" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                <h1>Edit Customer</h1>
                <div class="form-group form-control form-check form-check-inline">
                    &nbsp;
                    <input type="checkbox" onclick="SwitchCss(this)" class="form-check-input" id="chbSwitch" name="cnbSwitch" />
                    <label class="form-check-label" for="cnbSwitch">Check this to switch to high contrast design</label>
                    &nbsp;&nbsp;|&nbsp;&nbsp;
                    <asp:CheckBox ID="cboHelp" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="cboHelp_CheckedChanged" />
                    <label class="form-check-label" for="cboHelp">Check this to display detailed instruction on this form</label>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">ID</asp:Label>
                        <asp:TextBox ID="txtID" runat="server" placeholder="ID" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lblIdHelp" runat="server" Text="The customer's ID. It was automatically generated by the system. You cannot edit it" CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">First</asp:Label>
                        <asp:TextBox ID="txtFName" runat="server" placeholder="Eg. John" CssClass="form-control" required="required"></asp:TextBox>
                        <div class="invalid-feedback">Please input first name</div>
                        <asp:Label ID="lblFirstlHelp" runat="server" Text="Input the customer's first name (Eg. John)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Last</asp:Label>
                        <asp:TextBox ID="txtLName" runat="server" placeholder="Eg. Smith" CssClass="form-control" required="required"></asp:TextBox>
                        <div class="invalid-feedback">Please input last name</div>
                        <asp:Label ID="lblLastHelp" runat="server" Text="Input the customer's last name (Eg. Smith)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Phone</asp:Label>
                        <asp:TextBox ID="txtPhone" runat="server" placeholder="Eg. 2897774433" CssClass="form-control" TextMode="Phone" required="required"></asp:TextBox>
                        <div class="invalid-feedback">Please input phone number. 10 digits without +1 or spaces</div>
                        <asp:Label ID="lblPhoneHelp" runat="server" Text="Input the customer's phone number. 10 digits without +1 or spaces (Eg. 2897771414)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Email</asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Eg. email@gmail.com" CssClass="form-control" required="required"></asp:TextBox>
                        <div class="invalid-feedback">Please input email address</div>
                        <asp:Label ID="lblEmailHelp" runat="server" Text="Input the customer's email address (Eg. email@gmail.com)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Address</asp:Label>
                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Eg. 123 Real Street" CssClass="form-control" required="required"></asp:TextBox>
                        <div class="invalid-feedback">Please input address</div>
                        <asp:Label ID="lblAddressHelp" runat="server" Text="Input the customer's address (Eg. 123 Real Street)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">City</asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" placeholder="Eg. Welland" CssClass="form-control" required="required"></asp:TextBox>
                        <div class="invalid-feedback">Please input city</div>
                        <asp:Label ID="lblCityHelp" runat="server" Text="Input the city customer lives in(Eg. Welland)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Postal</asp:Label>
                        <asp:TextBox ID="txtPCode" runat="server" placeholder="Eg. L3C7H2" CssClass="form-control" required="required"></asp:TextBox>
                        <div class="invalid-feedback">Please input postal code. 6 characters, no spaces</div>
                        <asp:Label ID="lblPostalHelp" runat="server" Text="Input the customer's postal code. 6 characters, no spaces (Eg. L3C7H2)." CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <br />
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                <div class="form-row">
                    <div class="col-md-12">
                        <asp:Button ID="btnCreate" runat="server" aria-label="Update Customer" CssClass="btn btn-outline-primary" Text="Update Customer" OnClick="btnUpdate_Click"/>
                        &nbsp;<a class="btn btn-danger" href="/Customers/" role="button" aria-label="Cancel Editing Customer">Cancel</a>
                    </div>
                </div>
                <asp:Panel ID="pnlCustomerHelp" runat="server" Visible="False">
                        <p>Notes:</p>
                        <p>Edit the fields you want to update and click the "Update Customer" button to apply changes to the database.</p>
                        <p>You will be notified of the success or failure of the operation</p>
                        <p>Click the "Cancel" button to cancel editing the customer and go to the Customer page.</p>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>

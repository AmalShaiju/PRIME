<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewProduct.aspx.cs" Inherits="PRIMEWeb.Inventory.NewProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>PRIME - Add New Product</title>
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
        #lblMessage {
            display: block;
            margin-bottom: 10px;
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
        #help{
            width:90%;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
    <link href="/CSS/wcag.css" rel="stylesheet" />
    <script src="/Script/wcag.js"></script>
</head>
<body>
    <form id="frmNewProd" runat="server"  class="was-validated">
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
                </ul>
                <ol class="navbar-collapse breadcrumb">
                    <li class="breadcrumb-item"><a href="/Landing.aspx">Home</a></li>
                    <li class="breadcrumb-item"><a href="/Inventory/">Inventory</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Add New Product</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" OnClick="btnLogout_Click" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                <h1>Create New Product</h1>
                <div class="form-group form-control form-check form-check-inline">
                    <input type="checkbox" onclick="SwitchCss(this)" class="form-check-input" id="cboSwitch" name="cboSwitch" />
                    <label class="form-check-label" for="cboSwitch">Check this to switch to high contrast design</label>
                    &nbsp;&nbsp;|&nbsp;&nbsp;
                    <asp:CheckBox ID="cboHelp" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="cboHelp_CheckedChanged" />
                    <label class="form-check-label" for="cboHelp">Check this to display detailed instruction on this form</label>
                </div>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:ObjectDataSource ID="dsBrands" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.InventoryDataSetTableAdapters.BrandLookUpTableAdapter"></asp:ObjectDataSource>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <label class="control-label">Product:</label>
                        <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                        <div class="invalid-feedback">Please input product name</div>
                        <asp:Label ID="lblIdHelp" runat="server" Text="Input the product name" CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                    <div class="col-md-6 form-group">
                        <label class="control-label">Brand:</label>
                        <asp:DropDownList ID="ddlBrand" CssClass="custom-select" runat="server" DataSourceID="dsBrands" DataTextField="prodBrand" DataValueField="prodBrand" required="required">
                        </asp:DropDownList>
                        <div class="invalid-feedback">Please select the product brand</div>
                        <asp:Label ID="lblBrandHelp" runat="server" Text="Please select the product brand" CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <label class="control-label">Description:</label>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                        <div class="invalid-feedback">Please input product description</div>
                        <asp:Label ID="lblDescHelp" runat="server" Text="Input the product description" CssClass="lbl-help" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-row">
                    <asp:Panel ID="pnlBtnItems" CssClass="col-md-12" runat="server">
                        <asp:Button ID="btnCreate" runat="server" aria-label="Add the Inventory Item" CssClass="btn btn-outline-primary" Text="Add the Item" OnClick="btnAddItem_Click" />
                        <input id="btnClear" type="reset" value="Clear Form" class="btn btn-outline-primary" aria-label="Clear Form" />
                        <a class="btn btn-danger" href="/Inventory/" role="button" aria-label="Cancel Adding Inventory Item">Cancel</a>
                    </asp:Panel>
                </div>
                <asp:Panel ID="pnlProductssHelp" runat="server" Visible="False">
                    <p>Notes:</p>
                    <p>Fill the products form and click the "Add The Item" button to add the product record to the database and start creating a new one.</p>
                    <p>Click the "Clear Form" button to remove all the text from textboxes and deselect the brand.</p>
                    <p>Click the "Cancel" button to cancel creating the product and go to the Product page.</p>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>


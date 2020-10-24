<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEquipment.aspx.cs" Inherits="PRIMEWeb.Equipments.NewEquipment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Create New Equipment</title>
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
        #divBtnEquipments {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }
        #divBtnEquipments input, #divBtnEquipments a {
            margin: 0 10px;
        }
    </style>
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
                        <a class="nav-link" href="/Sales/">Sales</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Inventory/">Inventory</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Equipments/">Equipments</a>
                    </li>
                </ul>
                <ol class="navbar-collapse breadcrumb">
                    <li class="breadcrumb-item"><a href="/Landing.aspx">Home</a></li>
                    <li class="breadcrumb-item"><a href="/Equipments/">Equipments</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Create New Equipment</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9">
                <h1>Create New Equipment</h1>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" placeholder="Model" required="required"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:TextBox ID="txtSerialNum" runat="server" CssClass="form-control" placeholder="Serial Number" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:DropDownList ID="ddlManufacturer" runat="server" CssClass="custom-select">
                            <asp:ListItem>Select the Manufacturer...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="custom-select">
                            <asp:ListItem>Select the Type...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div id="divBtnEquipments" class="col-md-12">
                        <asp:Button ID="btnCreate" runat="server" aria-label="Create Equipment" CssClass="btn btn-outline-primary" Text="Create Equipment" />
                        <input type="reset" value="Clear Form" class="btn btn-outline-primary" aria-label="Clear Form"/>
                        <a class="btn btn-outline-primary" href="/Equipments/" role="button" aria-label="Cancel Creating Equipment">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

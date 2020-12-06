<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEquipment.aspx.cs" Inherits="PRIMEWeb.Customers.EditEquipment" %>

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
            margin-top:5px;
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
                        <a class="nav-link" href="/Repairs/">Repairs</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Inventory/">Inventory</a>
                    </li>
                </ul>
                <ol class="navbar-collapse breadcrumb">
                    <li class="breadcrumb-item"><a href="/Landing.aspx">Home</a></li>
                    <li class="breadcrumb-item"><a href="/Customers/">Customers</a></li>
                    <li class="breadcrumb-item"><a href="/Customers/Equipments.aspx">Equipments</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Edit Equipment</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9">
                <h1>Edit Equipment</h1>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">ID</asp:Label>
                        <asp:TextBox ID="txtID" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Model</asp:Label>
                        <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" placeholder="Model" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Serial</asp:Label>
                        <asp:TextBox ID="txtSerialNum" runat="server" CssClass="form-control" placeholder="Serial Number" required="required"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Manufacturer</asp:Label>
                        <asp:DropDownList ID="ddlManufacturer" runat="server" CssClass="custom-select" AppendDataBoundItems="True" DataSourceID="odsManufacturer" DataTextField="Manufacturer" DataValueField="ID">
                            <asp:ListItem Value="0">Select Manufacturer</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Type</asp:Label>
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="custom-select" AppendDataBoundItems="True" DataSourceID="odsType" DataTextField="Type" DataValueField="ID">
                            <asp:ListItem Value="0">Select Type</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label class="context_help" runat="server">Customer</asp:Label>
                        <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="custom-select" AppendDataBoundItems="True" DataSourceID="odsCustomer" DataTextField="Customer" DataValueField="ID">
                            <asp:ListItem Value="0">Select Customer</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div id="divBtnEquipments" class="col-md-12">
                        <asp:Button ID="btnCreate" runat="server" aria-label="Update Equipment" CssClass="btn btn-outline-primary" Text="Update Equipment" OnClick="btnUpdate_Click" />
                        <a class="btn btn-outline-primary" href="/Customers/Equipments.aspx" role="button" aria-label="Cancel Editing Equipment">Cancel</a>
                    </div>
                </div>
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                <br />
                <asp:ObjectDataSource ID="odsType" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.EquipmentDataSetTableAdapters.equip_typeTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsCustomer" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.EquipmentDataSetTableAdapters.customerTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsManufacturer" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.EquipmentDataSetTableAdapters.manufacturerTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
    </form>
</body>
</html>

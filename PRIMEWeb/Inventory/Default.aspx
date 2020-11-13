<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PRIMEWeb.Inventory.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>PRIME - Inventory</title>
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
        #divBtnSales {
            margin: 10px 0;
        }
        #divBtnSearch {
            text-align: right;
            margin-bottom: 1rem;
        }
        #btnClear {
            margin-left: 30px;
        }
        .table {
            margin: 15px auto;
        }
        .table td, .table th {
            text-align: center;
            vertical-align: middle;
        }
        
        
        .textbox {
            width: 200px;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            border: 0px 0px 0px 0px;

            margin-right: 0px;

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
                        <a class="nav-link" href="/Inventory/">Inventory</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Equipments/">Equipments</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="/Repairs/">Repairs</a>
                    </li>
                </ul>
                <ol class="navbar-collapse breadcrumb">
                    <li class="breadcrumb-item"><a href="/Landing.aspx">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Inventory</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg">
            <div id="wrapper" class="row justify-content-sm-center">
                <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                    <h1>Inventory</h1>
                    <div id="divBtnInventory" class="btn-group" role="group">
                        <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-secondary" aria-label="Create New Inventory Item" Text="Create New Inventory Item" PostBackUrl="/Inventory/CreateNewItem.aspx" />
                        <button class="btn btn-secondary" type="button" data-toggle="collapse" data-target="#collapseFilter" aria-expanded="false" aria-controls="collapseFilter" aria-label="Filter Inventory Items">
                            Filter Inventory
                        </button>
                    </div>
                    <div class="collapse" id="collapseFilter">
                        <div class="card card-body bg-light">
                            <div class="form-row">
                                <div class="col-md-4 ">
                                    <div class="form-group ">
                                        <label class="control-label">Product :</label>
                                        <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control " ></asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="col-md-4 ">
                                    <div class="form-group">
                                        <label class="control-label">Quantity:</label>
                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control " ></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="col-md-4 ">
                                    <div class="form-group">
                                        <label class="control-label">Size:</label>
                                        <asp:TextBox ID="txtSize" runat="server" CssClass="form-control " ></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                            <div class="form-row">
                                <div class="col-md-4 ">
                                    <div class="form-group">
                                        <label class="control-label">Measure:</label>
                                        <asp:DropDownList ID="ddlMeasures" runat="server" CssClass="form-control ">
                                            <asp:ListItem>All Measures</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            
                            
                                    <div class="col-md-4 ">
                                    <div class="form-group">
                                        <label class="control-label">Price:</label>
                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control " ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 ">
                                    <div class="form-group" >
                                        <label class="control-label">Brand:</label>
                                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="form-control ">
                                            <asp:ListItem>All brands</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        
                            
                                <div id="divBtnSearch" class="col-md-6 align-self-end">
                                    <asp:Button ID="btnSearch" runat="server" aria-label="Apply Filter" CssClass="btn btn-outline-secondary" Text="Apply Filter" />
                                    <input id="btnClear" type="reset" value="Clear Filter" class="btn btn-outline-secondary" aria-label="Clear Filter"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Name</th>
                                <th scope="col">Description</th>
                                <th scope="col">Quantity</th>
                                <th scope="col">Size</th>
                                <th scope="col">Price</th>
                                <th scope="col">Brand</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>2 stroke oil</td>
                                <td>Blue -Oil for a two stroke engine</td>
                                <td>12</td>
                                <td>6.00 FL oz</td>
                                <td>$4.95</td>
                                <td>Castrol</td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-outline-warning" aria-label="Edit Customer" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-outline-danger" aria-label="Delete Customer" Text="Delete" />
                                </td>
                            </tr>
                            <tr>
                                <td>Air Filter</td>
                                <td>Paper. Air filter for Briggs and Stratton engines</td>
                                <td>23</td>
                                <td>5.00 inch</td>
                                <td>$15.99</td>
                                <td>Briggs and Stratton</td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-outline-warning" aria-label="Edit Customer" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-outline-danger" aria-label="Delete Customer" Text="Delete" />
                                </td>
                            </tr>
                            <tr>
                                <td>50:1 Mixed Gas</td>
                                <td>Pre-mixed gas for two stroke engines requiring 
                                    <br />a 50:1 gas to oil ratio</td>
                                <td>9</td>
                                <td>1.00 Litre</td>
                                <td>$12.50</td>
                                <td>Champion</td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-outline-warning" aria-label="Edit Customer" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-outline-danger" aria-label="Delete Customer" Text="Delete" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

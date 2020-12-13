<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArrivedOrderDefaultPage.aspx.cs" Inherits="PRIMEWeb.Orders.ArrivedOrderDefaultPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>PRIME - Orders</title>
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
        .table {
            margin: 30px auto 0 auto;
        }
        .table td, .table th {
            text-align: center;
            vertical-align: middle;
        }
        td .btn {
            width: 80px;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmOrders" runat="server">
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
                    <li class="nav-item">
                        <a class="nav-link" href="/Orders/ArrivedOrderDefaultPage.aspx">Arriving Orders</a>
                    </li>
                </ul>
                <ol class="navbar-collapse breadcrumb">
                    <li class="breadcrumb-item"><a href="/Landing.aspx">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Arrived Order</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg">
            <div id="wrapper" class="row justify-content-sm-center">
                <div id="wrapper-inner" class="col-lg-9 rounded-lg">
                    <h1>Arrived Item</h1>
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-secondary" aria-label="Add info about Arrived Item" Text="Add info about Arrived Item" PostBackUrl="/Orders/ArrivedOrder.aspx" />
                   <button class="btn btn-secondary" type="button" data-toggle="collapse" data-target="#collapseFilter" aria-expanded="false" aria-controls="collapseFilter" aria-label="Filter Arrived Items">
                        Filter Arrived Items
                    </button>
                    
                    <div class="collapse" id="collapseFilter">
                        <div class="card card-body bg-light">
                            <div class="form-row">
                                <div class="auto-style1">
                                    <div class="form-group">
                                        <label class="control-label">Date In:</label>
                                        <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                
                            </div>
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Service:</label>
                                        <asp:DropDownList ID="ddlInventoryID" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataSourceID="on_order" DataTextField="inventoryID" DataValueField="id">
                                            <asp:ListItem Selected="True" Value="None">None</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Equipment:</label>
                                        <asp:DropDownList ID="ddlProdOrderID" runat="server" CssClass="form-control" AppendDataBoundItems="True" DataSourceID="on_order" DataTextField="prodorderID" DataValueField="id">
                                            <asp:ListItem Selected="True">None</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="auto-style1">
                                    <div class="form-group">
                                        <label class="control-label">Date Arrived:</label>
                                        <asp:TextBox ID="txtDateAttived" runat="server" CssClass="form-control" TextMode ="Date" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Number In Order:</label>
                                        <asp:TextBox ID="txtNumberInOrder" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label">Number In Order:</label>
                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode ="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                            <div>
                                <div id="divBtnSearch" class="col-md-6 align-self-end">
                                    <asp:Button ID="btnSearch" runat="server" aria-label="Apply Filter" CssClass="btn btn-outline-secondary" Text="Apply Filter" OnClick="btnSearch_Click" />
                                    <input id="btnClear" type="reset" value="Clear Filter" class="btn btn-outline-secondary" aria-label="Clear Filter"/>
                                </div>
                            </div>
                        </div>
                    </div>

              
                    
                        <asp:GridView ID="gv_Orders" runat="server" BorderStyle="None" CssClass="table" GridLines="None" OnRowDataBound="gv_Orders_RowDataBound">
                            <EmptyDataTemplate>
                                No Records Found
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:Label ID="lbl_Status" runat="server" Text="Label"></asp:Label>

                        <br />
                    <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                        </Triggers>
                   </div>

            </div>
        </div>
            <asp:ObjectDataSource ID="on_order" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.OrdersDataSetTableAdapters.on_orderTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_id" Type="Int32" />
                    <asp:Parameter Name="Original_onordInvoiceNum" Type="String" />
                    <asp:Parameter Name="Original_onordArriveDate" Type="DateTime" />
                    <asp:Parameter Name="Original_onordNumInOrder" Type="Int32" />
                    <asp:Parameter Name="Original_onordPrice" Type="Decimal" />
                    <asp:Parameter Name="Original_inventoryID" Type="Int32" />
                    <asp:Parameter Name="Original_prodorderID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="onordInvoiceNum" Type="String" />
                    <asp:Parameter Name="onordArriveDate" Type="DateTime" />
                    <asp:Parameter Name="onordNumInOrder" Type="Int32" />
                    <asp:Parameter Name="onordPrice" Type="Decimal" />
                    <asp:Parameter Name="inventoryID" Type="Int32" />
                    <asp:Parameter Name="prodorderID" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="onordInvoiceNum" Type="String" />
                    <asp:Parameter Name="onordArriveDate" Type="DateTime" />
                    <asp:Parameter Name="onordNumInOrder" Type="Int32" />
                    <asp:Parameter Name="onordPrice" Type="Decimal" />
                    <asp:Parameter Name="inventoryID" Type="Int32" />
                    <asp:Parameter Name="prodorderID" Type="Int32" />
                    <asp:Parameter Name="Original_id" Type="Int32" />
                    <asp:Parameter Name="Original_onordInvoiceNum" Type="String" />
                    <asp:Parameter Name="Original_onordArriveDate" Type="DateTime" />
                    <asp:Parameter Name="Original_onordNumInOrder" Type="Int32" />
                    <asp:Parameter Name="Original_onordPrice" Type="Decimal" />
                    <asp:Parameter Name="Original_inventoryID" Type="Int32" />
                    <asp:Parameter Name="Original_prodorderID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            </div>
    </form>
</body>
</html>
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    <%--  <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Invoice Number</th>
                                <th scope="col">Arrive Date</th>
                                <th scope="col">Number in Order</th>
                                <th scope="col">Price</th>
                                <th scope="col">Inventoty ID</th>
                                <th scope="col">Product Order</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>###</td>
                                <td>11/29/2019</td>
                                <td>###</td>
                                <td>100$</td>
                                <td>500</td>
                                <td>Abrakadabra</td>
                                
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-info" aria-label="Item Details" Text="Details" />
                                    <asp:Button runat="server" CssClass="btn btn-dark" aria-label="Edit Item" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-danger" aria-label="Delete Item" Text="Delete" />
                                </td>
                            </tr>
                            <tr>
                                
                                <td>###</td>
                                <td>12/1/2019</td>
                                <td>###</td>
                                <td>1050$</td>
                                <td>590</td>
                                <td>Abrakadabra</td>
                                
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-info" aria-label="Item Details" Text="Details" />
                                    <asp:Button runat="server" CssClass="btn btn-dark" aria-label="Edit Item" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-danger" aria-label="Delete Item" Text="Delete" />
                                </td>
                            </tr>
                            <tr>
                                
                                <td>###</td>
                                <td>12/20/2019</td>
                                <td>###</td>
                                <td>105$</td>
                                <td>501</td>
                                <td>Abrakadabra</td>
                                
                                <td>
                                    <asp:Button runat="server" CssClass="btn btn-info" aria-label="Item Details" Text="Details" />
                                    <asp:Button runat="server" CssClass="btn btn-dark" aria-label="Edit Item" Text="Edit" />
                                    <asp:Button runat="server" CssClass="btn btn-danger" aria-label="Delete Item" Text="Delete" />
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
--%>
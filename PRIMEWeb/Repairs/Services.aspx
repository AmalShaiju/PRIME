﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="PRIMEWeb.Repairs.Services" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Services</title>
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

        .form-check-inline {
            margin-right: 2rem;
        }

        #divBtnSearch {
            text-align: right;
            margin-bottom: 1rem;
        }

        #btnClear {
            margin-left: 30px;
        }

        .table {
            margin: 30px auto 0 auto;
        }

            .table td, .table th {
                text-align: center;
                vertical-align: middle;
            }
           

        td .btn {
            width: 70px;
            margin: 0 5px;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmServices" runat="server">
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
                    <li class="breadcrumb-item"><a href="/Repairs/">Repairs</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Services</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg">
            <div id="wrapper" class="row justify-content-sm-center">
                <div id="wrapper-inner" class="col-lg-11 rounded-lg">
                    <h1>Services</h1>
                    <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-secondary" aria-label="Create New Service" Text="Create New Service" PostBackUrl="/Repairs/NewService.aspx" ToolTip="Create new service" />
                    <button class="btn btn-secondary" type="button" data-toggle="collapse" data-target="#collapseFilter" aria-expanded="false" aria-controls="collapseFilter" aria-label="Filter Services">
                        Filter Services
                    </button>
                    <br />
                    <br />
                    <br />
                    <strong> <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green" ToolTip="Status"></asp:Label></strong>
                    <br />
                    <div class="collapse" id="collapseFilter">
                        <div class="card card-body bg-light">
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Service Name:</label>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ToolTip="Service name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Service Description:</label>
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" ToolTip="service description"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Service Price:</label>
                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" ToolTip="service price"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="divBtnSearch" class="col-md-6 align-self-end">
                                    <asp:Button ID="btnSearch" runat="server" aria-label="Apply Filter" CssClass="btn btn-warning" Text="Apply Filter" OnClick="btnSearch_Click" ToolTip="Apply filter" />
                                    <input id="btnClear" type="reset" value="Clear Filter" class="btn btn-outline-secondary" aria-label="Clear Filter"/>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:GridView ID="GridView1" runat="server" CssClass="table" EmptyDataText="No Records Found" OnRowDataBound="GridView1_RowDataBound" GridLines="None" ToolTip="Service info grid">
                        <EmptyDataTemplate>
                            No Records Found
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <br />  
                </div>

            </div>
        </div>
    </form>
</body>
</html>

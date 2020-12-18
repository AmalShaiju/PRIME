<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarrantyReport.aspx.cs" Inherits="PRIMEWeb.Repairs.WarrantyReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Warranty Report</title>
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
            padding: 10px 0 30px 0;
        }

        h4 {
            padding-top: 30px;
        }

        .table {
            margin: 15px auto 20px auto;
        }

            .table td, .table th {
                text-align: center;
                vertical-align: middle;
            }

        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 75%;
            flex: 0 0 75%;
            max-width: 75%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmReport" runat="server">
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
                    <li class="breadcrumb-item active" aria-current="page">Warranty Report</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div class="auto-style1">
                <h1>Warranty Report</h1>
                <button class="btn btn-secondary" type="button" data-toggle="collapse" data-target="#collapseFilter" aria-expanded="false" aria-controls="collapseFilter" aria-label="Filter Entries">
                    Filter Entries
                </button>
                <br />
                <br />
                <br />
                <strong><asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green" ToolTip="Records found"></asp:Label>
                <br />
                <br />
                </strong>

                <div class="collapse" id="collapseFilter">
                    <div class="card card-body bg-light">
                        <div class="form-row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">From Date:</label>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" TextMode="Date" ToolTip="From date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">To Date:</label>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" TextMode="Date" ToolTip="To date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Manufacturer:</label>
                                    <asp:DropDownList ID="ddlManufacturer" runat="server" CssClass="form-control" DataSourceID="Manufacturer" DataTextField="manName" DataValueField="id" AppendDataBoundItems="True" ToolTip="manufacturer">
                                        <asp:ListItem>None</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="divBtnSearch" class="col-md-6 form-group align-self-end">
                                <asp:Button ID="btnSearch" runat="server" aria-label="Apply Filter" CssClass="btn btn-warning" Text="Apply Filter" OnClick="btnSearch_Click" ToolTip="Apply  filter" />
                                <input id="btnClear" type="reset" value="Clear Filter" class="btn btn-secondary" aria-label="Clear Filter" />
                            </div>
                        </div>
                    </div>
                </div>
                <h4>Detailed Report</h4>


                <asp:GridView ID="DetailGrid" runat="server" CssClass="table" BorderStyle="None" EmptyDataText="No Records Found" GridLines="None" ToolTip="Detailed report">
                    <EmptyDataTemplate>
                        No Records Found
                    </EmptyDataTemplate>
                </asp:GridView>
                <br />

                <h4>Overall Report</h4>
                <div>

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" DataSourceID="OverallWarranty" GridLines="None" ToolTip="Overall report">
                        <Columns>
                            <asp:BoundField DataField="manName" HeaderText="Manufacturer" SortExpression="manName" />
                            <asp:BoundField DataField="Total Repairs" HeaderText="Total Repairs" ReadOnly="True" SortExpression="Total Repairs" />
                            <asp:BoundField DataField="Total Price" HeaderText="Total Price" ReadOnly="True" SortExpression="Total Price" />
                        </Columns>
                        <EmptyDataTemplate>
                            No Records Found
                        </EmptyDataTemplate>
                    </asp:GridView>

                </div>
                <br />
                <asp:ObjectDataSource ID="Manufacturer" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.RepairsDataSetTableAdapters.Manufacturer"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="OverallWarranty" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.RepairsDataSetTableAdapters.OverallWarrentyReportLookUpTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
    </form>
</body>
</html>

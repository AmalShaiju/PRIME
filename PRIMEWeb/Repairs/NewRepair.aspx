<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewRepair.aspx.cs" Inherits="PRIMEWeb.Repairs.NewRepair" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Create New Repair</title>
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
        #txtIssue {
            height: 45px;
        }
        #lblInWarranty {
            margin-right: 30px;
        }
        #pnlBtnRepairs {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }
        #pnlBtnRepairs input, #pnlBtnRepairs a {
            margin: 0 10px;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmNewRepair" runat="server">
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
                    <li class="breadcrumb-item active" aria-current="page">Create New Repair</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9">
                <h1>Create New Repair</h1>
                <div class="form-row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Date In:</label>
                            <asp:TextBox ID="txtDateIn" runat="server" CssClass="form-control" TextMode="Date" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Date Out:</label>
                            <asp:TextBox ID="txtDateOut" runat="server" CssClass="form-control" TextMode="Date" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Issue:</label>
                            <asp:TextBox ID="txtIssue" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Issue for this repair..." required="required"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Warranty Status:</label>
                            <div class="form-control form-check form-check-inline">
                                <asp:RadioButton ID="radInWarranty" runat="server" CssClass="form-check-input" value="true" GroupName="radStatus" />
                                <label class="form-check-label" for="radInWarranty" id="lblInWarranty">In Warranty</label>
                                <asp:RadioButton ID="radNoWarranty" runat="server" CssClass="form-check-input" value="false" GroupName="radStatus" required="required" />
                                <label class="form-check-label" for="radNoWarranty">Not In Warranty</label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Receipt:</label>
                            <asp:DropDownList ID="ddlReceipt" runat="server" CssClass="custom-select">
                                <asp:ListItem>Select a Receipt...</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Service:</label>
                            <asp:DropDownList ID="ddlService" runat="server" CssClass="custom-select">
                                <asp:ListItem>Select a Service...</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Equipment:</label>
                            <asp:DropDownList ID="ddlEquipment" runat="server" CssClass="custom-select">
                                <asp:ListItem>Select a Equipment...</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Employee:</label>
                            <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="custom-select">
                                <asp:ListItem>Select an Employee...</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <asp:Panel ID="pnlBtnRepairs" CssClass="col-md-12" runat="server">
                        <asp:Button ID="btnCreate" runat="server" aria-label="Create Repair" CssClass="btn btn-outline-primary" Text="Create Repair" />
                        <input class="btn btn-outline-primary" type="reset" value="Clear Form" aria-label="Clear Form" />
                        <a class="btn btn-outline-primary" href="/Repairs/" role="button" aria-label="Cancel Creating Sale">Cancel</a>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

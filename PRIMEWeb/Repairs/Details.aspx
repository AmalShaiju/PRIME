<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="PRIMEWeb.Repairs.Details" %>

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
            padding: 10px;
        }

        h1 {
            text-align: center;
            padding: 1rem 0;
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

        .Detail-container{
            width:100%;
        }
        .wrapper {
            margin: 0px 0px;
        }

            .wrapper h2 {
                margin: 30px 0px;
            }
        .flex-box{
            display:flex;
            justify-content:space-around;
            margin-bottom:20px;
            
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
                    <li class="breadcrumb-item active" aria-current="page">Details</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" PostBackUrl="/" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner">
                <h1>Details</h1>

                </div>
                <div class="Detail-container">
                    <div class="flex-box">
                        <div class="wrapper">
                            <h2>Repair Info</h2>

                            <asp:Label ID="Label1" runat="server" Text="Date IN"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblDateIn" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Date Out"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblDateOut" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="Issue"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblssue" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label4" runat="server" Text="In Warrenty"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblWarranty" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label18" runat="server" Text="Service Requested"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblService" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="Employee "></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblEmployee" runat="server" Text="Label"></asp:Label>

                        </div>
                        <div class="wrapper">

                            <h2>Equipment Info</h2>

                            <asp:Label ID="Label15" runat="server" Text="Name"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblEquipmentName" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label17" runat="server" Text="Type"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblEquipmentType" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label13" runat="server" Text="Model"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblEquipmentModel" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label14" runat="server" Text="Serial"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblEquipmentSerial" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="Label16" runat="server" Text="Manufacturer"></asp:Label>
                            &nbsp;:
                <asp:Label ID="lblEquipmentManufacturer" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                        </div>

                <div class="wrapper">

                    <h2>Customer Info</h2>
                    <asp:Label ID="Label6" runat="server" Text="First Name"></asp:Label>
                    &nbsp;:
                <asp:Label ID="lblCustomerFirst" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Last Name"></asp:Label>
                    &nbsp;:
                <asp:Label ID="lblCustomerLast" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Phone"></asp:Label>
                    &nbsp;:
                <asp:Label ID="lblCustomerPhone" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
                    &nbsp;:
                <asp:Label ID="lblCustomerEmail" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Address"></asp:Label>
                    :
                <asp:Label ID="lblCustomerAddress" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="City"></asp:Label>
                    &nbsp;:
                <asp:Label ID="lblCustomerCity" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="Postal"></asp:Label>
                    &nbsp;:
                <asp:Label ID="lblCustomerPostal" runat="server" Text="Label"></asp:Label>
                </div>

                </div>

                </div>

        </div>
    </form>
</body>
</html>

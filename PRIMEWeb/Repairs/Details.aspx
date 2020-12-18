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

        .Detail-container {
            width: 100%;
        }

        .wrapper {
            margin: 0px 0px;
        }

            .wrapper h2 {
                margin: 30px 0px;
            }

        .flex-box {
            display: flex;
            justify-content: space-around;
            margin-bottom: 50px;
            border: 1px solid #e9e9e9;
        }

        #wrapper-inner {
            width: 100%;
        }

        .details {
            padding-left: 60px;
            padding-top: 25px;
        }


        .dark-detail {
            background: #f9fafa;
            width: 50%;
            padding: 45px 50px;
        }

        .light-detail {
            width: 50%;
            padding: 45px 50px;
            border-left: 1px solid #e9e9e9;
        }

        .detail-Items {
            margin-bottom: 40px;
        }


        #pnlTimer {
            margin-bottom: 40px;
        }

        #Repair-shop-details {
            margin-bottom: 20px;
        }

        .repair-summary-items {
            margin-bottom: 10px;
        }

        #repair-summary-heading {
            margin-bottom: 20px;
        }

        .flex-box-repair-summary-items {
            display: flex;
            justify-content: space-around;
            width: 100%;
        }

        #pnlDeleteConfirm {
            margin-top: 30px;
            margin-left: 56px;
            width: 95%;
        }

        #btnDelete {
            margin-left: 13px;
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
                    <li class="nav-item">
                        <a class="nav-link" href="/Orders/">Orders</a>
                    </li>
                </ul>
                <ol class="navbar-collapse breadcrumb">
                    <li class="breadcrumb-item"><a href="/Landing.aspx">Home</a></li>
                    <li class="breadcrumb-item"><a href="/Repairs/">Repairs</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Details</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" OnClick="btnLogout_Click" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">

            <div id="wrapper-inner">
                <h1>Repair Details</h1>
                <asp:Panel ID="pnlDeleteConfirm" runat="server" CssClass="alert alert-danger" role="alert" Visible="False">
                    <h4 class="alert-heading">Do you really want to delete this sale?</h4>
                    <hr />
                    <p>Doing this will also delete all orders and repairs under this repair.</p>
                    <p>Please check out the orders and repairs before doing so.</p>
                    <p>If you're sure about this, click the "Delete" button.</p>
                    <hr />
                    <a href="/Repairs/" type="button" class="btn btn-secondary">Cancel</a>
                    <asp:Button ID="btnDeleteConfirm" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDeleteConfirm_Click" />
                </asp:Panel>
                <div style="margin: 20px 0px;">
                    <asp:Label ID="redirectMsg" runat="server" ForeColor="Green" Text="Label" Visible="False"></asp:Label>
                </div>
                <div class="details">
                    <div class="inner-deatils">
                        <asp:Panel ID="pnlTimer" runat="server">
                            <h2>Repair Summary</h2>
                            <hr />
                            <br />
                            <div class="flex-box">
                                <div class="dark-detail">

                                    <div class="detail-Items">
                                        <asp:Label runat="server" Text="Repair Status : "></asp:Label>
                                    </div>
                                    <div class="detail-Items">
                                        <asp:Label ID="Label20" runat="server" Text="Repair Started : " Visible="False"></asp:Label>
                                    </div>
                                    <div>
                                        <div class="detail-Items">
                                            <asp:Label ID="Label15" runat="server" Text="Repair Paused : " Visible="False"></asp:Label>

                                        </div>
                                        <div class="detail-Items">
                                            <asp:Label ID="Label19" runat="server" Text="Repair Resumed : " Visible="False"></asp:Label>
                                        </div>
                                        <div class="detail-Items">
                                            <asp:Label ID="Label21" runat="server" Text="Repair Stoped : " Visible="False"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="flex-box-repair-summary-items">
                                        <div>
                                            <asp:Button ID="btnStart" runat="server" Text="Start Repair" CssClass="btn btn-success" Width="150px" OnClick="btnStart_Click" Visible="False" />
                                        </div>
                                        <div>
                                            <asp:Button ID="btnPause" runat="server" Text="Pause Repair" CssClass="btn btn-warning" OnClick="btnPause_Click" Width="150px" Visible="False" />
                                        </div>

                                    </div>
                                </div>
                                <div class="light-detail">
                                    <div class="detail-Items">

                                        <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div class="detail-Items">
                                        <asp:Label ID="lblStart" runat="server" Text="Label" Visible="False"></asp:Label>

                                    </div>
                                    <div class="detail-Items">
                                        <asp:Label ID="lblpaused" runat="server" Text="Label" Visible="False"></asp:Label>

                                    </div>
                                    <div class="detail-Items">
                                        <asp:Label ID="lblResumed" runat="server" Text="Label" Visible="False"></asp:Label>

                                    </div>
                                    <div class="detail-Items">
                                        <asp:Label ID="lblStop" runat="server" Text="Label" Visible="False"></asp:Label>

                                    </div>
                                    <div class="flex-box-repair-summary-items">
                                        <div>
                                            <asp:Button ID="btnResume" runat="server" Text="Resume Repair" CssClass="btn btn-success" OnClick="btnResume_Click" Width="150px" />
                                        </div>

                                        <div>
                                            <asp:Button ID="btnStop" runat="server" Text="Stop Repair" CssClass="btn btn-danger" Width="150px" OnClick="btnStop_Click" Visible="False" />
                                        </div>
                                    </div>
                                </div>
                            </div>



                        </asp:Panel>


                        <h2>Repair Info</h2>
                        <hr />

                        <br />

                        <div class="flex-box">
                            <div class="dark-detail">
                                <div class="detail-Items">
                                    <asp:Label ID="Label1" runat="server" Text="Date In"></asp:Label>
                                </div>
                                <div class="detail-Items">
                                    <asp:Label ID="Label2" runat="server" Text="Date Out"></asp:Label>
                                </div>
                                <div class="detail-Items">
                                    <asp:Label ID="Label3" runat="server" Text="Issue"></asp:Label>
                                </div>
                                <div class="detail-Items">
                                    <asp:Label ID="Label4" runat="server" Text="In Warrenty"></asp:Label>
                                </div>
                                <div class="detail-Items">
                                    <asp:Label ID="Label18" runat="server" Text="Service Requested"></asp:Label>

                                </div>
                                <div class="detail-Items" style="margin-bottom: 0;">
                                    <asp:Label ID="Label5" runat="server" Text="Employee "></asp:Label>
                                </div>

                            </div>
                            <div class="light-detail">
                                <div class="detail-Items">
                                    <asp:Label ID="lblDateIn" runat="server" Text="Label"></asp:Label>
                                </div>

                                <div class="detail-Items">
                                    <asp:Label ID="lblDateOut" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">
                                    <asp:Label ID="lblssue" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">
                                    <asp:Label ID="lblWarranty" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">
                                    <asp:Label ID="lblService" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items" style="margin-bottom: 0;">
                                    <asp:Label ID="lblEmployee" runat="server" Text="Label"></asp:Label>
                                </div>


                            </div>
                        </div>


                        <h2>Equipment Info</h2>
                        <hr />
                        <br />
                        <div class="flex-box">
                            <div class="dark-detail">

                                <div class="detail-Items">
                                    <asp:Label ID="Label17" runat="server" Text="Type"></asp:Label>
                                </div>
                                <div class="detail-Items">
                                    <asp:Label ID="Label13" runat="server" Text="Model"></asp:Label>
                                </div>
                                <div class="detail-Items">
                                    <asp:Label ID="Label14" runat="server" Text="Serial"></asp:Label>
                                </div>
                                <div class="detail-Items" style="margin-bottom: 0;">

                                    <asp:Label ID="Label16" runat="server" Text="Manufacturer"></asp:Label>
                                </div>
                            </div>

                            <div class="light-detail">

                                <div class="detail-Items">

                                    <asp:Label ID="lblEquipmentType" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="lblEquipmentModel" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="lblEquipmentSerial" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items" style="margin-bottom: 0;">

                                    <asp:Label ID="lblEquipmentManufacturer" runat="server" Text="Label"></asp:Label>
                                </div>

                            </div>
                        </div>

                        <h2>Customer Info</h2>
                        <hr />
                        <br />
                        <div class="flex-box">
                            <div class="dark-detail">
                                <div class="detail-Items">

                                    <asp:Label ID="Label6" runat="server" Text="First Name"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="Label7" runat="server" Text="Last Name"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="Label8" runat="server" Text="Phone"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
                                </div>
                                <div class="detail-Items">


                                    <asp:Label ID="Label10" runat="server" Text="Address"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="Label11" runat="server" Text="City"></asp:Label>
                                </div>
                                <div class="detail-Items" style="margin-bottom: 0;">

                                    <asp:Label ID="Label12" runat="server" Text="Postal"></asp:Label>
                                </div>


                            </div>
                            <div class="light-detail">

                                <div class="detail-Items">

                                    <asp:Label ID="lblCustomerFirst" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="lblCustomerLast" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="lblCustomerPhone" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="lblCustomerEmail" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="lblCustomerCity" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items">

                                    <asp:Label ID="lblCustomerAddress" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="detail-Items" style="margin-bottom: 0;">

                                    <asp:Label ID="lblCustomerPostal" runat="server" Text="Label"></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-info" Text="Edit" Width="100px" OnClick="Button1_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" Width="100px" OnClick="btnDelete_Click" />
                    </div>

                </div>
            </div>

        </div>



    </form>
</body>
</html>

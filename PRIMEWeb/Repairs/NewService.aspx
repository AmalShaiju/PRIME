<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewService.aspx.cs" Inherits="PRIMEWeb.Repairs.NewService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Create New Service</title>
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

        #pnlBtnRepairs {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }

            #pnlBtnRepairs input, #pnlBtnRepairs a {
                margin: 0 10px;
            }

        .flex-box {
            display: flex;
            margin-top: 3px;
        }

        .inner-flex-box {
        }

        .question {
            width: 18px;
            margin-right: 3px;
        }

        img {
            width: 18px;
            margin-right: 3px;
            margin-top: 12px;
        }

        .help-text {
            color: #5bc8de;
            font-size: 12px;
            margin-top: 4px;
            margin-right: 5px;
            width: 95%;
        }
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 100%;
            flex: 0 0 100%;
            max-width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
         .validation-child {
            margin-top: 10px;
            font-size: 12px;
            color: red;
        }

        .auto-style2 {
            display: block;
            width: 100%;
            height: 45px;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: 0;
            transition: none;
            -webkit-box-shadow: none;
            box-shadow: none;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 2px solid #6c757d;
            margin-top: 0;
            background-color: #fff;
        }

    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmNewService" runat="server" class="was-validated">
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
                    <li class="breadcrumb-item"><a href="/Repairs/Services.aspx">Services</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Create New Service</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" OnClick="btnLogout_Click" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9">
                <h1>Create New Service</h1>
              <%--  <div class="form-group form-control form-check form-check-inline">
                    <asp:CheckBox ID="cboHelp" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="cboHelp_CheckedChanged" />
                    <label class="form-check-label" for="cboHelp">Check this to display detailed instruction on this form.</label>
                </div>--%>

                <strong>
                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green" ToolTip="Status" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <br />
                </strong>

                <div class="form-row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Service Name:</label>

                            <div class="flex-box">
                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required="required" ToolTip="Service name" MaxLength="20"></asp:TextBox>
                                    <div class="invalid-feedback">Please enter a service name</div>
                                </div>
                                <div>
                                    <img id="ServiceNameImg" src="images/question.png" alt="Question mark" />

                                </div>
                            </div>
                           
                            <div style="visibility: hidden" class="help-text" id="lblServiceName">
                                <p>input a service Name (Eg: oil change)</p>
                            </div>


                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Service Description:</label>

                            <div class="flex-box">
                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="auto-style2" required="required" ToolTip="service description" MaxLength="100"></asp:TextBox>
                                    <div class="invalid-feedback">Please enter a service description</div>
                                </div>
                                <div>
                                    <img id="ServiceDescImg" src="images/question.png" alt="Question mark" />

                                </div>
                            </div>
                           
                            <div style="visibility: hidden" class="help-text" id="lblServiceDesc">
                                <p>input a service Description (Eg: Change oil)</p>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Service Price:</label>
            
                            <div class="flex-box">
                                <div style="width: 100%;">
                                   <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" required="required" ToolTip="service price" MaxLength="8" TextMode="Number"></asp:TextBox>
                            <div class="invalid-feedback">Please enter a service Price</div>
                                </div>
                                <div>
                                    <img id="PriceImg" src="images/question.png" alt="Question mark" />

                                </div>
                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblPriceVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <div style="visibility: hidden" class="help-text" id="lblPrice">
                                <p>input a service Price (Eg: $25)</p>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <asp:Panel ID="pnlBtnRepairs" CssClass="auto-style1" runat="server">
                        <asp:Button ID="btnCreate" runat="server" aria-label="Create Service" CssClass="btn btn-success" Text="Create" OnClick="btnCreate_Click" ToolTip="Create service" Width="100px" />
                        <input class="btn btn-secondary" type="reset" value="Clear Form" aria-label="Clear Form" width="100px" />
                        <a class="btn btn-danger" href="/Repairs/Services.aspx" role="button" aria-label="Cancel Creating Service" style="width: 100px;">Cancel</a>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>

    <script src="/Script/service-help_text.js"></script>

</body>
</html>

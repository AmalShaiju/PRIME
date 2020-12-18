<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditItem.aspx.cs" Inherits="PRIMEWeb.Inventory.EditItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Add New Inventory Item</title>
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

        label {
            display: inline-block;
            margin-bottom: 0.5rem;
            width: 100%;
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

        #lblMessage {
            display: block;
            margin-bottom: 10px;
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

        #pnlBtnItems {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }

        #pnlBtnItems input, #pnlBtnItems a {
            margin: 0 10px;
        }
        
    </style>
    <script>
        function SwitchCss(element) {
            var btnDangers = document.getElementsByClassName("btn-danger");
            var btnInfos = document.getElementsByClassName("btn-info");
            var btnInfos = document.getElementsByClassName("btn-info");
            var btnSearch = document.getElementById("btnSearch");
            var btnFilter = document.getElementById("btnFilter");
            var btnUpdate = document.getElementById("btnUpdate");
            var btnClear = document.getElementById("btnClear");
            var btnLogOut = document.getElementById("btnLogout");
            var btnDependents = document.getElementsByClassName("btn btn-secondary btn-dependent-page");
            var body = document.getElementsByTagName("body");
            var navigation = document.getElementsByTagName("nav");
            var ol = document.getElementsByTagName("ol");
            var container = document.getElementsByClassName("container");
            var table = document.getElementsByClassName("table");
            var createZicheng = document.getElementById("btnModify");

            if (element.checked) {
                btnLogOut.classList.add("btn-logout-high");
                for (var i = 0; i < btnDangers.length; i++) {
                    btnDangers[i].classList.add("btn-danger-high");
                }

                for (var i = 0; i < btnInfos.length; i++) {
                    btnInfos[i].classList.add("btn-info-high");
                }

                for (var i = 0; i < btnDependents.length; i++) {
                    btnDependents[i].classList.add("btn-dependent-high");
                }

                for (var i = 0; i < body.length; i++) {
                    body[i].classList.add("body-high");
                }

                for (var i = 0; i < navigation.length; i++) {
                    navigation[i].classList.add("nav-high");
                }

                for (var i = 0; i < ol.length; i++) {
                    ol[i].classList.add("border-high");
                }

                for (var i = 0; i < container.length; i++) {
                    container[i].classList.add("border-high");
                }

                for (var i = 0; i < table.length; i++) {
                    table[i].classList.add("table-high");
                }

                btnSearch.classList.add("btn-search-high");
                btnFilter.classList.add("btn-search-high");
                btnUpdate.classList.add("btn-create-high");
                btnClear.classList.add("btn-clear-high");
                createZicheng.classList.add("btn-create-high");
            }
            else {
                btnLogOut.classList.remove("btn-logout-high");
                for (var i = 0; i < btnDangers.length; i++) {
                    btnDangers[i].classList.remove("btn-danger-high");
                }

                for (var i = 0; i < btnInfos.length; i++) {
                    btnInfos[i].classList.remove("btn-info-high");
                }

                for (var i = 0; i < btnDependents.length; i++) {
                    btnDependents[i].classList.remove("btn-dependent-high");
                }

                for (var i = 0; i < body.length; i++) {
                    body[i].classList.remove("body-high");
                }

                for (var i = 0; i < navigation.length; i++) {
                    navigation[i].classList.remove("nav-high");
                }

                for (var i = 0; i < ol.length; i++) {
                    ol[i].classList.remove("border-high");
                }

                for (var i = 0; i < container.length; i++) {
                    container[i].classList.remove("border-high");
                }

                for (var i = 0; i < table.length; i++) {
                    table[i].classList.remove("table-high");
                }

                btnSearch.classList.remove("btn-search-high");
                btnFilter.classList.remove("btn-search-high");
                btnUpdate.classList.remove("btn-create-high");
                btnClear.classList.remove("btn-clear-high");
                createZicheng.classList.remove("btn-create-high");
            }
        }
    </script>
    <link href="/CSS/wcag.css" rel="stylesheet" />
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmNewItem" runat="server" class="was-validated">
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
                    <li class="breadcrumb-item"><a href="/Inventory/">Inventory</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Edit Inventory Item</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" OnClick="btnLogout_Click" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9">
                <h1>Edit Product</h1>
                <div class="form-group form-control form-check form-check-inline">
                    <input type="checkbox" onclick="SwitchCss(this)" class="form-check-input" id="cboSwitch" name="cboSwitch" />
                    <label class="form-check-label" for="cboSwitch">Check this to switch to high contrast design</label>
                    &nbsp;&nbsp;|&nbsp;&nbsp;
                    <asp:CheckBox ID="cboHelp" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="cboHelp_CheckedChanged" />
                    <label class="form-check-label" for="cboHelp">Check this to display detailed instruction on this form</label>
                </div>
                <asp:ScriptManager ID="smgEditInv" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="uplEditInv" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <div class="form-row">
                            <div class="col-md-6 form-group">
                                <label class="control-label">Product:</label>
                                <asp:DropDownList ID="ddlProducts" runat="server" CssClass="custom-select" DataSourceID="dsInvLookUp" DataTextField="prodName" DataValueField="id" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="lblProducthelp" runat="server" Text="Please select the product" Visible="False"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                                <label class="control-label">Measure:</label>
                                <asp:DropDownList ID="ddlMeasures" runat="server" CssClass="custom-select" DataSourceID="dsInvLookUp" DataTextField="InvMeaPrice" DataValueField="invMeasure">
                                </asp:DropDownList>
                                <asp:Label ID="lblMeasureHelp" runat="server" Text="Please select the measure" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6 form-group">
                                <label class="control-label">Quantity:</label>
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" required="required"></asp:TextBox>
                                <asp:Label ID="lblQtyHelp" runat="server" Text="Please input the quantity" Visible="False"></asp:Label>
                                <div class="invalid-feedback">Please input the quantity</div>
                            </div>
                            <div class="col-md-6 form-group">
                                <label class="control-label">Size:</label>
                                <asp:TextBox ID="txtSize" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                <asp:Label ID="lblSizeHelp" runat="server" Text="Please input the size" Visible="False"></asp:Label>
                                <div class="invalid-feedback">Please input the size</div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6 form-group">
                                <label class="control-label">Description:</label>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="lblDescHelp" runat="server" Text="Description of the product you selected" Visible="False"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                                <label class="control-label">Brand:</label>
                                <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="lblBrandHelp" runat="server" Text="Brand of the product you selected" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6 form-group">
                                <label class="control-label">Price:</label>
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                                <asp:Label ID="lblPriceHelp" runat="server" Text="Please input the price" Visible="False"></asp:Label>
                                <div class="invalid-feedback">Please input the price</div>
                            </div>
                        </div>
                        <div class="form-row">
                            <asp:Panel ID="pnlBtnItems" CssClass="col-md-12" runat="server">
                                <asp:Button ID="btnUpdate" runat="server" aria-label="Update the Inventory Item" CssClass="btn btn-outline-primary" OnClick="btnUpdate_Click" Text="Save Changes" />
                                <input id="btnClear" type="reset" value="Clear Form" class="btn btn-outline-primary" aria-label="Clear Form" />
                                <a aria-label="Cancel Editing Inventory Item" class="btn btn-danger" href="/Inventory/" role="button">Cancel</a>
                            </asp:Panel>
                        </div>
                        <asp:ObjectDataSource ID="dsInvLookUp" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.InventoryDataSetTableAdapters.InventoryLookUpTableAdapter"></asp:ObjectDataSource>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cboHelp" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlProducts" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewItem.aspx.cs" Inherits="PRIMEWeb.Inventory.NewItem" %>

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
        label
        {
            width: 100%;
        }
    </style>
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
    <link href="/CSS/wcag.css" rel="stylesheet" />
    <script src="/Script/wcag.js"></script>
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
                    <li class="breadcrumb-item active" aria-current="page">Add New Inventory Item</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" OnClick="btnLogout_Click" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9">
                <h1>Add New Product</h1>
                <div class="form-group form-control form-check form-check-inline">
                    &nbsp;
                    <input type="checkbox" onclick="SwitchCss(this)" class="form-check-input" id="cboSwitch" name="cboSwitch" />
                    <label class="form-check-label" for="cboSwitch">Check this to switch to high contrast design</label>
                    &nbsp;&nbsp;|&nbsp;&nbsp;
                    <asp:CheckBox ID="cboHelp" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="cboHelp_CheckedChanged" />
                    <label class="form-check-label" for="cboHelp">Check this to display detailed instruction on this form</label>
                </div>
                <asp:ScriptManager ID="smgInvNew" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="uplInvNew" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <div class="form-row">
                            <div class="col-md-6 form-group">
                                <label class="control-label">Product:</label>
                                <asp:DropDownList ID="ddlProducts" runat="server" CssClass="custom-select" DataSourceID="odsProduct" DataTextField="prodName" DataValueField="id" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" required="required">
                                    <asp:ListItem Selected="True" Value="">Select a Product</asp:ListItem>
                                    <asp:ListItem Value="new_item">Add New Product</asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-check-label" for="ddlProducts" id="lblProduct"></label>
                                <asp:Label ID="lblProducthelp" runat="server" Text="Please select a product" Visible="False"></asp:Label>
                                <div class="invalid-feedback">Please select a product</div>
                            </div>
                            <div class="col-md-6 form-group">
                                <label class="control-label">Measure:</label>
                                <asp:DropDownList ID="ddlMeasures" runat="server" CssClass="custom-select" DataSourceID="odsInvLookUp" DataTextField="InvMeaPrice" DataValueField="invMeasure">
                                    <asp:ListItem>Select a Measure</asp:ListItem>
                                </asp:DropDownList>
                                <div class="invalid-feedback">Please select the measure</div>
                                <asp:Label ID="lblMeasureHelp" runat="server" Text="Please select the measure" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6 form-group">
                                <label class="control-label">Quantity:</label>
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" required="required"></asp:TextBox>
                                <div class="invalid-feedback">Please input the quantity</div>
                                <asp:Label ID="lblQuantityHelp" runat="server" Text="Please input the quantity" Visible="False"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                                <label class="control-label">Size:</label>
                                <asp:TextBox ID="txtSize" runat="server" CssClass="form-control" required="required" TextMode="Number"></asp:TextBox>
                                <div class="invalid-feedback">Please input the size</div>
                                <asp:Label ID="lblSizeHelp" runat="server" Text="Please input the size" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6 form-group">
                                <label class="control-label">Description:</label>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="lblDescriptionHelp" runat="server" Text="Description of the product you selected" Visible="False"></asp:Label>
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
                                <div class="invalid-feedback">Please input the price</div>
                                <asp:Label ID="lblPriceHelp" runat="server" Text="Please input the price" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <asp:Panel ID="pnlBtnItems" CssClass="col-md-12" runat="server">
                                <asp:Button ID="btnCreate" runat="server" aria-label="Add the Inventory Item" CssClass="btn btn-outline-primary" OnClick="btnAddItem_Click" Text="Add the Item" />
                                <input id="btnClear" type="reset" value="Clear Form" class="btn btn-outline-primary" aria-label="Clear Form" />
                                <a aria-label="Cancel Adding Inventory Item" class="btn btn-danger" href="/Inventory/" role="button">Cancel</a>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cboHelp" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlProducts" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:ObjectDataSource ID="odsInventory" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.InventoryDataSetTableAdapters.InventoryTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id" Type="Int32" />
                        <asp:Parameter Name="Original_invQuantity" Type="Int32" />
                        <asp:Parameter Name="Original_invSize" Type="Decimal" />
                        <asp:Parameter Name="Original_invMeasure" Type="String" />
                        <asp:Parameter Name="Original_invPrice" Type="Decimal" />
                        <asp:Parameter Name="Original_productID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="invQuantity" Type="Int32" />
                        <asp:Parameter Name="invSize" Type="Decimal" />
                        <asp:Parameter Name="invMeasure" Type="String" />
                        <asp:Parameter Name="invPrice" Type="Decimal" />
                        <asp:Parameter Name="productID" Type="Int32" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="invQuantity" Type="Int32" />
                        <asp:Parameter Name="invSize" Type="Decimal" />
                        <asp:Parameter Name="invMeasure" Type="String" />
                        <asp:Parameter Name="invPrice" Type="Decimal" />
                        <asp:Parameter Name="productID" Type="Int32" />
                        <asp:Parameter Name="Original_id" Type="Int32" />
                        <asp:Parameter Name="Original_invQuantity" Type="Int32" />
                        <asp:Parameter Name="Original_invSize" Type="Decimal" />
                        <asp:Parameter Name="Original_invMeasure" Type="String" />
                        <asp:Parameter Name="Original_invPrice" Type="Decimal" />
                        <asp:Parameter Name="Original_productID" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsProduct" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.InventoryDataSetTableAdapters.ProductTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id" Type="Int32" />
                        <asp:Parameter Name="Original_prodName" Type="String" />
                        <asp:Parameter Name="Original_prodDescription" Type="String" />
                        <asp:Parameter Name="Original_prodBrand" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="prodName" Type="String" />
                        <asp:Parameter Name="prodDescription" Type="String" />
                        <asp:Parameter Name="prodBrand" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="prodName" Type="String" />
                        <asp:Parameter Name="prodDescription" Type="String" />
                        <asp:Parameter Name="prodBrand" Type="String" />
                        <asp:Parameter Name="Original_id" Type="Int32" />
                        <asp:Parameter Name="Original_prodName" Type="String" />
                        <asp:Parameter Name="Original_prodDescription" Type="String" />
                        <asp:Parameter Name="Original_prodBrand" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsInvLookUp" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.InventoryDataSetTableAdapters.InventoryLookUpTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        </div>
    </form>
</body>
</html>

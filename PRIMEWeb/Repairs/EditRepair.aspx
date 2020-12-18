<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRepair.aspx.cs" Inherits="PRIMEWeb.Repairs.EditRepair" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Edit Repair</title>
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
            font-size: 13px;
            margin-top: 4px;
            margin-right: 5px;
            width: 95%;
        }

        .validation-child {
            margin-top: 10px;
            font-size: 12px;
            color: red;
            margin-bottom: 10px;
        }
        /*BODY TAG*/
.body-high {
    background-color: #B5B5B5;
    color:#000000;
}

/*NAVIGATION  CONTAINER*/
.nav-high{
    border-bottom: solid 1.5px #000;
}

.border-high {
    border: solid 1.5px #000;
}

.table-high {
    border: solid 1.5px #000;
}


/*INFO and DELETE*/
.btn-danger-high {
    color: #fff;
    background-color: #AE191B;
    border-color: #AE191B;
}

.btn-info-high {
    color: #fff;
    background-color: #6E1EE6;
    border-color: #6E1EE6;
}



/*SEARCH and FILTER*/
#btnSearch, #btnFilter {
    color: #fff;
    background-color: #1B6AFE;
    border-color: #1B6AFE;
}

#btnSearch:hover, #btnFilter:hover {
    color: #fff;
    background-color: #0152E9;
    border-color: #0152E9;
}

#btnSearch.btn-search-high, #btnFilter.btn-search-high  {
    color: #fff;
    background-color: #014BD5;
    border-color: #014BD5;
}

#btnSearch.btn-search-high:hover, #btnFilter.btn-search-high:hover {
    color: #fff;
    background-color: #012F84;
    border-color: #012F84;
}


/*CLEAR button*/
#btnClear, .btn-dependent-page {
    color: #fff;
    background-color: #F07000;
    border-color: #F07000;
}

#btnClear:hover, .btn-dependent-page:hover {
    color: #fff;
    background-color: #D16200;
    border-color: #D16200;
}

#btnClear.btn-clear-high, .btn-dependent-page.btn-dependent-high {
    color: #fff;
    background-color: #BD5800;
    border-color: #BD5800;
}

#btnClear.btn-clear-high:hover, .btn-dependent-page.btn-dependent-high:hover {
    color: #fff;
    background-color: #7A3900;
    border-color: #7A3900;
}

/*CREATE BUTTON*/
#btnCreate, #btnModify {
    color: #fff;
    background-color: #777718;
    border-color: #777718;
}

#btnCreate:hover, #btnModify:hover {
    color: #fff;
    background-color: #656515;
    border-color: #656515;
}

#btnCreate.btn-create-high, #btnModify.btn-create-high {
    color: #fff;
    background-color: #5C5B05;
    border-color: #5C5B05;
}

#btnCreate.btn-create-high:hover, #btnModify.btn-create-high:hover {
    color: #fff;
    background-color: #3C3C07;
    border-color: #3C3C07;
}

/*LOGOUT BUTTON*/
#btnLogout.btn-logout-high {
    color: #fff;
    background-color: #DC3545;
    border-color: #DC3545;
}

#btnLogout.btn-logout-high:hover {
    color: #fff;
    background-color: #C72334;
    border-color: #C72334;
}
    </style>
    <script>
        function SwitchCss(element) {
            var btnDangers = document.getElementsByClassName("btn-danger");
            var btnInfos = document.getElementsByClassName("btn-info");
            var btnInfos = document.getElementsByClassName("btn-info");
            var btnSearch = document.getElementById("btnSearch");
            var btnFilter = document.getElementById("btnFilter");
            var btnCreate = document.getElementById("btnCreate");
            var btnClear = document.getElementById("btnClear");
            var btnLogOut = document.getElementById("btnLogout");
            var btnDependents = document.getElementsByClassName("btn btn-secondary btn-dependent-page");
            var body = document.getElementsByTagName("body");
            var navigation = document.getElementsByTagName("nav");
            var ol = document.getElementsByTagName("ol");
            var container = document.getElementsByClassName("container");
            var table = document.getElementsByClassName("table");

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
                btnCreate.classList.add("btn-create-high");
                btnClear.classList.add("btn-clear-high");

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
                btnCreate.classList.remove("btn-create-high");
                btnClear.classList.remove("btn-clear-high");

            }
        }
    </script> 
    <script src="/Script/jquery-3.5.1.min.js"></script>
    <script src="/Script/bootstrap.min.js"></script>
</head>
<body>
    <form id="frmNewRepair" runat="server" class="was-validated">
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
                    <li class="breadcrumb-item active" aria-current="page">Create New Repair</li>
                </ol>
            </div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-danger rounded-pill" OnClick="btnLogout_Click" />
        </nav>
        <div class="container rounded-lg row justify-content-sm-center">
            <div id="wrapper-inner" class="col-lg-9">
                <h1>Edit Repair</h1>
                <div class="form-group form-control form-check form-check-inline">
                    &nbsp;
                    <input type="checkbox" onclick="SwitchCss(this)" class="form-check-input" id="chbSwitch" name="cnbSwitch" />
                    <label class="form-check-label" for="cnbSwitch">Check this to switch to high contrast design</label>
                    &nbsp;&nbsp;|&nbsp;&nbsp;
                    <asp:CheckBox ID="cboHelp" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="cboHelp_CheckedChanged" />
                    <label class="form-check-label" for="cboHelp">Check this to display detailed instruction on this form</label>
                </div>
                <strong>
                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green" ViewStateMode="Disabled" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <br />
                </strong>

                <div class="form-row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Issue:</label>

                            <div class="flex-box">

                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtIssue" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Issue for this repair..." required="required" ToolTip="issue"></asp:TextBox>
                                    <div class="invalid-feedback">Please enter the issue</div>
                                </div>
                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblIssueVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <asp:Label ID="lblIssueHelp" runat="server" Text="Input the Issues of the equipment (Eg. oil change)." CssClass="help-text" Visible="False"></asp:Label>

                        </div>
                        <div class="form-group">

                            <label class="control-label">Equipment:</label>
                            <div class="flex-box">
                                <div style="width: 100%;">
                                    <asp:DropDownList ID="ddlEquipment" runat="server" CssClass="custom-select" DataSourceID="Equipment" DataTextField="Equipment Type" DataValueField="id" ToolTip="Equipment">
                                        <asp:ListItem>Select a Equipment...</asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="invalid-feedback">Please select a equipment</div>
                                </div>

                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblEquipmentVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <asp:Label ID="lblEquipmentHelp" runat="server" Text="Select an equipment type for repair." CssClass="help-text" Visible="False"></asp:Label>



                        </div>
                        <div class="form-group">
                            <label class="control-label">Warranty Status:</label>
                            <div class="flex-box">

                                <div class="form-control form-check form-check-inline">
                                    <asp:RadioButton ID="radInWarranty" runat="server" CssClass="form-check-input" value="true" GroupName="radStatus" ToolTip="In warranty" />
                                    <label class="form-check-label" for="radInWarranty" id="lblInWarranty">In Warranty</label>
                                    <asp:RadioButton ID="radNoWarranty" runat="server" CssClass="form-check-input" value="false" GroupName="radStatus" required="required" ToolTip="Not in warranty" />
                                    <label class="form-check-label" for="radNoWarranty">Not In Warranty</label>
                                </div>

                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblrWarrantyVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <asp:Label ID="lblWarrantyHelp" runat="server" Text="Select if the equipment is in warranty." CssClass="help-text" Visible="False"></asp:Label>



                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Receipt:</label>

                            <div class="flex-box">
                                <div style="width: 100%;">
                                    <asp:DropDownList ID="ddlReceipt" runat="server" CssClass="custom-select" DataSourceID="Reciept" DataTextField="ordNumber" DataValueField="id" ToolTip="Reciept">
                                        <asp:ListItem>Select a Receipt...</asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="invalid-feedback">Please select a reciept</div>

                                </div>
                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblRecieotVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <asp:Label ID="lblRecieptHelp" runat="server" Text="select a Reciept related to this repair." CssClass="help-text" Visible="False"></asp:Label>
                        </div>


                        <div class="form-group">
                            <label class="control-label">Service:</label>


                            <div class="flex-box">
                                <div style="width: 100%;">
                                    <asp:DropDownList ID="ddlService" runat="server" CssClass="custom-select" DataSourceID="Service" DataTextField="serName" DataValueField="id" ToolTip="Service">
                                        <asp:ListItem>Select a Service...</asp:ListItem>
                                    </asp:DropDownList>

                                    <div class="invalid-feedback">Please select a service</div>
                                </div>

                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblServiceVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <asp:Label ID="lblServiceHelp" runat="server" Text="Select the service required." CssClass="help-text" Visible="False"></asp:Label>


                        </div>

                        <div class="form-group">
                            <label class="control-label">Employee:</label>
                            <div class="flex-box">
                                <div style="width: 100%;">
                                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="custom-select" DataSourceID="Employee" DataTextField="Employee Full Name" DataValueField="id" ToolTip="Employee">
                                        <asp:ListItem>Select an Employee...</asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="invalid-feedback">Please select a employee</div>
                                </div>

                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblEmployeeval" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <asp:Label ID="lblEmployeeHelp" runat="server" Text="Select the Employee who is creating the repair ." CssClass="help-text" Visible="False"></asp:Label>




                        </div>

                    </div>
                </div>
            </div>
            <div class="form-row">
                <asp:Panel ID="pnlBtnRepairs" CssClass="col-md-12" runat="server">
                    <asp:Button ID="btnCreate" runat="server" aria-label="Create Repair" CssClass="btn btn-success" Text="Save" OnClick="btnCreate_Click" ToolTip="Create repair" Width="100px" OnClientClick="return confirm('Are you sure you want to edit this record ?');" />
                    <input id="btnClear" class="btn btn-secondary" type="reset" value="Clear Form" aria-label="Clear Form" width="100px" />
                    <a class="btn btn-danger" href="/Repairs/" role="button" aria-label="Cancel Creating Sale" style="width: 100px;">Cancel</a>
                    <br />
                </asp:Panel>
                <br />
                <asp:ObjectDataSource ID="Service" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.RepairsDataSetTableAdapters.serviceTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id" Type="Int32" />
                        <asp:Parameter Name="Original_serName" Type="String" />
                        <asp:Parameter Name="Original_serDescription" Type="String" />
                        <asp:Parameter Name="Original_serPrice" Type="Decimal" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="serName" Type="String" />
                        <asp:Parameter Name="serDescription" Type="String" />
                        <asp:Parameter Name="serPrice" Type="Decimal" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="serName" Type="String" />
                        <asp:Parameter Name="serDescription" Type="String" />
                        <asp:Parameter Name="serPrice" Type="Decimal" />
                        <asp:Parameter Name="Original_id" Type="Int32" />
                        <asp:Parameter Name="Original_serName" Type="String" />
                        <asp:Parameter Name="Original_serDescription" Type="String" />
                        <asp:Parameter Name="Original_serPrice" Type="Decimal" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="Reciept" runat="server" DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.RepairsDataSetTableAdapters.OrderLookUpTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id" Type="Int32" />
                        <asp:Parameter Name="Original_ordNumber" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ordNumber" Type="String" />
                        <asp:Parameter Name="Original_id" Type="Int32" />
                        <asp:Parameter Name="Original_ordNumber" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="Customer" runat="server" DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.RepairsDataSetTableAdapters.CustomerLookUpTableAdapter">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="Employee" runat="server" DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.RepairsDataSetTableAdapters.EmployeeLookUpTableAdapter">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_id" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="Equipment" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PRIMELibrary.RepairsDataSetTableAdapters.EquipmentLookUpTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
    </form>

</body>
</html>

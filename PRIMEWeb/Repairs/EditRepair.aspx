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
            color: #5bc8de;
            font-size: 12px;
            margin-top: 4px;
            margin-right: 5px;
            width: 95%;
        }
        
        .validation-child {
            margin-top: 10px;
            font-size: 12px;
            color: red;
        }
    </style>
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
                <h1>Edit Repair</h1>

                <%-- <div class="form-group form-control form-check form-check-inline">
                    <asp:CheckBox ID="cboHelp" runat="server" CssClass="form-check-input" AutoPostBack="True" OnCheckedChanged="cboHelp_CheckedChanged" />
                    <label class="form-check-label" for="cboHelp">Check this to display detailed instruction on this form.</label>
                </div>--%>
                <strong>
                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Green" ViewStateMode="Disabled" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <br />
                </strong>

                <div class="form-row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Date In:</label>


                            <div class="flex-box">
                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtDateIn" runat="server" CssClass="form-control" TextMode="Date" required="required" ToolTip="Date in"></asp:TextBox>
                                    <div class="invalid-feedback">Please select a date In</div>
                                </div>
                                <div>
                                    <img id="DateInImg" src="images/question.png" alt="Question mark" />

                                </div>
                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblDateInVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <div style="visibility: hidden" class="help-text" id="lblDateIn">
                                <p>Input the Date equipment came into store (Eg. 12/12/2020)</p>
                            </div>





                        </div>
                        <div class="form-group">
                            <label class="control-label">Date Out:</label>



                            <div class="flex-box">
                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtDateOut" runat="server" CssClass="form-control" TextMode="Date" required="required" ToolTip="Date out"></asp:TextBox>

                                    <div class="invalid-feedback">Please select a date out</div>
                                </div>
                                <div>
                                    <img id="DateOutImg" src="images/question.png" alt="Question mark" />

                                </div>
                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblDateOutVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <div style="visibility: hidden" class="help-text" id="lblDateOut">
                                <p>Input the Date equipment went out of store (Eg:12/12/2020)</p>
                            </div>



                        </div>
                        <div class="form-group">
                            <label class="control-label">Issue:</label>

                            <div class="flex-box">
                                <div style="width: 100%;">
                                    <asp:TextBox ID="txtIssue" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Issue for this repair..." required="required" ToolTip="issue"></asp:TextBox>


                                    <div class="invalid-feedback">Please enter the issue</div>
                                </div>
                                <div>
                                    <img style="margin-top: 8px;" id="IssueImg" src="images/question.png" alt="Question mark" />


                                </div>
                            </div>
                              <div class="validation-child">
                                <asp:Label ID="lblIssueVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <div style="visibility: hidden" class="help-text" id="lblIssue">
                                <p>Input the issue of the equipment (Eg. oil change)</p>
                            </div>



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
                                <div>
                                    <img id="WarrantyImg" src="images/question.png" alt="Question mark" />

                                </div>
                            </div>
                            <div style="visibility: hidden" class="help-text" id="lblWarranty">
                                <p>Select if the equipment is in warranty</p>
                            </div>


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
                                <div>
                                    <img id="RecieptImg" src="images/question.png" alt="Question mark" />
                                </div>
                            </div>
                            <div class="validation-child">
                                <asp:Label ID="lblRecieotVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <div style="visibility: hidden" class="help-text" id="lblRecipet">
                                <p>Select the Reciept Number (Eg: 1)</p>
                            </div>




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
                                <div>
                                    <img id="ServiceImg" src="images/question.png" alt="Question mark" />

                                </div>
                            </div>
                              <div class="validation-child">
                                <asp:Label ID="lblServiceVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <div style="visibility: hidden" class="help-text" id="lblService">
                                <p>Select a service (Eg. oil change)</p>
                            </div>

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
                                <div>
                                    <img id="EquipmentImg" src="images/question.png" alt="Question mark" />
                                </div>
                            </div>
                             <div class="validation-child">
                                <asp:Label ID="lblEquipmentVal" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <div style="visibility: hidden" class="help-text" id="lblEquipment">
                                <p>Select an Equipment (Eg: lawn Mower)</p>
                            </div>

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
                                <div>
                                    <img id="EmployeeImg" src="images/question.png" alt="Question mark" />

                                </div>
                            </div>
                             <div class="validation-child">
                                <asp:Label ID="lblEmployeeval" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <div style="visibility: hidden" class="help-text" id="lblEmployee">
                                <p>Select an Employee (Eg: Sarah Kendell)</p>
                            </div>



                        </div>

                    </div>
                </div>
            </div>
            <div class="form-row">
                <asp:Panel ID="pnlBtnRepairs" CssClass="col-md-12" runat="server">
                    <asp:Button ID="btnCreate" runat="server" aria-label="Create Repair" CssClass="btn btn-success" Text="Save" OnClick="btnCreate_Click" ToolTip="Create repair" Width="100px" OnClientClick="return confirm('Are you sure you want to edit this record ?');" />
                    <input class="btn btn-secondary" type="reset" value="Clear Form" aria-label="Clear Form" width="100px" />
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
    <script src="/Script/help_text.js"></script>

</body>
</html>

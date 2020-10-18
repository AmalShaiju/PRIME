<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PRIMEWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PRIME - Login</title>
    <link href="CSS/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        body {
            background-color: #e0e0e0;
        }

        #wrapper-out {
            text-align: center;
        }

        @media (max-width: 991px) {
            #wrapper-out {
                padding: 0 20vw;
            }
        }

        #wrapper-in {
            height: 100vh;
        }

        #title {
            margin-bottom: 2rem;
        }

        .form-group {
            margin-bottom: 2rem;
        }

        .form-control {
            background: transparent;
            border: none;
            border-bottom: 2px solid #6c757d;
            -webkit-box-shadow: none;
            box-shadow: none;
            border-radius: 0;
            height: 45px;
        }

        .form-control:focus {
            box-shadow: none;
        }

        #btnLogin {
            background-image: linear-gradient(to right, #25cefd, #6385fd, #786bfe, #b625ff);
            border: 2px solid #fff;
            margin-top: 2rem;
            padding: 10px 95px 12px 95px;
        }

        #btnLogin:hover {
            background-image: linear-gradient(to right, #05beed, #4375ed, #585bee, #9615ef);
        }

        #frmLogin {
            background-color: #fff;
            box-shadow: 2px 2px 10px 3px #a8a8a8;
            padding: 8vh 3vw;
        }
    </style>
</head>
<body>
    <div id="wrapper-out" class="container">
        <div id="wrapper-in" class="row align-items-center justify-content-sm-center">
            <form id="frmLogin" runat="server" class="col-lg-4 rounded-lg">
                <h1 id="title">Welcome</h1>
                <div class="form-group">
                    <asp:TextBox ID="txtUser" runat="server" placeholder="Username" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPass" runat="server" placeholder="Password" required="required" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary rounded-pill" Text="LOGIN" PostBackUrl="~/Landing.aspx" />
            </form>
        </div>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alkatrészek.aspx.cs" Inherits="Alkatrészek" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <style type="text/css">
        .auto-style1 {
            left: -1px;
            top: -2px;
        }
        .btnh:hover{
            background-color:yellow;
        }
        .btnh{
            background-color:white;
        }
        .col{
            text-align:center;
        }
        .tbox{
            width:100%;
        }
    </style>
</head>
<body style="background-color: lightgray">
    <form id="form1" runat="server">
       <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="Default.aspx">Garázs</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="Alkatrészek.aspx">Alkatrészek</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Termékek.aspx">Termékek</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Összeszerelő.aspx">Összeszerelő</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container">
            <div class="row">
                <div class="col" style="text-align:center; padding-top:4vh">
                    Alkatrész lista
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <asp:Label ID="ErrorLabel" runat="server" Text="" Visible="false" Class="alert alert-danger"></asp:Label>
            </div>
        </div>
        <br />
        <div class="container" style="padding-bottom:2vh">
            <asp:Button class="btnh" ID="btnHozzáad" runat="server" Text="Hozzáad" OnClick="btnHozzáad_Click" />
            <asp:Button class="btnh" ID="btnMódosít" runat="server" Text="Módosít" OnClick="btnMódosít_Click" />
            <asp:Button class="btnh" ID="btnTöröl" runat="server" Text="Töröl" OnClick="btnTöröl_Click" />
        </div>
        <div class="container" style="padding-bottom:1vh">
                <div class="row">
                    <div class="col"><asp:TextBox class="tbox" placeholder="ID" ID="IDbev" value="" runat="server"></asp:TextBox></div>
                    <div class="col"><asp:TextBox class="tbox" placeholder="Megnevezés" ID="Megnevezésbev" runat="server"></asp:TextBox></div>
                    <div class="col"><asp:TextBox class="tbox" placeholder="Súly" ID="Súlybev" runat="server"></asp:TextBox></div>
                    <div class="col"><asp:TextBox class="tbox" placeholder="Ár" ID="Árbev" runat="server"></asp:TextBox></div>
                </div>
        </div>
        <div class="container">
            <asp:Table border=1 ID="Table1" class="table table-dark table-sm" runat="server">
                <asp:TableRow>
                    <asp:TableCell>ID</asp:TableCell>
                    <asp:TableCell>Megnevezés</asp:TableCell>
                    <asp:TableCell>Súly</asp:TableCell>
                    <asp:TableCell>Ár</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js" integrity="sha384-7+zCNj/IqJ95wo16oMtfsKbZ9ccEh31eOz1HGyDuCQ6wgnyJNSYdrPa03rtR1zdB" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js" integrity="sha384-QJHtvGhmr9XOIpI6YVutG+2QOK9T+ZnN4kzFN1RtK3zEFEIsxhlmWl5/YESvpZ13" crossorigin="anonymous"></script>
    </form>
</body>
</html>

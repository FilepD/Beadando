<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Összeszerelő.aspx.cs" Inherits="Összeszerelő" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
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
        <br />
        <div class="container">
            <div class="row">
                <asp:Label ID="ErrorLabel" runat="server" Text="" Visible="false" Class="alert alert-danger"></asp:Label>
            </div>
        </div>
        <br />

        <div class="container">
            <div class="row">
                <div class="col-2">Termékek</div>
                <div class="col-2">Alkatrészek</div>
                <div class="col-2">Mennyiség</div>
                <%--<div class="col">Gomb</div>--%>
            </div>
            <div class="row">
                <div class="col-2">
                    <asp:DropDownList ID="TermékLista" runat="server" OnSelectedIndexChanged="TermékLista_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-2">
                    <asp:DropDownList ID="AlkatrészLista" runat="server" OnSelectedIndexChanged="AlkatrészLista_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="TbAlkatrészMennyiség" Placeholder="Mennyit adsz hozzá?" TextMode="Number" min="1" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button ID="BtnEllenőrzés" runat="server" Text="Hozzáad" OnClick="BtnEllenőrzés_Click" />
                </div>
                <div class="col">
                    <asp:TextBox ID="törölID" placeholder="ID" TextMode="Number" min="1" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button ID="idtörl" runat="server" Text="Törlés" OnClick="idtörl_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <asp:Table border="1" ID="Table1" class="table table-dark table-sm" runat="server">
                <asp:TableRow>
                    <asp:TableCell>ID</asp:TableCell>
                    <asp:TableCell>Termék id</asp:TableCell>
                    <asp:TableCell>Alkatrész id</asp:TableCell>
                    <asp:TableCell>Mennyiség</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js" integrity="sha384-7+zCNj/IqJ95wo16oMtfsKbZ9ccEh31eOz1HGyDuCQ6wgnyJNSYdrPa03rtR1zdB" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js" integrity="sha384-QJHtvGhmr9XOIpI6YVutG+2QOK9T+ZnN4kzFN1RtK3zEFEIsxhlmWl5/YESvpZ13" crossorigin="anonymous"></script>
</body>
</html>

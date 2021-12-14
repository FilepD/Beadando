<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <title></title>
</head>
<body style="background-color:lightgray">
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
        <div class="container" style="height:100%">
            <div class="row align-items-center">
                <div class="col" style="font-size: 5vw;text-align: center">
                    <b>Üdvözöllek a Garázsban!</b>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

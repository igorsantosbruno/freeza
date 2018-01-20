<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="layout.aspx.cs" Inherits="ProjetoDefinitivo.layout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="padroes.css" rel="stylesheet" />
    <link href="css/animate.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/light-bootstrap-dashboard.css" rel="stylesheet" />
    <link href="css/pe-icon-7-stroke.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <script src="js/bootstrap-notify.js"></script>
    <script src="js/bootstrap-select.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/chartist.min.js"></script>
    <script src="js/jquery.3.2.1.min.js"></script>
    <script src="js/light-bootstrap-dashboard.js"></script>

    <form id="form1" runat="server">
        <div>
            <div class="wrapper">
    <div class="sidebar" data-color="purple" data-image="assets/img/sidebar-5.jpg">
  

    	<div class="sidebar-wrapper">
            <div class="logo">
                <img id="imagem" src="img/índice.jpg"  />
                <a href="#" class="simple-text">
                    Freeza
                </a>
            </div>

            <ul class="nav">
                <li class="active">
                    <a href="dashboard.html">
                        <i class="pe-7s-graph"></i>
                        <p>Menu</p>
                    </a>
                </li>

            </ul>
    	</div>
    </div>

    <div class="main-panel">
        <nav class="navbar navbar-default navbar-fixed">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">Dashboard</a>
                </div>
                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-left">
                        <li>
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <i class="fa fa-dashboard"></i>
                            </a>
                        </li>
                    </ul>

                    <ul class="nav navbar-nav navbar-right">
                        <li>
                           <a href="">
                               Deslogar
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>


        <div class="content">
            <div class="container-fluid">
                <div class="row">

                </div>
            </div>
        </div>


        <footer class="footer">
            <div class="container-fluid">
                <nav class="pull-left">
                    <ul>
                        <li>
                            <a href="#">
                                www.freeza.com.br
                            </a>
                        </li>

                    </ul>
                </nav>
              
            </div>
        </footer>

    </div>
</div>

        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="ProjetoDefinitivo.menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   <script language="Javascript">
        window.onload = function () {
            setTimeout('location.reload();', 5000);
        }  
    </script> 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="icon" type="image/png" href="img/LogoRoxoEscuro.png" />
     <link href="padroes.css" rel="stylesheet" />
    <link href="css/animate.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min-teste.css" rel="stylesheet" />
    <link href="css/light-bootstrap-dashboard.css" rel="stylesheet" />
    <link href="css/pe-icon-7-stroke.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/default.css">
    <title>menu freeza</title>
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
               <img id="imagem" src="img/LogoRoxoEscuro.png"  />
<%--                <a href="#" class="simple-text">
                    Olá, Eduardo
                </a>--%>
                <asp:Label CssClass="simple-text" ID="usuarioLogado" Text="" runat="server"></asp:Label>
            </div>

            <ul class="nav">
                <li class="active">
                    <a href="menu.aspx">                
                        <p>Home</p>
                    </a>
                </li>
                <li>
                    <asp:HyperLink ForeColor="white" ID="linkGerenciamentoUsuario" NavigateUrl="usuario.aspx" Text="USUÁRIOS" runat="server">
                        <p>USUÁRIOS</p>
                    </asp:HyperLink>
                </li>
              <li>
                     
                    <a href="Historico.aspx">                     
                        <p>Historico</p>
                    </a>
                </li>
            
                <li>
                    <a href="Perfil.aspx">                     
                        <p>Perfil</p>
                    </a>
                </li>
            </ul>
    	</div>
    </div>

    <div class="main-panel">
        <nav class="navbar navbar-default navbar-fixed">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navigation-example-2">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#"></a><br/>
                </div>
                <div class="collapse navbar-collapse">
           

                    <ul class="nav navbar-nav navbar-right">
                                                    
                       <li>
                            <asp:Button CssClass="btn-sair"  id="testedeslogar" OnClick="Logout_Click" runat="server" Text="Sair"></asp:Button>
                        </li> 
						<li class="separator hidden-lg"></li>
                    </ul>
                </div>
            </div>
        </nav>


        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-4">
                        <div class="card">

                            <div class="header">
                                <h4 class="title" id="teste11">Temperatura</h4>
                               
                            </div>
                            <div class="content">
                                <div id="chartPreferences" class="ct-chart ct-perfect-fourth"></div>
                                <asp:Label ID="lblTemperatura" CssClass="mano1" Font-Size="100px"  runat="server"></asp:Label><br/>
                                <center><asp:Label ID="lblAtencao" runat="server" Text="" Font-Size="30px"></asp:Label></center>
                                <center><asp:Label ID="lblInfo" runat="server"></asp:Label></center>
                                <div class="footer">                                 
                                    <hr>
                                    <div class="stats">
                                        <i id="teste22" class="fa fa-clock-o"></i> 
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
        
                                <div class="footer">
                                    <hr>
                                    
                                </div>
                            </div>
                  
        </div>


        <footer class="footer">
            <div class="container-fluid">
                <nav class="pull-left">
                    <ul>
                        <li>
                            <a href="#">
                                wwww.GrupoFreeza.com.br
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

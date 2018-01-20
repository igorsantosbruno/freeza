﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ProjetoDefinitivo.Perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="icon" type="image/png" href="img/LogoRoxoEscuro.png" />
    <link href="padroes.css" rel="stylesheet" />
    <link href="css/animate.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/light-bootstrap-dashboard.css" rel="stylesheet" />
    <link href="css/pe-icon-7-stroke.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/default.css">
    <title>perfil freeza</title>
</head>
<body>
    <script src="js/bootstrap-notify.js"></script>
    <script src="js/bootstrap-select.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/chartist.min.js"></script>
    <script src="js/jquery.3.2.1.min.js"></script>
    <script src="js/light-bootstrap-dashboard.js"></script>

<form runat="server">
       <div class="wrapper">
    <div class="sidebar" data-color="purple" data-image="assets/img/sidebar-5.jpg">

    	<div class="sidebar-wrapper">
            <div class="logo">
               <img id="imagem" src="img/LogoRoxoEscuro.png"  />
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
                    <a class="navbar-brand" href="#"></a>
                </div>
                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-left">
                        <li>
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <i class="fa fa-dashboard"></i>
								<p class="hidden-lg hidden-md">Dashboard</p>
                            </a>
                        </li>
                        <li class="dropdown">
                              <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    <i class="fa fa-globe"></i>
                                    <b class="caret hidden-lg hidden-md"></b>
									<p class="hidden-lg hidden-md">
										5 Notifications
										<b class="caret"></b>
									</p>
                              </a>
                            
                        </li>
                        <li>
                         
                        </li>
                    </ul>

                    <ul class="nav navbar-nav navbar-right">
                                                                 
                       <li>
                            <asp:Button CssClass="btn-sair" OnClick="Logout_Click" runat="server" Text="Sair"></asp:Button>
                        </li>
						<li class="separator hidden-lg"></li>
                    </ul>
                </div>
            </div>
        </nav>
       <div class="content" />
                 <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-8">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Atualizar dados do perfil</h4>
                            </div>
                            <div class="content">
                                <form>
                                                <label for="txtBoxUsuario">Novo nome de usuário</label>
                                                <asp:TextBox ID="txtBoxUsuario" CssClass="data" runat="server" /><br/>
                                    <asp:Button ID="btnAtualizarNomeUsuario" CssClass="botao-cadastrar" Text="Atualizar nome usuário" OnClick="AtualizarNomeUsuario_Click" runat="server"/><br/><br/>
                                                <asp:Label CssClass="lbl-validacao" ID="lblValidacaoNomeUsuario" Text="" runat="server" />
                                            
                                               <br/><br/>
                                                <label for="txtBoxSenha">Nova Senha</label>
                                                <asp:TextBox ID="txtBoxSenha" TextMode="Password" CssClass="data" runat="server" /><br/>
                                            
                                                <label for="txtBoxConfirmarSenha">Confirmar senha</label>
                                                <asp:TextBox ID="txtBoxConfirmarSenha" TextMode="Password" CssClass="data" runat="server" /><br/>
                                    <asp:Button ID="btnAtualizarSenha" CssClass="botao-cadastrar" Text="Atualizar nova senha" OnClick="AtualizarSenhaUsuario_Click" runat="server"/><br/><br/>
                                    <asp:Label CssClass="lbl-validacao" ID="lblValidacaoSenha" Text="" runat="server"></asp:Label>
                                    <div class="clearfix"></div>
                                </form>
                            </div>
                        </div>
                    </div>
        </div>
      
    </div>
</div>
    </form>
</body>
</html>

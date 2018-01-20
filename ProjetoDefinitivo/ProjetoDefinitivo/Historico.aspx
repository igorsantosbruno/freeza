<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="ProjetoDefinitivo.Historico" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <link rel="icon" type="image/png" href="img/LogoRoxoEscuro.png" />
    <link href="padroes.css" rel="stylesheet" />
    <link href="padroes2.css" rel="stylesheet" />
    <link href="css/animate.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min-teste3.css" rel="stylesheet" />
    <link href="css/light-bootstrap-dashboard.test.css" rel="stylesheet" />
    <link href="css/pe-icon-7-stroke.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/default.css">

    <title>historico freeza</title>
</head>
<body>

    <script src="js/bootstrap-notify.js"></script>
    <script src="js/bootstrap-select.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/chartist.min.js"></script>
    <script src="js/jquery.3.2.1.min.js"></script>
    <script src="js/light-bootstrap-dashboard.js"></script>

<form Runat="Server">
<div>
           <div class="wrapper" />
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
                    <a class="navbar-brand" href="#"></a><br/>
                </div>
                <div class="collapse navbar-collapse">
           

                    <ul class="nav navbar-nav navbar-right">
                                                                 
                        <li>
                            <asp:Button CssClass="btn-sair" OnClick="Logout_Click" runat="server" Text="Sair"></asp:Button>
                        </li>
						<li class="separator hidden-lg"></li>
                    </ul>
                </div>
            </div>
        </nav>
        <!-- conteudo -->

          <div id="inner">
              <center><h4 class="text-muted"> Historico de Temperatura</h4></center>
              <div id="div-data">
                  <asp:TextBox CssClass="data" ID="txtBoxData" placeholder="Data de:" Text="" Runat="server"> </asp:TextBox><br/><br/>
                  <asp:TextBox CssClass="data" ID="txtBoxData2" placeholder="Data até:" Runat="server"> </asp:TextBox><br/><br/>
              </div>
              <div id="div-botao">
                  <asp:Button CssClass="botaoBuscarHistorico" Text="Buscar histórico"   OnClick="ConsultarHistorico_Click" runat="server"/>  
                  <asp:Button CssClass="botaoLimpar" Text="Limpar tela"  OnClick="LimparTela_Click" runat="server"/>
              </div>
          </div>
    
</form>

<asp:Label CssClass="lbl-erro" ID="lblErro" Text="" Font-Size="18px" runat="server"></asp:Label><br/>
    
  
      <!-- abaixo sem bossT -->

<div class="content table-responsive">                                           
<table class="table table-striped">
    <thead>
    <tr>
        <th><asp:Label Text="" ID="lblHistorico" runat="server"></asp:Label></th>
        <th><asp:Label Text="" ID="lblData" runat="server"></asp:Label></th>
    </tr>
    </thead>
    <tbody>
    <asp:Repeater runat="server" ID="listRepeaterHistorico">
        <ItemTemplate>
            <tr>
                <td><%#Eval("Temperatura") %><label class="text-muted">°C</label></td>
                <td><%#Eval("DataRegistro") %></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </tbody>
</table>
</div>


<br/><br/>
<center><asp:Label CssClass="texto" Text="" ID="lblMenorTemperatura" Font-Size="30px" runat="server"></asp:Label></center><br/><br/>
<center><asp:Label CssClass="texto" Text="" ID="lblMaiorTemperatura"  Font-Size="30px" runat="server"></asp:Label></center><br/><br/>
<center><asp:Label CssClass="texto" Text="" ID="lblMediaTemperatura" Font-Size="30px" runat="server"></asp:Label></center><br/><br/>
</body>
</html>

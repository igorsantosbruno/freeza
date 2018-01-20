<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="img/LogoRoxoEscuro.png" />
    <link href="padroes.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/estiloconta.css" rel="stylesheet" type="text/css" />
    <title>login freeza</title>
</head>
<body>
<div id="corpo">
    <form id="form2" runat="server">
                 
        <asp:TextBox ID="txtBoxUsuario" placeholder="Usúario" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtBoxSenha" TextMode="Password" placeholder="Senha" runat="server"></asp:TextBox>
        <asp:Button ID="botaologin"  OnClick="Logar_Click" runat="server" Text="Login" /><br/><br/>        
        <asp:Label ID="lblFalhaAutenticacao" Text="" runat="server"></asp:Label>
    </form>
   </div>
    <p>
    <img src="img/telaaa.png" id="logologin" /></p>
  
</body>
</html>


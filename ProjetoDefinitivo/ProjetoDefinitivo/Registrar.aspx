<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="WebApplication3.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/estiloregistro.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
<div id="corpo">
    <form id="form2" runat="server">
        <asp:TextBox ID="usuario" placeholder="Usúario" runat="server"></asp:TextBox>
        <asp:TextBox ID="senha" TextMode="Password" placeholder="Senha" runat="server"></asp:TextBox>
        <asp:TextBox ID="senhacheck"  placeholder="Confirme a senha" runat="server" CssClass="form" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="vldmessage" runat="server"></asp:Label>
        <br />
        <asp:Button ID="botaologin"  OnClick="Registrar_Click" runat="server" Text="Criar Conta" />                    
    </form>
</div>
</body>
</html>

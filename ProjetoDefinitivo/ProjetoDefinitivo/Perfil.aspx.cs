using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.App.Banco;
using WebApplication3.App.Model;

namespace ProjetoDefinitivo
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            HttpCookie cookie = Request.Cookies["usuarioLogado"];
            if (cookie == null) {
                Response.Redirect("Login.aspx");
                return;
            }
            
            HttpCookie cookieIdUsuario = Request.Cookies["idUsuario"];
            
            if (cookieIdUsuario.Value != "1")
            {
                
                HyperLink linkGerenciamentoUsuario = this.Page.FindControl("linkGerenciamentoUsuario") as HyperLink;
                linkGerenciamentoUsuario.Visible = false;
            }
        }
        
        protected void Logout_Click(object sender, EventArgs e)
        {
            
            HttpCookie cookie = new HttpCookie("usuarioLogado");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            HttpCookie cookie2 = new HttpCookie("idUsuario");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            Response.Redirect("Login.aspx");
        }
        
        private void limpar()
        {
            
            Label lblValidacao = this.Page.FindControl("lblValidacao") as Label;
            lblValidacao.Text = "";
            TextBox usuario = this.Page.FindControl("txtBoxUsuario") as TextBox;
            usuario.Text = "";
            TextBox senha = this.Page.FindControl("txtBoxSenha") as TextBox;
            senha.Text = "";
            TextBox senhacheck = this.Page.FindControl("txtBoxConfirmarSenha") as TextBox;
            senhacheck.Text = "";
        }
        
        protected void AtualizarNomeUsuario_Click(object sender, EventArgs e)
        {
            
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            TextBox txtBoxUsuario = this.Page.FindControl("txtBoxUsuario") as TextBox;

            if (txtBoxUsuario.Text == "")
            {
                
                Label lblValidacaoNomeUsuario = this.Page.FindControl("lblValidacaoNomeUsuario") as Label;
                lblValidacaoNomeUsuario.Text = "Preencha o campo!";
            }
            else if (!usuarioBanco.validarNomeUsuario(txtBoxUsuario.Text))
            {

                HttpCookie cookieIdUsuario = Request.Cookies["idUsuario"];
                int id = int.Parse(cookieIdUsuario.Value);
                usuarioBanco.atualizarNomeUsuario(txtBoxUsuario.Text, id);
                Label lblValidacaoNomeUsuario = this.Page.FindControl("lblValidacaoNomeUsuario") as Label;
                lblValidacaoNomeUsuario.Text = "Nome de usuário atualizado com sucesso!";
            }
            else
            {
                
                Label lblValidacaoNomeUsuario = this.Page.FindControl("lblValidacaoNomeUsuario") as Label;
                lblValidacaoNomeUsuario.Text = "Este nome de usuário já existe!";
            }
        }
        
        protected void AtualizarSenhaUsuario_Click(object sender, EventArgs e)
        {
            
            TextBox txtBoxSenha = this.Page.FindControl("txtBoxSenha") as TextBox;
            TextBox txtBoxConfirmarSenha = this.Page.FindControl("txtBoxConfirmarSenha") as TextBox;

            if (txtBoxSenha.Text == "" || txtBoxConfirmarSenha.Text == "")
            {
                
                Label lblValidacaoSenha = this.Page.FindControl("lblValidacaoSenha") as Label;
                lblValidacaoSenha.Text = "Preencha os campos";                
            }
            else if (txtBoxSenha.Text != txtBoxConfirmarSenha.Text)
            {

                Label lblValidacaoSenha = this.Page.FindControl("lblValidacaoSenha") as Label;
                lblValidacaoSenha.Text = "As senhas não conferem!";
            }
            else
            {
                
                HttpCookie cookieIdUsuario = Request.Cookies["idUsuario"];
                int id = int.Parse(cookieIdUsuario.Value);
                UsuarioBanco usuarioBanco = new UsuarioBanco();
                usuarioBanco.atualizarSenha(txtBoxSenha.Text, id);
                Label lblValidacaoSenha = this.Page.FindControl("lblValidacaoSenha") as Label;
                lblValidacaoSenha.Text = "Senha atualizada!";
            }
        }
    }
}
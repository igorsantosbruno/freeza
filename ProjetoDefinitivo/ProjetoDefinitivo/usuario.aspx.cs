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
    public partial class dispositivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["usuarioLogado"];
            HttpCookie cookie2 = Request.Cookies["idUsuario"];
            if (cookie == null) {
                Response.Redirect("Login.aspx");
                return;
            }else if (cookie2.Value != "1")
            {
                
                Response.Redirect("menu.aspx");
            }
            
            HttpCookie cookieIdUsuario = Request.Cookies["idUsuario"];
            
            if (cookieIdUsuario.Value != "1")
            {
                
                HyperLink linkGerenciamentoUsuario = this.Page.FindControl("linkGerenciamentoUsuario") as HyperLink;
                linkGerenciamentoUsuario.Visible = false;
            }
            
            Label usuarioLogado = this.Page.FindControl("usuarioLogado") as Label;
            usuarioLogado.Text = "Olá " + cookie.Value.ToUpper();
            atualizarLista();
        }
        
        private void atualizarLista()
        {
            
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            Repeater listRepeaterHistorico = this.FindControl("listRepeaterUsuario") as Repeater;
            List<Usuario> usuarios = usuarioBanco.buscarUsuario();
            usuarios.RemoveAt(0);
            listRepeaterHistorico.DataSource = usuarios;
            listRepeaterHistorico.DataBind();
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

        protected void CadastrarUsuario_Click(object sender, EventArgs e)
        {
            
            UsuarioBanco banco = new UsuarioBanco();
            TextBox usuario = this.Page.FindControl("txtBoxUsuario") as TextBox;
            TextBox senha = this.Page.FindControl("txtBoxSenha") as TextBox;
            TextBox senhacheck = this.Page.FindControl("txtBoxConfirmarSenha") as TextBox;
            if (usuario.Text == "" || senha.Text == "" || senhacheck.Text == "")
            {
                Label lblValidacao = this.Page.FindControl("lblValidacao") as Label;
                lblValidacao.Text = "Por favor preencha todos os campos!";
            }
            else if (senha.Text != senhacheck.Text) {
                Label lblValidacao = this.Page.FindControl("lblValidacao") as Label;
                lblValidacao.Text = "Senhas não conferem";
            }
            else if (!banco.inserir(usuario.Text, senha.Text))
            {

                Label lblValidacao = this.Page.FindControl("lblValidacao") as Label;
                lblValidacao.Text = "Usuário já existente.";

            }
            else
            {
                
                atualizarLista();
                limpar();
            }
        }
    }
}
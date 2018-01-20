using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.App.Banco;

//opa
namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            HttpCookie cookie = Request.Cookies["usuarioLogado"];
            if (cookie != null) {
                Response.Redirect("menu.aspx");
            }
        }

        protected void Logar_Click(object sender, EventArgs e)
        {
            String nomeUsuario = txtBoxUsuario.Text;        
            String senha = txtBoxSenha.Text;
            
            UsuarioBanco banco = new UsuarioBanco();
            string usuarioLogado = banco.validarLogin(nomeUsuario, senha);
            if (usuarioLogado != "")
            {
                
                HttpCookie cookieUsuarioLogado = new HttpCookie("usuarioLogado", usuarioLogado);
                cookieUsuarioLogado.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookieUsuarioLogado);
                HttpCookie cookieIdUsuario = new HttpCookie("idUsuario", banco.obterIdUsuario(usuarioLogado));
                cookieIdUsuario.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookieIdUsuario);
                Response.Redirect("menu.aspx");
            }
            else
            {
                Label lbl = Page.FindControl("lblFalhaAutenticacao") as Label;
                lbl.Text = "Usuário e/ou senha inválido(s)";
            }
        }
    }
}
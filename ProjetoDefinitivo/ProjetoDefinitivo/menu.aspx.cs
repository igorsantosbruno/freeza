using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.App.Banco;

namespace ProjetoDefinitivo
{
    public partial class menu : System.Web.UI.Page
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
            
            Label usuarioLogado = this.Page.FindControl("usuarioLogado") as Label;
            usuarioLogado.Text = "Olá " + cookie.Value.ToUpper();
            Label temperatura = this.Page.FindControl("lblTemperatura") as Label;
            DispositivoBanco dispositivoBanco = new DispositivoBanco();
            temperatura.Text = dispositivoBanco.obterTemperatura();
            String str = temperatura.Text.Replace("°","");
            int temperaturaInt = int.Parse(str);
            if (temperaturaInt < 2 || temperaturaInt > 8)
            {
                
                temperatura.ForeColor = Color.Crimson;
                Label lblInfo = this.Page.FindControl("lblInfo") as Label;
                lblInfo.Text = "A temperatura não está de acordo";
                lblInfo.ForeColor = Color.Crimson;
                Label lblAtencao = this.Page.FindControl("lblAtencao") as Label;
                lblAtencao.Text = "Atenção";
                lblAtencao.ForeColor = Color.Crimson;
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
 
    }
}
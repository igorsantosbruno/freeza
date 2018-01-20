using System;
using System.Web.UI.WebControls;
using WebApplication3.App.Banco;

namespace WebApplication3
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            
        }
        protected void Registrar_Click (object sender, EventArgs e)
        {
           
            UsuarioBanco banco = new UsuarioBanco();
            TextBox usuario = this.Page.FindControl("usuario") as TextBox;
            TextBox senha = this.Page.FindControl("senha") as TextBox;
            TextBox senhacheck = this.Page.FindControl("senhacheck") as TextBox;

            if (usuario.Text == "" || senha.Text == "" || senhacheck.Text == "")
            {
                Label vldmessage = this.Page.FindControl("vldmessage") as Label;
                vldmessage.Text = "Por favor preencha todos os campos!";
            }
            else if (senha.Text != senhacheck.Text) {
                Label vldmessage = this.Page.FindControl("vldmessage") as Label;
                vldmessage.Text = "Senhas não conferem";
            }
            else if (!banco.inserir(usuario.Text, senha.Text))
            {

                Label vldmessage = this.Page.FindControl("vldmessage") as Label;
                vldmessage.Text = "Usuário já existente.";

            }
            else
            {
                Session.Add("administrador", usuario.Text);
                Response.Redirect("menu.aspx");
            }

        }

    }
}
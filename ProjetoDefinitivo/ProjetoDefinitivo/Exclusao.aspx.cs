using System;
using WebApplication3.App.Banco;

namespace ProjetoDefinitivo
{
    public partial class Exclusao : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int id;
            if (!int.TryParse(Request.QueryString["id"], out id)) {
                
                return;
            }
            
            UsuarioBanco usuarioBanco = new UsuarioBanco();
            usuarioBanco.deletar(id);
            Response.Redirect("usuario.aspx");
        }
    }
}
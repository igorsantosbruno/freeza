using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebApplication3.App.Banco;
using WebApplication3.App.Model;

namespace ProjetoDefinitivo
{
    public partial class Historico : System.Web.UI.Page
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

        public void limparTela()
        {
            
            Repeater listRepeaterHistorico = this.FindControl("listRepeaterHistorico") as Repeater;
            listRepeaterHistorico.DataSource = null;
            listRepeaterHistorico.DataBind();
            Label lblHistorico = 
                this.FindControl("lblHistorico") as Label;
            lblHistorico.Text = "";
            Label lblMaiorTemperatura = 
                this.FindControl("lblMaiorTemperatura") as Label;
            lblMaiorTemperatura.Text = "";
            Label lblMenorTemperatura = 
                this.FindControl("lblMenorTemperatura") as Label;
            lblMenorTemperatura.Text = "";
            Label lblMediaTemperatura = 
                this.FindControl("lblMediaTemperatura") as Label;
            lblMediaTemperatura.Text = "";
            Label lblErro =
                this.FindControl("lblErro") as Label;
            Label lblData =
                this.FindControl("lblData") as Label;
            lblData.Text = "";
        }
        
        protected void LimparTela_Click(object sender, EventArgs e)
        {
            
            Repeater listRepeaterHistorico = this.FindControl("listRepeaterHistorico") as Repeater;
            listRepeaterHistorico.DataSource = null;
            listRepeaterHistorico.DataBind();
            Label lblHistorico = 
                this.FindControl("lblHistorico") as Label;
            lblHistorico.Text = "";
            Label lblMaiorTemperatura = 
                this.FindControl("lblMaiorTemperatura") as Label;
            lblMaiorTemperatura.Text = "";
            Label lblMenorTemperatura = 
                this.FindControl("lblMenorTemperatura") as Label;
            lblMenorTemperatura.Text = "";
            Label lblMediaTemperatura = 
                this.FindControl("lblMediaTemperatura") as Label;
            lblMediaTemperatura.Text = "";
            Label lblErro =
                this.FindControl("lblErro") as Label;
            lblErro.Text = "";
            TextBox txtBoxData =
                this.FindControl("txtBoxData") as TextBox;
            txtBoxData.Text = "";
            TextBox txtBoxData2 =
                this.FindControl("txtBoxData2") as TextBox;
            txtBoxData2.Text = "";
            Label lblData =
                this.FindControl("lblData") as Label;
            lblData.Text = "";
        }

        public int obterMaiorTemperatura(List<Arduino> listaTemperatura)
        {

            int maior = int.Parse(listaTemperatura[0].Temperatura);
            for (int i = 1; i < listaTemperatura.Count; i++)
            {

                int temperatura = int.Parse(listaTemperatura[i].Temperatura);
                if (maior < temperatura)
                {
                    maior = temperatura;
                }
            }
            return maior;
        }
        
        public int obterMenorTemperatura(List<Arduino> listaTemperatura)
        {

            int menor = int.Parse(listaTemperatura[0].Temperatura);
            for (int i = 1; i < listaTemperatura.Count; i++)
            {

                int temperatura = int.Parse(listaTemperatura[i].Temperatura);
                if (menor > temperatura)
                {
                    menor = temperatura;
                }
            }
            return menor;
        }

        public int obterMediaTemperatura(List<Arduino> listaTemperatura)
        {

            int media = 0;
            for (int i = 0; i < listaTemperatura.Count; i++)
            {

                media += int.Parse(listaTemperatura[i].Temperatura);
            }
            media /= listaTemperatura.Count;
            return media;
        }
        
        protected void ConsultarHistorico_Click(object sender, EventArgs e)
        {
            TextBox txtBoxData =
                this.FindControl("txtBoxData") as TextBox;
            TextBox txtBoxData2 =
                this.FindControl("txtBoxData2") as TextBox;
            string d1 = txtBoxData.Text;
            string d2 = txtBoxData2.Text;
            DateTime data1, data2;
            if(DateTime.TryParse(d1, 
                   System.Globalization.CultureInfo.GetCultureInfo("pt-br"), 
                   System.Globalization.DateTimeStyles.None, out data1) &&
               DateTime.TryParse(d2, 
                   System.Globalization.CultureInfo.GetCultureInfo("pt-br"), 
                   System.Globalization.DateTimeStyles.None, out data2))
            {

                if (data1 > data2)
                {
                     
                    Label lblErro =
                        this.FindControl("lblErro") as Label;
                    lblErro.Text = "Digite um intervalo válido";
                    limparTela();
                }
                else
                {
                    DispositivoBanco dispositivoBanco = new DispositivoBanco();
                    Repeater listRepeaterHistorico = this.FindControl("listRepeaterHistorico") as Repeater;
                    string strData = d1.Replace("/", "-");
                    string strData2 = d2.Replace("/", "-");
                    //25/11/2017
                    string dia = strData.Substring(0, 2);
                    string mes = strData.Substring(3, 3);
                    string ano = strData.Substring(5,5);
                    mes = mes.Replace("-", "");
                    ano = ano.Replace("-", "");
                    strData = ano + "-" + mes + "-" + dia;
                    dia = strData2.Substring(0, 2);
                    mes = strData2.Substring(3, 3);
                    ano = strData2.Substring(5,5);
                    mes = mes.Replace("-", "");
                    ano = ano.Replace("-", "");
                    strData2 = ano + "-" + mes + "-" + dia;
                    List<Arduino> listaHistorico = dispositivoBanco.consultarTemperaturaPorIntervalo(strData, strData2);
                    if (listaHistorico.Count > 0)
                    {
                        listRepeaterHistorico.DataSource = listaHistorico;
                        listRepeaterHistorico.DataBind();
                        Label lblHistorico =
                            this.FindControl("lblHistorico") as Label;
                        lblHistorico.Text = "Histórico:";
                        Label lblData =
                            this.FindControl("lblData") as Label;
                        lblData.Text = "Data registro:";
                        Label lblMaiorTemperatura =
                            this.FindControl("lblMaiorTemperatura") as Label;
                        lblMaiorTemperatura.Text = "Maior temperatura lida: "
                                                   + obterMaiorTemperatura(listaHistorico) + "°C";
                        Label lblMenorTemperatura =
                            this.FindControl("lblMenorTemperatura") as Label;
                        lblMenorTemperatura.Text = "Menor temperatura lida: "
                                                   + obterMenorTemperatura(listaHistorico) + "°C";
                        Label lblMediaTemperatura =
                            this.FindControl("lblMediaTemperatura") as Label;
                        lblMediaTemperatura.Text = "Media das temperaturas lidas: "
                                                   + obterMediaTemperatura(listaHistorico) + "°C";
                        Label lblErro =
                            this.FindControl("lblErro") as Label;
                        lblErro.Text = "";
                    }
                    else
                    {
                        
                        Label lblErro =
                            this.FindControl("lblErro") as Label;
                        lblErro.Text = "Sem resultado";
                    }
                }
            }
            else
            {
                
                Label lblErro =
                    this.FindControl("lblErro") as Label;
                lblErro.Text = "Data inválida";
                limparTela();
            }
        }
    }
}



















